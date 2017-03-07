using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.RefreshView;
using Newtonsoft.Json;
using BIMT.Util.RestAPI;
using BIMT.Util.Configuration;
using System.Windows.Forms;

namespace BIMTClassLibrary.Model
{
    public class User
    {
        static string BASE_URL = ConfigurationHelper.GetConfig("literatureBaseUrl");
        private dynamic key;
        private dynamic detail;
        private static User user = new User();
        private User() { }
        public static User GetInstance()
        {
            if (user == null)
            {
                user = new User();
            }
            return user;
        }
        public dynamic Key
        {
            get
            {
                return key;
            }
        }
        public dynamic Detail
        {
            get
            {
                if (detail == null)
                {
                    throw new Exception("未执行 InitDetail 操作");
                }
                return detail;
            }
        }

        public void RefreshDetail()
        {
            InitDetail(userName, passWord);
        }

        string userName;
        string passWord;
        public void InitDetail(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
            string url = string.Format(@"http://m.bimt.com/mobile/user/signin?account={0}&password={1}", userName, passWord);
            RestHelper rest = new RestHelper(url, string.Empty, string.Empty);
            string result = rest.SendPost();
            detail = JsonConvert.DeserializeObject(result);
            string s = detail.result.company;
        }

        public void InitKey(string userName, string passWord)
        {
            string _url = string.Format(@"{0}/users/login", BASE_URL);
            dynamic _request = new System.Dynamic.ExpandoObject();
            _request.username = userName;
            _request.password = passWord;
            _request.timestamp = GetTimeStamp();
            string _postData = JsonConvert.SerializeObject(_request);
            string _result = new RestHelper(_url, _postData, string.Empty).SendPost();
            key = JsonConvert.DeserializeObject(_result);
        }

        public bool IsVip()
        {
            int ispay = Detail.result.isPayment;
            int overdate = Detail.result.overDate;
            if ((user.Key != null 
                && user.Key.id == "44909") 
                || 
                (user.Detail != null 
                && (ispay == 1 && overdate > 0)))
            {
                return true;
            }
            return false;
        }

        public bool IsAdmin()
        {
            if ((user.Key != null && user.Key.id == "44909"))
            {
                return true;
            }
            return false;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public void SetKeyNull()
        {
            key = null;
        }
    }
}
