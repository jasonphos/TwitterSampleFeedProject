using Jasonphos.SharedUtil.Data;
using System.Net;
using System.Net.Http.Headers;

namespace Jasonphos.TwitterSampleFeedLogic {
    public class SampleFeedProcessor {
        public SampleFeedAppData _ApplicationData { get; }
        private SemaphoreSlim _semaphoreSlimReceive = null; //Could have additional semaphores for other tasks in the future, this one is specific to processing the stream.
        private SemaphoreSlim _semaphoreSlimProcess = null;
        private HttpClient _httpClient;

        private StreamReader? ConnectedStream = null;
        public SampleFeedProcessor(SampleFeedAppData appData) {
            _ApplicationData = appData;
            if(_semaphoreSlimReceive == null) {
                _semaphoreSlimReceive = new SemaphoreSlim(1); //Only one receive thread
            }
            if (_semaphoreSlimProcess == null) {
                _semaphoreSlimProcess = new SemaphoreSlim(appData.ProcessorThreadCount);
            }
            _httpClient = new HttpClient(); //Todo: Use IHttpClientFactory instead, see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
        }

        public async Task StartReceivingAsync() {
            if (!_ApplicationData.IsStarted) { //Note: Currently, we have a single count for the max threads, but this code right here makes the assumption that all threads are started at roughly the same time, at the start. In reality, we should probably have 3: Min, Max and Current thread counts. This would allow us to scale up and down. This could be useful if we install into a single VM and want to scale that VM up. However, more likely we would architect this to support scaliing out, in which case the need to scale up with threads on this instance probably isn't anything to focus on. Still, it could be an option if we spent a lot of time optimizing this code.
                _ApplicationData.IsRunning = true;
                _ApplicationData.IsStarted = true;
            }
            
            while(_ApplicationData.IsRunning) {  //Todo: Use a Cancellation Token instead? Or, this may be good enough. I need to research Cancellation Tokens more}
                try {

                    await _semaphoreSlimReceive.WaitAsync();
                    int batchId = 0;
                    await ReceiveSampleFeedAsync(_ApplicationData,batchId);
                    batchId++;
                } catch(Exception e) {
                    _ApplicationData.Config.Logger.LogException(e);
                } finally {
                    _semaphoreSlimReceive.Release();
                }
            }
            //Dispose of StreamReader?
            if(ConnectedStream != null) {
                StreamReader sr = (StreamReader)ConnectedStream;
                sr.Close();
            }

        }

        public async Task StartProcessingAsync(int threadId) {
            while(_ApplicationData.IsRunning || _ApplicationData.Messages.Count > 0 || _ApplicationData.IsStarted == false) {  //Todo: Use a Cancellation Token instead? Or, this may be good enough. I need to research Cancellation Tokens more}
                try {
                    await _semaphoreSlimProcess.WaitAsync();

                    if(_ApplicationData.Messages.Count > 0)
                        await ProcessSampleFeed(_ApplicationData,threadId);
                    else
                        await Task.Delay(250); //Give it a little time to start running. 250 is arbitrary, could analyze and tweak to find optimal amount.
                    
                } catch(Exception e) {
                    _ApplicationData.Config.Logger.LogException(e);
                } finally {
                    _semaphoreSlimProcess.Release();
                }
            }
        }

