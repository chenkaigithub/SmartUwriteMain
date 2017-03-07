using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMT.Util
{
    public class BaseFormView : Form, IViewCallback
    {
        public void MyInvoke(InitItemInvoke mi, object[] arrayObj)
        {
            IAsyncResult result = BeginInvoke(mi, arrayObj);
            if (result.IsCompleted)
            {
                mi.EndInvoke(result);
            }
          
        }

        public virtual void SetView(int count, string value){}
        
    }
}
