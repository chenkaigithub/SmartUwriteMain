using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Log4Net;
using System.IO.Compression;
using System.Windows.Forms;


namespace BIMTClassLibrary.Service
{
    class HttpTool
    {


        /// <summary>
        /// 获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="referUrl">请求引用地址</param>
        /// <param name="data">请求带的数据</param>
        /// <returns>响应内容</returns>
        public static string PostRequest(string postUrl, string referUrl, string data)
        {
            string result = "";
            try
            {
                //命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //参照浏览器的请求报文 封装需要的参数 这里参照ie9
                //浏览器可接受的MIME类型
                request.Accept = "text/plain, */*; q=0.01";
                //包含一个URL，用户从该URL代表的页面出发访问当前请求的页面
                request.Referer = referUrl;
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                request.ContentType = "application/json; charset=utf-8";
                //请求方式
                request.Method = "POST";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                //表示请求消息正文的长度
                request.ContentLength = data.Length;

                Stream postStream = request.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(data);
                //将传输的数据，请求正文写入请求流
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();
                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //判断响应的信息是否为压缩信息 若为压缩信息解压后返回
                if (response.ContentEncoding == "gzip")
                {
                    MemoryStream ms = new MemoryStream();
                    GZipStream zip = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    byte[] buffer = new byte[1024];
                    int l = zip.Read(buffer, 0, buffer.Length);
                    while (l > 0)
                    {
                        ms.Write(buffer, 0, l);
                        l = zip.Read(buffer, 0, buffer.Length);
                    }
                    ms.Dispose();
                    zip.Dispose();
                    result = Encoding.UTF8.GetString(ms.ToArray());
                }
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(HttpTool), ex);
                return ex.ToString();
            }
        }

        public static string HttpGet(string Url, string postDataStr, string p_strHeader)
        {
            return HttpGet(Url, postDataStr, p_strHeader, true);
            //try
            //{
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            //    request.Headers.Add("BIMT-WA-KEY", p_strHeader);
            //    request.IsVIP = "GET";
            //    request.ContentType = "application/json; charset=utf-8";

            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    Stream myResponseStream = response.GetResponseStream();
            //    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //    string retString = myStreamReader.ReadToEnd();
            //    myStreamReader.Close();
            //    myResponseStream.Close();

            //    return retString;
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(HttpTool), ex);
            //    return ex.ToString();
            //}
           
        }

        public static string HttpGet(string Url, string DataStr, string p_strHeader ,bool addKey)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (DataStr == "" ? "" : "?") + DataStr);
                if (addKey)
                {
                    request.Headers.Add("BIMT-WA-KEY", p_strHeader);
                }
               
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(HttpTool), ex);
                return "-1";
            }

        }

        /// <summary>
        /// 模拟POST访问
        /// </summary>
        /// <param name="postUrl">模拟POST的URL</param>
        /// <param name="postDataStr">需要POST的数据</param>
        /// <returns>模拟访问的网页源代码</returns>
        public static string BIMTHttpRequest(string postUrl, string postDataStr,string p_strHeader,string p_reqMethod)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            System.Net.ServicePointManager.Expect100Continue = false;

            //用来存放cookie
            CookieContainer cookie = null;
            HttpWebRequest request = null;
            Stream myRequestStream = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                
                //转化
                byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr);
                cookie = new CookieContainer();
                //发送一个POST请求
                request = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                request.CookieContainer = cookie;
                request.Timeout = 30000;
                request.Method = p_reqMethod;
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                //headers添加
                request.Headers.Add("BIMT-WA-KEY", p_strHeader);
                if (p_reqMethod == "POST" || p_reqMethod == "PUT")
                {
                    myRequestStream = request.GetRequestStream();
                    myRequestStream.Write(byteArray, 0, byteArray.Length);
                    myRequestStream.Close();
                }
                //获取返回的内容
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                return myStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("405"))
                {
                    LogHelper.WriteLog(typeof(HttpTool), "没有权限");
                    //MessageBox.Show("用户未登录");
                }
                else
                {
                    LogHelper.WriteLog(typeof(HttpTool), ex);
                }
               
            }
            finally
            {
                if (myStreamReader != null)
                {
                    myStreamReader.Close();
                }
                if (myResponseStream != null)
                {
                    myResponseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return "-1";
        }


        /// <summary>
        /// 模拟POST访问
        /// </summary>
        /// <param name="postUrl">模拟POST的URL</param>
        /// <param name="postDataStr">需要POST的数据</param>
        /// <returns>模拟访问的网页源代码</returns>
        public static string sendPost(string postUrl, string postDataStr)
        {
            return BIMTHttpRequest(postUrl, postDataStr, string.Empty,"POST");
            //System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            //System.Net.ServicePointManager.Expect100Continue = false;

            ////用来存放cookie
            //CookieContainer cookie = null;
            //HttpWebRequest request = null;
            //Stream myRequestStream = null;
            //HttpWebResponse response = null;
            //Stream myResponseStream = null;
            //StreamReader myStreamReader = null;
            //try
            //{

            //    //转化
            //    byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr);
            //    cookie = new CookieContainer();
            //    //发送一个POST请求
            //    request = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            //    request.CookieContainer = cookie;
            //    request.Timeout = 30000;
            //    request.IsVIP = "POST";
            //    //request.ContentType = "application/x-www-form-urlencoded";
            //    request.ContentType = "application/json; charset=utf-8";
            //    request.ContentLength = byteArray.Length;
            //    //headers添加
            //    //request.Headers.Add("BIMT-WAKEY", "");
            //    myRequestStream = request.GetRequestStream();
            //    myRequestStream.Write(byteArray, 0, byteArray.Length);
            //    myRequestStream.Close();
            //    //获取返回的内容
            //    response = (HttpWebResponse)request.GetResponse();
            //    response.Cookies = cookie.GetCookies(response.ResponseUri);
            //    myResponseStream = response.GetResponseStream();
            //    myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //    return myStreamReader.ReadToEnd();
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(HttpTool), ex);
            //}
            //finally
            //{
            //    if (myStreamReader != null)
            //    {
            //        myStreamReader.Close();
            //    }
            //    if (myResponseStream != null)
            //    {
            //        myResponseStream.Close();
            //    }
            //    if (response != null)
            //    {
            //        response.Close();
            //    }
            //    if (request != null)
            //    {
            //        request.Abort();
            //    }
            //}
            //return "";
        }

        public static string sendPut(string postUrl, string postDataStr, string pheader)
        {
            return BIMTHttpRequest(postUrl, postDataStr, pheader, "PUT");
        }

        public static string sendPost(string postUrl, string postDataStr,string pheader)
        {
            return BIMTHttpRequest(postUrl, postDataStr, pheader, "POST");
        }
        /// <summary>
        /// 模拟GET访问
        /// </summary>
        /// <param name="getUrl">模拟GET的URL</param>
        /// <returns>模拟访问的网页源代码</returns>
        public static string SendGet(string getUrl)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(getUrl);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = 3000;
                response = (HttpWebResponse)request.GetResponse();
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                return myStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("getUrl = " + getUrl + "  Exception" + ex);
            }
            finally
            {
                if (myStreamReader != null)
                {
                    myStreamReader.Close();
                }
                if (myResponseStream != null)
                {
                    myResponseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }

            return "-1";
        }
    }
}