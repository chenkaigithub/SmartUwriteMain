using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using BIMT.Util.Serialiaze;
using BIMTClassLibrary.rest;
using BIMT.Util.Configuration;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.LogIn
{
    [Obsolete("该类已经过时", true)]
    public class UserKey
    {
        static string BASE_URL = ConfigurationHelper.GetConfig("literatureBaseUrl");
        dynamic property = null;
        [JsonProperty("WAKey")]
        private string waKey = string.Empty;
        [JsonProperty("id")]
        private string id;

        private static UserKey user = new UserKey();
        private UserDetail detail = new UserDetail();
        private UserKey() { }
        public static UserKey GetInstance()
        {
            if (user == null)
            {
                user = new UserKey();
            }
            return user;
        }

        //public static UserKey GetUser(string userName, string passWord)
        //{
        //    string _url = string.Format(@"{0}/users/login", BASE_URL);
        //    dynamic _request = new System.Dynamic.ExpandoObject();
        //    _request.username = userName;
        //    _request.password = passWord;
        //    _request.timestamp = GetTimeStamp();
        //    string _postData = SerialiazeClass.Serialiaze(_request);
        //    string _result = new RestHelper(_url, _postData, string.Empty).SendPost();
        //    return DeserialiazeClass.Deserialize<UserKey>(_result);
        //}

        public UserDetail Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public UserDetail GetUserDetail()
        {
            string url = string.Empty;
            try
            {
                //string loginUrl = @"http://app.bimttest.com/mobile/user/signin?account={0}&password={1}";
                string loginUrl = @"http://m.bimt.com/mobile/user/signin?account={0}&password={1}";
                url = string.Format(loginUrl, user.loginEntity.username, user.loginEntity.password);
                //string url = string.Format(loginUrl, "18910182735", "123456");
                RestHelper r = new RestHelper(url, string.Empty, string.Empty);
                string result = r.SendPost();
                ResponseEntity<UserDetail> ru = DeserialiazeClass.Deserialize<ResponseEntity<UserDetail>>(result);
                Detail = ru.GetResponse();
                //Log4Net.LogHelper.WriteLog(typeof(User), "###" + url);
                return Detail;
            }
            catch (Exception)
            {
                Log4Net.LogHelper.WriteLog(typeof(UserKey), "GetUserDetail");
                throw;
            }
        }

        //public static void SetInstance(UserKey puser)
        //{
        //    user = puser;
        //}


        public static void SetNull()
        {
            if (user != null)
            {
                user = null;
            }
        }


       

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty("userName")]
        private string userName;

        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }
        [JsonProperty("phone")]
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        [JsonProperty("email")]
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }



        private string nickName;

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public string WaKey
        {
            get { return waKey; }
            set { waKey = value; }
        }

        public bool IsVip()
        {
            //UserDetail detail = GetUserDetail();
            //if (Detail != null && Detail.result.IsPayment == "1" && int.Parse(Detail.result.OverDate) > 0)
            //{
            //    return true;
            //}
            return false;
        }


        static string baseUrl = ConfigurationHelper.GetConfig("literatureBaseUrl");
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public struct loginReguestEntity
        {
            public string username;
            public string password;
            public string timestamp;
        }
        private loginReguestEntity loginEntity = new loginReguestEntity();

        public loginReguestEntity LoginEntity
        {
            get { return loginEntity; }
            private set { loginEntity = value; }
        }

        struct NickNameEntity
        {
            [JsonProperty("nickname")]
            public string nickname;
            [JsonProperty("userLevel")]
            public string userLevel;
        }

        /// <summary>
        /// 获取用户
        /// wuhailong
        /// 2016-06-24
        /// </summary>
        public static UserKey GetUser(string userName, string passWord)
        {
            try
            {
                string url = string.Format("{0}/users/login", baseUrl);
                user.LoginEntity = new loginReguestEntity();
                user.loginEntity.username = userName;
                user.loginEntity.password = passWord;
                user.loginEntity.timestamp = GetTimeStamp();
                string postData = SerialiazeClass.Serialiaze(user.LoginEntity);
                string result = new RestHelper(url, postData, string.Empty).SendPost();
                user = DeserialiazeClass.Deserialize<UserKey>(result);
                user.loginEntity.username = userName;
                user.loginEntity.password = passWord;
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取用户nickname
        /// wuhailong
        /// 2016-10-14
        /// </summary>
        /// <returns></returns>
        public string GetNickName()
        {
            return null;
            //try
            //{
            //    string url = String.Format("{0}/users/me", baseUrl);
            //    string header = UserKey.GetInstance().ke.WAKey;
            //    string result = new RestHelper(url, string.Empty, header).SendGet();
            //    NickNameEntity nn = DeserialiazeClass.Deserialize<NickNameEntity>(result);
            //    UserKey.GetInstance().NickName = nn.nickname;
            //    return nn.nickname;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
