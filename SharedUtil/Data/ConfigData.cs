using Jasonphos.SharedUtil.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace Jasonphos.SharedUtil.Data {
    public class ConfigData
    {
        private Dictionary<String, String> data ;
        private IAppLogger logger;
        public Dictionary<String, String> Data { get { return data; } }
        public IAppLogger Logger { get { return logger; } }

        public ConfigData(IAppLogger? logger)
        {
            data = new Dictionary<String,String>();
            LoadConfigFromFile();
            if (logger == null)
                logger = new AppLogger(GetValue("LogPath"), "Y".Equals(GetValue("IsLogToFile")));
            this.logger = logger;
        }

        private void LoadConfigFromFile() {
            try {
                //Loads configuration from app.config
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                foreach(String? key in appSettings.AllKeys) {
                    if (key != null)
                        SetValue(key,appSettings[key]);
                }
            } catch(Exception e) {
                logger.LogException(e);
            }
        }

        public string GetValue(string key) {
            if(Data.ContainsKey(key))
                return Data[key];
            else
                return "";
        }

        public void SetValue(String key, String? inValue) {
            String value = inValue ?? "";
            Data[key] = value;
        }
    }
}
