using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitterJoiner.Controllers
{
    public static class MTools
    {
        public static long GetKilobytes(this long bytes)
        {
            return bytes / 1024;
        }
        public static long GetMegabytes(this long bytes)
        {
            return bytes.GetKilobytes() / 1024;
        }
        

    }
}
