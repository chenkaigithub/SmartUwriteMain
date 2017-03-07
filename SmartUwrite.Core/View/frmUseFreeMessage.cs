using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Controller;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.View
{
    public partial class frmUseFreeMessage : Form
    {
        IRefreshViewable view;
        public frmUseFreeMessage()
        {
            InitializeComponent();
            lb_info.Parent = pictureBox1;
        }

        public frmUseFreeMessage(IRefreshViewable view,string times)
        {
            InitializeComponent();
            lb_info.Parent = this;
            label1.Parent = this;
            lb_info.Text = string.Format(lb_info.Text,times);
            this.view = view;
        }

        private void btn_usefree_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            try
            {
                new ChargeableController(view).PayFunction();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUseFreeMessage), ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
