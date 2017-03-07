using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Controller.Service;
using System.Threading;
using BIMT.Util;

namespace BIMTClassLibrary.View
{
    public partial class frmRuning : Form, IViewCallback
    {
        IInvokeService service;
        Magazine magazine;
        public frmRuning(Magazine magazine)
        {
            InitializeComponent();
            this.magazine = magazine;
            Runing();
        }

        public void Runing()
        {
            service = new SubmissionOnlineService(this, magazine);
            Thread t = new Thread(service.DoWord);
            t.Start();
        }

        

        private void lb_close_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        public void SetView(int count, string value)
        {
            if (count < 0)
            {
                this.FindForm().Close();
            }
            else
            {
                lb_message.Text = value + "\n" + lb_message.Text;
            }
        }

        public void MyInvoke(InitItemInvoke mi, object[] arrayObj)
        {
            BeginInvoke(mi, arrayObj);
        }
    }
}
