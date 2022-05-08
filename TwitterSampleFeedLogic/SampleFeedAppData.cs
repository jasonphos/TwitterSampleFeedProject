using Jasonphos.SharedUtil.Data;
using Jasonphos.SharedUtil.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasonphos.TwitterSampleFeedLogic {
    public class SampleFeedAppData : AppData {

        public ConcurrentQueue<String> Messages;
        public int ProcessorThreadCount { get {
                return GetIntValueOrADefault("cfg_ProcessorThreads",1);
            } 
        }
        public int ProcessorBatchSize {  get {
                return GetIntValueOrADefault("cfg_ProcessorBatchSize",10);
            } 
        }

        public int MaxGUILogLengthChars { get {
                return GetIntValueOrADefault("cfg_ProcessorBatchSize",2000);
            }
        }

        public DateTime? LastReceivedDateTime {  get {
                return GetDataValue<DateTime>("LastReceivedDateTime");
            }
            set {
                SetDataValue<DateTime?>("LastReceivedDateTime", value);
            }
        }

        public DateTime? LastProcessedDateTime {
            get {
                return GetDataValue<DateTime>("LastProcessingDateTime");
            }
            set {
                SetDataValue<DateTime?>("LastProcessingDateTime",value);
            }

        }

        public int MaxTwitterConnectionTries { get {
                return GetIntValueOrADefault("MaxTwitterConnectionTries",2);
            }
        }

        public string? TwitterSampleFeedEndpoint { get {
                return RestUtil.Combine(Config.GetValue("cfg_ServiceEndpointBase"),"tweets/sample/stream");
            }
        }

        protected volatile int tweetsReceivedCount;
        protected volatile int tweetsProcessedCount;
        public int TweetsReceivedCount { get { return tweetsReceivedCount; } }
        public int TweetsProcessedCount { get { return tweetsProcessedCount; } }

        public double TweetsReceivedPerMin { get {
                TimeSpan? ts = LastReceivedDateTime - StartProcessTimestamp;
                if(ts != null)
                    return tweetsReceivedCount / ( ((TimeSpan)ts).TotalSeconds/60);
                else
                    return 0;
            }
        }

        public void IncrementTweetsReceivedCount(int count = 1) {
            Interlocked.Add(ref this.tweetsReceivedCount, count);
        }
        public void IncrementTweetsProcessedCount(int count = 1) {
            Interlocked.Add(ref this.tweetsProcessedCount,count);
        }
        public SampleFeedAppData(ConfigData configData) : base(configData) {
            Messages = new();
        }
    }
}
