using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using BIMT.Util.Serialiaze;

namespace BIMTClassLibrary.RefreshView
{
    public class UserService
    {
        private string userName;
        private string passWord;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="u">用户名</param>
        /// <param name="p">密码</param>
        public UserService(string u,string p) {
            userName = u;
            passWord = p;
        }
        //private  const string loginUrl = @"http://app.bimttest.com/mobile/user/signin?account={0}&password={1}";
        private static readonly string loginUrl = @"http://m.bimt.com/mobile/user/signin?account={0}&password={1}";
        //public UserDetail GetUser()
        //{
        //    try
        //    {
        //        //string url = string.Format(loginUrl, userName, passWord);
        //        string url = string.Format(loginUrl, "18910182735", "123456");
        //        RestHelper r = new RestHelper(url, string.Empty, string.Empty);
        //        string result = r.SendPost();
        //        ResponseEntity<UserDetail> ru = DeserialiazeClass.Deserialize<ResponseEntity<UserDetail>>(result);
        //        UserDetail u = ru.GetResponse();
        //        return u;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
