using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    [DataContractAttribute]
    class RecommendDataEntity
    {
        [DataMemberAttribute(Name = "words", IsRequired = false, Order = 0)]
        public string words = string.Empty;
        [DataMemberAttribute(Name = "docAmount", IsRequired = false, Order = 1)]
        public int docAmount = 50;

        public RecommendDataEntity(string words, int count)
        {
            this.words = words;
            this.docAmount = count;
        }

        public override string ToString()
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(this.GetType());
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream, this);
                byte[] dataBytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(dataBytes, 0, (int)stream.Length);
                return Encoding.UTF8.GetString(dataBytes);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(RecommendDataEntity), ex.Message);
                return string.Empty;
            }
        }
    }
}
