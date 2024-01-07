using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.appData
{
    internal class ConDB
    {
        public static Database1Entities1 con;
        public static Database1Entities1 context
        {
            get
            {
                if(con == null) con = new Database1Entities1();
                return con;
            }
        }
    }
}
