using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Log4Net;
using BIMTClassLibrary.EditStyle;

namespace BIMTClassLibrary.Json
{
    public class JsonHelper
    {
        public static string m_strJsonDir = PublicVar.StyleDir;
        public static string m_strJsonPath = string.Empty;// m_strJsonDir + PublicVar.CurrentStyle + ".json";

        public JsonHelper(string p_strJsonPath) {
            m_strJsonPath = p_strJsonPath;
        }

        /// <summary>
        /// 测试读取json
        /// 2016-03-25
        /// wuhailong
        /// </summary>
        public static void TestJson() {
            string jsonText = @"{""input"" : ""value"", ""output"" : ""result""}";
            JObject jo = JObject.Parse(jsonText);
            string _s= jo["input"].ToString();
            string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();
        }

        public static JObject GetObj(string p_strJson)
        {
            try
            {
                JObject jo = JObject.Parse(p_strJson);
                return jo;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return null;
            }
          
        }



        /// <summary>
        /// 通过key获取对应的value
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <returns></returns>
        public static string GetValue(string p_strKey)
        {
            string _strStyleFile = string.Empty;
            try
            {
                JObject jo = JObject.Parse(PublicVar.CurrentStyleJsonString);
                string _s = jo[p_strKey].ToString();
                return _s;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), "样式：" + _strStyleFile + "\n 键 ：" + p_strKey + "\n异常：" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 通过key获取对应的value
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <returns></returns>
        public static string GetValue(string p_strKey,string p_strJson)
        {
            try
            {
                //string jsonText = System.IO.File.ReadAllText(m_strJsonPath, Encoding.UTF8);
                JObject jo = JObject.Parse(p_strJson);
                string _s = jo[p_strKey].ToString();
                return _s;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return null;
            }
        }




        /// <summary>
        /// 修改keydUI应的值
        /// 2016-03-31
        /// wuhailog
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        public static void UpdateValues(string p_strKey,string p_strValue) {
            try
            {
                string _strJsonPath = m_strJsonDir + MagazineStyle.GetInstance().Name + ".json";// @"C:\Users\jishu12\Desktop\style.json";
                string jsonText = System.IO.File.ReadAllText(_strJsonPath);
                JObject jo = JObject.Parse(jsonText);
                jo.Remove(p_strKey);
                jo.Add(p_strKey,p_strValue);
                string _strNewJson = jo.ToString();
                System.IO.File.WriteAllText(_strJsonPath, _strNewJson, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
            }
        }

        /// <summary>
        /// 修改keydUI应的值
        /// 2016-03-31
        /// wuhailog
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        public static string UpdateValuesByStyleJson(string p_strKey, string p_strValue,string p_strStyleJson)
        {
            try
            {
                //string _strJsonPath = m_strJsonPath;// @"C:\Users\jishu12\Desktop\style.json";
                string jsonText = p_strStyleJson;// System.IO.File.ReadAllText(_strJsonPath);
                JObject jo = JObject.Parse(jsonText);
                jo.Remove(p_strKey);
                jo.Add(p_strKey, p_strValue);
                return jo.ToString();
                //System.IO.File.WriteAllText(_strJsonPath, _strNewJson, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// 修改keydUI应的值
        /// 2016-03-31
        /// wuhailog
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        public static string UpdateValuesBySyleName(string p_strKey, string p_strValue, string p_strStyleName)
        {
            try
            {
                string _strJsonPath = m_strJsonDir + MagazineStyle.GetInstance().Name + ".json";// @"C:\Users\jishu12\Desktop\style.json";
                string jsonText = System.IO.File.ReadAllText(PublicVar.StyleDir+p_strStyleName);
                JObject jo = JObject.Parse(jsonText);
                jo.Remove(p_strKey);
                jo.Add(p_strKey, p_strValue);
                return jo.ToString();
                System.IO.File.WriteAllText(_strJsonPath, jsonText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(JsonHelper), ex);
                return string.Empty;
            }
        }

    }
}
