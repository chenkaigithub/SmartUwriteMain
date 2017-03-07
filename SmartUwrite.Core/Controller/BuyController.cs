using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.Controller
{
    public class BuyController : BaseController
    {

        public BuyController(IRefreshViewable view)
            : base(view)
        {

        }

        public override void Do()
        {
            LoginController controller = new LoginController(this.view);
            if (controller.IsLogin("请登陆后进行购买!"))
            {
                Pay();
            }
        }

        public void Pay()
        {
            User user = User.GetInstance();
            string token = user.Detail.result.token;
            PayService _service = new PayService(token);
            _service.Jump();
            frmPay frm = new frmPay(this.view);
            frm.ShowDialog();
        }
    }
}
