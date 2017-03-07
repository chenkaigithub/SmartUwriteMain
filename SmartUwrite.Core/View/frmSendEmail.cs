using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BIMTClassLibrary.Email;

namespace BIMTClassLibrary
{
    public partial class frmSendEmail : Form
    {
        List<string> m_listFJ = new List<string>();
        List<Button> m_listButton = new List<Button>(); 
        public frmSendEmail()
        {
            InitializeComponent();
            m_listButton.Add(option4);
            m_listButton.Add(option5);
            m_listButton.Add(option1);
            m_listButton.Add(option2);
            m_listButton.Add(option3);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取一个button作为附件显示容器
        /// wuhailong
        /// 2016-07-14
        /// </summary>
        /// <returns></returns>
        public Button GetButton()
        {
            foreach (Button item in m_listButton)
            {
                if (item.Visible == false)
                {
                    item.Visible = true;
                    return item;
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtb_content.Height == 428)
                {
                    rtb_content.Height = 395;
                }
                ofd_file.ShowDialog();
                if (File.Exists(ofd_file.FileName))
                {
                    FileInfo fi = new FileInfo(ofd_file.FileName);
                    m_listFJ.Add(fi.Name);
                    Button btn = GetButton();
                    btn.Text = fi.Name;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSendEmail), ex.Message);
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (DialogResult.Yes==MessageBox.Show(null,"确定删除当前附件吗？","删除附件",MessageBoxButtons.YesNo))
            {
                m_listFJ.Remove(btn.Text);
                btn.Visible = false;
            }
           
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (txt_title.Text==string.Empty||rtb_content.Text==string.Empty)
            {
                MessageBox.Show(null,"标题或内容不能为空！","用户反馈");
            }
            else
            {
                EmailService.TestEmail3(txt_title.Text, rtb_content.Text);
            }
            this.FindForm().Close();
        }
    }
}
