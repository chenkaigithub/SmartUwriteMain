using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.RefreshView
{
    class ResponseEntity<T>
    {
        [JsonProperty("code")]
        string code;
        [JsonProperty("message")]
        string msg;
        [JsonProperty("result")]
        T response;
        public T GetResponse()
        {
            return response;
        }
    }
}
