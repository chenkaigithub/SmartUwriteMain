using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using BIMTClassLibrary.Controller.Service.ReviewCommonts;
using System.IO;
using BIMT.Util;

namespace BIMTClassLibrary.Controller.Service
{
    /// <summary>
    /// 导出审稿意见书
    /// wuhailong
    /// 2016-12-05
    /// </summary>
    class ExportReviewCommentService : CommonExportProcess, IInvokeService
    {
        string path;
        public ExportReviewCommentService(IViewCallback view, string path)
        {
            this.view = view;
            this.path = path;
        }

        public void DoWord()
        {
            InitItemInvoke mi = new InitItemInvoke(view.SetView);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] arrayDocs = di.GetFiles();
            view.MyInvoke(mi, new object[] { arrayDocs.Length, null });
            int count = 0;
            foreach (FileInfo item in arrayDocs)
            {
                if (!item.Name.StartsWith("~"))
                {
                    count++;
                    view.MyInvoke(mi, new object[] { count, OutputTempletSGYJ(item) });
                }
            }
            view.MyInvoke(mi, new object[] { 999999, "模板导出完毕..." });
        }

        bool Exist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
        private static readonly string DESKTOP = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public string OutputTempletSGYJ(FileInfo item)
        {
            Microsoft.Office.Interop.Word._Document templet = null;// OpenDoc(DESKTOP + "\\临床研究编辑部审稿意见书.docx");
            Microsoft.Office.Interop.Word._Document doc = null;// OpenDoc(item.FullName);
            try
            {
                string[] array = item.Name.Split('_');
                string path = DESKTOP + "\\临床研究编辑部审稿意见书\\" + array[1] + ".pdf";
                if (Exist(path))
                {
                    return string.Format("{0}.pdf文档已导出", array[1]);
                }
                templet = OpenDoc(DESKTOP + "\\临床研究编辑部审稿意见书.docx");
                doc = OpenDoc(item.FullName);
                BaseComments service = GetService(doc);
                if (service == null)
                {
                    return item.FullName;
                }
                
                Random r = new Random();
                r.Next(5, 7);
                InsertValue(templet, "title", array[1]);
                InsertValue(templet, "author", array[0]);
                InsertValue(templet, "artitleno", array[2].Substring(0, 14));
                string dateString = array[2].Substring(0, 8);
                InsertValue(templet, "date", DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString(@"yyyy/MM/dd"));
                InsertValue(templet, "date2", DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddDays(7).ToString(@"yyyy/MM/dd"));
                InsertValue(templet, "date3", DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddDays(r.Next(5, 6)).ToString(@"yyyy/MM/dd"));
                service.BuildComments(templet);
                PDFConvertHelper.DOCConvertToPDF(templet, path);
                return string.Format("意见书 标题：{0} 作者：{1}", array[1], array[0]);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DoNotSaveChanges(templet);
                DoNotSaveChanges(doc);
            }
            
        }

        public void SetCheck()
        {
            Microsoft.Office.Interop.Word._Document doc = OpenDoc(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\临床研究编辑部审稿意见书.docx");
            //Microsoft.Office.Interop.Word.CheckBox chk = new Microsoft.Office.Interop.Word.CheckBox
            doc.Activate();
            foreach (Field wdField in doc.Fields)
            {
                if (wdField.Type == WdFieldType.wdFieldFormCheckBox)
                {
                    bool ok=((Microsoft.Office.Interop.Word.CheckBox)wdField).Value;
                    //wdField.Select();
                    string fieldText = wdField.Result.Text;
                }
            }
            Microsoft.Office.Interop.Word.CheckBox chk = (Microsoft.Office.Interop.Word.CheckBox)doc.FormFields.get_Item("CheckBox1");
            chk.Value = false;//.get_Value();
            SaveDocument(doc, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\111.docx");
        }

        public BaseComments GetService(string path)
        {
            return GetService(OpenDoc(path));
        }

        public BaseComments GetService(Microsoft.Office.Interop.Word._Document doc)
        {
            try
            {
                if (CommentsAccept.GetInstance().IsMe(doc))
                {
                    return CommentsAccept.GetInstance();
                }
                else if (CommentsReviewAfterFix.GetInstance().IsMe(doc))
                {
                    return CommentsReviewAfterFix.GetInstance();
                }
                else if (CommentsReject.GetInstance().IsMe(doc))
                {
                    return CommentsReject.GetInstance();
                }
                else if (CommentsAcceptAfterFix.GetInstance().IsMe(doc))
                {
                    return CommentsAcceptAfterFix.GetInstance();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
