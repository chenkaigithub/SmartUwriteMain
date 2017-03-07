using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Log4Net;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.RefreshView
{
    public partial class frmPay : Form
    {

        public frmPay()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(DoWord));
            thread.Start();
        }
        IRefreshViewable view;
        public frmPay(IRefreshViewable view)
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(DoWord));
            thread.Start();
            this.view = view;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            MessageBox.Show(null,"购买成功！","pay");
            this.FindForm().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.FindForm().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_done;

        }

       

        public delegate void InitItemInvoke(string u);

        public void DoWord()
        {
            try
            {
                InitItemInvoke mi = new InitItemInvoke(PayDone);
                bool ok = false;
                while (!ok)
                {
                    Thread.Sleep(1000 * 6);
                    User user = User.GetInstance();
                    user.RefreshDetail();
                    ok = user.IsVip();
                }
                string result = string.Empty;
                BeginInvoke(mi, new object[] { result });
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmPay), ex);
            }
           
        }

        public void PayDone(string str)
        {
            tabControl1.SelectedTab = tp_done;
            lb_day.Text = string.Format(lb_day.Text, User.GetInstance().Detail.result.overDate);
            view.Payed();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
