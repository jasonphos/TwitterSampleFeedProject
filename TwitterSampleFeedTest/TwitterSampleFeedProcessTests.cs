using Jasonphos.SharedUtil.Data;
using Jasonphos.TwitterSampleFeedLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterSampleFeedTest {
    [TestClass]
    public class TwitterSampleFeedProcessTests {
        [TestMethod]
        public void SimpleSampleFeedSimpleTest() {
            ConfigData configData = new ConfigData(null);
            SampleFeedAppData appData = new SampleFeedAppData(configData);
            SampleFeedProcessor processor = new SampleFeedProcessor(appData);

            Assert.IsFalse(processor._ApplicationData.IsStarted);
            int numberThreads = 1;
            Task.Run(async () => { //Can only do a single receive Thread, since StreamReader is not threadsafe! I think that should be fine for any program that reads the Twitter Sample Stream API
                await processor.StartReceivingAsync();
            });

            for(int i = 0; i < numberThreads; i++) { //I also am using semaphoreslim to set the maximum number of threads, based upon some async examples I read. One of the two might not be needed, I'm not certain, but even if semaphoreslim isn't strictly needed, I don't think it causes any harm and in fact it could be useful to throttle up and down the number of threads, if we ever wanted to do that.
                int threadNumber = i + 1;
                Task.Run(async () => {
                    await processor.StartProcessingAsync(threadNumber);
                });
            }
            Thread.Sleep(3000);
            Assert.IsTrue(processor._ApplicationData.IsStarted && processor._ApplicationData.IsRunning);
            Thread.Sleep(30000000);
            processor._ApplicationData.IsRunning = false; //Stop it from running
            Thread.Sleep(500);
            Assert.IsTrue(processor._ApplicationData.IsRunning);
            Assert.IsTrue(processor._ApplicationData.TweetsReceivedCount > 0);


        }
    }
}
