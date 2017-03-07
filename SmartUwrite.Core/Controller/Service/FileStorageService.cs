using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIMTClassLibrary;
using System.Windows.Forms;
using System.Data;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace LiteratureManager
{
    public class FileStorageService : IStorageService
    {
        private static readonly string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\\BIMT\\literatures\\";

        public string GetBaseDir()
        {
            if (!Directory.Exists(baseDir + User.GetInstance().Key.id + "\\"))
            {
                Directory.CreateDirectory(baseDir + User.GetInstance().Key.id + "\\未分类\\");
                Directory.CreateDirectory(baseDir + User.GetInstance().Key.id + "\\回收站\\");
            }
            return baseDir + User.GetInstance().Key.id + "\\";
        }
        private static FileStorageService storage;

        private FileStorageService() { }

        public static FileStorageService GetInstance()
        {
            if (storage == null)
            {
                storage = new FileStorageService();
            }
            return storage;
        }

        public void BindingTreeViewData(System.Windows.Forms.TreeView treeView)
        {
            DirectoryInfo folder = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir());
            if (treeView.Nodes["未分类"] == null)
            {
                treeView.Nodes.Add("未分类", "未分类");
            }
            TreeNode all = treeView.Nodes["未分类"];//.Add("未分类", "未分类");
            foreach (FileInfo item in folder.GetFiles())
            {
                all.Nodes.Add(item.Name.Replace(item.Extension, string.Empty), item.Name.Replace(item.Extension, string.Empty));
            }
            foreach (DirectoryInfo dir in folder.GetDirectories())
            {
                if (dir.Name == "回收站")
                {
                    continue;
                }
                TreeNode trGroup = new TreeNode(dir.Name);
                trGroup.Name = dir.Name;
                treeView.Nodes.Insert(1, trGroup);//.Add(dir.Name, dir.Name);
                DirectoryInfo group = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + dir);
                foreach (FileInfo item in group.GetFiles())
                {
                    TreeNode trItem = trGroup.Nodes.Add(item.Name.Replace(item.Extension, string.Empty), item.Name.Replace(item.Extension, string.Empty));
                }
            }
            //回收站放在最后位置
            if (treeView.Nodes["回收站"] == null)
            {
                treeView.Nodes.Add("回收站", "回收站");
            }
            TreeNode trHsz = treeView.Nodes["回收站"];//.Add("回收站", "回收站");
            DirectoryInfo diHsz = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + "回收站");
            foreach (FileInfo item in diHsz.GetFiles())
            {
                TreeNode trItem = trHsz.Nodes.Add(item.Name.Replace(item.Extension, string.Empty), item.Name.Replace(item.Extension, string.Empty));
            }
        }

        public void BindingGridViewData(string groupName, System.Windows.Forms.DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("标题");
            dt.Columns.Add("作者");
            dt.Columns.Add("杂志名称");
            dt.Columns.Add("年份");
            dt.Columns.Add("卷");
            dt.Columns.Add("期");
            DirectoryInfo folder = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + "\\" + groupName);
            foreach (FileInfo item in folder.GetFiles())
            {

                //string _strJson =File.ReadAllText(item.FullName);
                //CommonFunction.parse<Quotation>(_strJson);
                //dt.Rows.Add();
            }
        }

        public void AddCategory(string categoryName, TreeView treeView)
        {
            TreeNode node = treeView.Nodes.Insert(1, categoryName, categoryName);
            node.ImageIndex = 8;
            node.SelectedImageIndex = 9;
            //node.i
            string _strPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
            if (!Directory.Exists(_strPath))
            {
                Directory.CreateDirectory(_strPath);
            }
        }

        public void AddCategory(Quotation quotation, TreeView treeView)
        {
            throw new NotImplementedException();
        }

        public void DelCategory(string categoryName, TreeView treeView)
        {
            try
            {
                //TreeNode tr = new TreeNode(categoryName);
                treeView.Nodes.Remove(treeView.SelectedNode);
                string _strPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
                if (Directory.Exists(_strPath))
                {
                    DirectoryInfo group = new DirectoryInfo(_strPath);
                    foreach (FileInfo item in group.GetFiles())
                    {
                        File.Copy(item.FullName, FileStorageService.GetInstance().GetBaseDir() + "\\" + item.Name, true);
                        File.Delete(item.FullName);

                        treeView.Nodes["未分类"].Nodes.Add(item.Name.Replace(item.Extension, string.Empty), item.Name.Replace(item.Extension, string.Empty));
                    }
                    Directory.Delete(_strPath);
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "类别删除失败" + ex.Message);
                MessageBox.Show("类别删除失败！");
            }
        }

        /// <summary>
        /// 删除文献类别
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="categoryName"></param>
        public void DelCategory(string categoryName)
        {
            try
            {
                string _strPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
                if (Directory.Exists(_strPath))
                {
                    DirectoryInfo group = new DirectoryInfo(_strPath);
                    foreach (FileInfo item in group.GetFiles())
                    {
                        File.Copy(item.FullName, FileStorageService.GetInstance().GetBaseDir() + "\\未分类\\" + item.Name, true);
                        File.Delete(item.FullName);
                    }
                    Directory.Delete(_strPath);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改文献类别
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="SourceCategory"></param>
        /// <param name="TargetCategory"></param>
        public void UpdateLiteratureCategory(string literatureName, string SourceCategory, string TargetCategory)
        {
            try
            {
                string _strSourcePath = FileStorageService.GetInstance().GetBaseDir() + "\\" + SourceCategory + "\\";
                string _strTargetPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + TargetCategory + "\\";
                if (Directory.Exists(_strSourcePath) && Directory.Exists(_strTargetPath))
                {
                    if (TargetCategory == string.Empty)
                    {
                        TargetCategory = "未分类";
                    }
                    File.Copy(_strSourcePath + literatureName + ".json", _strTargetPath + literatureName + ".json", true);
                    File.Delete(_strSourcePath + literatureName + ".json");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddLiterature(Quotation quotation)
        {
            try
            {
                StringBuilder _sbTitle = new StringBuilder(quotation.title);
                CommonFunction.CleanStringBuilder(_sbTitle);
                string _strR2 = CommonFunction.stringify(quotation);
                string _strName = FileStorageService.GetInstance().GetBaseDir() + "\\未分类\\" + _sbTitle + ".json";
                File.WriteAllText(_strName, _strR2, Encoding.UTF8);

            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "文献添加失败" + ex.Message);

            }
        }

        public bool AddLiterature(string category, Quotation quotation)
        {
            try
            {
                StringBuilder titile = new StringBuilder(quotation.title);
                CommonFunction.CleanStringBuilder(titile);
                string _strR2 = CommonFunction.stringify(quotation);
                string _strName = FileStorageService.GetInstance().GetBaseDir() + "\\" + category + "\\" + titile + ".json";
                File.WriteAllText(_strName, _strR2, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "文献添加失败" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除文献
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="literatureName"></param>
        /// <param name="categoryName"></param>
        /// <param name="treeView"></param>
        public void DelLiterature(string literatureName, string categoryName, TreeView treeView)
        {
            try
            {
                string _strSourcePath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
                if (Directory.Exists(_strSourcePath))
                {
                    File.Delete(_strSourcePath + literatureName + ".json");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditLiterature(string literatureName, string categoryName)
        {
            throw new NotImplementedException();
        }

        public void InitCatagory(DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("类别名称");
            if (Directory.Exists(FileStorageService.GetInstance().GetBaseDir()))
            {
                DirectoryInfo group = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir());
                foreach (DirectoryInfo item in group.GetDirectories())
                {
                    if (item.Name == "回收站")
                    {
                        continue;
                    }
                    dt.Rows.Add(item.Name);
                }
            }
            dataGridView.DataSource = dt.DefaultView;
        }

        /// <summary>
        /// 通过类别、文献获取文献对象
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Quotation GetQuotationByName(string category, string name)
        {
            try
            {
                string _strPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + category + "\\" + name + ".json";
                string _strJson = File.ReadAllText(_strPath);
                Quotation quotation = CommonFunction.parse<Quotation>(_strJson);
                return quotation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveLiterature(string category, Quotation quotation)
        {
            try
            {
                string _strJson = CommonFunction.stringify(quotation);
                if (Directory.Exists(FileStorageService.GetInstance().GetBaseDir() + "\\"))
                {
                    StringBuilder sbJsonName = new StringBuilder(quotation.title);
                    CommonFunction.CleanStringBuilder(sbJsonName);
                    string _path = FileStorageService.GetInstance().GetBaseDir() + "\\" + category + "\\" + sbJsonName + ".json";
                    File.WriteAllText(_path, _strJson);
                    MessageBox.Show("文献保存成功！");
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "文献保存失败！" + ex.Message);
                MessageBox.Show("文献保存失败！");
            }
        }

        /// <summary>
        /// 返回类别下的文献信息
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataTable GetLiteratureDetail(string category)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("标题");
                dt.Columns.Add("作者");
                dt.Columns.Add("杂志名称");
                dt.Columns.Add("年份");
                dt.Columns.Add("卷");
                dt.Columns.Add("期");
                dt.Columns.Add("摘要");
                dt.Columns.Add("关键词");//浏览原文
                dt.Columns.Add("浏览原文");
                //string _strTemp = string.Empty;
                //if (category != "未分类")
                //{
                //    _strTemp = category;
                //}
                DirectoryInfo folder = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + "\\" + category + "\\");
                foreach (FileInfo item in folder.GetFiles())
                {
                    string _strJson = File.ReadAllText(item.FullName);
                    Quotation quotation = CommonFunction.parse<Quotation>(_strJson);
                    string _strLLYW = "浏览原文";
                    if (quotation.online.ToUpper() != "TRUE")
                    {
                        _strLLYW = "无信息";
                    }
                    dt.Rows.Add(quotation.did, quotation.title, quotation.authors, quotation.publishInfo.periodicalInfo.name, quotation.publishInfo.publishYear, quotation.publishInfo.volumeInfo, quotation.publishInfo.issueInfo, quotation.abstracts, quotation.keywords, _strLLYW);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "获取文献详细信息失败！" + ex.Message);
                MessageBox.Show("获取文献详细信息失败！" + ex.Message);
                return null;
            }
        }

        public DataTable GetAllLiteratures()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("标题");
                dt.Columns.Add("作者");
                dt.Columns.Add("杂志名称");
                dt.Columns.Add("年份");
                dt.Columns.Add("卷");
                dt.Columns.Add("期");
                dt.Columns.Add("摘要");
                dt.Columns.Add("关键词");
                dt.Columns.Add("类别");
                DirectoryInfo folder = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir());
                foreach (FileInfo item in folder.GetFiles())
                {
                    string _strJson = File.ReadAllText(item.FullName);
                    Quotation quotation = CommonFunction.parse<Quotation>(_strJson);
                    dt.Rows.Add(quotation.title, quotation.authors, quotation.publishInfo.periodicalInfo.name, quotation.publishInfo.publishYear, quotation.publishInfo.volumeInfo, quotation.publishInfo.issueInfo, quotation.abstracts, quotation.keywords, string.Empty);
                }
                foreach (DirectoryInfo dir in folder.GetDirectories())
                {
                    DirectoryInfo group = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + dir);
                    foreach (FileInfo item in group.GetFiles())
                    {
                        string _strJson = File.ReadAllText(item.FullName);
                        Quotation quotation = CommonFunction.parse<Quotation>(_strJson);
                        dt.Rows.Add(quotation.title, quotation.authors, quotation.publishInfo.periodicalInfo.name, quotation.publishInfo.publishYear, quotation.publishInfo.volumeInfo, quotation.publishInfo.issueInfo, quotation.abstracts, quotation.keywords, dir.Name);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(FileStorageService), "获取全部文献失败！" + ex.Message);
                MessageBox.Show("获取全部文献失败！" + ex.Message);
                return null;
            }
        }

        public string GetAbstractInfo(string literatureName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCategorylist()
        {
            try
            {
                string userId = string.Empty;
                List<string> list = new List<string>();
                list.Add("未分类");
                DirectoryInfo folder = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir());
                foreach (DirectoryInfo dir in folder.GetDirectories())
                {
                    if (dir.Name == "未分类" || dir.Name == "回收站")
                    {
                        continue;
                    }
                    list.Add(dir.Name);
                }
                list.Add("回收站");
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetLiteratures(string catagoryName)
        {
            try
            {
                List<string> list = new List<string>();
                string path = FileStorageService.GetInstance().GetBaseDir() + "\\" + catagoryName;
                if (Directory.Exists(path))
                {
                    DirectoryInfo folder = new DirectoryInfo(path);
                    foreach (FileInfo item in folder.GetFiles())
                    {
                        list.Add(item.Name.Replace(item.Extension, string.Empty));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddCatagory(string catagoryName)
        {
            try
            {
                string path = string.Format("{0}\\{1}", FileStorageService.GetInstance().GetBaseDir(), catagoryName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
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
            string _strPath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
            if (!Directory.Exists(_strPath))
            {
                Directory.CreateDirectory(_strPath);
            }
        }

        public void DelLiterature(string literatureName, string categoryName)
        {
            try
            {
                string _strSourcePath = FileStorageService.GetInstance().GetBaseDir() + "\\" + categoryName + "\\";
                if (Directory.Exists(_strSourcePath))
                {
                    File.Delete(_strSourcePath + literatureName + ".json");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCategorys()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("类别名称");
            if (Directory.Exists(FileStorageService.GetInstance().GetBaseDir()))
            {
                DirectoryInfo group = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir());
                foreach (DirectoryInfo item in group.GetDirectories())
                {
                    if (item.Name == "回收站")
                    {
                        continue;
                    }
                    dt.Rows.Add(item.Name);
                }
            }
            return dt;
        }

        public void CreateBaseDir()
        {
            try
            {
                string dir = GetBaseDir();
                if (!Directory.Exists(dir))
                {
                   
                    Directory.CreateDirectory(dir);
                    Directory.CreateDirectory(dir + "回收站\\");
                    Directory.CreateDirectory(dir + "未分类\\");
                }
                string s = FileStorageService.GetInstance().GetBaseDir();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

