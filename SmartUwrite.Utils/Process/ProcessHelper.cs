using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BIMT.Util.ExeProcess
{
    public static class ProcessHelper
    {
        public static bool StartProcess(string filename, string[] args)
        {
            string arguments = "";
            foreach (string arg in args)
            {
                arguments = arguments + arg + " ";
            }
            arguments = arguments.Trim();
            Process myprocess = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(filename, arguments);
            myprocess.StartInfo = startInfo;
            //通过以下参数可以控制exe的启动方式，具体参照 myprocess.StartInfo.下面的参数，如以无界面方式启动exe等
            myprocess.StartInfo.UseShellExecute = false;
            myprocess.Start();
            return true;
        }

        public static Process GetProcess(string name)
        {
            Process[] arrayP = Process.GetProcesses();
            foreach (Process item in arrayP)
            {
                if (item.ProcessName.Contains(name))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
