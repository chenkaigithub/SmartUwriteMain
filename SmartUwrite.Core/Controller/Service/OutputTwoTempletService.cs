using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using BIMT.Util;
using BIMT.Util.CSV;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace BIMTClassLibrary.Controller.Service
{
    public class OutputTwoTempletService :CommonExportProcess, IInvokeService
    {
        string excelPath;
        string ouputPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\导出目录\\";
        object docpath1 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\临床研究编辑部审稿意见书.docx";
        object docpath2 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\论文授权书.docx";

        public void InitFolder()
        {
            if (!Directory.Exists(ouputPath))
            {
                Directory.CreateDirectory(ouputPath);
            }
        }

        private bool Exist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        private OutputTwoTempletService(IViewCallback view):base() {
            this.view = view;

        }

        public OutputTwoTempletService(IViewCallback view, string path)
            : base()
        {
            this.view = view;
            this.excelPath = path;
            //doc_sgyj = OpenDoc(docpath1);
            //doc_sqs = OpenDoc(docpath2);
        }

        public void DoWord()
        {
            try
            {
                InitItemInvoke mi = new InitItemInvoke(view.SetView);
                DataTable source = ExcelHelper.ImportExcel(excelPath);
                int count = 0;
                view.MyInvoke(mi, new object[] { source.Rows.Count, null });
                foreach (DataRow item in source.Rows)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\意见书\\" + item["A"].ToString() + ".pdf";
                    if (!Exist(path) && item["A"].ToString().Trim() != string.Empty)
                    {
                        count++;
                        view.MyInvoke(mi, new object[] { count, OutputTempletSGYJ(item) });
                        view.MyInvoke(mi, new object[] { count, OutputTempletSQS(item) });
                    }
                }
                view.MyInvoke(mi, new object[] { source.Rows.Count, "模板导出完毕..." });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                QuitWord();
            }
        }

        public string OutputTempletSGYJ(DataRow item)
        {
            Microsoft.Office.Interop.Word._Document doc = OpenDoc(docpath1);
            Random r = new Random();
            r.Next(5, 7);
            InsertValue(doc, "title", item["A"].ToString());
            InsertValue(doc, "author", item["D"].ToString());
            InsertValue(doc, "artitleno", item["B"].ToString());
            InsertValue(doc, "date", DateTime.Parse(item["C"].ToString()).ToString(@"yyyy/MM/dd"));
            InsertValue(doc, "date2", DateTime.Parse(item["C"].ToString()).AddDays(7).ToString(@"yyyy/MM/dd"));
            InsertValue(doc, "date3", DateTime.Parse(item["C"].ToString()).AddDays(r.Next(5, 6)).ToString(@"yyyy/MM/dd"));
            PDFConvertHelper.DOCConvertToPDF(doc, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\意见书\\" + item["A"].ToString() + ".pdf");
            DoNotSaveChanges(doc);
            return string.Format("意见书 标题：{0} 作者：{1}", item["A"].ToString(), item["D"].ToString());
        }


        public string OutputTempletSQS(DataRow item)
        {
            Microsoft.Office.Interop.Word._Document doc = OpenDoc(docpath2);
            InsertValue(doc, "title", item["A"].ToString());
            InsertValue(doc, "author", item["D"].ToString());
            InsertValue(doc, "artitleno", item["B"].ToString());
            InsertValue(doc, "date", DateTime.Parse(item["C"].ToString()).ToString("yyyy年MM月dd日"));
            string ouputPaht = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\";
            PDFConvertHelper.DOCConvertToPDF(doc, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\授权书\\" + item["A"].ToString() + ".pdf");
            object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            //object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            //object RouteDocument = false;
            doc.Close(ref SaveChanges, ref unknow, ref unknow);
            return string.Format("授权书 标题：{0} 作者：{1}", item["A"].ToString(), item["D"].ToString());
        }

    }
}
