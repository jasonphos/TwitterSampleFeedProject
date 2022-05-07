using Jasonphos.SharedUtil.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasonphos.SharedUtil.Data {
    public class AppData {

        protected StringBuilder logSb;
        public ConfigData Config { get; set; }
        public volatile bool IsStarted;
        public volatile bool IsRunning;
        public DateTime startProcessTimestamp;
        public DateTime lastProcessingTimestamp;
        protected ConcurrentDictionary<String,Object> data;
        public AppData(ConfigData config) {
            IsStarted = false;
            Config = config;
            logSb = new StringBuilder();
            config.Logger.AssociatedAppData = this;
            data = new ConcurrentDictionary<String,Object>();
        }
        public void AppendToLog(string message) {
            throw new NotImplementedException();
        }

        public string BearerToken {
            get {
                return (Config.GetValue("cfg_TwitterAPIBearerToken"));
            }
        }
    }
}
