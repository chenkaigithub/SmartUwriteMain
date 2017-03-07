using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Service;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using BIMTClassLibrary.response;
using System.Threading;
using BIMTClassLibrary.rest;
using BIMT.Util.Serialiaze;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using BIMT.Util.Configuration;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.styles
{
    public class StyleManager
    {

        public static string styleDir = PublicVar.StyleDir;
        private string _strDir;
        private string currentStyleId;
        private string currentStyleName;
        private string currentStyleContent;
        static StyleManager sm = null;

        private StyleManager() { }

        private StyleManager(string p)
        {
            styleDir = p;
        }

        private StyleManager(string currentStyleId,string currentStyleName, string currentStyleJson)
        {
            this.currentStyleId = currentStyleId;
            this.currentStyleName = currentStyleName;
            this.currentStyleContent = currentStyleJson;
        }

        public static StyleManager GetInstance(string currentStyleId, string currentStyleName, string currentStyleContent)
        {
            if (sm == null)
            {
                sm = new StyleManager(currentStyleId, currentStyleName, currentStyleContent);
                return sm;
            }
            sm.currentStyleId = currentStyleId;
            sm.currentStyleName = currentStyleName;
            sm.currentStyleContent = currentStyleContent;
            return sm;
        }


        

        //public StyleManager(global::Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1, string _strDir)
        //{
        //    // TODO: Complete member initialization
        //    this.comboBox1 = comboBox1;
        //    this._strDir = _strDir;
        //}

        /// <summary>
        /// 下载样式
        /// 2016-05-30
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public static int DownStyles()
        {
            string result = BIMTService.CallGetService(PublicVar.literatureBaseUrl + @"/templates", string.Empty, User.GetInstance().Key.WAKey);
            var quotations = CommonFunction.JsonToDictionary(result);
            ArrayList _arrayQuotation = (ArrayList)quotations["list"];
            Dictionary<string, object> _dictMeta = (Dictionary<string, object>)quotations["meta"];
            int count = 0;
            foreach (var item in _arrayQuotation)
            {
                Dictionary<string, object> _dictDid = (Dictionary<string, object>)item;
                string _strPath = PublicVar.BaseDir + "\\BIMT\\styles\\" + (_dictDid["name"] == null ? string.Empty : _dictDid["name"].ToString()) + ".json";
                string _strId = _dictDid["tid"] == null ? string.Empty : _dictDid["tid"].ToString();

                string content = BIMTService.CallGetService(PublicVar.literatureBaseUrl + @"/templates/" + _strId, string.Empty, User.GetInstance().Key.WAKey);
                Dictionary<string, object> contentObj = CommonFunction.JsonToDictionary(content);
                Dictionary<string, object> items = (Dictionary<string, object>)contentObj["formats"];
                string _strR = "{";
                _strR += "\"" + "TID" + "\":" + "\"" + _strId + "\",";
                foreach (string key in items.Keys)
                {
                    _strR += "\"" + key + "\":" + "\"" + items[key] + "\",";
                }
                _strR = _strR.Trim(',');
                _strR += "}";
                JsonReader reader = new JsonTextReader(new StringReader(content));

                File.WriteAllText(_strPath, _strR, Encoding.UTF8);
                count++;
            }
            return count;
        }

        public static void DownloadStyles1()
        {
            try
            {
                DownLoadStyles(styleDir);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(StyleManager), ex);
            }
          
        }

        private static RegistryKey OpenRegistryPath(RegistryKey root, string s)
        {
            s = s.Remove(0, 1) + @"\";
            while (s.IndexOf(@"\") != -1)
            {
                root = root.OpenSubKey(s.Substring(0, s.IndexOf(@"\")));
                s = s.Remove(0, s.IndexOf(@"\") + 1);
            }
            return root;
        }

        /// <summary>
        /// 将样式下载到指定目录
        /// </summary>
        /// <param name="downloadDir"></param>
        /// <returns></returns>
        public static int DownLoadStyles(string downloadDir)
        {
            RegistryKey folders;
            folders = OpenRegistryPath(Registry.CurrentUser, @"\software\microsoft\windows\currentversion\explorer\shell folders");
            downloadDir = folders.GetValue("Personal").ToString() + "\\BIMT\\styles\\";
            string header1 = User.GetInstance().Key.WAKey;
            RestHelper rh = new RestHelper(PublicVar.literatureBaseUrl + @"/templates", string.Empty, header1);
            string result = rh.SendGet();
            var styles = DeserialiazeClass.Deserialize<Dictionary<string, object>>(result);
            JArray array = (JArray)styles["list"];
            int count = 0;
            string styleName = string.Empty;
            foreach (var item in array)
            {
                try
                {
                    JToken dictStyleBaseInfo = (JToken)item;
                    styleName = (dictStyleBaseInfo["name"] == null ? string.Empty : dictStyleBaseInfo["name"].ToString());
                    styleName = styleName.Replace("--OK", string.Empty);
                    string _strPath = downloadDir + "\\" + styleName + ".json";
                    string styleId = dictStyleBaseInfo["tid"] == null ? string.Empty : dictStyleBaseInfo["tid"].ToString();
                    string url = PublicVar.literatureBaseUrl + @"/templates/" + styleId;
                    string postData = string.Empty;
                    string header = User.GetInstance().Key.WAKey;
                    string styleContent = new RestHelper(url, postData, header).SendGet();
                    Dictionary<string, object> contentObj = DeserialiazeClass.Deserialize<Dictionary<string, object>>(styleContent);
                    JObject response = (JObject)contentObj["response"];
                    JObject formats = (JObject)response["formats"];
                    formats.Remove("tid");
                    formats.Remove("TID");
                    formats.Add("TID", (JValue)styleId);
                    string jsonStyle2 = SerialiazeClass.Serialiaze(formats);
                    File.WriteAllText(_strPath, jsonStyle2, Encoding.UTF8);
                    count++;
                }
                catch (Exception ex)
                {
                    Log4Net.LogHelper.WriteLog(typeof(StyleManager), styleName + "样式下载失败");
                }
            }
            return count;
        }

        /// <summary>
        /// 获取下载目录
        /// wuhailong
        /// 2016-10-14
        /// </summary>
        /// <returns></returns>
        public static string GetDownLoadDir() {
            try
            {
                RegistryKey folders = OpenRegistryPath(Registry.CurrentUser, @"\software\microsoft\windows\currentversion\explorer\shell folders");
                string dir = string.Format("{0}\\BIMT\\styles\\", folders.GetValue("Personal").ToString());
                return dir;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        struct mate
        {
            public int count;
        }
        public struct Style
        {
            public string name;
            public string type;
            public string refJournalId;
            public string tid;
            public string refJournal;
        }
        struct StyleListResponsEntity
        {
            public mate mate;
            public List<Style> list;
        }
        public static List<Style> GetStyles()
        {
            RestHelper rh = new RestHelper(PublicVar.literatureBaseUrl + @"/templates", string.Empty, User.GetInstance().Key.WAKey);
            string result = rh.SendGet();
            StyleListResponsEntity slre = DeserialiazeClass.Deserialize<StyleListResponsEntity>(result);
            return slre.list;
        }

        /// <summary>
        /// 将样式下载到指定目录
        /// </summary>
        /// <param name="downloadDir"></param>
        /// <returns></returns>
        public static int DownLoadStyles()
        {

            //try
            //{

            //    string dir=GetDownLoadDir();
            //    string baseUrl=ConfigurationHelper.GetConfig("literatureBaseUrl");
            //    User user = User.GetInstance();
            //    List < Style > list= GetStyles();
            //    int count = 0;
            //    foreach (var item in list)
            //    {
            //        try
            //        {
            //            string path = string.Format("{0}\\{1}.json",dir,item.name);
            //            string id = item.tid;
            //            string url = string.Format("{0}/templates/{1}",baseUrl,id);
            //            string styleContent = new RestHelper(url, string.Empty, user.WaKey).SendGet();
            //            Dictionary<string, object> contentObj = DeserialiazeClass.Deserialize<Dictionary<string, object>>(styleContent);
            //            JObject response = (JObject)contentObj["response"];
            //            JObject formats = (JObject)response["formats"];
            //            formats.Remove("tid");
            //            formats.Remove("TID");
            //            formats.Add("TID", (JValue)id);
            //            string jsonStyle2 = SerialiazeClass.Serialiaze(formats);
            //            File.WriteAllText(path, jsonStyle2, Encoding.UTF8);
            //            count++;
            //        }
            //        catch (Exception ex)
            //        {
            //            Log4Net.LogHelper.WriteLog(typeof(StyleManager), styleName + "样式下载失败");
            //        }
            //    }
            //    return count;
            //}
            //catch (Exception ex)
            //{
            //    Log4Net.LogHelper.WriteLog(typeof(StyleManager), downloadDir + "样式下载失败");
            //    return -1;
            //}
            return 0;
      
        }

        /// <summary>
        /// 将当前样式上传到服务器
        /// wuhailong
        /// 2016-07-28
        /// </summary>
        /// <param name="name"></param>
        /// <param name="styleJson"></param>
        /// <returns></returns>
        public string AddStyle(string name, string styleJson)
        {
            try
            {
                string url = PublicVar.literatureBaseUrl + @"/templates";
                styleJson = CommonFunction.FixStyleJson(styleJson);
                string postData =
                "{"
                + "\"name\": \"" + name + "\","
                + "\"refJournalId\": \"" + string.Empty + "\","
                + "\"descptn\": \"" + string.Empty + "\","
                + "\"formats\":"
                + styleJson
                + "}";
                string header = User.GetInstance().Key.WAKey;
                string result = new RestHelper(url, postData, header).SendPost(); // HttpTool.sendPost(PublicVar.BaseUrl + @"/templates", postData, User.GetInstance().WaKey);
                //if (result == string.Empty)
                //{
                //    return true;
                //}
                return new ResponseState().GetResponse(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddStyle()
        {
            try
            {
                return AddStyle(currentStyleName, currentStyleContent);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 当前服务器是否存在此样式
        /// wuhailong
        /// 2016-07-28
        /// </summary>
        /// <returns></returns>
        public bool ExistStyle()
        {
            try
            {
                string url = PublicVar.literatureBaseUrl + "/templates/" + currentStyleId + "//check";
                string postData = string.Empty;
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendGet();
                return new ResponseState().GetResponseState(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 增加样式
        /// 2016-05-30
        /// wuhailong
        /// </summary>
        /// <param name="name"></param>
        /// <param name="refid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public  bool UpdateStyle()
        {
            try
            {
                //bool ok = ExistStyle();
                //if (!ok)//新增
                //{
                //    if (DialogResult.Yes==MessageBox.Show(null, "服务器未找到当前样式，是否新增到服务器？", "更新样式", MessageBoxButtons.YesNo))
                //    {
                //       return AddStyle();     
                //    }
                //    return false;
                //}
                //else//修改
                //{
                string url = PublicVar.literatureBaseUrl + @"/templates/" + currentStyleId;
                currentStyleContent = CommonFunction.FixStyleJson(currentStyleContent);
                string postData =
                  "{"
                  + "\"name\": \"" + currentStyleName + "\","
                  + "\"descptn\": \"" + string.Empty + "\","
                  + "\"formats\":"
                  + currentStyleContent
                  + "}";
                string header = User.GetInstance().Key.WAKey;
                string result = new RestHelper(url, postData, header).SendPut();// HttpTool.sendPut(PublicVar.BaseUrl + @"/templates/" + currentStyleId, postData, User.GetInstance().WaKey);
                return new ResponseState().GetResponseState(result);
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 将当前样式转化为公有
        /// </summary>
        /// <param name="currentStyleId"></param>
        /// <returns></returns>
        public  bool ConvertToPublic()
        {
            try
            {
                string postData =
                                          "{"
                                         + "\"publicOrPrivate\": true"
                                         + "}";
                string responseData = HttpTool.sendPut(PublicVar.literatureBaseUrl + @"/templates/" + currentStyleId + "/convert", postData, User.GetInstance().Key.WAKey);
                //ResponseState rs = ;// ResponseState.GetResponseStateInstance(responseData);
                return new ResponseState().GetResponseState(responseData);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        internal  bool ConvertToMy()
        {
            try
            {
                string postData = "{"
                                     + "\"publicOrPrivate\": false"
                                     + "}";
                string result = HttpTool.sendPut(PublicVar.literatureBaseUrl + @"/templates/" + currentStyleId + "/convert", postData, User.GetInstance().Key.WAKey);
                //ResponseState rs =; // ResponseState.GetResponseStateInstance(result);
                return new ResponseState().GetResponseState(result);
            }
            catch (Exception)
            {
                
                throw;
            }
            
           
        }

        public static void SynDownLoadStyles()
        {
            try
            {
                Thread t = new Thread(DownloadStyles1);
                t.Start();
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        /// <summary>
        /// 删除样式
        /// </summary>
        internal bool DeleteStyle()
        {
            try
            {
                string url = PublicVar.literatureBaseUrl+currentStyleId;
                string postData = string.Empty;
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendDelete();
                return new ResponseState().GetResponseState(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsStandardStyle()
        {
            try
            {
                string url = PublicVar.literatureBaseUrl + @"/templates/" + currentStyleId;
                string postData = string.Empty;
                string header = User.GetInstance().Key.WAKey;
                string content = new RestHelper(url, postData, header).SendGet(); //BIMTService.CallGetService(PublicVar.BaseUrl + @"/templates/" + TID.Text, string.Empty, User.GetInstance().WaKey);
                Dictionary<string, object> _dictDid = (Dictionary<string, object>)CommonFunction.JsonToDictionary(content);
                Dictionary<string, object> response = (Dictionary<string, object>)_dictDid["response"];
                string _strType = response["type"].ToString();
                if (_dictDid == null)
                {
                    return false;
                }
                if (_strType == "Standard")
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
    }
}
