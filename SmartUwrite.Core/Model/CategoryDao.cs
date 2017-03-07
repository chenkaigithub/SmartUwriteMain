using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.DocDatabase.Dao;

namespace BIMTClassLibrary.DocDatabase
{
    class CategoryDao : BaseDocManager, IBaseDao<CategoryDao>
    {
        string userId, userName, userPhone, userEmail,categoryName;

        /// <summary>
        /// 查询分类
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="userPhone"></param>
        /// <param name="userEmail"></param>
        public CategoryDao(string userId, string userName, string userPhone, string userEmail)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPhone = userPhone;
            this.userEmail = userEmail;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="categoryName">类别名称</param>
        public CategoryDao(string userId, string categoryName)
        {
            this.userId = userId;
            this.categoryName = categoryName;
        }

        public bool Add()
        {
            try
            {
                AddCategoryRequestEntity acre = new AddCategoryRequestEntity("C", userId, categoryName);
                string url = string.Format("{0}/rest/document/category/update", BaseUrl);
                string postData = Serialiaze(acre);
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendPost();
                AddCategoryResponseEntity re = Deserialize<AddCategoryResponseEntity>(result);
                return re.result;
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

        public List<string> Query()
        {
            try
            {
                List<string> list = new List<string>();
                string url = string.Format("{0}/rest/document/", BaseUrl);
                CatagoryRequestEntity request = new CatagoryRequestEntity(userId, userName, userPhone, userEmail);
                string postData = Serialiaze(request);// request.ToString();
                string header = string.Empty;
                RestHelper rh = new RestHelper(url, postData, header);
                string result = rh.SendPost();
                CatagoryResponseEntity cre = Deserialize<CatagoryResponseEntity>(result);
                foreach (var item in cre.result)
                {
                    list.Add(item.category);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetDetail()
        {
            throw new NotImplementedException();
        }



        List<CategoryDao> IBaseDao<CategoryDao>.Query()
        {
            throw new NotImplementedException();
        }

        CategoryDao IBaseDao<CategoryDao>.GetDetail()
        {
            throw new NotImplementedException();
        }


        public bool Add(CategoryDao t)
        {
            throw new NotImplementedException();
        }

        public bool Upgrade(CategoryDao t)
        {
            throw new NotImplementedException();
        }

        public bool Del(CategoryDao t)
        {
            throw new NotImplementedException();
        }
    }
}
