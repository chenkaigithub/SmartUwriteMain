using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteratureManager;
using BIMTClassLibrary.DocDatabase;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.DocDatabase.Doc;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    public class LieteratureNetService :BaseDocManager, IStorageService
    {
       
        public void BindingTreeViewData(System.Windows.Forms.TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public void BindingGridViewData(string groupName, System.Windows.Forms.DataGridView dataGridView)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(string categoryName, System.Windows.Forms.TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public void DelCategory(string categoryName, System.Windows.Forms.TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public void UpdateLiteratureCategory(string literatureName, string SourceCategory, string TargetCategory)
        {
            throw new NotImplementedException();
        }

        public void AddLiterature(Quotation quotation)
        {
            throw new NotImplementedException();
        }

        public void SaveLiterature(string category, Quotation quotation)
        {
            throw new NotImplementedException();
        }

        public void DelLiterature(string literatureName, string categoryName, System.Windows.Forms.TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public void EditLiterature(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }

        public void InitCatagory(System.Windows.Forms.DataGridView dataGridView)
        {
            throw new NotImplementedException();
        }

        public Quotation GetQuotationByName(string category, string name)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetLiteratureDetail(string category)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetAllLiteratures()
        {
            throw new NotImplementedException();
        }

        public string GetAbstractInfo(string literatureName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCategorylist()
        {
            User user = User.GetInstance();
            CategoryDao cd = new CategoryDao(user.Key.id, user.Detail.result.loginName, user.Detail.result.tel, user.Detail.result.email);
            return cd.Query();
        }

        public List<string> GetLiteratures(string catagoryName)
        {
            try
            {
                LiteratureDao dao = new LiteratureDao(catagoryName, User.GetInstance().Key.id);
                return dao.Query();
            }
            catch (Exception)
            {
                throw;
            }
            //try
            //{//2016-09-11
            //    List<string> list = new List<string>();
            //    string url = string.Format("{0}/rest/document/category/{1}/{2}", BaseUrl, catagoryName,User.GetInstance().Id);
            //    string postData = string.Empty;
            //    string header = string.Empty;
            //    RestHelper rh = new RestHelper(url, postData, header);
            //    string result = rh.SendGet();
            //    LiteratureResponseEntity lre = Deserialize<LiteratureResponseEntity>(result);
            //    List<Quotation> quotations = Deserialize<List<Quotation>>(lre.result);
            //    foreach (var item in quotations)
            //    {
            //        list.Add(item.title);
            //    }
            //    return list;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }


        public bool AddCatagory(string catagoryName)
        {
            throw new NotImplementedException();
        }

        public bool DelCatagory(string catagoryName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCatagory(string oldName, string NewName)
        {
            throw new NotImplementedException();
        }


        public void AddCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void DelCategory(string categoryName)
        {
            throw new NotImplementedException();
        }


        public void DelLiterature(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }


        public System.Data.DataTable GetCategorys()
        {
            throw new NotImplementedException();
        }

        public void CreateBaseDir()
        {
            throw new NotImplementedException();
        }
    }
}
