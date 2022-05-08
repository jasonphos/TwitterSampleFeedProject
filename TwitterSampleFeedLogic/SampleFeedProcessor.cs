﻿using Jasonphos.SharedUtil.Data;
using System.Net;
using System.Net.Http.Headers;

namespace Jasonphos.TwitterSampleFeedLogic {
    public class SampleFeedProcessor {
        public SampleFeedAppData _ApplicationData { get; }
        private SemaphoreSlim _semaphoreSlimProcessing = null; //Could have additional semaphores for other tasks in the future, this one is specific to processing the stream.
        private HttpClient _httpClient;
        public SampleFeedProcessor(SampleFeedAppData appData) {
            _ApplicationData = appData;
            if(_semaphoreSlimProcessing == null) {
                _semaphoreSlimProcessing = new SemaphoreSlim(appData.ProcessorThreadCount);
            }
            _httpClient = new HttpClient(); //Todo: Use IHttpClientFactory instead, see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
        }

        public async Task StartFeedAsync(int threadId) {
            if (!_ApplicationData.IsStarted) { //Note: Currently, we have a single count for the max threads, but this code right here makes the assumption that all threads are started at roughly the same time, at the start. In reality, we should probably have 3: Min, Max and Current thread counts. This would allow us to scale up and down. This could be useful if we install into a single VM and want to scale that VM up. However, more likely we would architect this to support scaliing out, in which case the need to scale up with threads on this instance probably isn't anything to focus on. Still, it could be an option if we spent a lot of time optimizing this code.
                _ApplicationData.IsStarted = true;
                _ApplicationData.IsRunning = true;
            }
            
            while(_ApplicationData.IsRunning || _ApplicationData.Messages.Count > 0) {  //Todo: Use a Cancellation Token instead? Or, this may be good enough. I need to research Cancellation Tokens more}
                try {

                    await _semaphoreSlimProcessing.WaitAsync();

                    if (_ApplicationData.IsRunning)
                        await ReceiveSampleFeedAsync(_ApplicationData, threadId);

                    ProcessSampleFeed(_ApplicationData);

                } catch(Exception e) {
                    _ApplicationData.Config.Logger.LogException(e);
                } finally {
                    _semaphoreSlimProcessing.Release();
                }
            }

            
        }

        private void ProcessSampleFeed(SampleFeedAppData appData) {
            const int ExtraMessagesBufferCount = 1; //Technically, we don't have to process ProcessorBatchSize number of messages here. We could process more. For that reason, I'm going to introduce this constant that can be tweaked during testing. We could make this configurable, but for now it's in the research phase. I'm not certain we need a buffer, but we might. So, the plan is to do some development testing with this number as different values.
            for(int i = 0; i < appData.ProcessorBatchSize + ExtraMessagesBufferCount; i++) {
                if (appData.Messages.TryDequeue(out String? jsonMessage)) {
                    //We are processing a Tweet. Increment our counters and other appData stuff
                    appData.IncrementTweetsProcessedCount();
                    appData.LastReceivedDateTime  = DateTime.Now;
                } else {
                    break;
                }
            }
        }

        private async Task ReceiveSampleFeedAsync(SampleFeedAppData appData, int threadId) {
            int tried = 0;
            int requestCount = 0;

            while(tried < appData.MaxTwitterConnectionTries) {
                tried++;
                try {
                    appData.Config.Logger.LogInfo("Thread " + threadId + "In ReceiveTwitterStreamAsync trying to Connect Attempt: " + tried);
                    int recordsReceived = 0;

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, appData.TwitterSampleFeedEndpoint) {
                        Headers = { { "Authorization", "Bearer " + appData.BearerToken } }
                    };
                    
                    
                    //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded;charset=UTF-8");

                    try {
                        Task<HttpResponseMessage> result = _httpClient.SendAsync(request);
                        HttpResponseMessage response = await result;

                        requestCount++;
                        if(response.StatusCode == HttpStatusCode.OK) {
                            //stream opened!
                            appData.Config.Logger.LogInfo("Thread " + threadId + " Opened Stream!");
                            Stream stream = await response.Content.ReadAsStreamAsync();
                            using(StreamReader str = new StreamReader(stream)) {
                                // loop through each item in the Filtered Stream API
                                do {
                                    if(recordsReceived >= appData.ProcessorBatchSize) {
                                        break; //Not sure this is necessary, but just in case. I mean, what if batchsize is 0? Doesn't make sense, but still it would be a race condition...
                                    }
                                    String responseBodyAsText = await response.Content.ReadAsStringAsync();

                                    string json = str.ReadLine();

                                    if(!string.IsNullOrEmpty(json)) {
                                        // Add a message to be processed to the queue.
                                        appData.Messages.Enqueue(json);
                                        recordsReceived++;
                                    }
                                } while(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()
                                            && !str.EndOfStream && recordsReceived < appData.ProcessorBatchSize);
                            }
                            appData.Config.Logger.LogInfo("Thread " + threadId + "records received:" + recordsReceived);
                        } else {
                            appData.Config.Logger.LogInfo("Thread " + threadId + "response.StatusCode not HttpStatusCode.OK. Currently: " + response.StatusCode);
                        }
                    } catch(WebException ex) {
                        appData.Config.Logger.LogException(ex);

                    } catch(Exception ex) {
                        appData.Config.Logger.LogException(ex);
                    }
                } catch(Exception ex) {
                    if(tried < appData.MaxTwitterConnectionTries)
                        await Task.Delay(100);//Simple wait to retry connection logic. Todo: Enhance, i.e. increase time period as tries increases.
                    appData.Config.Logger.LogException(ex);
                }
            }
        }
    }
}