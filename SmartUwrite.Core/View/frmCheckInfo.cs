using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Upgrade.PushUpgrade;

namespace BIMTClassLibrary.Upgrade.CheckUpgrade
{
    public partial class frmCheckInfo : Form
    {
        public frmCheckInfo()
        {
            InitializeComponent();
        }

        public frmCheckInfo(string version)
        {
            InitializeComponent();
            lb_info.Text = string.Format("当前版本为 {0} 已是最新,无需更新！", version);
        }
        int count = 0;
        private void frmCheckInfo_Click(object sender, EventArgs e)
        {
            count++;
            if (count==5)
            {
                frmPushUpgrade frm = new frmPushUpgrade();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
