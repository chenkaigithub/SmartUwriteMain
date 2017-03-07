using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.token;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.magazine
{
    /// <summary>
    /// 杂事推荐的服务
    /// </summary>
    class MagazineService
    {
        private Magazine magazine;

        public MagazineService(Magazine magazine)
        {
            // TODO: Complete member initialization
            this.magazine = magazine;
        }
        /// <summary>
        /// 在线投稿功能
        /// wuhailong
        /// 2016-08-03
        /// </summary>
        public void OnlineSubmission()
        {
            try
            {
                string uValue = @"http://i.bimt.com/match?symbiosis={0}&periodical.id={1}&decode=";
                string symbiosis = "false";
                if (magazine.IsCol)
                {
                    symbiosis = "true";
                }

                string periodical = magazine.Id;
                uValue = string.Format(uValue, symbiosis, periodical);
                uValue = System.Web.HttpUtility.UrlEncode(uValue);
                //string url = "http://192.168.1.221/login?username={0}&token={1}&r_u={2}";
                string url = "http://i.bimt.com/login?username={0}&token={1}&r_u={2}";
                string token = TokenHelper.GetToken();
                url = string.Format(url, User.GetInstance().Detail.result.tel, token, uValue);
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
