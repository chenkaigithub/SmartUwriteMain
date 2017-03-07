using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.WordTemplate
{
    public partial class frmAddTemplate : Form
    {
        public frmAddTemplate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txt_path.Text = string.Empty;
                ofd_template.ShowDialog();
                txt_path.Text = ofd_template.FileName;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmAddTemplate), ex);
            }
        }

        private void btn_od_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("上传模板");
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmAddTemplate), ex);
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
