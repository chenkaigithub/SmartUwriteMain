using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BIMTClassLibrary.response
{
    [DataContract]
    public class ResponseState
    {
        [DataMember]
        private string code;
        [DataMember]
        private string msg;
        [DataMember]
        private object response;

        public ResponseState() { }

        private ResponseState(string code, string msg, object response)
        {
            this.code = code;
            this.msg = msg;
            this.response = response;
        }

        private ResponseState(string responseData)
        {
            try
            {
                ResponseState rs = JsonConvert.DeserializeObject<ResponseState>(responseData);
                code = rs.code;
                msg = rs.msg;
                response = rs.response;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            // TODO: Complete member initialization
            
        }

        /// <summary>
        /// 获取返回状态码
        /// 200正常
        /// </summary>
        /// <returns></returns>
        public bool GetResponseState(string responseData)
        {
            try
            {
                string code =JsonConvert.DeserializeObject<ResponseState>(responseData).code;
                if (code == "200")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取返回状态码
        /// 200正常
        /// </summary>
        /// <returns></returns>
        public string GetResponse(string responseData)
        {
            try
            {
                object response = JsonConvert.DeserializeObject<ResponseState>(responseData).response;
                return response.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static ResponseState GetResponseStateInstance(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseState>(json);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetCode()
        {
            return code;
        }
    }
}