        private async Task ProcessSampleFeed(SampleFeedAppData appData, int threadId) {
            const int ExtraMessagesBufferCount = 1; //Technically, we don't have to process ProcessorBatchSize number of messages here. We could process more. For that reason, I'm going to introduce this constant that can be tweaked during testing. We could make this configurable, but for now it's in the research phase. I'm not certain we need a buffer, but we might. So, the plan is to do some development testing with this number as different values.
            bool isFirstMessage = true;

            int maxDelayCount = 0;
            int i;
            const int MAXIMUM_DELAYS = 10; //We'll only delay up to 10 times, then we'll just call this batch a wrap and move on.
            for(i = 0; i < appData.ProcessorBatchSize + ExtraMessagesBufferCount; i++) {
                if (appData.Messages.TryDequeue(out String? jsonMessage)) {
                    //We are processing a Tweet. Increment our counters and other appData stuff
                    appData.IncrementTweetsProcessedCount();
                    appData.LastReceivedDateTime  = DateTime.Now;

                    if (isFirstMessage) {
                        isFirstMessage = false;
                        appData.Config.Logger.LogInfo("First Processed Message this Batch by Thread " + threadId + ": " + jsonMessage);
                    }
                } else {
                    if (maxDelayCount < MAXIMUM_DELAYS)
                        await Task.Delay(200); //There are no messages in the queue, so let's wait for more and let other things run, such as receiving messages!
                    else
                        break; //We'll consider this batch done and move on.
                }
            }
            appData.Config.Logger.LogInfo("Processing Thread " + threadId + " processed " + i + " messages");
        }

        private async Task ReceiveSampleFeedAsync(SampleFeedAppData appData, int currentBatch) {
            await ConnectToSampleStream(appData);
            StreamReader str;
            if(ConnectedStream != null) {
                str = (StreamReader)ConnectedStream;
                int recordsReceived = 0;
                // loop through each item in the Filtered Stream API
                do {
                    if(recordsReceived == 0) {
                        appData.Config.Logger.LogInfo(" Batch: " + currentBatch + " Starting. Will receive " + appData.ProcessorBatchSize);
                    }
                    
                    String? json = str.ReadLine();

                    if(!String.IsNullOrEmpty(json)) {
                        // Add a message to be processed to the queue.
                        appData.Messages.Enqueue(json);
                        recordsReceived++;
                        appData.IncrementTweetsReceivedCount();
                        appData.LastReceivedDateTime = DateTime.Now;
                    }
                } while(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()
                            && !str.EndOfStream && recordsReceived < appData.ProcessorBatchSize);

                
                appData.Config.Logger.LogInfo("Receiving Batch: " + currentBatch + " complete. Records received:" + recordsReceived);
            }
        }

        private async Task ConnectToSampleStream(SampleFeedAppData appData) {
            
            if(ConnectedStream == null) { //If not null then we are already connected
                int tried = 0;
                int requestCount = 0;
                while(tried < appData.MaxTwitterConnectionTries) {
                    tried++;
                    try {
                        appData.Config.Logger.LogInfo("In ReceiveTwitterStreamAsync trying to Connect Attempt: " + tried);
                        

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,appData.TwitterSampleFeedEndpoint) {
                            Headers = { { "Authorization","Bearer " + appData.BearerToken } }
                        };

                        try {

                            HttpResponseMessage response = await _httpClient.SendAsync(request,HttpCompletionOption.ResponseHeadersRead);

                            requestCount++;
                            if(response.StatusCode == HttpStatusCode.OK) {
                                //stream opened!
                                Stream stream = await response.Content.ReadAsStreamAsync();
                                appData.Config.Logger.LogInfo("Opened Stream to Receive!");
                                ConnectedStream = new StreamReader(stream);
                                return;
                            } else {
                                appData.Config.Logger.LogError("response.StatusCode not HttpStatusCode.OK. Currently: " + response.StatusCode);
                                appData.Config.Logger.LogInfo("Sleeping 5 minutes in an effort to prevent too many requests");
                                await Task.Delay(1000 * 300);
                            }
                        } catch(WebException ex) {
                            appData.Config.Logger.LogException(ex);

                        } catch(Exception ex) {
                            appData.Config.Logger.LogException(ex);
                        }
                    } catch(Exception ex) {
                        if(tried < appData.MaxTwitterConnectionTries) {
                            appData.Config.Logger.LogException(ex);
                            appData.Config.Logger.LogInfo("Sleeping 2 minutes in an effort to prevent too many requests");
                            await Task.Delay(1000 * 120);//Simple wait to retry connection logic. Todo: Enhance, i.e. increase time period as tries increases.
                        }

                    }
                }
            }
        }
    }
}