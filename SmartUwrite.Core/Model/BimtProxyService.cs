using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using BIMT.Util.Serialiaze;

namespace BIMTClassLibrary.Model
{
    public class BimtProxyService:BaseProxy
    {
        string url = string.Format("http://bigdata.api.bimt.com/v1/{0}", "/utils/googleScholar");
        string postData = string.Empty;
        string header = string.Empty;

        public BimtProxyService()
        {
            try
            {
                RestHelper rh = new RestHelper(url, postData, header);
                string json = rh.SendGet();
                ResponseEntity<ProxyEntity> re = DeserialiazeClass.Deserialize<ResponseEntity<ProxyEntity>>(json);
                ip = re.GetResponse().Ip;
                port = re.GetResponse().Port;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public override string GetIp()
        {
            return ip;
        }

        public override string GetPort()
        {
            return port;
        }
    }
}
