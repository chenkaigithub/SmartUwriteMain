using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.Controller.Service
{
    
    public interface IViewCallback
    {
        //void SetView(int count);
        void SetView(int count, string value);
        void MyInvoke(InitItemInvoke mi, object[] arrayObj);
    }
}
