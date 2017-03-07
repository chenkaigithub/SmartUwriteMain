using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.RefreshView
{
    public interface IRefreshViewable
    {
        void Payed();
        void NonPay();
        void Logined();
        void Logout();
        void SetStyle(string name);
        void HideOtherPanel(string name);
        void ShowTaskPane(string name, UserControl uc);
        void ShowAdminPanel();
        void HideAdminPanel();
        void NeedUpdate();
    }
}
