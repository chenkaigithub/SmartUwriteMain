using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.Json;
using BIMTClassLibrary.styles;
using BIMTClassLibrary.DocDatabase.Upload;
using Log4Net;
using BIMT.Util.Serialiaze;
using BIMT.Util.Configuration;
using Newtonsoft.Json;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.LogIn
{
    public class LoginService
    {
        string userName;
        string passWord;
         /// <summary>
        /// 
        /// </summary>
        /// <param name="p1">用户名</param>
        /// <param name="p2">密码</param>
        public LoginService(string puserName, string ppassWord)
        {
            userName = puserName;
            passWord = ppassWord;
        }

        public User GetUser()
        {
            User user = User.GetInstance();
            user.InitKey(userName, passWord);
            user.InitDetail(userName, passWord);
            return user;
        }
    }
}
