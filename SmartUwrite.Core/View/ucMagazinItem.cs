using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.magazine;
using BIMTClassLibrary.Controller.Service;
using BIMTClassLibrary.View;

namespace BIMTClassLibrary
{
    public partial class ucMagazinItem : UserControl
    {
        private Magazine magazine;

        public ucMagazinItem()
        {
            InitializeComponent();
            //rtb_ttile.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
            //rtb_baseInfo.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
        }

        public ucMagazinItem(Magazine _magazine)
        {
            InitializeComponent();
            //rtb_ttile.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
            //rtb_baseInfo.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
            this.magazine = _magazine;
            rtb_ttile.Text = _magazine.StrName;
            if ( _magazine.StrDoi.Trim()==string.Empty)
            {
                _magazine.StrDoi = "0";
            }
            rtb_baseInfo.Text = "期刊级别：" + _magazine.StrLevel + " 影响因子：" + _magazine.StrDoi+ " 匹配度：" + _magazine.FMatch;
            if (_magazine.IsCol)
            {
                btn_online_submission.Visible = true;
            }
            else
            {
                button1.Visible = true;
            }
        }

        /// <summary>
        /// 判断是否登录假如没登录
        /// </summary>
        /// <returns></returns>
        public bool IsLogin() {
            try
            {
                //if (User.GetInstance().Id==string.Empty)
                //{
                //    if (DialogResult.Yes==MessageBox.Show(null,"用户登陆后方可在线投稿，是否在线投稿？","在线投稿",MessageBoxButtons.YesNo))
                //    {
                //        frmLogin frm = new frmLogin();
                //        if (DialogResult.OK == frm.ShowDialog())
                //        {
                //            int _n = "会员登录".Length;
                //            string _strN = frm.userName.PadRight(_n, ' ');
                //            button1.Label = _strN.ToUpper();
                //        }
                //    }
                //}
                return false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//在线投稿
            try
            {
                frmRuning frm = new frmRuning(magazine);
                frm.ShowDialog();
                //frm.Runing();
                //SubmissionOnlineService service = new SubmissionOnlineService(magazine);
                //service.SendMagazine();
                //MagazineService ms = new MagazineService(magazine);
                //ms.OnlineSubmission();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucMagazinItem), ex);
            }
        }

        private void ucMagazinItem_Load(object sender, EventArgs e)
        {

        }
    }
}
