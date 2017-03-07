using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using BIMT.Util;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Microsoft.Office.Interop.Word;
using BIMTClassLibrary.View;
namespace BIMTClassLibrary.Controller.Service
{
    public class ExtractInfoService : CommonExportProcess, IInvokeService
    {
        //ISetViewable view;
        //Microsoft.Office.Interop.Word.Application wordApp = null;//new Word.Application();
        private Microsoft.Office.Interop.Word._Document doc;
        object _nullobj = System.Reflection.Missing.Value;
        string path = string.Empty;
        DataTable table = new DataTable();

        public DataTable Table
        {
            get { return table; }
            set { table = value; }
        }

        public void InitTable()
        {
            Table.Columns.Add("标题");
            Table.Columns.Add("作者");
            Table.Columns.Add("英文关键词");
            Table.Columns.Add("中文关键词");
            Table.Columns.Add("英文摘要");
            Table.Columns.Add("中文摘要");
        }
        private ExtractInfoService() { }

        public ExtractInfoService( IViewCallback view,string path)
        {
            this.path = path;
            this.view = view;
            wordApp = new Word.Application();
        }

        public ExtractInfoService(Microsoft.Office.Interop.Word.Application wordApp)
        {
            if (this.wordApp != null)
            {
                QuitWord();
            }
            this.wordApp = wordApp;
        }

        public string ExtractTitle()
        {
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                if (item.Range.Text.Trim() != string.Empty)
                {
                    return item.Range.Text.Trim();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 作者稿件第二个非空段默认为作者
        /// wuhailong
        /// 2016-12-02
        /// </summary>
        /// <returns></returns>
        public string ExtractAuthors()
        {
            int count = 0;
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                if (item.Range.Text.Trim() != string.Empty)
                {
                    count++;
                    if (count == 2)
                    {
                        return item.Range.Text.Trim();
                    }
                }
            }
            return string.Empty;
        }

        private string ExtractCNKeywords(string content)
        {
            Regex r = new Regex(@"(\[|\【)?(关|關)(\s)*(键|鍵)(\s)*(词|詞)(\]|\】|\s|:|：)?");
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return content;
            }
            return string.Empty;
        }

        public string ExtractCNKeywords()
        {
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                string result = ExtractCNKeywords(item.Range.Text.Trim());
                if (result != string.Empty)
                {
                    return result;
                }
            }
            return string.Empty;
        }

        private string ExtractENKeywords(string content)
        {
            Regex r = new Regex(@"(\[|\【)?key(\s)?word(s)?(\]|\】|\s|:|：)?", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return content;
            }
            return string.Empty;
        }

