using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.WordTemplate
{
    class TemplateEntity
    {
        [JsonProperty("id")]
        public string id;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("quotationName")]
        public string quotationName;
        [JsonProperty("quotationUrl")]
        public string quotationUrl;
        [JsonProperty("templateName")]
        public string templateName;
        [JsonProperty("templateUrl")]
        public string templateUrl;
        [JsonProperty("ifvalue")]
        public string ifvalue;
        [JsonProperty("level")]
        public string level;
    }
}
