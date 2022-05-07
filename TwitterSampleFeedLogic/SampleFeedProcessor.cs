using Jasonphos.SharedUtil.Data;

namespace Jasonphos.TwitterSampleFeedLogic {
    public class SampleFeedProcessor {
        public SampleFeedAppData ApplicationData { get; }
        private static SemaphoreSlim? _semaphoreSlimProcessing = null; //Could have additional semaphores for other tasks in the future, this one is specific to processing the stream.
        public SampleFeedProcessor(SampleFeedAppData appData) {
            ApplicationData = appData;
            if(_semaphoreSlimProcessing == null) {
                _semaphoreSlimProcessing = new SemaphoreSlim(appData.ProcessorThreadCount);
            }
        }

        public async Task StartFeedAsync() {
            await _semaphoreSlimProcessing.WaitAsync();

            await ReceiveTwitterStreamAsync(ApplicationData);

            ProcessTwitterStream(ApplicationData);

            _semaphoreSlimProcessing.Release();
        }

        private void ProcessTwitterStream(object appData) {
            throw new NotImplementedException();
        }

        private Task ReceiveTwitterStreamAsync(object appData) {
            throw new NotImplementedException();
        }
    }
}