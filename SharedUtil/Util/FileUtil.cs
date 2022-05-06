using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasonphos.SharedUtil.Util {
    public class FileUtil {
        public static bool AreFileContentsEqual(String path1, String path2) {
            return File.ReadLines(path1).SequenceEqual(File.ReadLines(path2));
        }
    }
}
