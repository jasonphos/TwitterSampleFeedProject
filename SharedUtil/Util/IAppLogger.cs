using Jasonphos.SharedUtil.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jasonphos.SharedUtil.Util {
    public interface IAppLogger {
        public void LogError(String message);

        public void LogInfo(String message);

        public void LogException(Exception e);

        public AppData? AssociatedAppData { get; set; }  

    }
}
