using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.userBeheiverTrick;
using BIMTClassLibrary.Controller.Service;
using System.Windows.Forms;
using System.Diagnostics;


namespace BIMTClassLibrary.Controller
{
    public class SmartUwriteLoadController
    {
        public void UseWord()
        {
            using (UserBeheiverTrickService ubts = new UserBeheiverTrickService())
            {
                HardwareInfoService service = new HardwareInfoService();
                string code = service.CreateCode();
                ubts.SynDoTrick("写作助手插件载入", "SmartUwrite_Load", code + '_' + Application.ProductVersion);
                
            }
        }

        public void InstallSmartUwrite()
        {
            using (UserBeheiverTrickService ubts = new UserBeheiverTrickService())
            {
                CheckVersionService cService = new CheckVersionService();
                FileVersionInfo oldFile = FileVersionInfo.GetVersionInfo(string.Format(cService.GetPath(), "BIMT200.dll"));
                HardwareInfoService hService = new HardwareInfoService();
                string code = hService.CreateCode();
                ubts.SynDoTrick("写作助手插件安装", "SmartUwrite_Install", code + '_' + oldFile.FileVersion);
            }
        }
    }
}
