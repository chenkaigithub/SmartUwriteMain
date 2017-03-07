using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMT.Util;

namespace BIMTClassLibrary.Controller.Service
{
    //public delegate void InitItemInvoke(int count, string str);
    public class BaseService
    {
        public IViewCallback view = null;
        public InitItemInvoke mi = null;
        public BaseService(IViewCallback view)
        {
            this.view = view;
            mi = new InitItemInvoke(this.view.SetView);
        }

    }
}
