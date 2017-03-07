using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace BIMTClassLibrary.DocDatabase
{
    class CatagoryRequestEntity
    {
        [JsonProperty("userId")]
        string userId = string.Empty;
        [JsonProperty("account")]
        string account = string.Empty;
        [JsonProperty("mobile")]
        string mobile = string.Empty;
        [JsonProperty("email")]
        string email = string.Empty;

        public CatagoryRequestEntity(string userId, string account, string mobile, string email)
        {
            try
            {
                this.userId = userId;
                this.account = account;
                this.mobile = mobile;
                this.email = email;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
