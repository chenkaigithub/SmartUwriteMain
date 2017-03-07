using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMT.Util.Serialiaze;
using BIMTClassLibrary.rest;
using System.Data;
using System.Net;
using System.IO;
using System.Diagnostics;
using Aliyun.OpenServices.OpenStorageService;

namespace BIMTClassLibrary.WordTemplate
{
    class TemplateService : BaseTemplate
    {

        public TemplateService() : base() { }
        public override DataTable GetSource()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Columns.Add("templateUrl");
                dt.Columns.Add("ifvalue");
                dt.Columns.Add("level");
                dt.Columns.Add("templateName");
                dt.Columns.Add("text");
                dt.Columns.Add("quotationName");
                dt.Columns.Add("quotationUrl");
                //dt.Columns.Add();
                //dt.Columns.Add();
                //string url = "http://j.bimttest.com/api/smartWrite/periodicals?BimtAPI=BIMT_PERIODICAL";
                string url = "http://j.bimt.com/api/smartWrite/periodicals?BimtAPI=BIMT_PERIODICAL";
                string header = string.Empty;
                string postData = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);

                string json = rh.SendGet();
                List<TemplateEntity> list = DeserialiazeClass.Deserialize<List<TemplateEntity>>(json);
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        dt.Rows.Add(item.id,
                            item.name,
                            item.templateUrl,
                            item.ifvalue,
                            item.level,
                            item.templateName,
                            item.templateUrl==string.Empty?"--":"期刊模板."+item.templateUrl.Split('.')[1],
                            item.quotationName,
                            item.quotationUrl);
                    }
                }
                
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// oss下载文件
        /// </summary>
        public static void OssDownloadFile(string key, string path)
        {
            try
            {
                OssClient client = OssManager.GetInstance();
                OssObject obj = client.GetObject("bimt-resource", key);
                if (obj != null)
                {

                    // Object流处理   
                    int numBytesRead = 0;
                    int numBytesToRead = (int)obj.Metadata.ContentLength;
                    byte[] bytes = new byte[numBytesToRead];
                    FileStream fs = new FileStream(path, FileMode.Create);
                    // 将流写入本地文件保存   
                    while (numBytesToRead > 0)
                    {
                        int n = obj.Content.Read(bytes, numBytesRead, Math.Min(numBytesToRead, int.MaxValue));
                        if (n <= 0)
                        { break; }
                        fs.Write(bytes, numBytesRead, n);
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    fs.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override void OpenTemplate(string name, string url)
        {
            try
            {
                string path= Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\BIMT\\template\\" + name;
                OssDownloadFile(url, path);
                if (File.Exists(path))
                {
                    string newPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+name;
                    File.Copy(path, newPath, true);
                    if (File.Exists(newPath))
                    {
                        Process.Start(newPath);
                    }
                    else
                    {
                        Log4Net.LogHelper.WriteLog(typeof(Demo), "复制文件失败！");
                    }

                }
                else
                {
                    Log4Net.LogHelper.WriteLog(typeof(Demo), "文件不存在！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override void OpenLink(string name)
        {
            try
            {
                System.Diagnostics.Process.Start(string.Format("http://j.bimt.com/periodical/{0}.html", name));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
