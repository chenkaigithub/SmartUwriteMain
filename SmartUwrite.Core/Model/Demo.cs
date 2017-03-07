using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.Model
{
    class Demo : BaseProxy
    {
        public Demo()
        {
            ip = "114.112.127.106";
            port = "20801";
        }
        public override string GetIp()
        {
            return ip;
        }

        public override string GetPort()
        {
            return port;
        }
    }
}
