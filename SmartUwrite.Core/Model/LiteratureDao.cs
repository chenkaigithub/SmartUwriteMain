using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;

namespace BIMTClassLibrary.DocDatabase.Doc
{
    public class LiteratureDao : BaseDocManager,IBaseDao<LiteratureDao>
    {
        string userId;
        string categoryName;
        string doc;

        /// <summary>
        /// 添加文献
        /// wuhailong
        /// 2016-09-13
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="categoryName">类别名称</param>
        /// <param name="doc">文档串</param>
        public LiteratureDao(string userId,string categoryName, string doc)
        {
            this.userId = userId;
            this.categoryName = categoryName;
            this.doc = doc;
        }

        /// <summary>
        /// 查询文献
        /// </summary>
        /// <param name="categoryName">类别名称</param>
        /// <param name="userId">用户id</param>
        public LiteratureDao(string categoryName, string userId)
        {
            this.categoryName = categoryName;
            this.userId = userId;
        }

        public List<string> Query()
        {
            try
            {
                List<string> list = new List<string>();
                List<Quotation> quotations = QueryQuotation();
                foreach (var item in quotations)
                {
                    list.Add(item.title);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Quotation> QueryQuotation()
        {
            try
            {
                string url = string.Format("{0}/rest/document/category/{1}/{2}", BaseUrl, categoryName, userId);
                string postData = string.Empty;
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendGet();
                AddLiteratureResponseEntity lre = Deserialize<AddLiteratureResponseEntity>(result);
                List<Quotation> quotations = Deserialize<List<Quotation>>(lre.result);
                return quotations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Add()
        {
            try
            {
                List<string> list = new List<string>();
                string url = string.Format("{0}/rest/document/save", BaseUrl);
                AddDocRequestEntity request = new AddDocRequestEntity(userId, categoryName, doc);
                string postData = Serialiaze(request);
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendPost();
                AddDocResponseEntity cre = Deserialize<AddDocResponseEntity>(result);
                return cre.result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool Upgrade()
        {
            throw new NotImplementedException();
        }

        public bool Del()
        {
            throw new NotImplementedException();
        }


        public object GetDetail()
        {
            throw new NotImplementedException();
        }

        List<LiteratureDao> IBaseDao<LiteratureDao>.Query()
        {
            throw new NotImplementedException();
        }

        LiteratureDao IBaseDao<LiteratureDao>.GetDetail()
        {
            throw new NotImplementedException();
        }


        public bool Add(LiteratureDao t)
        {
            throw new NotImplementedException();
        }

        public bool Upgrade(LiteratureDao t)
        {
            throw new NotImplementedException();
        }

        public bool Del(LiteratureDao t)
        {
            throw new NotImplementedException();
        }
    }
}
