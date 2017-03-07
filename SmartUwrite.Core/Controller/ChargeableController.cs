using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Model;
using BIMTClassLibrary.RefreshView;
using BIMT.Util.Configuration;
using BIMT.Util.Encrypt;
using System.Windows.Forms;
using BIMTClassLibrary.View;

namespace BIMTClassLibrary.Controller
{
    public class ChargeableController : BaseController
    {
        public ChargeableController(IRefreshViewable view) : base(view) { }

        public void UseChargedFunction()
        {
            bool tologin = true;
            if ((new LoginController(view).IsLogined() && User.GetInstance().IsVip())
                || InFreeTrial()
                || (!new LoginController(view).IsLogined() && (tologin = new LoginController(view).ToLogin("此功能为付费功能，请购买后使用，如已购买请登录后使用！")) && User.GetInstance().IsVip()))
            {
                Do();
            }
            else if ((tologin && !new LoginController(view).IsLogined() && new LoginController(view).IsLogin("此功能为付费功能，请购买后使用，如已购买请登录后使用！") && !User.GetInstance().IsVip())
                || new LoginController(view).IsLogined() && !User.GetInstance().IsVip())
            {
                new BuyController(view).Pay();
            }
        }

        public void PayFunction()
        {
            new LoginController(view).ToLogin();
            new BuyController(view).Pay();
        }

        private bool InFreeTrial()
        {
            try
            {
                EncryptHelper helper = new EncryptHelper();
                int times = int.Parse(helper.De(ConfigurationHelper.GetConfig("FreeTimes")));
                ConfigurationHelper.SetConfig("FreeTimes", helper.Do((times - 1).ToString()));
                if (times > 0 && times < 90)
                {
                    frmUseFreeMessage frm = new frmUseFreeMessage(view,times.ToString());
                    frm.ShowDialog();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void Do()
        {
            throw new NotImplementedException();
        }
    }
}
