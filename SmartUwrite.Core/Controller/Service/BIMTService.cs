using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BIMTClassLibrary.Service
{
    public class BIMTService
    {
        public static string CallPostService(string postUrl, string postDataStr)
        {
            string _strResult = HttpTool.sendPost(postUrl, postDataStr);
            return _strResult;
        }

        /// <summary>
        /// 附加header信息
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="postDataStr"></param>
        /// <param name="p_strHeader"></param>
        /// <returns></returns>
        public static string CallPostService(string postUrl, string postDataStr, string p_strHeader)
        {
            string _strResult = HttpTool.sendPost(postUrl, postDataStr,  p_strHeader);
            return _strResult;
        }

        /// <summary>
        /// 附加header信息
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="DataStr"></param>
        /// <param name="p_strHeader"></param>
        /// <param name="addKey"></param>
        /// <returns></returns>
        public static string CallGetService(string postUrl, string postDataStr, string p_strHeader)
        {
            string _strResult = HttpTool.HttpGet(postUrl, postDataStr, p_strHeader);
            return _strResult;
        }

        
        public static string CallGetService(string postUrl, string DataStr, string p_strHeader, bool addKey)
        {
            string _strResult = HttpTool.HttpGet(postUrl, DataStr, p_strHeader, addKey);
            return _strResult;
        }
    }
}
