using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BIMTClassLibrary.style
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class UpdateStyleEntity:BaseResponseEntity
    {
        [DataMember]
        private string name;
        [DataMember]
        private string descptn;
        [DataMember]
        private string formats;

        public UpdateStyleEntity(string name, string descptn, string formats)
        {
            this.name = name;
            this.descptn = descptn;
            this.formats = formats;
        }

        /// <summary>
        /// 生成样式更新的json字符串
        /// wuhailog
        /// 2016-07-25
        /// </summary>
        /// <returns></returns>
        public string GetUpdatePostString()
        {
            try
            {
                return JsonConvert.SerializeObject(this);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
