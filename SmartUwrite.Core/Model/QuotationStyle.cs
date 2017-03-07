using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Word = Microsoft.Office.Interop.Word;
using BIMTClassLibrary.Model;
namespace BIMTClassLibrary
{
    public class QuotationStyle:IQuotation
    {
        public static readonly string FLAG = "QUOTATION_STYLE";
        private string styleName = string.Empty;
        public void InitStatus()
        {
            throw new NotImplementedException();
        }
        public QuotationStyle(string style) {
            styleName = style;
        }

        public void WriteContent()
        {
            try
            {
                //Microsoft.Office.Interop.Word.Field fieldQuotationSet = CommonFunction.GetFieldByCodeText(WordApplication.GetInstance().WordApp, FLAG);
                //if (null != fieldQuotationSet)
                //{
                //    if (styleName == string.Empty)
                //    {
                //        throw (new Exception("没有设置样式名称"));
                //    }
                //    fieldQuotationSet.Data = styleName;
                //}
                //else
                //{
                //    object fieldType = Word.WdFieldType.wdFieldAddin;
                //    object formula = FLAG;
                //    object presrveFormatting = false;
                //    Word.Range _rangeData = WordApplication.GetInstance().WordApp.ActiveDocument.Range(1, 1);
                //    Word.Field _fieldAddIn = WordApplication.GetInstance().WordApp.ActiveDocument.Fields.Add(_rangeData, ref fieldType, ref formula, ref presrveFormatting);
                //    _fieldAddIn.ShowCodes = false;
                //}
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(QuotationSet), ex);
            }
        }

        public string GetPreStyle()
        {
            Microsoft.Office.Interop.Word.Field fieldQuotationSet = CommonFunction.GetFieldByCodeText(WordApplication.GetInstance().WordApp, FLAG);
            if (null != fieldQuotationSet)
            {

                return fieldQuotationSet.Data;
            }
            return "-1";
        }

        public void RefreshStyle(string styleName)
        {
            throw new NotImplementedException();
        }

        public void SetStyle()
        {
            throw new NotImplementedException();
        }

        public bool ExistField(string authorYear)
        {
            throw new NotImplementedException();
        }

        public List<Microsoft.Office.Interop.Word.Field> GetDocFieldList()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Word.Field GetFieldByAuthorYear(string authorYear)
        {
            throw new NotImplementedException();
        }

        public string GetFieldAuthorYearInfo(Microsoft.Office.Interop.Word.Field field)
        {
            throw new NotImplementedException();
        }

        public int GetQuotationIndex(string authorYear)
        {
            throw new NotImplementedException();
        }
    }
}
