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
        public String LogMessages { get { return logSb.ToString(); } }
        public ConfigData Config { get; set; }
        private volatile bool isStarted;
        private volatile bool isRunning;
        public DateTime? startProcessTimestamp;
        public DateTime? endProcessingTimestamp;
        protected ConcurrentDictionary<String,Object> data;
        
        public DateTime? StartProcessTimestamp { get { return startProcessTimestamp; } }
        public DateTime? EndProcessingTimestamp { get { return endProcessingTimestamp; } }
        public bool IsStarted { get { return isStarted; } 
            set {
                if(value == true)
                    startProcessTimestamp = DateTime.Now;
                isStarted = value; 
            } 
        }
        public bool IsRunning { get { return isRunning; } 
            set { 
                if (value == false && isRunning == true)
                    endProcessingTimestamp = DateTime.Now;
                isRunning = value; 
            } 
        }      
        private int maxGUILogLengthChars;
        public AppData(ConfigData config) {
            IsStarted = false;
            Config = config;
            logSb = new StringBuilder();
            config.Logger.AssociatedAppData = this;
            data = new ConcurrentDictionary<String,Object>();
            maxGUILogLengthChars = GetIntValueOrADefault("MaxGUILogLengthChars",3000);
        }
        public void AppendToLog(string message) {
            logSb.Insert(0,message);
            if (logSb.Length > maxGUILogLengthChars) {
                logSb.Remove(maxGUILogLengthChars, logSb.Length - maxGUILogLengthChars);    
            }
        }

        public string BearerToken {
            get {
                return (Config.GetValue("cfg_TwitterAPIBearerToken"));
            }
        }

        protected T? GetDataValue<T>(String key) {
            if(data.ContainsKey(key))
                return (T)data[key];
            else
                return default(T);
        }
        protected void SetDataValue<T>(String key,T? value) {
            if(value != null)
                data[key] = value;
            else
                data.Remove(key,out object? outValue);
        }

        protected int GetIntValueOrADefault(String key,int defaultValue) {
            if (!Int32.TryParse(Config.GetValue(key), out int toReturn)) {
                toReturn = defaultValue;
            }
            return toReturn;
        }
    }
}
