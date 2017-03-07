using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.Model
{
    public class ProxyServer
    {
        [JsonProperty("server")]
        public string server;
        [JsonProperty("password")]
        public string password;
        [JsonProperty("server_port")]
        public int server_port;
    }

    public class ShadowSocksEntity : IEntity
    {

        public static string URL = string.Format("http://bigdata.api.bimt.com/v1/{0}", "/utils/google_scholar_sslist");
        [JsonProperty("configs")]
        List<ProxyServer> configs = new List<ProxyServer>();
        public string GetUrl()
        {
            return URL;
        }

        public List<ProxyServer> GetParams()
        {
            return configs;
        }
    }
}
