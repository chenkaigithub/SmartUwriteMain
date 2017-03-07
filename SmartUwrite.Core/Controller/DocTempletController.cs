using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;
using BIMTClassLibrary.WordTemplete;
using System.Windows.Forms;

namespace BIMTClassLibrary.Controller
{
    public class DocTempletController : ChargeableController
    {
        public DocTempletController(IRefreshViewable view) : base(view) { }

        public override void Do()
        {
            //LoginController controller = new LoginController(view);
            //if (controller.IsLogin("此功能为付费功能，请购买后使用！"))
            //{
            //    if (User.GetInstance().IsVip())
            //    {
            frmSelectTemplate frm = new frmSelectTemplate(view);
            frm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("此功能为付费功能，请购买付费版后使用!");
            //    }
            //}
        }
    }
}
