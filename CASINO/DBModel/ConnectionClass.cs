using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASINO.DBModel
{
    public static class ConnectionClass
    {
        public static CASINOEntities db = new CASINOEntities();

        public static int IsOnlineUserId = -1;
    }
}
