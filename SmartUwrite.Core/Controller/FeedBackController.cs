using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;
using System.Windows.Forms;

namespace BIMTClassLibrary.Controller
{
    public class FeedBackController:BaseController
    {
        public FeedBackController(IRefreshViewable view) : base(view) { }
        public override void Do()
        {
            if (new LoginController(view).IsLogin("请登录后进行反馈信息！"))
            {
                frmSendEmail frm = new frmSendEmail();
                frm.ShowDialog();
            }
        }
    }
}
