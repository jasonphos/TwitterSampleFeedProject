using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasonphos.SharedUtil.Util {
    public class RestUtil {
        public static string Combine(string uri1,string uri2) {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}",uri1,uri2);
        }
    }
}
