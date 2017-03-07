using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BIMTClassLibrary.DocDatabase.Dao
{
    class AddCategoryRequestEntity
    {
        [JsonProperty("type")]
        string type;
        [JsonProperty("id")]
        string id;
        [JsonProperty("name")]
        string name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">C/D/R</param>
        /// <param name="id">C:id为userid，D/R:id为categoryid</param>
        /// <param name="name">删除操作此字段可为空，其他操作均需输入值</param>
        public AddCategoryRequestEntity(string type, string id, string name)
        {
            this.type = type;
            this.id = id;
            this.name = name;
        }
    }
}
