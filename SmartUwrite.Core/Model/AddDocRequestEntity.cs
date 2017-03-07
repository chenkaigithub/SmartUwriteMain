using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BIMTClassLibrary.DocDatabase.Doc
{
    //[Serializable]
    class AddDocRequestEntity
    {
        //[DataMember(Name = "userId", IsRequired = false, Order = 0)]
        [JsonProperty("userId")]
        string userId;
        //[DataMember(Name = "categoryName", IsRequired = false, Order = 0)]
        [JsonProperty("categoryName")]
        string categoryName;
        //[DataMember(Name = "doc", IsRequired = false, Order = 0)]
        [JsonProperty("doc")]
        Quotation doc;
        //Dictionary<string, object> doc;
        //string doc;
        //[usrName: NonSerializedAttribute()]

        public AddDocRequestEntity(string userid, string categoryName, string doc)
        {
            this.userId = userid;
            this.categoryName = categoryName;
            //this.doc = doc;
            this.doc = JsonConvert.DeserializeObject<Quotation>(doc);
            //this.doc = CommonFunction.JsonToDictionary(doc);
            //this.doc = CommonFunction.ConvertDictToJson(dic);
        }
    }
}
