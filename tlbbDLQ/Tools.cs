using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tlbbDLQ
{
    class Tools
    {
        public static bool T_DEBUG { set; get; }
        private static readonly object _lock_ = new object();

        public Tools()
        {
            T_DEBUG = false;
        }

        public static void Log(String msg)
        {
            if (!T_DEBUG)
                return;
            lock(Tools._lock_)
            {
                using (StreamWriter sw = new StreamWriter("./log", true, Encoding.UTF8))
                {
                    String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sw.WriteLine($"[{time}] {msg}");
                }
            }           
        }
    }
}
