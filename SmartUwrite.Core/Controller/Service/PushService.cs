using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMT.Util.RestAPI;
using BIMT.Util.Serialiaze;

namespace BIMTClassLibrary.Upgrade.PushUpgrade
{
    class PushService
    {
        static string url = "http://bigdata.api.bimt.com/v1/writeAid/version";
        public static void DoWork(RequestEntity re)
        {
            string postData = SerialiazeClass.Serialiaze(re);
            RestHelper rest = new RestHelper(url, postData, string.Empty);
            rest.SendPost();
        }
    }
}
