using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Jasonphos.SharedUtil.Data;

namespace Jasonphos.SharedUtil.Util {
    public class AppLogger : IAppLogger {
        private enum Type{
            Error, Info, Exception
        }
        
        protected String _logFileName;
        protected bool _isLogToFile;
        protected int _maxLogLengthMemory;
        StreamWriter? _file = null;

        public AppLogger(String logPath, bool isLogToFile, String appName = "Application") {
            this._isLogToFile = isLogToFile;
            if (String.IsNullOrEmpty(logPath)) {
                logPath = AppDomain.CurrentDomain.BaseDirectory;
                logPath = Path.Combine(logPath,@"log");
            }
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            _logFileName = Path.Combine(logPath,appName + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt");
            if(isLogToFile)
                _file = new StreamWriter(_logFileName,append: true);
        }
        public AppData? AssociatedAppData { get; set; } //An AppData can be associated with this logger. If so, the log will be stored in memory up to a set amount of data.
        public void LogError(string message) {
            message = FormatMessage(Type.Error,message);
            WriteMessage(message);
        }

        public void LogException(Exception e) {
            String message = FormatMessage(Type.Exception,e.Message + " " + e.StackTrace);
            WriteMessage(message);
        }

        public void LogInfo(string message) {
            message = FormatMessage(Type.Info,message);
            WriteMessage(message);
        }

        private String FormatMessage(Type type, String message) {
            message = DateTime.Now.ToString("yyyyMMdd HHmmss - ") + type.ToString() + " - " + message;
            return message;
        }

        private void WriteMessage(String message) {
            WriteMessageToFile(message);
            WriteMessageToAppData(message); //This can be read by interested parties, such as a Windows Form.
        }
        private void WriteMessageToFile(String message) {
            if (_file!=null) {
                _file.WriteLine(message);
                _file.Flush();
            }
        }

        private void WriteMessageToAppData(String message) {
            if (AssociatedAppData != null) {
                AssociatedAppData.AppendToLog(message + System.Environment.NewLine);
            }
        }
    }
}
