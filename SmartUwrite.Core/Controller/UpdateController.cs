using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Controller.Service;
using BIMTClassLibrary.Upgrade.CheckUpgrade;
using BIMT.Util.ExeProcess;
using System.Diagnostics;
using System.Threading;

namespace BIMTClassLibrary.Controller
{
    public class UpdateController : BaseController
    {
        public static bool FileMajorPart = false;
        static string comments = string.Empty;
        public UpdateController(IRefreshViewable view) : base(view) { }

        public override void Do()
        {
            Thread t = new Thread(OpenExe);
            t.Start();
        }

        public void CheckUpdate()
        {
            CheckVersionService service = new CheckVersionService();
            string path = string.Format("{0}\\BIMT\\update\\BIMT200_NEW.dll", PublicVar.BaseDir);
            service.OssDownloadFile("BIMT200.dll", path);
            FileVersionInfo oldFile = FileVersionInfo.GetVersionInfo(string.Format(service.GetPath(), "BIMT200.dll"));
            FileVersionInfo newFile = FileVersionInfo.GetVersionInfo(string.Format(path, "BIMT200_NEW.dll"));
            
            if (newFile.FileVersion.CompareTo(oldFile.FileVersion) > 0)
            {
                if (newFile.FileMajorPart > oldFile.FileMajorPart)
                {//大更新
                    FileMajorPart = true;// Process.Start(string.Format(service.GetPath(), "SmartUwriteDownload.exe"));
                }
                comments = newFile.Comments;
                view.NeedUpdate();
            }
        }

        private void OpenExe()
        {
            if (FileMajorPart)
            {
                CheckVersionService service = new CheckVersionService();
                Process.Start(string.Format(service.GetPath(), "SmartUwriteDownload.exe"));
            }
            else
            {
                string path = string.Format("{0}\\BIMT\\update\\SmartUwriteUpdate.exe", PublicVar.BaseDir);
                string[] arg = new string[1];
                arg[0] = comments;
                ProcessHelper.StartProcess(path, arg);
            }
            
        }
    }
}
