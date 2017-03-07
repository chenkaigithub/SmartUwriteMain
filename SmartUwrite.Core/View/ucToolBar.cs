using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.ScreenShot
{
    public partial class ucToolBar : Form
    {
        private static ucToolBar frm;
        private ucToolBar()
        {
            InitializeComponent();
        }

        public static ucToolBar GetInstance()
        {
            if (frm == null)
            {
                frm = new ucToolBar();
            }
            return frm;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.Reset();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.Reset();
        }
    }
}
