using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMTClassLibrary.DBF;
using Log4Net;
using LiteratureManager;
using System.Threading;
using System.IO;
using BIMTClassLibrary.DocDatabase.Service;
using BIMTClassLibrary.DocDatabase.Upload;
using BIMTClassLibrary.MyLiterature;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.EditStyle;
using BIMTClassLibrary.Model;
//using BIMTClassLibrary.db;



namespace BIMTClassLibrary
{
    public partial class frmLiteratureStorage : Form
    {

        public TreeNode tnCurrent = null;
        private static frmLiteratureStorage frm = null;
        //public  LiteratureManager.IMyLiterature Source = new LieteratureNetService();
        public LiteratureManager.IStorageService Source = FileStorageService.GetInstance();
        public frmLiteratureStorage()
        {
            try
            {
                InitializeComponent();
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }


       
        public frmLiteratureStorage(string userId, string userName, string UserPhone, string UserEmail)
        {
            // TODO: Complete member initialization
            this.userId = userId;
            this.userName = userName;
            this.userPhone = UserPhone;
            this.serEmail = UserEmail;
        }

        

        /// <summary>
        /// 初始化treeview
        /// </summary>
        public void InitTreeView()
        {
            try
            {
                treeView1.Nodes.Clear();
                List<string> listUserCatagorys = Source.GetCategorylist();
                int index = 0;
                foreach (string catagoryName in listUserCatagorys)
                {
                    index++;
                    TreeNode trGroup = new TreeNode(catagoryName);

                    trGroup.Name = catagoryName;
                    treeView1.Nodes.Insert(index, trGroup);
                    //添加节点下文献
                    List<string> listCatagoryLiteratures = Source.GetLiteratures(catagoryName);
                    foreach (string item in listCatagoryLiteratures)
                    {
                        TreeNode trItem = trGroup.Nodes.Add(item, item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InitIcon()
        {
            try
            {
                foreach (TreeNode item in treeView1.Nodes)
                {
                    if (item.Name == "未分类")
                    {
                        item.ImageKey = "未分类1.png";
                        item.SelectedImageKey = "未分类1.png";
                    }
                    else if (item.Name == "回收站")
                    {
                        item.ImageKey = "回收站1.png";
                        item.SelectedImageKey = "回收站1.png";
                    }
                    else
                    {
                        item.ImageKey = "分类2-.png";
                        item.SelectedImageKey = "分类1.png";
                    }

                }
                if (PublicVar.selectedCatagory == string.Empty)
                {
                    treeView1.SelectedNode = treeView1.Nodes["未分类"];
                    this.Text = "我的文献库--未分类";
                }
                else
                {
                    treeView1.SelectedNode = treeView1.Nodes[PublicVar.selectedCatagory];
                    this.Text = "我的文献库--" + PublicVar.selectedCatagory;
                }
                lab_file_count.Text = dataGridView1.Rows.Count.ToString() + "篇文献";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InitData()
        {
            try
            {
                treeView1.Nodes.Clear();
                //Source.BindingTreeViewData(treeView1);
                //Source.BindingGridViewData("", dataGridView1);
                treeView1.ExpandAll();
               
                foreach (TreeNode item in treeView1.Nodes)
                {
                    item.ImageIndex = 8;
                    item.SelectedImageIndex = 9;
                }
                treeView1.Nodes["未分类"].ImageIndex = 7;
                treeView1.Nodes["未分类"].SelectedImageIndex = 7;
                treeView1.Nodes["回收站"].ImageIndex = 5;
                treeView1.Nodes["回收站"].SelectedImageIndex = 5;
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        /// <summary>
        /// 添加文献
        /// </summary>
        public void AddQuotation()
        {
            frmEditQuotation frm = new frmEditQuotation(true, Guid.NewGuid().ToString());
            if (DialogResult.OK == frm.ShowDialog())
            {
                InitData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string literatureId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
           
        }

        /// <summary>
        /// 插入文献数据
        /// </summary>
        /// <param name="p_strTitle"></param>
        /// <param name="p_strTitleType"></param>
        /// <param name="p_strAuthor"></param>
        /// <param name="p_strPubYear"></param>
        /// <param name="p_strPubPlace"></param>
        /// <param name="p_strPubPersion"></param>
        /// <param name="p_strJuan"></param>
        /// <param name="p_strQi"></param>
        /// <param name="p_strPageRange"></param>
        /// <param name="p_strDOI"></param>
        /// <param name="p_strCountry"></param>
        /// <param name="p_strPubDate"></param>
        /// <param name="p_strSecondPersion"></param>
        /// <param name="p_strVersion"></param>
        /// <param name="p_strISSN"></param>
        /// <param name="p_strPrintTime"></param>
        /// <param name="p_strAuthorInEng"></param>
        /// <param name="p_strTitleInEng"></param>
        /// <param name="p_strPubPersionInEng"></param>
        /// <param name="p_strCountryInEng"></param>
        /// <param name="p_strPubPlaceInEng"></param>
        /// <param name="p_strVersionInEng"></param>
        /// <param name="p_strRefDate"></param>
        /// <param name="p_strkey_words"></param>
        /// <param name="p_strOutline"></param>
        /// <returns></returns>
        public static int  AddLiterature(string p_strTitle, string p_strTitleType, string p_strAuthor, string p_strPubYear, string p_strPubPlace, string p_strPubPersion, string p_strJuan,
            string p_strQi, string p_strPageRange, string p_strDOI, string p_strCountry, string p_strPubDate, string p_strSecondPersion, string p_strVersion,
            string p_strISSN, string p_strPrintTime, string p_strAuthorInEng, string p_strTitleInEng, string p_strPubPersionInEng, string p_strCountryInEng, string p_strPubPlaceInEng,
            string p_strVersionInEng, string p_strRefDate,string p_strkey_words,string p_strOutline)
        {
            string _strSQL = string.Format(@"insert into literature 
                                            (title,title_type,author,pub_year,pub_place,pub_er,juan,qi,page_range,doi,country,pub_date,se_person,version,issn,pri_time,author_eng,title_eng,puber_eng,coun_eng,palce_eng,ver_eng,ref_date,key_words,outline,id) 
                                            values
                                            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')",
                p_strTitle, p_strTitleType, p_strAuthor, p_strPubYear, p_strPubPlace, p_strPubPersion, p_strJuan,
             p_strQi, p_strPageRange, p_strDOI, p_strCountry, p_strPubDate, p_strSecondPersion, p_strVersion,
             p_strISSN, p_strPrintTime, p_strAuthorInEng, p_strTitleInEng, p_strPubPersionInEng, p_strCountryInEng, p_strPubPlaceInEng,
             p_strVersionInEng, p_strRefDate, p_strkey_words, p_strOutline,Guid.NewGuid().ToString()
                );
            int _nReault = LocalDBHelper.ExcuteNonQuery(_strSQL);
             return _nReault;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "标题")
            {
                OpenLocalDoc();
            }
            else
            {
                string _strCatagory = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                StringBuilder _strTitle = new StringBuilder(dataGridView1.CurrentRow.Cells["标题"].Value.ToString());
                CommonFunction.CleanStringBuilder(_strTitle);
                frmEditLiterature frm = new frmEditLiterature(this,_strCatagory, _strTitle.ToString());
                frm.ShowDialog();
                //InitData();
                treeView1.SelectedNode = treeView1.Nodes[_strCatagory];
            }
            //frmEditLiterature frm = new frmEditLiterature(treeView1.SelectedNode.Parent.Text, dataGridView1.CurrentRow.Cells["标题"].Value.ToString());
            //frm.ShowDialog();
        }

        private void frmMyLiterature_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“literatureDataSet.CLASS”中。您可以根据需要移动或删除它。
            //this.cLASSTableAdapter.Fill(this.literatureDataSet.CLASS);

        }

        private void 添加文献ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _strClass = string.Empty;
            if (treeView1.SelectedNode.Parent == null)
            {
                _strClass = treeView1.SelectedNode.Name;
            }
            else
            {
                _strClass = treeView1.SelectedNode.Parent.Name;
            }
            frmEditQuotation frm = new frmEditQuotation(true, Guid.NewGuid().ToString(), _strClass);
            if (DialogResult.OK == frm.ShowDialog())
            {
                InitData();
            }
        }

        private void 删除文献ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                //if ( DialogResult.Yes ==MessageBox.Show(this,"删除当前文献吗？","确定",MessageBoxButtons.YesNo))
                //{
                //string _strId = treeView1.SelectedNode.Name;
                //DeleteLiterature(_strId);
                //treeView1.Nodes.Remove(treeView1.SelectedNode);
                string catagoryName = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                string literatureName = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();
                StringBuilder sbLiteratureName = new StringBuilder(literatureName);
                CommonFunction.CleanStringBuilder(sbLiteratureName);
                literatureName = sbLiteratureName.ToString();
                Source.UpdateLiteratureCategory(literatureName, catagoryName, "回收站");
                RefreshUpdateCatagoryUI(catagoryName,"回收站",literatureName);
                //TreeNode trCatagory= treeView1.Nodes[catagoryName];//
                //TreeNode trLiterature = trCatagory.Nodes[literatureName];
                //trLiterature.Remove();
                //TreeNode tr = new TreeNode(literatureName);
                //tr.Name = literatureName;
                //treeView1.Nodes["回收站"].Nodes.Add(tr);//[literatureName].Remove();
                //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);//.SelectedRows[0]
                //InitData();
                //treeView1.SelectedNode = treeView1.Nodes[_strCatagory];
                //Source.DelLiterature(treeView1.SelectedNode.Name, treeView1.SelectedNode.Parent.Name,treeView1);
                //}
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
           
        }

        /// <summary>
        /// 删除文献
        /// 2016-04-21
        /// wuhailong
        /// </summary>
        /// <param name="_strTitle"></param>
        private void DeleteLiterature(string _strTitle)
        {
            int _n = LocalDBHelper.ExcuteNonQuery(string.Format("delete from  literature where id ='{0}'", _strTitle));
            if (_n == 1)
            {
                MessageBox.Show("删除成功！");
                //InitData();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                TreeNode _nodeSelected = treeView1.SelectedNode;
                if (_nodeSelected != null && _nodeSelected.Nodes.Count == 0 && _nodeSelected.Parent != null && _nodeSelected.Parent.Text != "回收站")
                {//未在回收站内的文献节点

                    contextMenuStrip1.Items["重命名分类ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["清空回收站ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["还原文献ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["addClass"].Visible = false;
                    contextMenuStrip1.Items["delClass"].Visible = false;
                    contextMenuStrip1.Items["彻底删除ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["delLite"].Visible = true;
                    contextMenuStrip1.Items["editLite"].Visible = true;
                    contextMenuStrip1.Items["updataClass"].Visible = true;

                    contextMenuStrip2.Items["编辑ToolStripMenuItem"].Visible = true;
                    //contextMenuStrip2.Items["放入回收站ToolStripMenuItem"].Visible = true;
                    //contextMenuStrip2.Items["彻底删除ToolStripMenuItem1"].Visible = false;
                    //contextMenuStrip1.Items["openLite"].Visible = true;
                    //contextMenuStrip1.Items["openFolder"].Visible = true;

                    //contextMenuStrip1.Items["addLite"].Enabled = true;
                    //contextMenuStrip1.Items["delLite"].Enabled = true;
                    //contextMenuStrip1.Items["editLite"].Enabled = true;
                    //contextMenuStrip1.Items["updataClass"].Enabled = true;
                    //contextMenuStrip1.Items["openLite"].Enabled = true;
                    //contextMenuStrip1.Items["openFolder"].Enabled = true;
                    //contextMenuStrip1.Items["delClass"].Enabled = false;
                    ////-- contextMenuStrip1.Items["delClass"].Enabled = false;
                    //contextMenuStrip1.Items["addClass"].Enabled = false;
                    //contextMenuStrip1.Items["delClass"].Enabled = false;
                }
                else if (_nodeSelected != null && _nodeSelected.Parent == null)
                {
                   
                    contextMenuStrip1.Items["delLite"].Visible = false;
                    contextMenuStrip1.Items["editLite"].Visible = false;
                    contextMenuStrip1.Items["updataClass"].Visible = false;
                    contextMenuStrip1.Items["彻底删除ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["还原文献ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["清空回收站ToolStripMenuItem"].Visible = false;
                    if (_nodeSelected.Text == "回收站")
                    {//回收站节点
                        contextMenuStrip1.Items["addClass"].Visible = false;
                        contextMenuStrip1.Items["delClass"].Visible = false;
                        contextMenuStrip1.Items["重命名分类ToolStripMenuItem"].Visible = false;
                        contextMenuStrip1.Items["清空回收站ToolStripMenuItem"].Visible = true;
                        //contextMenuStrip1.Items["还原文献ToolStripMenuItem"].Visible = true;
                    }
                    else if (_nodeSelected.Text == "未分类")
                    {
                        contextMenuStrip1.Items["addClass"].Visible = true;
                        contextMenuStrip1.Items["delClass"].Visible = false;
                        contextMenuStrip1.Items["重命名分类ToolStripMenuItem"].Visible = false;
                        contextMenuStrip1.Items["清空回收站ToolStripMenuItem"].Visible = false;
                    }
                    else
                    {//文献类别节点
                        contextMenuStrip1.Items["addClass"].Visible = true;
                        contextMenuStrip1.Items["delClass"].Visible = true;
                        contextMenuStrip1.Items["重命名分类ToolStripMenuItem"].Visible = true;
                    }


                    //contextMenuStrip1.Items["addClass"].Enabled = true;
                    //contextMenuStrip1.Items["delClass"].Enabled = true;
                    //--
                    //contextMenuStrip1.Items["addLite"].Enabled = false;
                    //contextMenuStrip1.Items["delLite"].Enabled = false;
                    //contextMenuStrip1.Items["editLite"].Enabled = false;
                    //contextMenuStrip1.Items["updataClass"].Enabled = false;
                    //contextMenuStrip1.Items["openLite"].Enabled = false;
                    //contextMenuStrip1.Items["openFolder"].Enabled = false;
                    //if (_nodeSelected.Text=="全部")
                    //{
                    //    contextMenuStrip1.Items["delClass"].Enabled = false;
                    //}
                }
                else if (_nodeSelected != null && _nodeSelected.Nodes.Count == 0 && _nodeSelected.Parent != null && _nodeSelected.Parent.Text == "回收站")
                {//回收站内的文献节点
                    contextMenuStrip1.Items["重命名分类ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["delLite"].Visible = false;
                    contextMenuStrip1.Items["editLite"].Visible = false;
                    contextMenuStrip1.Items["updataClass"].Visible = false;
                    contextMenuStrip1.Items["清空回收站ToolStripMenuItem"].Visible = false;
                    contextMenuStrip1.Items["彻底删除ToolStripMenuItem"].Visible = true;
                    contextMenuStrip1.Items["还原文献ToolStripMenuItem"].Visible = true;

                    contextMenuStrip2.Items["编辑ToolStripMenuItem"].Visible = false;
                    //contextMenuStrip2.Items["放入回收站ToolStripMenuItem"].Visible = false;
                    //contextMenuStrip2.Items["彻底删除ToolStripMenuItem1"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
           
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tnCurrent = treeView1.SelectedNode;
                TreeNode _nodeSelected = treeView1.SelectedNode;
                //根节点
                if (_nodeSelected != null && _nodeSelected.Parent == null)
                {
                    string _strCatagory = _nodeSelected.Text;
                    this.catagory = _nodeSelected.Text;
                    PublicVar.selectedCatagory = _nodeSelected.Text;
                    this.Text = "我的文献库--" + PublicVar.selectedCatagory;
                    if (_nodeSelected.Parent != null)
                    {
                        _strCatagory = _nodeSelected.Parent.Text;
                    }
                    DataTable dt = Source.GetLiteratureDetail(_strCatagory);
                    dataGridView1.DataSource = dt.DefaultView;
                    lab_file_count.Text = dataGridView1.Rows.Count.ToString() + "篇文献";
                }
                if (_nodeSelected.Parent != null)
                {
                    string _strCatagory = _nodeSelected.Parent.Text;
                    DataTable dt = Source.GetLiteratureDetail(_strCatagory);
                    dataGridView1.DataSource = dt.DefaultView;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        StringBuilder _strRigtTitle = new StringBuilder(item.Cells["标题"].Value.ToString());
                        CommonFunction.CleanStringBuilder(_strRigtTitle);
                        if (_strRigtTitle.ToString().Trim() == _nodeSelected.Text.Trim())
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterQuotation();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void editLite_Click(object sender, EventArgs e)
        {
            try
            {
                string _strCatagory = treeView1.SelectedNode.Parent.Text;
                frmEditLiterature frm = new frmEditLiterature(this,treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text);
                frm.ShowDialog();
                InitData();
                treeView1.SelectedNode = treeView1.Nodes[_strCatagory];
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
          
            //string literatureId = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString();
            //frmEditQuotation frm = new frmEditQuotation(literatureId);
            //if (DialogResult.OK == frm.ShowDialog())
            //{
            //    InitData();
            //}
        }

        private void addClass_Click(object sender, EventArgs e)
        {
            frmAddClass frm = new frmAddClass(treeView1); //frmAddClass(this);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除分类
        /// 2016-06-29
        /// wuhailong
        /// </summary>
        public void DeleteCatagory()
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null && (treeView1.SelectedNode.Text != "未分类" && treeView1.SelectedNode.Text != "回收站"))
                {
                    if (DialogResult.OK == MessageBox.Show(this, "确定删除分类" + treeView1.SelectedNode.Text + "？", "删除", MessageBoxButtons.OKCancel))
                    {
                        string catagory = treeView1.SelectedNode.Text;
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        Source.DelCategory(catagory);
                        treeView1.SelectedNode = treeView1.Nodes["未分类"];
                    }
                }
                else
                {
                    MessageBox.Show("不允许删除此分类！");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void delClass_Click(object sender, EventArgs e)
        {
            DeleteCatagory();
            //try
            //{
            //    string _strSQL = string.Empty;
            //    foreach (DataGridViewRow item in dataGridView1.Rows)
            //    {
            //        _strSQL = string.Format("update literature set class_id =null  where id = '{0}'", item.Cells["id"].Value.ToString());
            //        LocalDBHelper.ExcuteNonQuery(_strSQL);
            //    }
            //    string _strClassName = string.Empty;
            //    if (treeView1.SelectedNode.Parent == null)
            //    {
            //        _strClassName = treeView1.SelectedNode.Name;
            //    }
            //    else
            //    {
            //        _strClassName = treeView1.SelectedNode.Parent.Text;
            //    }
            //    _strSQL = string.Format("delete from class where id = '{0}'", _strClassName);
            //    LocalDBHelper.ExcuteNonQuery(_strSQL);
            //    treeView1.Nodes.Remove(treeView1.SelectedNode);
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmSelectQuotation), ex);
            //}
        }

        public void FilterQuotation()
        {
            try
            {
                string _strFilter = string.Format("标题 like '%{0}%' or 杂志名称 like '%{0}%' or 作者 like '%{0}%'  or  年份 like '%{0}%'  or 卷 like '%{0}%' or 期 like '%{0}%'", textBox1.Text);
                string category = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                DataTable _Source = Source.GetLiteratureDetail(category);// ((DataView)dataGridView1.DataSource).ToTable().Copy();
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = _Source.DefaultView;
                }
                else
                {
                    DataRow[] _array = _Source.Select(_strFilter);
                    DataTable _dt = ((DataView)dataGridView1.DataSource).ToTable().Clone();
                    if (_array.Length >= 1)
                    {
                        foreach (DataRow item in _array)
                        {
                            _dt.Rows.Add(item.ItemArray);
                        }
                    }
                    dataGridView1.DataSource = _dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterQuotation();
        }

        /// <summary>
        /// 更新转换类别的UI界面
        /// wuhailong
        ///2016-08-02
        /// </summary>
        /// <param name="sourceCatagory">源类别名称</param>
        /// <param name="targetCatagory">目标类别名称</param>
        /// <param name="literatureName">转换类别的文献</param>
        public void RefreshUpdateCatagoryUI(string sourceCatagory, string targetCatagory, string literatureName)
        {
            try
            {
                TreeNode trLiterature = new TreeNode(literatureName);
                trLiterature.Name = literatureName;
                treeView1.Nodes[sourceCatagory].Nodes.Remove(treeView1.Nodes[sourceCatagory].Nodes[literatureName]);
                //treeView1.SelectedNode = null;// treeView1.Nodes[sourceCatagory];
                //treeView1.SelectedNode = treeView1.Nodes[sourceCatagory];
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                treeView1.Nodes[targetCatagory].Nodes.Add(trLiterature);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改文献类别
        /// wuhailong 
        /// 2016-06-29
        /// </summary>
        public void UpgradeQuotationCatagory()
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null && (treeView1.SelectedNode.Parent.Text != "回收站"))
                {
                    string catagoryName = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                    string literatureName = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();
                    //StringBuilder sbLiteratureName = new StringBuilder(literatureName);
                    //CommonFunction.CleanStringBuilder(sbLiteratureName);
                    //literatureName = sbLiteratureName.ToString();

                    frmChangeClass frm = new frmChangeClass(this);
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        Source.UpdateLiteratureCategory(literatureName, catagoryName,frm.newCatagoryName);
                        RefreshUpdateCatagoryUI(catagoryName, frm.newCatagoryName, literatureName);
                    }
                    //TreeNode trLiterature = new TreeNode(literatureName);
                    //trLiterature.Name = literatureName;
                    //treeView1.Nodes[catagoryName].Nodes.Remove(treeView1.Nodes[catagoryName].Nodes[literatureName]);
                    //treeView1.Nodes[frm.newCatagoryName].Nodes.Add(trLiterature);
                    //InitData();
                    //treeView1.SelectedNode = treeView1.Nodes[catagoryName];
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex.Message);
            }
        }

        /// <summary>
        /// 清理文献标题使之符合文件命名
        /// wuhailong
        /// 2016-08-10
        /// </summary>
        /// <param name="literatureName"></param>
        /// <returns></returns>
        public string CleanLiteratureName(string literatureName)
        {
            try
            {
                return literatureName
                    .Replace("\\", string.Empty)
                    .Replace("/", string.Empty)
                    .Replace("<", string.Empty)
                    .Replace(">", string.Empty)
                    .Replace("|", string.Empty)
                    .Replace("\"", string.Empty)
                    .Replace("*", string.Empty)
                    .Replace("?", string.Empty)
                    .Replace(":", string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

      

        private void updataClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null && (treeView1.SelectedNode.Parent.Text != "回收站"))
                {
                    string catagoryName = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                    string literatureName = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();
                    StringBuilder sbLiteratureName = new StringBuilder(literatureName);
                    CommonFunction.CleanStringBuilder(sbLiteratureName);
                    literatureName = sbLiteratureName.ToString();

                    frmChangeClass frm = new frmChangeClass(this);
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        Source.UpdateLiteratureCategory(literatureName, catagoryName, frm.newCatagoryName);
                        RefreshUpdateCatagoryUI(catagoryName, frm.newCatagoryName, literatureName);
                    }
                    //TreeNode trLiterature = new TreeNode(literatureName);
                    //trLiterature.Name = literatureName;
                    //treeView1.Nodes[catagoryName].Nodes.Remove(treeView1.Nodes[catagoryName].Nodes[literatureName]);
                    //treeView1.Nodes[frm.newCatagoryName].Nodes.Add(trLiterature);
                    //InitData();
                    //treeView1.SelectedNode = treeView1.Nodes[catagoryName];
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
            
        }

        private void openLite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("目前没有全文，此功能暂未实现。");
        }




        internal  void MoveNodetoAnother()
        {
            throw new NotImplementedException();
        }

        internal void MoveNodetoAnother(string p)
        {
            this.SelectNodeText = treeView1.SelectedNode.Text;
            treeView1.Nodes.Remove(treeView1.SelectedNode);
            TreeNode _tr = treeView1.Nodes[p];
            _tr.Nodes.Add(SelectNodeText);
        }

        public string SelectNodeText { get; set; }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditLiterature frm = new frmEditLiterature(this,treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text);
            frm.ShowDialog();
            //DataGridViewRow _dr = dataGridView1.CurrentRow;
            //string literatureId = _dr.Cells["id"].Value.ToString();
            //frmEditQuotation frm = new frmEditQuotation(literatureId);
            //if (DialogResult.OK == frm.ShowDialog())
            //{
            //    InitData();
            //}

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 编辑文献
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        private void EditQuotaion()
        {
            try
            {
                string catagory = (treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text);
                StringBuilder _sbFile = new StringBuilder(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                CommonFunction.CleanStringBuilder(_sbFile);
                string literature = _sbFile.ToString();
                frmEditLiterature frm = new frmEditLiterature(this,catagory, literature);
                frm.ShowDialog();
            }
            catch (Exception )
            {
                throw;
            }
        }

        private void 编辑ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                EditQuotaion();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
            

        }

        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 是否为回收站内文献
        /// </summary>
        /// <returns></returns>
        public bool IsDelQuotation()
        {
            try
            {
                if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "回收站")
                {//选中回收站内的文献节点
                    MessageBox.Show(null,"回收站内文献不能插入","插入文献");
                    return true;
                }
                else if (treeView1.SelectedNode.Parent == null && treeView1.SelectedNode.Text == "回收站")
                {//选中回收站节点
                    MessageBox.Show(null, "回收站内文献不能插入", "插入文献");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmLiteratureStorage),ex);

            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0 && !IsDelQuotation())
                {
                    Microsoft.Office.Interop.Word.Field _field = CommonFunction.GetFieldBySection(WordApplication.GetInstance().WordApp);
                    if (_field != null && _field.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        MessageBox.Show(null, "当前位置无法插入引文！", "插入引文");
                        return;
                    }
                    if (MagazineStyle.GetInstance().Name == "请选择样式")
                    {
                        MessageBox.Show("请选择具体的参考文献样式后再引用。");
                        return;
                    }
                   
                    string _strCatagory = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                    //string _strTitle = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();
                    StringBuilder _sbFile = new StringBuilder(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                    CommonFunction.CleanStringBuilder(_sbFile);
                    Quotation quotation = Source.GetQuotationByName(_strCatagory, _sbFile.ToString());
                    bool ok = quotation.IsAuthorInfoComplete();
                    if (!ok)
                    {
                        MessageBox.Show(null, "文献作者信息不完整请补全后引用！", "插入引文");
                        return;
                    }
                    //ThreadQuotation tq = new ThreadQuotation(quotation);
                    //Thread t = new Thread(tq.SynWriteQuuotation);
                    //t.Start();
                    CommonFunction.WriteQuotation(quotation);
                    using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
                    {
                        ubts.SynDoTrick("我的文献库", "引用", quotation.did + "_" + quotation.title + "_" + quotation.GetCurrentAuthorYear());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
           
        }

        private void 彻底删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(this, "彻底删除当前文献吗？删除后无法还原！", "确定", MessageBoxButtons.YesNo))
                {
                    string catagoryName = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                    string literatureName = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();

                    StringBuilder sbLiteratureName = new StringBuilder(literatureName);
                    CommonFunction.CleanStringBuilder(sbLiteratureName);
                    literatureName = sbLiteratureName.ToString();
                    Source.DelLiterature(literatureName, catagoryName);
                    treeView1.Nodes[catagoryName].Nodes[literatureName].Remove();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
           
        }

        private void 清空回收站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(this, "确定清空回收站吗？清空后无法还原！", "确定", MessageBoxButtons.YesNo))
                {
                    string _strSourcePath = FileStorageService.GetInstance().GetBaseDir() + "\\" + "回收站\\";
                    DirectoryInfo group = new DirectoryInfo(_strSourcePath);
                    foreach (FileInfo item in group.GetFiles())
                    {
                        StringBuilder _sbFile = new StringBuilder(item.Name);
                        Source.DelLiterature(_sbFile.Replace(item.Extension, string.Empty).ToString(), "回收站");
                    }
                    treeView1.Nodes["回收站"].Nodes.Clear();
                    DataTable dt = Source.GetLiteratureDetail("回收站");
                    dataGridView1.DataSource = dt.DefaultView;
                    lab_file_count.Text = "0篇文献";
                    //RefreshUpdateCatagoryUI("回收站", null, null);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void 还原文献ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    
                    string catagoryName = treeView1.SelectedNode.Parent==null?treeView1.SelectedNode.Text:treeView1.SelectedNode.Parent.Text;
                    string literatureName = dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString();
                    StringBuilder sbLiteratureName = new StringBuilder(literatureName);
                    CommonFunction.CleanStringBuilder(sbLiteratureName);
                    literatureName = sbLiteratureName.ToString();
                    Source.UpdateLiteratureCategory(literatureName, catagoryName, string.Empty);
                    RefreshUpdateCatagoryUI(catagoryName, "未分类", literatureName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        /// <summary>
        /// 重命名分类
        /// wuhailong
        /// 2016-06-29
        /// </summary>
        public void RenameCatagory()
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null && (treeView1.SelectedNode.Text != "未分类" && treeView1.SelectedNode.Text != "回收站"))
                {
                    string oldCatagory = treeView1.SelectedNode.Name;
                    frmRenameClass frm = new frmRenameClass(oldCatagory);
                    frm.ShowDialog();
                    DirectoryInfo di = new DirectoryInfo(FileStorageService.GetInstance().GetBaseDir() + treeView1.SelectedNode.Text);
                    try
                    {
                        string _strNewDir = frm.GetNewDir();
                        di.MoveTo(FileStorageService.GetInstance().GetBaseDir() + _strNewDir);
                        //InitData();
                        int index = treeView1.Nodes[oldCatagory].Index;
                        treeView1.Nodes.RemoveAt(index);
                        //treeView1.Nodes[oldCatagory].Name = _strNewDir;
                        //treeView1.Nodes[oldCatagory].Text = _strNewDir;
                        TreeNode trNew = new TreeNode(_strNewDir);
                        trNew.Name = _strNewDir;
                        treeView1.Nodes.Insert(index,trNew);
                        trNew.SelectedImageKey = "分类1.png";
                        trNew.ImageKey = "分类2-.png";
                        treeView1.SelectedNode = treeView1.Nodes[_strNewDir];
                        //di.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(frmLiteratureStorage), "类别重命名" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(null, "无法重命名此节点！              ", "重命名节点");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void 重命名分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameCatagory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddClass frm = new frmAddClass(this); //frmAddClass(this);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    TreeNode node = treeView1.Nodes.Insert(1, frm.GetNewCatagoryName(), frm.GetNewCatagoryName());
                    node.ImageIndex = 8;
                    node.SelectedImageIndex = 9;
                } 
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteCatagory();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                RenameCatagory();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
            
        }

        public void InitProcessBar(int num)
        {
            pb_value.Value = 0;
            pb_value.Maximum = num;
        }
        public void SetProcessValue(int value)
        {
            try
            {
                pb_value.Value = value;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ShowPb()
        {
            pb_value.Visible = true;
        }

        public void HidenPb()
        {
            pb_value.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show(null, "确定从服务器同步数据到本地？", "文献同步", MessageBoxButtons.OKCancel))
                {
                    User user = User.GetInstance();
                    SynDocInfoService service = new SynDocInfoService(this, user.Key.id, user.Detail.result.loginName, user.Detail.result.tel, user.Detail.result.email);
                    service.SynDocInfo();
                    InitTreeView();
                    InitIcon();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpgradeQuotationCatagory();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "浏览原文" && dataGridView1.CurrentCell.Value.ToString() == "浏览原文")
                {
                    OpenNetDoc();
                }
                
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        /// <summary>
        /// 打开本地文献
        /// wuhailong
        /// 2016-07-23
        /// </summary>
        private void OpenLocalDoc()
        {
            try
            {
                string _strCatagory = treeView1.SelectedNode.Parent == null ? treeView1.SelectedNode.Text : treeView1.SelectedNode.Parent.Text;
                StringBuilder _sbFile = new StringBuilder(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                CommonFunction.CleanStringBuilder(_sbFile);
                Quotation quotatio = Source.GetQuotationByName(_strCatagory, _sbFile.ToString());
                if (File.Exists(quotatio.extraInfo.localPath))
                {
                    System.Diagnostics.Process.Start(quotatio.extraInfo.localPath);
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show(null,"当前文献为链接本地文档，是否链接？","链接本地文档",MessageBoxButtons.YesNo))
                    {
                        EditQuotaion();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 打开网络文献地址
        /// wuhailong
        /// 2016-07-23
        /// </summary>
        private void OpenNetDoc()
        {
            try
            {
                string _strId = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                System.Diagnostics.Process.Start(PublicVar.literatureBaseUrl + "/documents/" + _strId + "/online?source=writeaid");
            }
            catch (Exception)
            {
                
                throw;
            }
        }



        public static frmLiteratureStorage GetInstance()
        {
            try
            {
                if (frm == null||frm.IsDisposed)
                {
                    frm = new frmLiteratureStorage();
                }
                frm.InitTreeView();
                frm.InitIcon();
                return frm;
            }
            catch (Exception ex)
            {
                throw new Exception("frmMyliterature",ex) ;
            }
        }

        public string catagory = "未分类";


        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (catagory == "回收站")
                {
                    contextMenuStrip2.Items["编辑ToolStripMenuItem"].Visible = false;
                    contextMenuStrip2.Items["修改分组ToolStripMenuItem"].Visible = false;
                    contextMenuStrip2.Items["删除放入回收站ToolStripMenuItem"].Visible = false;
                    contextMenuStrip2.Items["彻底删除ToolStripMenuItem1"].Visible = true;
                    contextMenuStrip2.Items["还原文献ToolStripMenuItem1"].Visible = true;
                }
                else
                {
                    contextMenuStrip2.Items["编辑ToolStripMenuItem"].Visible = true;
                    contextMenuStrip2.Items["修改分组ToolStripMenuItem"].Visible = true;
                    contextMenuStrip2.Items["删除放入回收站ToolStripMenuItem"].Visible = true;
                    contextMenuStrip2.Items["彻底删除ToolStripMenuItem1"].Visible = false;
                    contextMenuStrip2.Items["还原文献ToolStripMenuItem1"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        /// <summary>
        /// 修改文献分组
        /// wuhailong
        /// 2016-09-11
        /// </summary>
        public void ChangeLiteraturCatagory()
        {
            try
            {
                string sourceCatagoryName = PublicVar.selectedCatagory;
                string literatureName = CleanLiteratureName(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                string targetCatagoryName = string.Empty;
                frmChangeClass frm = new frmChangeClass(this);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    targetCatagoryName = frm.newCatagoryName;
                    Source.UpdateLiteratureCategory(literatureName, sourceCatagoryName, targetCatagoryName);
                    RefreshUpdateCatagoryUI(sourceCatagoryName, targetCatagoryName, literatureName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void 修改分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeLiteraturCatagory();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void 删除放入回收站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceCatagoryName = PublicVar.selectedCatagory;
                string targetCatagoryName = "回收站";
                string literatureName =CleanLiteratureName( dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                Source.UpdateLiteratureCategory(literatureName, sourceCatagoryName, targetCatagoryName);
                RefreshUpdateCatagoryUI(sourceCatagoryName, targetCatagoryName, literatureName);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void 彻底删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(this, "彻底删除当前文献吗？删除后无法还原！", "确定", MessageBoxButtons.YesNo))
                {
                    string sourceCatagoryName = PublicVar.selectedCatagory;
                    string literatureName = CleanLiteratureName(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                    Source.DelLiterature(literatureName, sourceCatagoryName);
                    RefreshUpdateCatagoryUI(sourceCatagoryName, string.Empty, literatureName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void 还原文献ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceCatagoryName = PublicVar.selectedCatagory;
                string literatureName = CleanLiteratureName(dataGridView1.SelectedRows[0].Cells["标题"].Value.ToString());
                Source.UpdateLiteratureCategory(literatureName, sourceCatagoryName, string.Empty);
                RefreshUpdateCatagoryUI(sourceCatagoryName, "未分类", literatureName);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
            AsynUploadDocService service = new AsynUploadDocService();
            service.SynUpolad();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }

        /// <summary>
        /// 关闭后进行上传操作，保证信息最新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMyLiterature_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{
            //    AsynUploadDocService service = new AsynUploadDocService();
            //    service.SynUpolad();
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmMyLiterature), ex);
            //}
            
        }



        public string userId { get; set; }

        public string userName { get; set; }

        public string userPhone { get; set; }

        public string serEmail { get; set; }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfd_zip.ShowDialog() == DialogResult.OK)
                {
                    string zipFile = sfd_zip.FileName;
                    ZipService.Zip(FileStorageService.GetInstance().GetBaseDir(), zipFile);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }

        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd_zip.ShowDialog() == DialogResult.OK)
                {
                    if (Directory.Exists(FileStorageService.GetInstance().GetBaseDir()))
                    {
                        Directory.Delete(FileStorageService.GetInstance().GetBaseDir(), true);
                    }
                    Directory.CreateDirectory(FileStorageService.GetInstance().GetBaseDir());
                    Directory.CreateDirectory(FileStorageService.GetInstance().GetBaseDir() + "回收站");
                    Directory.CreateDirectory(FileStorageService.GetInstance().GetBaseDir() + "未分类");
                    string zipFile = ofd_zip.FileName;
                    ZipService.UnZip(zipFile, FileStorageService.GetInstance().GetBaseDir());
                    InitTreeView();
                    InitIcon();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLiteratureStorage), ex);
            }
        }
    }
}
