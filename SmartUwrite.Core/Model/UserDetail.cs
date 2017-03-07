using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BIMTClassLibrary.RefreshView
{
    [Obsolete("该类已经过时", true)]
    public class UserDetail
    {
        [JsonProperty("company")]
        private string company;
        [JsonProperty("degree")]
        private string degree;
        [JsonProperty("degreeName")]
        private string degreeName;
        [JsonProperty("department")]
        private string department;
        [JsonProperty("email")]
        private string email;
        [JsonProperty("firstCnname")]
        private string firstCnname;
        [JsonProperty("friendRanking")]
        private string friendRanking;
        [JsonProperty("id")]
        private string id;
        [JsonProperty("impactnum")]
        private string impactnum;
        [JsonProperty("introduction")]
        private string introduction;
        [JsonProperty("lastCnname")]
        private string lastCnname;
        [JsonProperty("loginName")]
        private string loginName;
        [JsonProperty("name")]
        private string name;
        [JsonProperty("professionalTitle")]
        private string professionalTitle;
        [JsonProperty("professionalTitleId")]
        private string professionalTitleId;
        [JsonProperty("tel")]
        private string tel;
        [JsonProperty("userImg")]
        private string userImg;
        [JsonProperty("expert")]
        private string expert;
        [JsonProperty("zxingImg")]
        private string zxingImg;
        [JsonProperty("expireDate")]
        private string expireDate;

        [JsonProperty("isPayment")]
        private string isPayment = "0";
        [JsonProperty("overDate")]
        private string overDate = "-1";
        [JsonProperty("token")]
        private string token;

        public string IsPayment
        {
            get { return isPayment; }
            private set { isPayment = value; }
        }

        public string Token
        {
            get { return token; }
            private set { token = value; }
        }

        public string OverDate
        {
            get { return overDate; }
            private set { overDate = value; }
        }
    }
}
