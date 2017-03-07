using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMT.Util.Serialiaze;
using BIMT.Util.RestAPI;
using BIMT.Util.Configuration;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;
using System.Windows.Forms;
using LiteratureManager;

namespace BIMTClassLibrary.Controller
{
    public class LoginController:BaseController
    {
        public LoginController(IRefreshViewable view)
            : base(view)
        {
        }

        public bool IsLogin(string message)
        {
            User user = User.GetInstance();
            if (user.Key == null)
            {
                if (MessageBox.Show(null, message, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmLogin frmlog = new frmLogin(view);
                    frmlog.ShowDialog();
                }
                return false;
            }
            return true;
        }

        public bool IsLogined()
        {
            User user = User.GetInstance();
            if (user.Key == null)
            {
                return false;
            }
            return true;
        }

        public void ToLogin()
        {
            User user = User.GetInstance();
            if (user.Key == null)
            {
                frmLogin frmlog = new frmLogin(view);
                frmlog.ShowDialog();
            }
        }

        public bool ToLogin(string message)
        {
            if (MessageBox.Show(null, message, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmLogin frmlog = new frmLogin(view);
                if (DialogResult.OK == frmlog.ShowDialog())
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override void Do()
        {
            User user = User.GetInstance();
            if (user.Key == null)//登录
            {
                frmLogin frm = new frmLogin(view);
                frm.ShowDialog();
            }
            else//注销
            {
                if (DialogResult.Yes == MessageBox.Show(string.Format("确定登出 {0} 吗？", User.GetInstance().Detail.result.name), "消息", MessageBoxButtons.YesNo))
                {
                    view.Logout();
                    view.NonPay();
                    user.SetKeyNull();
                }
            }
        }
    }
}
