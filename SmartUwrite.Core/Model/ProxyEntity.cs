using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.Model
{
    class ProxyEntity
    {
        [JsonProperty("ip")]
        private string ip;

        public string Ip
        {
            get { return ip; }
        }
        [JsonProperty("port")]
        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

    }
}
