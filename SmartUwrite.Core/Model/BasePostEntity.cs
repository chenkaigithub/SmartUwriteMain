using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace BIMTClassLibrary
{
    public class BasePostEntity
    {
        public override string ToString()
        {
            DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                dataContractSerializer.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }



        public static Dictionary<string, object> ConvertJsonToDict(string json)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(json);
            }
            catch (Exception )
            {
                throw;
            }
        
        }

        public static string Serialiaze(object obj)
        {
            
            //DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(obj.GetType());
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    dataContractSerializer.WriteObject(ms, obj);
            //    return Encoding.UTF8.GetString(ms.ToArray());
            //}
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string json)
        {
            //return JsonConvert.DeserializeObject<T>(json);
            try
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                T objs = Serializer.Deserialize<T>(json);
                return objs;
            }
            catch (Exception)
            {

                throw;
            }
          
            //T obj = Activator.CreateInstance<T>();
            //using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            //{
            //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //    return (T)serializer.ReadObject(ms);
            //}
        }
    }
}
