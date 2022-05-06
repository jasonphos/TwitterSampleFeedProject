using Jasonphos.SharedUtil.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasonphos.TwitterSampleFeedLogic {
    public class SampleFeedAppData : AppData {

        public int ProcessorThreadCount { get 
                {
                return Int32.Parse(Config.GetValue("cfg_ProcessorThreads"));
            } 
        }

        public int MaxGUILogLengthChars { get {
                return Int32.Parse(Config.GetValue("cfg_MaxGUILogLengthChars"));
            }
        }

        public SampleFeedAppData(ConfigData configData) : base(configData) {
        }
    }
}
