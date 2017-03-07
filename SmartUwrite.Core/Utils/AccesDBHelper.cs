using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteratureManager
{
    class AccesDBHelper : IStorageService
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

        public void UpdateLiteratureCategory(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }

        public void AddLiterature(BIMTClassLibrary.Quotation quotation)
        {
            throw new NotImplementedException();
        }

        public void DelLiterature(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }

        public void EditLiterature(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }


        public void AddCategory(BIMTClassLibrary.Quotation quotation, System.Windows.Forms.TreeView treeView)
        {
            throw new NotImplementedException();
        }


        public void UpdateLiteratureCategory(string literatureName, string SourceCategory, string TargetCategory)
        {
            throw new NotImplementedException();
        }


        public void InitCatagory(System.Windows.Forms.DataGridView dataGridView)
        {
            throw new NotImplementedException();
        }


        public BIMTClassLibrary.Quotation GetQuotationByName(string name)
        {
            throw new NotImplementedException();
        }


        public BIMTClassLibrary.Quotation GetQuotationByName(string category, string name)
        {
            throw new NotImplementedException();
        }


        public void SaveLiterature(BIMTClassLibrary.Quotation quotation)
        {
            throw new NotImplementedException();
        }


        public void SaveLiterature(string category, BIMTClassLibrary.Quotation quotation)
        {
            throw new NotImplementedException();
        }


        public void DelLiterature(string literatureName, string categoryName, System.Windows.Forms.TreeView treeView)
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
            throw new NotImplementedException();
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

        public List<string> GetLiteratures(string catagoryName)
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
