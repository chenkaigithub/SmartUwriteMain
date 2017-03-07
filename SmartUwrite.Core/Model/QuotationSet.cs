using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BIMTClassLibrary.Model;




namespace BIMTClassLibrary
{
    class QuotationSet : IQuotation
    {
        public static readonly string FLAG = "QUOTATION_SET";
        static Microsoft.Office.Interop.Word.Application WordApp;
        private Quotation quotation;

        public QuotationSet()
        { WordApp = WordApplication.GetInstance().WordApp; }

        public QuotationSet(Microsoft.Office.Interop.Word.Application p_WordApp)
        {
            //InitStatus();
            if (p_WordApp == null)
            {
                WordApp = WordApplication.GetInstance().WordApp;
            }
            else
            {
                WordApp = p_WordApp;
            }
        }

        public QuotationSet(Quotation q)
        {
            // TODO: Complete member initialization
            this.quotation = q;
            WordApp = WordApplication.GetInstance().WordApp;
            
        }



        public void InitStatus()
        {
            //throw new NotImplementedException();
        }

        public bool ExistQuotation(List<Quotation> listq, Quotation q)
        {
            
            foreach (var item in listq)
            {
                if (item.GetCurrentAuthorYear() == q.GetCurrentAuthorYear())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 刷新数据域内容
        /// wuhailong
        /// 2016-11-03
        /// </summary>
        /// <param name="listq"></param>
        /// <param name="q"></param>
        public List<Quotation> FreshSet(List<Quotation> listq, Quotation q)
        {
            for (int i = 0; i < listq.Count; i++)
            {
                if (listq[i].GetCurrentAuthorYear() == q.GetCurrentAuthorYear())
                {
                    listq[i] = q;
                }
            }
            return listq;
        }

        /// <summary>
        /// 写入文献信息
        /// </summary>
        public void WriteContent()
        {
            try
            {
                Word.Field fieldQuotationSet = CommonFunction.GetFieldByCodeText(WordApp, QuotationSet.FLAG);
                if (null != fieldQuotationSet)
                {
                    string quotationDataJson = fieldQuotationSet.Data.ToString();
                    List<Quotation> listq = JsonConvert.DeserializeObject<List<Quotation>>(quotationDataJson);// CommonFunction.Deserialize<List<Quotation>>(quotationDataJson);
                    bool exist = ExistQuotation(listq, quotation);
                    if (!exist)
                    {
                        listq.Add(quotation);
                        quotationDataJson = CommonFunction.GetJsonString(listq);
                        fieldQuotationSet.Data = quotationDataJson;
                    }
                    else
                    {
                        listq = FreshSet(listq, quotation);
                        quotationDataJson = CommonFunction.GetJsonString(listq);
                        fieldQuotationSet.Data = quotationDataJson;
                    }
                }
                else
                {
                    QuotationSet qs = new QuotationSet(quotation);
                    List<Quotation> listq = new List<Quotation>();
                    listq.Add(quotation);
                    string _strJson = JsonConvert.SerializeObject(listq);// CommonFunction.GetJsonString(listq);
                    //自定义域用来保存所有插入的文献信息
                    object fieldType = Word.WdFieldType.wdFieldAddin;
                    object formula = QuotationSet.FLAG;
                    object presrveFormatting = false;
                    Word.Range _rangeData = WordApp.ActiveDocument.Range(0, 0);
                    Word.Field _fieldAddIn = WordApp.ActiveDocument.Fields.Add(_rangeData, ref fieldType, ref formula, ref presrveFormatting);
                    _fieldAddIn.Data = _strJson;
                    _fieldAddIn.ShowCodes = false;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(QuotationSet), ex);
            }
        }
        private static List<Quotation> listQuotationInDoc = new List<Quotation>();
        /// <summary>
        /// 获取word文档中保存 的文献对象
        /// 2016-05-10
        /// wuhailong
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        public static Quotation GetQuotationByeAuthorYear(string authorYear)
        {
            try
            {
                Quotation quotation = null;
                foreach (Quotation item in listQuotationInDoc)
                {
                    string currentAuthorYear = item.GetCurrentAuthorYear();
                    if (currentAuthorYear.Trim() == authorYear.Trim())
                    {
                        quotation = item;
                        break;
                    }
                }
                return quotation;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 将自定义域内的数据序列化为引文对象list
        /// wuhailong
        /// 2016-08-10
        /// </summary>
        public static void InitQuotationListInDoc()
        {
            try
            {
                Word.Field fieldQuotationSet = CommonFunction.GetFieldByCodeText(WordApp, QuotationSet.FLAG);
                if (null != fieldQuotationSet)
                {
                    string _strData = fieldQuotationSet.Data.ToString();
                    listQuotationInDoc = JsonConvert.DeserializeObject<List<Quotation>>(_strData);// CommonFunction.Deserialize<List<Quotation>>(_strData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetStyle()
        {
            throw new NotImplementedException();
        }


        public void RefreshStyle(string styleName)
        {
            throw new NotImplementedException();
        }


        public List<Word.Field> GetDocFieldList()
        {
            throw new NotImplementedException();
        }


        public bool ExistField(string authorYear)
        {
            throw new NotImplementedException();
        }


        public Word.Field GetFieldByAuthorYear(string authorYear)
        {
            throw new NotImplementedException();
        }


        public string GetFieldAuthorYearInfo(Word.Field field)
        {
            throw new NotImplementedException();
        }


        public int GetQuotationIndex(string authorYear)
        {
            throw new NotImplementedException();
        }
    }
}
