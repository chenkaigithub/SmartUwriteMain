using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BIMTClassLibrary.rest
{
    class RestHelper
    {
        private string url;
        private string postData;
        private string header;

        public string SendPost()
        {
            CookieContainer cookie = null;
            HttpWebRequest request = null;
            Stream myRequestStream = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = 100;
                System.Net.ServicePointManager.Expect100Continue = false;
                //转化
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                cookie = new CookieContainer();
                //发送一个POST请求
                request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.CookieContainer = cookie;
                request.Timeout = 30000;
                request.Method = "POST";
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                //headers添加
                request.Headers.Add("BIMT-WA-KEY", header);
                myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byteArray, 0, byteArray.Length);
                myRequestStream.Close();
                //获取返回的内容
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                return myStreamReader.ReadToEnd();
            }
            catch (Exception)
            {
                Log4Net.LogHelper.WriteLog(typeof(RestHelper), url);
                throw;
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
        }


        public string SendGet()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (postData == "" ? "" : "?") + postData);
                request.Headers.Add("BIMT-WA-KEY", header);
                request.Timeout = 3000;
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
            catch (Exception )
            {
                throw;
            }

        }



        public string SendPut()
        {
            CookieContainer cookie = null;
            HttpWebRequest request = null;
            Stream myRequestStream = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = 100;
                System.Net.ServicePointManager.Expect100Continue = false;
                //转化
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                cookie = new CookieContainer();
                //发送一个POST请求
                request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.CookieContainer = cookie;
                request.Timeout = 30000;
                request.Method = "PUT";
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                //headers添加
                request.Headers.Add("BIMT-WA-KEY", header);
                myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byteArray, 0, byteArray.Length);
                myRequestStream.Close();
                //获取返回的内容
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                return myStreamReader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
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
        }


        public string SendDelete()
        {
            CookieContainer cookie = null;
            HttpWebRequest request = null;
            Stream myRequestStream = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = 100;
                System.Net.ServicePointManager.Expect100Continue = false;
                //转化
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                cookie = new CookieContainer();
                //发送一个POST请求
                request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.CookieContainer = cookie;
                request.Timeout = 30000;
                request.Method = "DELETE";
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                //headers添加
                request.Headers.Add("BIMT-WA-KEY", header);
                myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byteArray, 0, byteArray.Length);
                myRequestStream.Close();
                //获取返回的内容
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                return myStreamReader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
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
        }

        public RestHelper(string url, string postData, string header)
        {
            this.url = url;
            this.postData = postData;
            this.header = header;
        }
        public RestHelper(string url, string postData)
        {
            this.url = url;
            this.postData = postData;
        }
        public RestHelper(string url)
        {
            this.url = url;
        }
    }
}
