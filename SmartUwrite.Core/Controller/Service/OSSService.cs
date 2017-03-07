using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using BIMT.Util.Oss;
using System.Windows.Forms;
using System.IO;
using Aliyun.OpenServices.OpenStorageService;
using BIMT.Util;

namespace BIMTClassLibrary.Controller.Service
{
    class OSSService : IUpdateStorage
    {
        public IViewCallback view;
        OssHelper helper;
        string bucketName;
        string dir;
        string[] files;
        public OSSService(IViewCallback view)
        {
            this.view = view;
            helper = new OssHelper(view);
        }

        public OSSService(IViewCallback view,string bucketName,string dir,string[] files)
        {
            this.view = view;
            helper = new OssHelper(view);
            this.bucketName = bucketName;
            this.dir = dir;
            this.files = files;
        }

        public List<string> GetContainers(dynamic param)
        {
            List<string> list = new List<string>();
            foreach (Bucket item in helper.GetBucketsList())
            {
                list.Add(item.Name);
            }
            return list;
        }

        public List<string> GetFileList(dynamic param)
        {
            string bucketName = param.containerName;
            if (bucketName == null)
            {
                throw new Exception("传参不存在containerName");
            }
            List<string> list = new List<string>();
            foreach (OssObjectSummary item in helper.GetObjectlist(bucketName))
            {
                list.Add(item.Key);
            }
            return list;
        }

        public string AddContainer(dynamic param)
        {
            string bucketName = param.containerName;
            if (bucketName == null)
            {
                throw new Exception("传参不存在containerName");
            }
            return helper.CreateBucket(bucketName);
        }

        public string DelContainer(dynamic param)
        {
            //string bucketName = param.containerName;
            //if (bucketName == null)
            //{
            throw new Exception("未实现");
            //}
            //return helper.d(bucketName);
        }

        private void UploadFile(dynamic param)
        {
            string bucketName = param.containerName;
            string filePath = param.path;
            string folder = param.folder;
            if (bucketName == null || param.path == null)
            {
                throw new Exception("传参不存在containerName or path");
            }
            if (File.Exists(filePath))
            {
                view.MyInvoke(helper.Mi, new object[] { 10, null });
                FileInfo info = new FileInfo(filePath);
                if (info.Length > 5 * 1024 * 1024)
                {
                    helper.mutiPartUpload(bucketName, string.Format("{0}{1}", folder, info.Name), filePath, 2);
                }
                else
                {
                    Stream stream = File.OpenRead(filePath);
                    view.MyInvoke(helper.Mi, new object[] { 999999, helper.UploadFile(bucketName, stream, string.Format("{0}{1}", folder, info.Name)) });
                }
                
            }
        }

        public string DelFile(dynamic param)
        {
            string bucketName = param.containerName;
            string name = param.fileName;
            if (bucketName == null || name == null)
            {
                throw new Exception("传参不存在fileName或containerName");
            }
            return helper.DeleteObject(bucketName, name);
        }

        public void UploadFile()
        {
            foreach (var item in files)
            {
                dynamic param = new System.Dynamic.ExpandoObject();
                param.containerName = bucketName;
                param.path = item;
                param.folder = dir;// GetFolder();
                UploadFile(param);
            }
        }
    }
}
