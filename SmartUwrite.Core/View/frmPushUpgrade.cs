using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.Upgrade.PushUpgrade
{
    public partial class frmPushUpgrade : Form
    {
        List<TextBox> listBox = new List<TextBox>();
        public frmPushUpgrade()
        {
            InitializeComponent();
            string version = UpgradeService.GetCurrentVersion();
            txtCurVersion.Text = version;
            num.Minimum = (decimal)double.Parse(version) + 1;
            listBox.Add(txtMessage1);
            listBox.Add(txtMessage2);
            listBox.Add(txtMessage3);
            listBox.Add(txtMessage4);
            listBox.Add(txtMessage5);
            listBox.Add(txtMessage6);
        }

        public List<string> GetPushInfo()
        {
            List<string> list = new List<string>();
            int index = 1;
            foreach (var item in listBox)
            {
                if (item.Text!=string.Empty)
                {
                    list.Add(index + ":" + item.Text);
                    index++;
                }
               
            }
            return list;
        }

        

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            try
            {
                RequestEntity re = new RequestEntity((int)num.Value, GetPushInfo());
                PushService.DoWork(re);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmPushUpgrade), ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMessage2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMessage3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMessage4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMessage5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMessage6.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtMessage6.Visible = false;
            txtMessage6.Text = string.Empty;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtMessage5.Visible = false;
            txtMessage5.Text = string.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtMessage4.Visible = false;
            txtMessage4.Text = string.Empty;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtMessage3.Visible = false;
            txtMessage3.Text = string.Empty;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtMessage2.Visible = false;
            txtMessage2.Text = string.Empty;
        }
    }
}
