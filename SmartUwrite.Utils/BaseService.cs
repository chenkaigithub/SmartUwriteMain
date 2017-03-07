using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMT.Util
{
    public class BaseService
    {
        public IViewCallback view = null;
        public InitItemInvoke mi = null;

        public BaseService(IViewCallback view)
        {
            this.view = view;
            mi = new InitItemInvoke(this.view.SetView);
        }

        public void SendMessage(string message)
        {
            view.MyInvoke(mi, new object[] { 0, message });
        }

        public void SendMessageWithProcess(int value,string message)
        {
            view.MyInvoke(mi, new object[] { value, message });
        }
    }
}
