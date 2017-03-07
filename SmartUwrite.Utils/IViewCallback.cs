using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMT.Util
{
    public delegate void InitItemInvoke(int count, string str);
    public interface IViewCallback
    {
        void SetView(int count, string value);
        void MyInvoke(InitItemInvoke mi, object[] arrayObj);
    }
}
