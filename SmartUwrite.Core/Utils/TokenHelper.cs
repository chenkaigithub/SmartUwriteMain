using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.response;

namespace BIMTClassLibrary.token
{
    /// <summary>
    /// 生成token帮助类
    /// </summary>
    class TokenHelper
    {
        /// <summary>
        /// 获取token
        /// wuhailong
        /// 2016-08-03
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            try
            {
                string url = PublicVar.recommandBaseUrl + @"/utils/token/";
                string postData = string.Empty;
                string header = string.Empty;
                string response = new RestHelper(url, postData, header).SendGet();
                return new ResponseState().GetResponse(response);//.GetResponseState(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
