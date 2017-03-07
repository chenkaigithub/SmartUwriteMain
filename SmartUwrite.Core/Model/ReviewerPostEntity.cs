using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 获取用户使用推荐审稿人的信息
    /// wuhailong
    /// 2016-08-19
    /// </summary>
    public class ReviewerPostEntity : BasePostEntity
    {
        [DataMember(Name = "userId", IsRequired = false, Order = 0)]
        public string userId = string.Empty;
        [DataMember(Name = "kwTitle", IsRequired = false, Order = 0)]
        public string kwTitle = string.Empty;
        [DataMember(Name = "kwAbstr", IsRequired = false, Order = 0)]
        public string kwAbstr = string.Empty;
        [DataMember(Name = "kwKeyword", IsRequired = false, Order = 0)]
        public string kwKeyword = string.Empty;
        [DataMember(Name = "readers", IsRequired = false, Order = 0)]
        public List<ReviewerInfo> readers = null;
        [DataMember(Name = "createTime", IsRequired = false, Order = 0)]
        public string createTime = string.Empty;

        public ReviewerPostEntity(string userId, string kwTitle, string kwAbstr, string kwKeyword, List<ReviewerInfo> readers, string createTime)
        {
            try
            {
                this.userId = userId;
                this.kwTitle = kwTitle;
                this.kwAbstr = kwAbstr;
                this.kwKeyword = kwKeyword;
                this.readers = readers;
                this.createTime = createTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReviewerPostEntity( ) { }

       
    }
}
