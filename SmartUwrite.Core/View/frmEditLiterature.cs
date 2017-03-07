using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BIMTClassLibrary.LiteratureStorage;

namespace BIMTClassLibrary
{
    public partial class frmEditLiterature : Form
    {
        List<ucAuthorInfo> listAuthers = new List<ucAuthorInfo>();
        private frmLiteratureStorage frmMyLiterature;
        private string category;
        private string literature;

        public frmEditLiterature()
        {
            InitializeComponent();
        }

        [method: Obsolete("该方法已经过时", true)]
        public frmEditLiterature(string p)
        {
            InitializeComponent();
            InitData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">类别</param>
        /// <param name="p_2">文件名称</param>
        [method: Obsolete("该方法已经过时", true)]
        public frmEditLiterature(string categoryName, string LiteratureName)
        {
            InitializeComponent();
            InitData();
        }

        [method: Obsolete("该方法已经过时", true)]
        public frmEditLiterature(string p, string p_2, frmLiteratureStorage frmMyLiterature)
        {
            InitializeComponent();
            this.frmMyLiterature = frmMyLiterature;
            InitData();
        }

        public frmEditLiterature(BIMTClassLibrary.frmLiteratureStorage frmMyLiterature, string catagory, string literature)
        {
            InitializeComponent();
            this.frmMyLiterature = frmMyLiterature;
            this.category = catagory;
            this.literature = literature;
            InitData();
        }

        private void InitData()
        {
            try
            {
                Quotation quotation = frmMyLiterature.Source.GetQuotationByName(this.category, literature);
                this.quotation = quotation;
                title.Text = quotation.title;
                zz.Text = quotation.publishInfo.periodicalInfo.name;
                zzjc.Text= quotation.publishInfo.periodicalInfo.nameAbbr;
                juan.Text = quotation.publishInfo.volumeInfo;
                qi.Text = quotation.publishInfo.issueInfo;
                year.Text = quotation.publishInfo.publishYear;
                date.Text = quotation.extraInfo.createDate;
                page.Text = quotation.publishInfo.pageRange;
                doi.Text = quotation.extraInfo.doi;
                pmid.Text = quotation.extraInfo.PMID;
                localPath.Text = quotation.extraInfo.localPath;
                int count = 1;
                //panel1.Height = quotation.listAuthor.Count * 37;
                //panel2.Location = new Point(panel1.Location.X, panel1.Location.Y + panel1.Height);
                foreach (Author item in quotation.listAuthor)
                {
                    ucAuthorInfo uc = new ucAuthorInfo(count, item);
                    uc.Location = new Point(0, (count - 1) * 37);//49-12=37
                    panel1.Controls.Add(uc);
                    listAuthers.Add(uc);
                    count++;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmEditLiterature), "文献保存失败！" + ex.Message);
            }
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void SaveQuotation() {
            try
            {
                quotation.title = title.Text;
                quotation.publishInfo.periodicalInfo.name = zz.Text;
                quotation.publishInfo.periodicalInfo.nameAbbr = zzjc.Text;
                quotation.publishInfo.volumeInfo = juan.Text;
                quotation.publishInfo.issueInfo = qi.Text;
                quotation.publishInfo.publishYear = year.Text;
                quotation.extraInfo.createDate = date.Text;//出版日期
                quotation.publishInfo.pageRange = page.Text;
                quotation.extraInfo.doi = doi.Text;
                quotation.extraInfo.PMID = pmid.Text;
                quotation.extraInfo.localPath = localPath.Text;
                int count = 1;
                foreach (Author item in quotation.listAuthor)
                {
                    item.name.fore = listAuthers[count - 1].getFore();
                    item.name.last = listAuthers[count - 1].getLast();
                    item.name.full = listAuthers[count - 1].getFull();

                    //ucAuthorInfo uc = new ucAuthorInfo(count, item);
                    //uc.Location = new Point(414, 17 + (count - 1) * 37);//49-12=37
                    //this.Controls.Add(uc);
                    count++;
                }

                frmMyLiterature.Source.SaveLiterature(category, quotation);
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmEditLiterature), "文献保存失败！" + ex.Message);
            }
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            try
            {
                SaveQuotation();
                bool ok = QuotationItem.GetInstance().ExistField(quotation.GetCurrentAuthorYear());
                if (ok)
                {
                    
                    SyntoDocService ss = new SyntoDocService(quotation);
                    ss.Refresh();
                    QuotationSet.InitQuotationListInDoc();
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmEditLiterature),ex);
            }
           
        }

        public Quotation quotation { get; set; }

        private void btn_link_doc_Click(object sender, EventArgs e)
        {
            LinkDoc();
        }

        /// <summary>
        /// 链接文档
        /// wuhailong
        /// 2016-07-23
        /// </summary>
        private void LinkDoc()
        {
            try
            {
                ofd_doc.ShowDialog();
                string _strFile = ofd_doc.FileName;
                if (File.Exists(_strFile))
                {

                    FileInfo fi = new FileInfo(_strFile);
                    localPath.Text = PublicVar.DocDir + fi.Name;
                    bool ok = CopyFileToLocalLib(_strFile, fi.Name);
                    if (ok)
                    {
                        SaveDocPathToQuotation(_strFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmEditLiterature), ex);
            }
            
        }

        /// <summary>
        /// 将文档的本地路径保存到文献的json文件中
        /// </summary>
        /// <param name="_strFile"></param>
        private void SaveDocPathToQuotation(string _strFile)
        {
            SaveQuotation();
        }

        /// <summary>
        /// 将文献拷贝到本地统一文献库下
        /// wuhailong
        /// 2016-07-23
        /// </summary>
        /// <param name="_strFile"></param>
        private bool CopyFileToLocalLib(string _strFile,string FileName)
        {
            try
            {
                if (File.Exists(PublicVar.DocDir + FileName))
                {
                    MessageBox.Show(null, "此文件已经绑定，现有文献条目！", "同名文档");
                    //string path = @"D:\Program Files";
                    System.Diagnostics.Process.Start("explorer.exe", PublicVar.DocDir);
                    return false;
                }
                else
                {
                    File.Copy(_strFile, PublicVar.DocDir + FileName);
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 将文献
        /// </summary>
        private void CopyFileToLocalLib()
        {
            throw new NotImplementedException();
        }
    }
}
