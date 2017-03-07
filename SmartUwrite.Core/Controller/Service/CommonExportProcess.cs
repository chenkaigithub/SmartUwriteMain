using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using BIMT.Util;

namespace BIMTClassLibrary.Controller.Service
{
    public class CommonExportProcess
    {
        public IViewCallback view;
        public Microsoft.Office.Interop.Word.Application wordApp = null;
        public object unknow = Type.Missing;

        public CommonExportProcess()
        {
            wordApp = new Word.Application();
        }

        public Document OpenDoc(object fileName)
        {
            return wordApp.Documents.Open(ref fileName,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow, ref unknow);
        }

        public void SaveDocument(Microsoft.Office.Interop.Word._Document doc, string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument;//保存格式
            object miss = System.Reflection.Missing.Value;
            doc.SaveAs(ref fileName,
             ref format, ref miss, ref miss, ref miss,
             ref miss, ref miss, ref miss, ref miss,
             ref miss, ref miss, ref miss, ref miss,
             ref miss, ref miss, ref miss);
            //关闭wordDoc，wordApp对象 
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            doc.Close(ref SaveChanges, ref miss, ref miss);
        }

        

        public bool InsertValue(Microsoft.Office.Interop.Word._Document doc, string bookmark, string value)
        {
            object bkObj = bookmark;
            if (doc.Bookmarks.Exists(bookmark))
            {
                doc.Bookmarks.get_Item(ref bkObj).Select();
                doc.Application.Selection.TypeText(value);
                return true;
            }
            return false;
        }

        public void DoNotSaveChanges(Microsoft.Office.Interop.Word._Document doc)
        {
            if (doc != null)
            {
                object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
                doc.Close(ref SaveChanges, ref unknow, ref unknow);
            }

        }

        public void SaveChanges(Microsoft.Office.Interop.Word._Document doc)
        {
            if (doc != null)
            {
                object SaveChanges = WdSaveOptions.wdSaveChanges;
                doc.Close(ref SaveChanges, ref unknow, ref unknow);
            }
        }

        public void QuitWord()
        {
            if (wordApp!=null)
            {
                wordApp.Quit(ref unknow, ref unknow, ref unknow);
                wordApp = null;
            }
        }
        
    }
}
