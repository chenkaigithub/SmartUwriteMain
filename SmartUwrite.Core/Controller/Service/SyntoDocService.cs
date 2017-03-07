using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using BIMTClassLibrary.Model;
namespace BIMTClassLibrary.LiteratureStorage
{
    /// <summary>
    /// 本地文献库数据修改后假如文档中引用了此文献则进行同步
    /// wuhailong
    /// 2016-11-03
    /// </summary>
    public class SyntoDocService
    {
        static Microsoft.Office.Interop.Word.Application wordApp = WordApplication.GetInstance().WordApp;
        QuotationItem item = QuotationItem.GetInstance();
        Quotation quotation = null;
        public SyntoDocService(Quotation q) {
            quotation = q;
        }
        public bool Exsit()
        {
            return false;
        }

        /// <summary>
        /// 只刷新文末引文
        /// </summary>
        public void Refresh()
        {
            QuotationSet set = new QuotationSet(quotation);
            set.WriteContent();
            Word.Field field = item.GetFieldByAuthorYear(quotation.GetCurrentAuthorYear());
            int start = field.Code.Start;
            Word.Range range = wordApp.ActiveDocument.Range(start, start);
            field.Delete();
            Word.Field _newField = CommonFunction.WriteQuotationFieldAtRange(range, QuotationItem.FLAG, quotation);
            QuotationItem.SetItemStyle(_newField.Result);
        }

    }
}
