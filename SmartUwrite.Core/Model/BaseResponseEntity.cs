using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary
{
    public class BaseResponseEntity
    {
        /// <summary>
        /// 通过json传获取序列化实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T GetInstance<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ConvertEntityToJson<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);//<T>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
