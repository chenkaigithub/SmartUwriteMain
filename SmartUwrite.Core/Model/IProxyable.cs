using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.Model
{
    interface IProxyable
    {
        void InitProxy();
        string GetIP();
        string GetPort();
    }
}
