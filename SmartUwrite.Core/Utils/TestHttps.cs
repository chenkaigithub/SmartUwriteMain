using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BaiduCang;
using System.IO;

namespace BIMTClassLibrary.Service
{
    public class TestHttps
    {
        public static string Test()
        {
            string loginUrl = "https://passport.baidu.com/?login";
            string userName = "userName";
            string password = "password";
            string tagUrl = "http://cang.baidu.com/" + userName + "/tags";
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("tpl", "fa");
            //parameters.Add("tpl_reg", "fa");
            //parameters.Add("u", tagUrl);
            //parameters.Add("psp_tt", "0");
            //parameters.Add("username", userName);
            //parameters.Add("password", password);
            //parameters.Add("mem_pass", "1");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse("https://192.168.1.52:8443/test.json", parameters, null, null, encoding, null);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
            string cookieString = response.Headers["Set-Cookie"];

            string _s = BIMTService.CallGetService("https://192.168.1.52:8443/test.json", string.Empty, string.Empty);
            return _s;
        }
    }
}
