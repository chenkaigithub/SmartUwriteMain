using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Json;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.Service;
using System.Net;
using System.Configuration;
using BIMTClassLibrary.styles;
using Log4Net;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.DocDatabase.Upload;
using BIMTClassLibrary.DocDatabase.Service;
using System.Threading;
using LiteratureManager;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Controller;
using BIMTClassLibrary.Model;
namespace BIMTClassLibrary
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            try
            {
                InitializeComponent();
                string _strRemeber = CommonFunction.GetConfig("RemeberUser");
                if ("TRUE" == _strRemeber)
                {
                    checkBox1.Checked = true;
                    textBox1.Text = CommonFunction.GetConfig("UserName");
                    textBox2.Text = CommonFunction.GetConfig("UserPwd");
                }
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(frmLogin), EX);
            }
           
        }
        IRefreshViewable view;
        public frmLogin(IRefreshViewable view)
        {
            try
            {
                InitializeComponent();
                string _strRemeber = CommonFunction.GetConfig("RemeberUser");
                if ("TRUE" == _strRemeber)
                {
                    checkBox1.Checked = true;
                    textBox1.Text = CommonFunction.GetConfig("UserName");
                    textBox2.Text = CommonFunction.GetConfig("UserPwd");
                }
                this.view = view;
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(frmLogin), EX);
            }

        }



        public string GetUserName() {
            return textBox1.Text;
        }

        public string GetPassWord() {
            return textBox2.Text;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text== "手机号码/邮箱")
            {
                textBox1.Focus();
                textBox1.Text = string.Empty;
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                //textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = '*';
            //if (textBox2.Text == "密码")
            //{
            //    textBox2.Focus();
            //    textBox2.Text = "";
            //    textBox2.ForeColor = Color.Black;
            //}
            //else
            //{
            //    //textBox1.Text = "";
            //    textBox2.ForeColor = Color.Black;
            //}
           
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 登录
        /// wuhailong
        /// 2016-06-24
        /// </summary>
        [Obsolete("This function is obsolete , please use DoLogin", true)]
        public void Login()
        {
            try
            {
                //string url = PublicVar.literatureBaseUrl + "/users/login";
                //string postData = "{\"username\": \"" + textBox1.Text.Trim() + "\",\"password\": \"" + textBox2.Text.Trim() + "\",\"timestamp\": " + GetTimeStamp() + "}";
                //string result =new RestHelper(url,postData,string.Empty).SendPost();
                //JObject jo = JsonHelper.GetObj(result);
                //User.GetInstance().WaKey = jo["WAKey"].ToString();
                //User.GetInstance().Id = jo["id"].ToString();
                //PublicVar.userName = jo["userName"].ToString();

                //PublicVar.UserEmail = jo["email"].ToString();
                //PublicVar.UserPhone = jo["phone"].ToString();

                //string url2 = PublicVar.literatureBaseUrl + "/users/me";
                //string header = User.GetInstance().WaKey;
                //string userInfo =new RestHelper(url2,string.Empty,header).SendGet();
                //JObject jo2 = JsonHelper.GetObj(userInfo);
                //this.userName = jo2["nickname"].ToString();
                ////我的文献库
                //IStorageService storage = FileStorageService.GetInstance();
                //storage.CreateBaseDir();
                ////下载样式 2016-06-22 wuhailong
                //StyleManager.SynDownLoadStyles();
                //this.DialogResult = DialogResult.OK;
                //this.FindForm().Close();
                ////登录时同步服务器信息到本地
                ////frmMyLiterature frm = new frmMyLiterature();
                ////SynDocInfoService service = new SynDocInfoService(frm, User.GetInstance().Id, PublicVar.userName, PublicVar.UserPhone, PublicVar.UserEmail);
                ////Thread t = new Thread(service.SynDocInfo);
                ////t.Start();
                //try
                //{
                //    AsynUploadDocService service = new AsynUploadDocService();
                //    service.SynUpolad();
                //}
                //catch (Exception ex)
                //{
                //    LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
                //}
            }
            catch (Exception ex)
            {
                this.label1.Visible = true;
                this.label1.Text = "用户名或密码错误!";
                Log4Net.LogHelper.WriteLog(typeof(frmLogin), ex);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                DoLogin();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.label1.Visible = true;
                this.label1.Text = "用户名或密码错误!";
                Log4Net.LogHelper.WriteLog(typeof(frmLogin), ex);
            }
        }

        

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                textBox1.Text = "手机号码/邮箱";
                textBox1.ForeColor = Color.Gray;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
        }

        public string m_strUKey { get; set; }

        public string userName { get; set; }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://i.bimt.com/register/select?r_u=&src=smartuwrite");
            using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
            {
                ubts.SynDoTrick("快速注册", "注册", "写作助手跳转注册页");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://i.bimt.com/forget-pwd/first"); 
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    CommonFunction.SaveConfig("RemeberUser", "TRUE");
                    CommonFunction.SaveConfig("UserName", textBox1.Text);
                    CommonFunction.SaveConfig("UserPwd", textBox2.Text);
                }
                else
                {
                    label1.Text = "用户名密码输入不全！";
                }
            }
            else
            {
                CommonFunction.SaveConfig("RemeberUser", "FALSE");
                CommonFunction.SaveConfig("UserName", string.Empty);
                CommonFunction.SaveConfig("UserPwd", string.Empty);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "手机号码/邮箱")
            {
                textBox1.Focus();
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            //else
            //{
            //    textBox1.Text = "";
            //    textBox1.ForeColor = Color.Black;
            //}
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = 
            //if (textBox2.Text == string.Empty)
            //{
            //    textBox2.Focus();
            //    textBox2.Text = "密码";
            //    textBox2.ForeColor = Color.Gray;
            //}
        }

        

        private void DoLogin()
        {
            string _userName = textBox1.Text;
            string _passWord = textBox2.Text;
            LoginService service = new LoginService(_userName, _passWord);
            User user = service.GetUser();
            if (user.IsVip())
            {
                view.Payed();
            }
            if (user.IsAdmin())
            {
                view.ShowAdminPanel();
            }
            view.Logined();
            this.DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    DoLogin();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLogin),ex);
            }
           
        }

        public string passWord { get; set; }
    }
}
