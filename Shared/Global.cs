using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Shared
{
    public static class Global
    {
        private static List<string> _globalVar = new List<string>();

        public static List<string> GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
