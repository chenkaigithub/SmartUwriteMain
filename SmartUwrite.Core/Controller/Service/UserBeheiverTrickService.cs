using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security.Policy;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.userBeheiverTrick
{
    /// <summary>
    /// 用户行为跟踪服务
    /// </summary>
    public class UserBeheiverTrickService : IDisposable
    {
        Thread t = null;
        string ip = string.Empty;
        string mac = string.Empty;
        //string userId = string.Empty;
        //string source = string.Empty;
        //string module = string.Empty;
        //string searchStr = string.Empty;

        public UserBeheiverTrickService()
        {
            try
            {
                IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
                ip = IpEntry.AddressList[0].ToString();
                List<string> listMac = GetMacByIPConfig();
                mac = listMac.Count > 0 ? listMac[0] : string.Empty;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(UserBeheiverTrickService), ex);
            }
        }

        string module; string searchStr;string source;
        /// <summary>
        ///  异步执行用户行为反馈
        /// wuhailong
        /// 2016-08-03
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="searchStr">所搜词条</param>
        public void SynDoTrick(string _module, string _source, string _searchStr)
        {
            try
            {
                source = _source;
                module = _module;
                searchStr = _searchStr;
                t = new Thread(SendUserInstall);
                t.Start();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(UserBeheiverTrickService), ex);
            }
        }

        public void SendUserTrick()
        {
            try
            {
                searchStr = searchStr.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                string url =  "http://bigdata.api.bimt.com/v1//utils/gatherData";
                User user = User.GetInstance();
                string postData = "{"
                                + "\"iPAddr\":\"" + ip + "\","
                                + "\"mac\":\"" + mac + "\","
                                + "\"userId\":\"" + (user.Key == null ? string.Empty : user.Key.id) + "\","
                                + "\"timeStamp\":\""+DateTime.Now.ToString()+"\","
                                + "\"source\":\""+source+"\","
                                + "\"module\":\"" + module + "\","
                                + "\"searchStr\":\"" + searchStr + "\""
                                + "}";
                postData = System.Web.HttpUtility.UrlEncode(postData);
                string header = string.Empty;
                string result = new RestHelper(url, postData, header).SendPost();
                //t.Abort();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendUserInstall()
        {
            try
            {
                searchStr = searchStr.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                string url = "http://bigdata.api.bimt.com/v1//utils/gatherData";
                string postData = "{"
                                + "\"iPAddr\":\"" + ip + "\","
                                + "\"mac\":\"" + mac + "\","
                                + "\"userId\":\"" +string.Empty + "\","
                                + "\"timeStamp\":\"" + DateTime.Now.ToString() + "\","
                                + "\"source\":\"" + source + "\","
                                + "\"module\":\"" + module + "\","
                                + "\"searchStr\":\"" + searchStr + "\""
                                + "}";
                postData = System.Web.HttpUtility.UrlEncode(postData);
                string header = string.Empty;
                string result = new RestHelper(url, postData, header).SendPost();
                //t.Abort();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        /// 根据截取ipconfig /all命令的输出流获取网卡Mac
        ///</summary>
        ///<returns></returns>
        public static List<string> GetMacByIPConfig()
        {
            try
            {
                List<string> macs = new List<string>();
                ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;
                Process p = Process.Start(startInfo);
                //截取输出流
                StreamReader reader = p.StandardOutput;
                string line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        line = line.Trim();

                        if (line.StartsWith("Physical Address"))
                        {
                            macs.Add(line);
                        }
                    }

                    line = reader.ReadLine();
                }

                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
                reader.Close();

                return macs;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public void Dispose()
        {
            if (t!=null)
            {
                //t.Abort();
            }
        }
    }
}
