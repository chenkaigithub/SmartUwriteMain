using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary;
using System.Data;

namespace LiteratureManager
{
    public interface IStorageService
    {
        /// <summary>
        /// 根据用户id创建基础文献目录
        /// </summary>
        void CreateBaseDir();
        /// <summary>
        /// 获取类别集合
        /// </summary>
        /// <returns></returns>
        List<string> GetCategorylist();

        /// <summary>
        /// 增加catagory
        /// </summary>
        /// <param name="catagoryName"></param>
        /// <returns></returns>
        bool AddCatagory(string catagoryName);

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="catagoryName"></param>
        /// <returns></returns>
        bool DelCatagory(string catagoryName);

        /// <summary>
        /// 重命名类别
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="NewName"></param>
        /// <returns></returns>
        bool UpdateCatagory(string oldName,string NewName);

        /// <summary>
        /// 通过类别名称获取文献
        /// </summary>
        /// <param name="catagoryName"></param>
        /// <returns></returns>
        List<string> GetLiteratures(string catagoryName);


        /// <summary>
        /// 绑定treeview数据源
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="treeView"></param>
        [method: Obsolete("该方法已经过时", true)]
        void BindingTreeViewData(TreeView treeView);

        /// <summary>
        /// 绑定datagridview数据源
        /// 2016-06-01
        /// wuhailong
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="dataGridView"></param>
        [method: Obsolete("该方法已经过时", true)]
        void BindingGridViewData(string groupName, DataGridView dataGridView);

        /// <summary>
        /// 添加类别
        /// 2016-06-01
        /// wuhailong
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="treeView"></param>
        [method: Obsolete("该方法已经过时", true)]
        void AddCategory(string categoryName, TreeView treeView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        void AddCategory(string categoryName);

        /// <summary>
        /// 删除类别
        /// 2016-06-01
        /// wuhailong
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="treeView"></param>
        [method: Obsolete("该方法已经过时", true)]
        void DelCategory(string categoryName, TreeView treeView);


        void DelCategory(string categoryName);

        /// <summary>
        /// 修改文献类别
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="categoryName"></param>
        void UpdateLiteratureCategory(string literatureName, string SourceCategory, string TargetCategory);

        /// <summary>
        /// 添加文献
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="quotation"></param>
        void AddLiterature(Quotation quotation);

        /// <summary>
        /// 保存文献
        /// wuhailong
        /// 2016-06-02
        /// </summary>
        /// <param name="quotation"></param>
        void SaveLiterature(string category,Quotation quotation);

        /// <summary>
        /// 删除文献
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="categoryName"></param>
        [method: Obsolete("该方法已经过时", true)]
        void DelLiterature(string literatureName, string categoryName, TreeView treeView);

        /// <summary>
        /// 删除文献
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="categoryName"></param>
        void DelLiterature(string literatureName, string categoryName);

        /// <summary>
        /// 编辑文献
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="categoryName"></param>
        void EditLiterature(string literatureName, string categoryName);

        /// <summary>
        /// 初始化类别选择
        /// wuhailong
        /// 2016-06-01
        /// </summary>
        /// <param name="dataGridView"></param>
        [method: Obsolete("该方法已经过时", true)]
        void InitCatagory(DataGridView dataGridView);

        DataTable GetCategorys();

        /// <summary>
        /// 通过文献名称获取文献对象
        /// 2016-06-02
        /// wuhailong
        /// </summary>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Quotation GetQuotationByName(string category,string name);

        /// <summary>
        /// 返回文献的详细信息展示在右侧
        /// wuhailong
        /// 2016-06-02
        /// </summary>
        /// <param name="category"></param>
        /// <param name="literature"></param>
        /// <returns></returns>
        DataTable GetLiteratureDetail(string category);

        /// <summary>
        /// 获取全部文献
        /// wuhailog
        /// 2016-06-01
        /// </summary>
        /// <returns></returns>
        DataTable GetAllLiteratures();

        /// <summary>
        /// 获取文献的摘要及关键词信息
        /// 2016-06-02
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        string GetAbstractInfo(string literatureName);
    }
}
