using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using BIMTClassLibrary.Json;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    public class QuotationItemSet
    {
        public static readonly string FLAG = "QUOTATION_ITEM_SET";
        Quotation quotation = null;

        public QuotationItemSet()
        {
            WordApp = WordApplication.GetInstance().WordApp;
        }

        public QuotationItemSet(Quotation quotation)
        {
            this.quotation = quotation;
            WordApp = WordApplication.GetInstance().WordApp;
        }

        public void InitStatus()
        {
            throw new NotImplementedException();
        }

        public void WriteContent()
        {
            string _strQuotationTitle = m_strTitle;
            Word.Field _fieldQuotationSet = CommonFunction.GetFieldByCodeText(WordApp, QuotationItemSet.FLAG);
            string _strTemplet = JsonHelper.GetValue(QuotationItem.FLAG).Split('#')[1];
            //已经有文末引文
            if (null != _fieldQuotationSet)
            {
                Word.Paragraph p = _fieldQuotationSet.Result.Paragraphs.Add();
                CommonFunction.WriteQuotationAtRange(WordApp, p.Range, QuotationItemSet.FLAG, _strTemplet, quotation);
                //_fieldQuotationSet.Result.End = WordApp.la
            }
            else//第一条文末引文建立文末疑问集合
            {
                //Microsoft.Office.Interop.Word.Paragraph paragraph = CommonFunction.AddEndParagraph(WordApp);
                Word.Paragraph p = CommonFunction.AddEndParagraph(WordApp);
                Word.Field _field = CommonFunction.AddField(WordApp, p.Range, QuotationItemSet.FLAG);
                CommonFunction.WriteQuotationAtRange(WordApp, _field.Result, QuotationItemSet.FLAG, _strTemplet, quotation);
                return;
            }
        }

        public void RefreshStyle(string styleName)
        {
            throw new NotImplementedException();
        }

        public void SetStyle()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Word.Application WordApp { get; set; }

        public string m_strTitle { get; set; }

        public string m_strFontFamily { get; set; }

        public float m_fFontSize { get; set; }


        public List<Word.Field> GetDocFieldList()
        {
            throw new NotImplementedException();
        }
    }
}
