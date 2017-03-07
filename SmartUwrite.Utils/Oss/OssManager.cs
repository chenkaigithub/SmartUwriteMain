using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.OpenServices.OpenStorageService;
using BIMT.Util.Configuration;

namespace BIMT.Util.Oss
{
    class OssManager
    {
        private static string _accessId = "pvKCnFrty5c0g48B";//ConfigurationHelper.GetConfig("_accessId");// = 
        private static string _accessKey = "xANkSRfCk3FLu5MAlVVKFyY4hFJJkc";
        private static string _http =  "http://oss-cn-hangzhou.aliyuncs.com";

        private static OssClient ossClient;

        public static OssClient GetInstance()
        {
            if (ossClient == null)
            {
                ossClient = new OssClient(_http, _accessId, _accessKey);
            }
            return ossClient;
        }

        
    }
}