        public string ExtractENKeywords()
        {
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                string result = ExtractENKeywords(item.Range.Text.Trim());
                if (result != string.Empty)
                {
                    return result;
                }
            }
            return string.Empty;
        }

        private string ExtractCNAbstracts(string content)
        {
            Regex r = new Regex(@"(\[|\【)?(摘)(\s)*(要)(\]|\】|\s|:|：)?");
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return content;
            }
            return string.Empty;
        }

        public string ExtractCNAbstracts()
        {
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                string result = ExtractCNAbstracts(item.Range.Text.Trim());
                if (result != string.Empty)
                {
                    return result;
                }
            }
            return string.Empty;
        }

        private string ExtractENAbstracts(string content)
        {
            Regex r = new Regex(@"(\[|\【)?abstract(s|ion)?(\]|\】|\s|:|：)?", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return content;
            }
            return string.Empty;
        }

        private string GetAimsorObjective(string content)
        {
            Regex r = new Regex(@"(^Aim(s)?)|(^Objective)", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return "\n" + content;
            }
            return string.Empty;
        }

        private string GetMethods(string content)
        {
            Regex r = new Regex(@"(^Method(s)?)", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return "\n" + content;
            }
            return string.Empty;
        }

        private string GetResults(string content)
        {
            Regex r = new Regex(@"(^Result(s)?)", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return "\n" + content;
            }
            return string.Empty;
        }

        private string GetConclusion(string content)
        {
            Regex r = new Regex(@"(^Conclusion)", RegexOptions.IgnoreCase);
            Match m = r.Match(content);
            if (m.Captures.Count > 0)
            {
                return "\n" + content;
            }
            return string.Empty;
        }

        public string ExtractENAbstracts()
        {
            string result = string.Empty;
            foreach (Word.Paragraph item in wordApp.ActiveDocument.Paragraphs)
            {
                string content = item.Range.Text.Trim();
                result += ExtractENAbstracts(content)
                   + GetAimsorObjective(content)
                   + GetMethods(content)
                   + GetResults(content)
                   + GetConclusion(content);
            }
            return result;
        }

        public FileInfo[] GetDocS()
        {
            
            return new DirectoryInfo(path).GetFiles();
        }

        public Document OpenDoc(object fileName)
        {
            
            return wordApp.Documents.Open(ref fileName,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow);
        }
        object unknow = Type.Missing;
        public void ExportBaseInfo()
        {
            try
            {
                InitTable();
                FileInfo[] fileInfos = GetDocS();
               
                int count = 0;
                foreach (FileInfo item in fileInfos)
                {
                    if (!item.Name.StartsWith("~")&&(item.Extension == ".doc" || item.Extension == ".docx"))
                    {
                      doc=  OpenDoc(item.FullName);
                        string title = ExtractTitle();
                        string keywords_en = ExtractENKeywords();
                        string keywords_cn = ExtractCNKeywords();
                        string abstracts_en = ExtractENAbstracts();
                        string abstracts_cn = ExtractCNAbstracts();
                        Table.Rows.Add(title, keywords_en, keywords_cn, abstracts_en, abstracts_cn);
                        doc.Close(ref _nullobj, ref _nullobj, ref _nullobj);
                        count++;
                        //frm.SetProcess(count, string.Format("标题：{0} 英文关键词：{1} 中文关键词：{2} 英文摘要：{3} 中文摘要：{4}"
                        //    , title
                        //    , keywords_en
                        //    , keywords_cn
                        //    , abstracts_en
                        //    , abstracts_cn));
                    }
                }
                ExportExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        string excelpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\文献信息.xlsx";
        public void ExportExcel()
        {
            ExcelHelper.DataTabletoExcel(Table, excelpath);
        }

        public void DoWord()
        {
            InitItemInvoke mi = new InitItemInvoke(view.SetView);
            InitTable();
            FileInfo[] fileInfos = GetDocS();
            int count = 0;
            view.MyInvoke(mi, new object[] { Directory.GetFiles(path).Length, null });
            foreach (FileInfo item in fileInfos)
            {
                if (!item.Name.StartsWith("~") && (item.Extension == ".doc" || item.Extension == ".docx"))
                {
                    Microsoft.Office.Interop.Word._Document doc = OpenDoc(item.FullName);
                    string title = ExtractTitle();
                    string authors = ExtractAuthors();
                    string keywords_en = ExtractENKeywords();
                    string keywords_cn = ExtractCNKeywords();
                    string abstracts_en = ExtractENAbstracts();
                    string abstracts_cn = ExtractCNAbstracts();
                    Table.Rows.Add(title, authors, keywords_en, keywords_cn, abstracts_en, abstracts_cn);
                    doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdSaveChanges, ref _nullobj, ref _nullobj);
                    string value = string.Format("标题：{0} 作者：{5} 英文关键词：{1} 中文关键词：{2} 英文摘要：{3} 中文摘要：{4}"
                        , title.Length > 10 ? title.Substring(0, 10) : title.PadLeft(10, ' ')
                            , keywords_en.Length > 10 ? keywords_en.Substring(0, 10) : keywords_en.PadLeft(10, ' ')
                            , keywords_cn.Length > 10 ? keywords_cn.Substring(0, 10) : keywords_cn.PadLeft(10, ' ')
                            , abstracts_en.Length > 10 ? abstracts_en.Substring(0, 10) : abstracts_en.PadLeft(10, ' ')
                            , abstracts_cn.Length > 10 ? abstracts_cn.Substring(0, 10) : abstracts_cn.PadLeft(10, ' ')
                            , authors.Length > 10 ? authors.Substring(0, 10) : authors.PadLeft(10, ' '));
                    count++;
                    view.MyInvoke(mi, new object[] { count, value });
                }
            }
            view.MyInvoke(mi, new object[] { Directory.GetFiles(path).Length, "文献信息采取完毕..." });
            ExportExcel();
        }

        //public override dynamic Init()
        //{
        //    InitTable();
        //    return GetDocS();
        //}

        //public override void Finish()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Process(dynamic item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
