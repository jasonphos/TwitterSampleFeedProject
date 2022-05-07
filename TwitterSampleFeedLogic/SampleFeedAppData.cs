﻿using Jasonphos.SharedUtil.Data;
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
                return Int32.Parse(Config.GetValue("cfg_ProcessorThreads"));
            } 
        }
        public int ProcessorBatchSize {  get {
                return Int32.Parse(Config.GetValue("cfg_ProcessorBatchSize"));
            } 
        }

        public int MaxGUILogLengthChars { get {
                return Int32.Parse(Config.GetValue("cfg_MaxGUILogLengthChars"));
            }
        }

        public DateTime? LastProcessingDateTime {  get {
                if(data.ContainsKey("LastProcessingDateTime"))
                    return (DateTime)data["LastProcessingDateTime"];
                else
                    return null;
            }
            set {
                if (value != null)
                    data["LastProcessingDateTime"] = value;
            }
                
        }

        public int MaxTwitterConnectionTries { get {
                return Int32.Parse(Config.GetValue("MaxTwitterConnectionTries"));
            }
        }

        public string? TwitterSampleFeedEndpoint { get {
                return RestUtil.Combine(Config.GetValue("cfg_ServiceEndpointBase"),"tweets/sample/stream");
            }
        }

        public volatile int TweetsCount;

        public void IncrementTweetsCount(int count = 1) {
            Interlocked.Add(ref this.TweetsCount, count);
        }
        public SampleFeedAppData(ConfigData configData) : base(configData) {
            Messages = new();
        }
    }
}
