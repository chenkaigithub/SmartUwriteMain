using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.Upgrade.PushUpgrade
{
    class RequestEntity
    {
        public RequestEntity(int v,List<string> list) {
            updateVersion = v;
            updateInfo = list;
        }
        [JsonProperty("updateVersion")]
        int updateVersion;

       
        [JsonProperty("updateInfo")]
        List<string> updateInfo;

       
    }
}
