using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Microsoft.Win32;
using 比美特医护在线.比美特写作助手;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using BIMTClassLibrary.rest;
using Log4Net;
using BIMTClassLibrary.upgrade;
using BIMTClassLibrary.Upgrade.CheckUpgrade;
using BIMT.Util.ExeProcess;

namespace BIMTClassLibrary.Upgrade
{
    public class UpgradeService
    {


        private static string m_strDirInfo = string.Empty;
        private bool autoFlag;

        public UpgradeService(bool autoFlag)
        {
            // TODO: Complete member initialization
            this.autoFlag = autoFlag;
        }

        public bool IsIgnore()
        {
            try
            {
                string s = CommonFunction.GetConfig("IgnoreCurVersion");
                if (s == "TRUE")
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetCurrentVersion()
        {
            string url = PublicVar.recommandBaseUrl + "/writeAid/version";
            string postData = string.Empty;
            string header = string.Empty;
            string result = new RestHelper(url, postData, header).SendGet();
            UpgradeEntity ue = BasePostEntity.Deserialize<UpgradeEntity>(result);
            return ue.response.updateVersion;
        }

        public void Update(List<string> info)
        {
            string path = string.Format("{0}\\BIMT\\update\\SmartUwriteUpdate.exe", PublicVar.BaseDir);
            string[] arg = new string[info.Count];
            for (int i = 0; i < info.Count; i++)
            {
                arg[i] = info[i];
            }
            ProcessHelper.StartProcess(path, arg);
        }

        public void DoWord()
        {
            try
            {
                string url = PublicVar.recommandBaseUrl + "/writeAid/version";
                string postData = string.Empty;
                string header = string.Empty;
                string result = new RestHelper(url,postData,header).SendGet();
                //var updateInfo = CommonFunction.JsonToDictionary(result);
                UpgradeEntity ue = BasePostEntity.Deserialize<UpgradeEntity>(result);
                if (autoFlag)
                {
                    if (double.Parse(ue.response.updateVersion) > PublicVar.Verstion && !IsIgnore())
                    {//自动检查更新
                        Update(ue.response.updateInfo);
                        //frmUpgradeInfo ui = new frmUpgradeInfo(ue.response.updateInfo, autoFlag);
                        //ui.ShowDialog();
                    }
                }
                else
                {
                    if (double.Parse(ue.response.updateVersion) > PublicVar.Verstion)
                    {//手动更新
                        Update(ue.response.updateInfo);
                        //frmUpgradeInfo ui = new frmUpgradeInfo(ue.response.updateInfo, autoFlag);
                        //ui.ShowDialog();
                    }
                    else if (double.Parse(ue.response.updateVersion) <= PublicVar.Verstion)
                    {//手动更新,无需更新
                        frmCheckInfo frm = new frmCheckInfo(PublicVar.Verstion.ToString());
                        frm.ShowDialog();
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        //private bool BeginInvoke(InitItemInvoke mi, object[] p)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 异步检查更新
        /// wuhailong
        /// 2016-08-19
        /// </summary>
        /// <returns></returns>
        public void SynCheckUpdate()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(UpgradeService), ex);
            }
        }
        /// <summary>
        /// 获取软件更新的dir
        /// wuhailong
        /// 2016-07-20
        /// </summary>
        /// <returns></returns>
        private static string GetDownloadDir()
        {
            try
            {//D:/GitLab/wordplugin-frontend/BIMTWordAddIn/bin/Debug/
                //RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"D:/GitLab/wordplugin-frontend/BIMTWordAddIn/bin/Debug\");
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\Word\Addins\比美特医护在线.BIMT写作助手\");
                string _strInfo = regkey.GetValue("Manifest").ToString();//.Substring(la);
                regkey.Close();
                string _strDirInfo = _strInfo.Remove(_strInfo.LastIndexOf('\\'));
                m_strDirInfo = _strDirInfo;
                return _strDirInfo;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(UpgradeService), "未获取到软件安装路径"+ex);
                return null;
            }
        }

        /// <summary>
        /// 执行更新操作
        /// wuhailog
        /// 2016-07-20
        /// </summary>
        public static void DoUpgrade()
        {
            try
            {
                string _strUpgradeDir = GetDownloadDir();
                FtpHelper fw = new FtpHelper("192.168.1.20", "", "jishu12", "wozuishuai");
                string[] _arrayFiles = fw.GetFilesDetailList();

                fw.Download(_strUpgradeDir, "temp.ini");

                if (NeedUpgrade(_arrayFiles))
                {
                    foreach (string item in _arrayFiles)
                    {
                        if (item.Trim() == "Resources")
                        {
                            continue;
                        }
                        fw.Download(_strUpgradeDir, item.Trim());
                    }
                    MessageBox.Show(null, "插件已经更新完成，请重启word体验新功能！", "程序更新");
                }
                
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(UpgradeService), "更新失败" + ex);
            }
        }

       /// <summary>
       /// 通过判断更新的目录中是否存在UPGRADE文件来检查是否需要更新；
       /// </summary>
       /// <param name="p_arrayFiles"></param>
       /// <returns></returns>
        private static bool NeedUpgrade(string[] p_arrayFiles) {
            try
            {
                FileInfo fi = new FileInfo(m_strDirInfo + "\\temp.ini");
                string _strNewVersion = ReadIniData("SoftWare", "version", "1.0.0.1", m_strDirInfo + "\\temp.ini");
                string _strCurrentVersion = ReadIniData("SoftWare", "version", "1.0.0.1", m_strDirInfo + "\\version.ini");
                if (_strCurrentVersion!=_strNewVersion)
                {
                    return true;
                }
                return false;
                //foreach (string item in p_arrayFiles)
                //{
                //    if (item=="UPGRADE")
                //    {
                //        Log4Net.LogHelper.WriteLog(typeof(UpgradeService), "检测到UPGRADE文件程序需要更新！" );
                //        return true;
                //    }
                //}
                //return false;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(UpgradeService), "检测失败" + ex);
                return false;
            }
        }

        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
