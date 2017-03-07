using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BIMT.Util.ExeProcess;

namespace BIMTClassLibrary.View
{
    public partial class frmProxyNotify : Form
    {
        public frmProxyNotify()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseFrm();
        }

        public void CloseFrm()
        {
            string softName = "BimtShadowsocks";
            Process p = ProcessHelper.GetProcess(softName);
            if (p != null)
            {
                p.Kill();
            }
            this.FindForm().Close();
        }

        private void frmProxyNotify_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseFrm();
        }
    }
}
