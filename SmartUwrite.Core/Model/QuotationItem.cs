using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMTClassLibrary;
using BIMTClassLibrary.Json;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using Log4Net;
using BIMTClassLibrary.quotation;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 引文条目
    /// 分为作者出版年制&顺序编码制
    /// 2016-04-05
    /// wuahilong
    /// </summary>
    public class QuotationItem : IQuotation
    {
        public static readonly string FLAG = "QUOTATION_ITEM";
        public struct QuotationStruct
        {
            public int _nStart;
            public int _nEnd;
            public string _strContext;
        }

        static Microsoft.Office.Interop.Word.Application wordApp = WordApplication.GetInstance().WordApp;
        private Quotation quotation;
        private static QuotationItem qItem = null;
        private static List<Word.Field> listField = null;

        public static QuotationItem GetInstance()
        {
            try
            {
                if (qItem == null)
                {
                    qItem = new QuotationItem();
                }
                PublicVar.WriteIndex = false;
                listField = qItem.GetDocFieldList();
                return qItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static QuotationItem GetInstance(Quotation quotation)
        {
            try
            {
                if (qItem == null)
                {
                    qItem = new QuotationItem(quotation);
                }
                qItem.quotation = quotation;
                listField = qItem.GetDocFieldList();
                return qItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private QuotationItem()
        {
            PublicVar.WriteIndex = false;
        }

        private QuotationItem(Quotation quotation)
        {
            this.quotation = quotation;
        }

        /// <summary>
        /// 删除文末参考文献的域
        /// wuhailong
        /// 2016-08-09
        /// </summary>
        /// <param name="usrName"></param>
        /// <returns></returns>
        public  string DeleteItemField(Word.Field field)
        {
            try
            {
                string currentAuthorYear = GetFieldAuthorYearInfo(field);
                int start = field.Code.Start;
                field.Delete();
                Word.Range _range = WordApplication.GetInstance().WordApp.ActiveDocument.Range(start - 1, start);//清除参考文献删除后剩余的回车符
                if (_range.Text == "\r")
                {
                    _range.Text = string.Empty;
                }
                if (WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                {//最后一个参考文献要特殊处理一下 wuhailong 2016-07-19
                    WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range.Delete();
                }
                return currentAuthorYear;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除文末引文联动删除文中引文
        /// wuhailong
        /// 2016-06-27
        /// </summary>
        public  void DeleteItemQuotation(Word.Field field)
        {
            try
            {
                string currentAuthorYear = DeleteItemField(field);
                QuotationIndex.GetInstance().DeleteIndexQuotation(currentAuthorYear);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
            }
        }


        /// <summary>
        /// 获取打枊前文末引文前有多少个引文
        /// 2016-05-19
        /// wuhailong
        /// </summary>
        /// <param name="quotation"></param>
        /// <returns></returns>
        public static int GetQuotationItemOrder(Quotation quotation)
        {
            int _nStart = wordApp.Selection.Start;
            List<Word.Field> _listItemFields = new List<Word.Field>();
            foreach (Word.Field item in wordApp.ActiveDocument.Fields)
            {
                if (item.Code.Text.Contains(QuotationItem.FLAG))
                {
                    _listItemFields.Add(item);
                }
            }
            return _listItemFields.Count;
        }


        public void WriteContent()
        {
            try
            {
                PublicVar.WriteIndex = false;
                QuotationSet.InitQuotationListInDoc();
                List<string> listAuthorYear = QuotationIndex.GetInstance().GetDocAuthorYearList();
                listAuthorYear = SortAuthorYearList(listAuthorYear);
                AdjustQuotationItemByList2(listAuthorYear);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
            }
        }




        /// <summary>
        /// 由list判断插入位置，然后更正序号；
        /// wuhailong
        /// 2016-07-16
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="_listAuthorYear"></param>
        private void AdjustQuotationItemByList(Microsoft.Office.Interop.Word.Application WordApp, List<string> _listAuthorYear)
        {
            try
            {
                //获取引文条目list
                List<Word.Field> _listMarks = new List<Word.Field>();
                Dictionary<string, QuotationStruct> _dictFieldContextInfo = new Dictionary<string, QuotationStruct>();
                _dictFieldContextInfo = GetFieldContextInfoOfAuthorYear(WordApp);
                //最后一个引文的作者姓氏首字母
                //不是最后一个引文
                string _strCurrentAuthorYear = quotation.GetCurrentAuthorYear();
                if ((_listAuthorYear.Count > 1) && (_listAuthorYear[_listAuthorYear.Count - 1] != _strCurrentAuthorYear))//多于1个元素，且非最后一个元素
                {
                    bool _boolDel = false;
                    List<string> _listNeedAppendItem = new List<string>();
                    for (int i = 0; i < _listAuthorYear.Count; i++)
                    {
                        PublicVar.CurrentIndex = i;
                        //遭到最大item，和他的下一个，然后插入引文
                        if (_listAuthorYear[i] == _strCurrentAuthorYear)
                        {
                            _boolDel = true;
                            continue;
                        }
                        if (_boolDel)
                        {
                            _listNeedAppendItem.Add(_listAuthorYear[i].Trim());
                            Word.Field _fieldDel = CommonFunction.GetFieldByCodeText(WordApp, QuotationItem.FLAG + "_" + _listAuthorYear[i]);
                            if (_fieldDel == null)
                            {
                                continue;
                            }
                            _fieldDel.Delete();//删除最新元素位置后元素
                            if (WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                            {
                                Word.Range _p = WordApp.ActiveDocument.Paragraphs.Last.Range;
                                if (_p.End - _p.Start == 2)
                                {
                                    _p.SetRange(_p.End - 1, _p.End);
                                }
                                _p.Delete();
                            }
                        }
                    }
                    //为第一个位置
                    if (_listNeedAppendItem.Count == _listAuthorYear.Count - 1)
                    {
                        //Word.Field _fieldTitle = CommonFunction.GetFieldByCodeText(WordApp, QuotationTitle.FLAG);
                        int end = WordApp.ActiveDocument.Paragraphs.Last.Range.End;
                        Word.Range _clearRange = WordApp.ActiveDocument.Range(end - 1, end - 1);
                        _clearRange.Text = "\r";
                    }
                    Word.Range _paragraphNewest = null;
                    //添加最新元素
                    if (WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                    {
                        _paragraphNewest = WordApp.ActiveDocument.Paragraphs.Last.Range;
                        //_paragraphNewest.
                    }
                    else
                    {
                        _paragraphNewest = AddParagraphAtEnd(WordApp);
                    }
                    if (_paragraphNewest.End - _paragraphNewest.Start > 1)
                    {
                        _paragraphNewest.SetRange(_paragraphNewest.End - 1, _paragraphNewest.End);
                    }
                    string _strFieldName = GetCurrentFieldName();
                    if (!CommonFunction.ExistField(WordApp, _strFieldName))
                    {
                        Word.Field _newField = CommonFunction.WriteQuotationFieldAtRange(WordApp, _paragraphNewest, QuotationItem.FLAG, quotation);
                        SetItemStyle(_newField.Result);
                    }
                    //补齐已删除元素
                    int _nLast = 1;
                    foreach (var item in _listNeedAppendItem)
                    {
                        Word.Range _paragrappend = null;
                        string _strKey = (QuotationItem.FLAG + "_" + item).Trim();
                        if (WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                        {
                            _paragrappend = WordApp.ActiveDocument.Paragraphs.Last.Range;
                        }
                        else
                        {
                            _paragrappend = AddParagraphAtEnd(WordApp);
                        }
                        if (!_dictFieldContextInfo.Keys.Contains(_strKey))
                        {
                            continue;
                        }
                        string _strAppendContext = _dictFieldContextInfo[_strKey]._strContext.Trim();
                        Word.Field _field = null;
                        if (!CommonFunction.ExistField(WordApp, _strKey))
                        {
                            Quotation _appItem = QuotationSet.GetQuotationByeAuthorYear(item);
                            Word.Field _newField = CommonFunction.WriteQuotationFieldAtRange(WordApp, _paragrappend, QuotationItem.FLAG, _appItem);
                            SetItemStyle(_newField.Result);
                        }
                        if (_nLast == _listNeedAppendItem.Count && _field != null)
                        {//最后一个引文不要换行
                            _field.Result.Text = _strAppendContext;
                        }
                        _nLast++;
                    }
                }
                else
                {
                    Word.Range _paragraphend = null;
                    if (WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                    {
                        _paragraphend = WordApp.ActiveDocument.Paragraphs.Last.Range;
                        if (_paragraphend.End - _paragraphend.Start == 2)
                        {
                            _paragraphend.SetRange(_paragraphend.End - 1, _paragraphend.End);
                        }
                    }
                    else
                    {
                        _paragraphend = AddParagraphAtEnd(WordApp);
                    }
                    //为最后一个元素时
                    string _strFieldName = GetCurrentFieldName();
                    if (!CommonFunction.ExistField(WordApp, _strFieldName))
                    {
                        Word.Field _fieldR = CommonFunction.WriteQuotationFieldAtRange(WordApp, _paragraphend, QuotationItem.FLAG, quotation);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        public  int GetQuotationIndex(string authorYear)
        {
            try
            {
                listField = GetDocFieldList();
                int index = 1;
                foreach (Word.Field item in listField)
                {
                    string currentAutlhorYear =GetFieldAuthorYearInfo(item); 
                    if (authorYear.Trim() == currentAutlhorYear.Trim())
                    {
                        break;
                    }
                    index++;
                }
                return index;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取文末引文的作者年list
        /// wuhailong
        /// 2016-08-09
        /// </summary>
        /// <returns></returns>
        public List<string> GetDocQuotationItemAuthorYearList()
        {
            try
            {
                List<Word.Field> listItems = GetDocFieldList();
                List<string> listAuthorYear = new List<string>();
                foreach (Word.Field item in listItems)
                {
                    string currentAutlhorYear = GetFieldAuthorYearInfo(item).Trim();
                    listAuthorYear.Add(currentAutlhorYear);
                }
                return listAuthorYear;
            }
            catch (Exception)
            {

                throw;
            }
        }

    
        /// <summary>
        /// 重定位参考文献位置
        /// 当参考文献的位置与文中引文的位置不对应时序号按照文中引文的位置修改参考文献位置
        /// 顺序编码制才需要
        /// wuhailong
        /// 2016-08-04
        /// </summary>
        public void ReLocationQuotationItem(List<string> listAuthorYear)
        {
            try
            {
                if ("TRUE" == JsonHelper.GetValue("USING_ORDER_CDOING_RULE").ToUpper())
                {
                    string currentAuthorYear = quotation.GetCurrentAuthorYear().Trim();

                    //应该的位置
                    QuotationIndex qIndex = QuotationIndex.GetInstance(null);
                    int index = qIndex.GetQuotationIndex(currentAuthorYear);

                    List<string> listItemAuthorYear = GetDocQuotationItemAuthorYearList();
                    int refIndex = GetQuotationIndex(currentAuthorYear);
                    //实际的位置
                    if (index != refIndex)
                    {//改参考文献位置
                        Word.Field field =GetFieldByAuthorYear(currentAuthorYear);//.GetFieldByCodeText(
                        int _nstart = field.Code.Start - 1;
                        field.Cut();
                        listField = GetDocFieldList();
                        Word.Range temp = WordApplication.GetInstance().WordApp.ActiveDocument.Range(_nstart, _nstart + 1);
                        if (temp.Text == "\r")
                        {
                            temp.Text = string.Empty;
                            temp.Delete();
                        }
                        Word.Field targetField = GetFieldByAuthorYear(listItemAuthorYear[index - 1]);
                        Word.Range rangeLocatated = WordApplication.GetInstance().WordApp.ActiveDocument.Range(targetField.Code.Start, targetField.Code.Start);
                        rangeLocatated.Select();
                        CommonFunction.AddParagraphAtSelection();
                        //rangeLocatated.SetRange(rangeLocatated.Start - 2, rangeLocatated.End - 1);
                        //rangeLocatated.Paste();
                        Word.Range rangePaste = wordApp.ActiveDocument.Range(rangeLocatated.Start - 2, rangeLocatated.End - 1);
                        string s = rangePaste.Text;
                        rangePaste.Paste();
                        rangePaste.Paragraphs.Add(ref oMissing);
                        //rangePaste.Text += "\r";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 获取参考文献的字典
        /// wuhailong
        /// 2016-08-04
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Word.Field> GetAllQuotationItemField()
        {
            try
            {
                Dictionary<string, Word.Field> dictField = new Dictionary<string, Word.Field>();
                List<Word.Field> listItem = GetDocFieldList();
                foreach (Word.Field item in listItem)
                {
                    string authorYear = GetFieldAuthorYearInfo(item).Trim();
                    dictField.Add(authorYear, item);
                }
                return dictField;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 返回以一个参考文献的起始位置
        /// wuhailong
        /// 2016-08-05
        /// </summary>
        /// <returns></returns>
        public static int GetFirstQuotationItemStart()
        {
            try
            {
                int start = 0;
                foreach (Word.Field item in WordApplication.GetInstance().WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        start = item.Code.Start;
                        break;
                    }
                }
                return start;
            }
            catch (Exception)
            {

                throw;
            }
        }

        static Object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// 刷新所有引文的参考文献位置
        /// wuhailong
        /// 2016-08-04
        /// </summary>
        /// <param name="listAuthorYear"></param>
        public void RefreshAllQuotationItemLocation()
        {
            try
            {
                List<string> listAuthorYear = QuotationIndex.GetInstance().GetDocAuthorYearList();
                Dictionary<string, Word.Field> dictQuotationItemField = GetAllQuotationItemField();
                int index = 0;
                foreach (string authorYear in listAuthorYear)
                {
                    try
                    {

                        Word.Range temp = null;
                        if (index != 0)
                        {//除去第一个参考文献位置的算法
                            //前一个引文作者年
                            string preAuthorYear = listAuthorYear[index - 1];
                            //前一个引文域
                            Word.Field preField = GetFieldByAuthorYear( preAuthorYear);
                            int preStart = preField.Result.End;// dictQuotationItemField[key].Result.End;
                            //当前域的开始位置
                            Word.Field tempField = dictQuotationItemField[authorYear.Trim()];
                            int startClear = tempField.Code.Start;
                            //剪切当前域
                            dictQuotationItemField[authorYear.Trim()].Cut();
                            //清除当前域 的回车符
                            Word.Range clear = WordApplication.GetInstance().WordApp.ActiveDocument.Range(startClear - 1, startClear);
                            if (clear.Text == "\r")
                            {
                                clear.Text = string.Empty;
                                //clear.Delete();
                            }
                            //新域的位置为上一个参考文献的的下一段
                            temp = WordApplication.GetInstance().WordApp.ActiveDocument.Range(preStart, preStart);
                            Word.Paragraph paragraph = CommonFunction.AddParagraphAtRange(WordApplication.GetInstance().WordApp, temp);
                            temp.SetRange(paragraph.Range.End, paragraph.Range.End);
                            //将当前域粘贴到新的位置
                            temp.Paste();
                        }
                        else
                        {//第一个参考文献位置算法
                            int start = GetFirstQuotationItemStart();
                            temp = WordApplication.GetInstance().WordApp.ActiveDocument.Range(start, start + 1);
                            Word.Paragraph paragraph = CommonFunction.AddParagraphAtRange(WordApplication.GetInstance().WordApp, temp);
                            temp.SetRange(paragraph.Range.Start - 1, paragraph.Range.Start);
                            dictQuotationItemField[authorYear].Cut();
                            temp.Paste();
                        }
                        dictQuotationItemField = GetAllQuotationItemField();
                        index++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(QuotationItem), new Exception("RefreshAllQuotationItemLocation",ex));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RefreshAllQuotationItemLocation", ex);
            }
        }

        /// <summary>
        /// 获取最后一个文末引文
        /// wuhailong
        /// 2016-10-17
        /// </summary>
        /// <returns></returns>
        public Word.Field GetLastQuotationItem()
        {
            try
            {
                List<Word.Field> list = GetDocFieldList();
                if (list.Count > 0)
                {
                    return list[list.Count - 1];
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertQuotationItem(List<string> listAuthorYear)
        {
            try
            {
                string currentAuthorYear = quotation.GetCurrentAuthorYear().Trim();
                for (int i = 0; i < listAuthorYear.Count; i++)
                {
                    PublicVar.CurrentIndex = i;
                    //遭到最大item，和他的下一个，然后插入引文
                    if (listAuthorYear[i].Trim() == currentAuthorYear)
                    {
                        Word.Range _rangInsert = null;
                        if ((i == 0 && listAuthorYear.Count == 1))//为第一个位置的文献，且为第一个文献
                        {
                            if (WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                            {//最后一段为"\r"
                                _rangInsert = WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range;
                            }
                            else
                            {
                                Word.Paragraph _para = CommonFunction.AddEndParagraph();
                                _rangInsert = _para.Range;
                            }

                        }
                        else if (i != 0 && i == listAuthorYear.Count - 1)//或最后一个
                        {
                            Word.Field lastField = GetLastQuotationItem();
                            int start = lastField.Result.End;
                            Word.Range temp = wordApp.ActiveDocument.Range(start,start);
                            CommonFunction.AddParagraphAtRangeEnd(temp);
                            _rangInsert = wordApp.ActiveDocument.Range(start+2, start+3);
                        }
                        else//中间位置引文
                        {
                            Word.Field _fieldItem = GetFieldByAuthorYear(listAuthorYear[i + 1].Trim());
                            Word.Range _range = WordApplication.GetInstance().WordApp.ActiveDocument.Range(_fieldItem.Code.Start, _fieldItem.Code.Start);
                            _range.Select();
                            CommonFunction.AddParagraphAtSelection();
                            _range.SetRange(_range.Start - 2, _range.End - 1);
                            _rangInsert = _range;
                        }

                        string _strFieldName = GetCurrentFieldName();
                        if (!CommonFunction.ExistField(_strFieldName))
                        {
                            Word.Field _newField = CommonFunction.WriteQuotationFieldAtRange(_rangInsert, QuotationItem.FLAG, quotation);
                            SetItemStyle(_newField.Result);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 通过引文序号的调整，修正引文条目
        /// 注：引文管理方式为域
        /// </summary>
        /// <param name="_listBookMark"></param>
        private void AdjustQuotationItemByList2(List<string> listAuthorYear)
        {
            try
            {
                //获取引文条目list
                string currentAuthorYear = quotation.GetCurrentAuthorYear().Trim();
                if (CommonFunction.ExistField(currentAuthorYear))
                {
                    ReLocationQuotationItem(listAuthorYear);
                }
                else
                {
                    InsertQuotationItem(listAuthorYear);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        private string GetCurrentFieldName()
        {
            return QuotationItem.FLAG + "_" + quotation.GetCurrentAuthorYear();
        }





        /// <summary>
        /// 替换指定域的code& result
        /// </summary>
        /// <param name="?"></param>
        /// <param name="p_strCode"></param>
        /// <param name="p_strResult"></param>
        public void ReplaceCodeAndResult(Word.Field p_field, string p_strCode, string p_strResult)
        {
            p_field.Code.Text = p_strCode;
            p_field.Result.Text = p_strResult;
        }

        /// <summary>
        /// 通过data 获取域
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public Word.Field GetFieldByAuthorYear(string authorYear)
        {
            try
            {
                Word.Field field = null;
                foreach (Word.Field item in listField)
                {
                    string currentAurthorYear = GetFieldAuthorYearInfo(item);
                    if (currentAurthorYear == authorYear.Trim())
                    {
                        field = item;
                    }
                }
                return field;
            }
            catch (Exception)
            {
                throw;
            }
        }




        /// <summary>
        /// 格式化引文条目；实现引文序号按顺序排列但是引文内容改变的功能
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string FormatQuotationItem(string p_strQuotation, int p_nQuotationIndex)
        {
            try
            {
                string _strStart = "[";
                string _strEnd = "]";
                //\[[^\[^\]]*\]
                string _strReg = @"\" + _strStart + _strStart + @"^\" + _strStart + @"^\" + _strEnd + _strEnd + @"*\" + _strEnd;
                var match = Regex.Match(p_strQuotation, _strReg);
                var result = match.Captures[0].Value;
                string _strNewResult = _strStart + p_nQuotationIndex.ToString() + _strEnd;
                p_strQuotation = p_strQuotation.Replace(result, _strNewResult);
                return p_strQuotation;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 获取书签内容及range信息
        /// 2016-03-30
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        private Dictionary<string, QuotationStruct> GetBookMarkContextInfo(Word.Application WordApp)
        {
            Dictionary<string, QuotationStruct> _dictBookMarkContextInfo = new Dictionary<string, QuotationStruct>();
            int _nPositionIndex = 1;
            foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
            {
                if (item.Name.StartsWith("QuotationItem"))
                {
                    string _strKey = "QuotationItem" + _nPositionIndex;
                    QuotationStruct _structBookMark;
                    _structBookMark._nStart = item.Start;
                    _structBookMark._nEnd = item.End;
                    _structBookMark._strContext = item.Range.Text;

                    _dictBookMarkContextInfo.Add(_strKey, _structBookMark);
                    _nPositionIndex++;
                }
            }
            return _dictBookMarkContextInfo;
        }

        /// <summary>
        /// 获取书签内容及range信息
        /// 2016-03-30
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        private Dictionary<string, QuotationStruct> GetFieldContextInfo(Word.Application WordApp)
        {
            try
            {
                Dictionary<string, QuotationStruct> _dictFieldContextInfo = new Dictionary<string, QuotationStruct>();
                int _nPositionIndex = 1;
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        string _strKey = item.Code.Text.Replace("KEYWORDS", string.Empty).Trim();// QuotationItem.FLAG +CommonFunction.GetNum(item.Code.Text);
                        QuotationStruct _structBookMark;
                        _structBookMark._nStart = item.Result.Start;
                        _structBookMark._nEnd = item.Result.End;
                        //美其名曰清洗数据域 2016-04-09 wuhailong
                        //if (item.Result.Text.StartsWith("\r"))
                        //{
                        //    item.Result.Text = item.Result.Text.Replace("\r", string.Empty);
                        //}
                        _structBookMark._strContext = item.Result.Text;

                        _dictFieldContextInfo.Add(_strKey, _structBookMark);
                        _nPositionIndex++;
                    }
                }
                return _dictFieldContextInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 获取书签内容及range信息
        /// 2016-03-30
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        private Dictionary<string, QuotationStruct> GetFieldContextInfoOfAuthorYear(Word.Application WordApp)
        {
            try
            {
                Dictionary<string, QuotationStruct> _dictFieldContextInfo = new Dictionary<string, QuotationStruct>();
                //int _nPositionIndex = 1;
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        string _strKey = QuotationItem.FLAG + item.Code.Text.Replace("KEYWORDS " + QuotationItem.FLAG, "").Trim();
                        QuotationStruct _structBookMark;
                        _structBookMark._nStart = item.Result.Start;
                        _structBookMark._nEnd = item.Result.End;
                        _structBookMark._strContext = item.Result.Text;
                        if (!_dictFieldContextInfo.Keys.Contains(_strKey))
                        {
                            _dictFieldContextInfo.Add(_strKey, _structBookMark);
                        }
                    }
                }
                return _dictFieldContextInfo;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
                return null;
            }

        }


        #region 通过计算插入引文的位置计算合适的引文序号

        /// <summary>
        /// 通过计算插入引文的位置格式化合适的引文序号
        /// 注：引文以书签标记时使用
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public static List<int> AdjustQuotationIndexByPositionOfBookMark(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nStart = WordApp.Selection.Start;
                int _nEnd = WordApp.Selection.End;
                if (_nStart != _nEnd)
                {
                    return null;
                }
                List<Word.Bookmark> _listMarks = new List<Word.Bookmark>();
                foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
                {
                    if (item.Name.StartsWith("BIMT"))
                    {
                        _listMarks.Add(item);
                    }
                }
                Word.Bookmark _markTemp = null;
                for (int i = 0; i < _listMarks.Count; i++)
                {
                    for (int j = i; j < _listMarks.Count; j++)
                    {
                        int _nStartA = _listMarks[i].Start;
                        int _nStartB = _listMarks[j].Start;
                        if (_nStartA > _nStartB)
                        {
                            _markTemp = _listMarks[i];
                            _listMarks[i] = _listMarks[j];
                            _listMarks[j] = _markTemp;
                        }
                    }
                }
                int _nIndex = 1;
                foreach (Word.Bookmark item in _listMarks)
                {
                    string _strIndex = string.Format("[{0}]", _nIndex);
                    string _strNmae = item.Name;
                    Word.Range _rangeTemp = WordApp.ActiveDocument.Range(item.Start, item.End);
                    _rangeTemp.Text = _strIndex;
                    Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strNmae, _rangeTemp);
                    _nIndex++;
                }

                List<int> _listBookMarkNo = new List<int>();
                foreach (Word.Bookmark item in _listMarks)
                {
                    _listBookMarkNo.Add(int.Parse(item.Name.Replace("BIMT", "")));
                }
                return _listBookMarkNo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// 获取文末引文位置
        /// wuhailong
        /// 2016-06-24
        /// </summary>
        /// <returns></returns>
        public static int GetQuotationOrder(string p_strAuthorYear)
        {
            int order = 1;
            try
            {
                foreach (Word.Field item in WordApplication.GetInstance().WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        string _strTemp = CommonFunction.GetFieldAuthorYear(item, -1).Trim();
                        if (p_strAuthorYear.Trim() == _strTemp)
                        {
                            return order;
                        }
                        order++;
                    }
                }
                LogHelper.WriteLog(typeof(QuotationItem), "作者年标志：" + p_strAuthorYear + "未查找到！");
                return -1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
                return -1;
            }
        }

        /// <summary>
        /// 返回作者年规则的引文消息list
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public static List<string> AdjustQuotationIndexByPositionOfFieldForAuthorYear(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nStart = WordApp.Selection.Start;
                int _nEnd = WordApp.Selection.End;
                if (_nStart != _nEnd)
                {
                    return null;
                }
                List<string> _listAuthorYear = new List<string>();
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationIndex.FLAG))
                    {
                        _listAuthorYear.Add(item.Code.Text.Replace("KEYWORDS " + QuotationIndex.FLAG + "_", "").Trim());
                    }
                }

                //根据引文作者的首字母排序
                string _strName = null;
                for (int i = 0; i < _listAuthorYear.Count; i++)
                {
                    for (int j = i; j < _listAuthorYear.Count; j++)
                    {
                        int _nStartA = _listAuthorYear[i].ToCharArray(0, 1)[0];
                        int _nStartB = _listAuthorYear[j].ToCharArray(0, 1)[0];
                        if (_nStartA > _nStartB)
                        {
                            _strName = _listAuthorYear[i];
                            _listAuthorYear[i] = _listAuthorYear[j];
                            _listAuthorYear[j] = _strName;
                        }
                    }
                }
                return _listAuthorYear;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
                return null;
            }
        }



        /// <summary>
        /// 根据样式规定，返回引文排序列表
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public static List<string> SortAuthorYearList(List<string> listAuthorYear)
        {
            try
            {
                if ("TRUE" == JsonHelper.GetValue("USING_FIRST_NAME_CHAR_ORDER_RULE").ToUpper())//作者首-标题
                {
                    string _strTemp = string.Empty;
                    for (int i = 0; i < listAuthorYear.Count; i++)
                    {
                        for (int j = i; j < listAuthorYear.Count; j++)
                        {
                            Quotation q1 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[i].Trim());
                            Quotation q2 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[j].Trim());
                            string _strA = q1.GetAuthor() + q1.title;//.publishInfo.publishYear;
                            string _strB = q2.GetAuthor() + q2.title;//.publishInfo.publishYear;
                            if (_strA.CompareTo(_strB) > 0)
                            {
                                _strTemp = listAuthorYear[i];
                                listAuthorYear[i] = listAuthorYear[j];
                                listAuthorYear[j] = _strTemp;
                            }
                        }
                    }
                }
                else if ("TRUE" == JsonHelper.GetValue("AUTHOR_PUBYEAR_TITLE").ToUpper())//作者-年代-标题
                {
                    string _strTemp = string.Empty;
                    for (int i = 0; i < listAuthorYear.Count; i++)
                    {
                        for (int j = i; j < listAuthorYear.Count; j++)
                        {
                            Quotation q1 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[i].Trim());
                            Quotation q2 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[j].Trim());
                            string _strA = q1.GetAuthor() + q1.publishInfo.publishYear + q1.title;
                            string _strB = q2.GetAuthor() + q2.publishInfo.publishYear + q2.title;
                            if (_strA.CompareTo(_strB) > 0)
                            {
                                _strTemp = listAuthorYear[i];
                                listAuthorYear[i] = listAuthorYear[j];
                                listAuthorYear[j] = _strTemp;
                            }
                        }
                    }
                }
                else if ("TRUE" == JsonHelper.GetValue("FAUTHOR_PUBYEAR_OTHERS").ToUpper())//第一作者-年代-其他作者
                {
                    string _strTemp = string.Empty;
                    for (int i = 0; i < listAuthorYear.Count; i++)
                    {
                        for (int j = i; j < listAuthorYear.Count; j++)
                        {
                            Quotation q1 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[i].Trim());
                            Quotation q2 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[j].Trim());
                            string _strA = q1.GetAuthor().Split('|')[0] + q1.publishInfo.publishYear + q1.GetAuthor().Split('|')[1];
                            string _strB = q2.GetAuthor().Split('|')[0] + q2.publishInfo.publishYear + q1.GetAuthor().Split('|')[1];
                            if (_strA.CompareTo(_strB) > 0)
                            {
                                _strTemp = listAuthorYear[i];
                                listAuthorYear[i] = listAuthorYear[j];
                                listAuthorYear[j] = _strTemp;
                            }
                        }
                    }
                }
                else if ("TRUE" == JsonHelper.GetValue("FAUTHOR_ALLAUTHOR_PUBYEAR").ToUpper())//第一作者-全部作者-年代
                {
                    string _strTemp = string.Empty;
                    for (int i = 0; i < listAuthorYear.Count; i++)
                    {
                        for (int j = i; j < listAuthorYear.Count; j++)
                        {
                            Quotation q1 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[i].Trim());
                            Quotation q2 = QuotationSet.GetQuotationByeAuthorYear(listAuthorYear[j].Trim());
                            string _strA = q1.GetAuthor() + q1.publishInfo.publishYear;// +GetOtherAuthers(q1.GetCurrentAuthorYear().Split('_')[0]);
                            string _strB = q2.GetAuthor() + q2.publishInfo.publishYear;// +GetOtherAuthers(q2.GetCurrentAuthorYear().Split('_')[0]); ;
                            if (_strA.CompareTo(_strB) > 0)
                            {
                                _strTemp = listAuthorYear[i];
                                listAuthorYear[i] = listAuthorYear[j];
                                listAuthorYear[j] = _strTemp;
                            }
                        }
                    }
                }
                else if ("TRUE" == JsonHelper.GetValue("USING_ORDER_CDOING_RULE").ToUpper())//按照引文先后顺序排列
                {
                    //根据引文在文中位置进行排序
                    string _strTemp = string.Empty;
                    QuotationIndex qIndex = QuotationIndex.GetInstance(null);
                    for (int i = 0; i < listAuthorYear.Count; i++)
                    {
                        for (int j = i; j < listAuthorYear.Count; j++)
                        {

                            int _nStartA = qIndex.GetQuotationIndex(listAuthorYear[i]);// CommonFunction.GetFieldByCodeText(WordApp, _listIndexAuthorYear[i]).Result.Start;//.Result.Start;
                            int _nStartB = qIndex.GetQuotationIndex(listAuthorYear[j]);// CommonFunction.GetFieldByCodeText(WordApp, _listIndexAuthorYear[j]).Result.Start;
                            if (_nStartA > _nStartB)
                            {
                                _strTemp = listAuthorYear[i];
                                listAuthorYear[i] = listAuthorYear[j];
                                listAuthorYear[j] = _strTemp;
                            }
                        }
                    }
                }
                return listAuthorYear;
            }
            catch (Exception ex)
            {
                throw new Exception("SortAuthorYearList", ex);
            }
        }

        private static string GetOtherAuthers(string p)
        {
            if (p.Contains(","))
            {
                return p.Split(',')[1];
            }
            return string.Empty;
        }

        /// <summary>
        /// 在文末添加段落
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public Word.Range AddParagraphAtEnd(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                //WordApp.ActiveDocument.Application.Selection.Start = WordApp.ActiveDocument.Paragraphs.Last.Range.End;
                //WordApp.ActiveDocument.Application.Selection.End = WordApp.ActiveDocument.Paragraphs.Last.Range.End;
                //Word.Paragraph paragraph = WordApp.ActiveDocument.Paragraphs.Add(WordApp.ActiveDocument.Application.Selection.Range);
                //WordApp.ActiveDocument.Application.Selection.Range.Text = "\r\n";
                //return WordApp.ActiveDocument.Application.Selection.Range.InsertParagraph;
                WordApp.ActiveDocument.Paragraphs.Last.Range.InsertAfter("\r");
                WordApp.ActiveDocument.Paragraphs.Last.CharacterUnitFirstLineIndent = 0;
                WordApp.ActiveDocument.Paragraphs.Last.FirstLineIndent = 0;
                //return WordApp.ActiveDocument.Range(WordApp.ActiveDocument.Paragraphs.Last.Range.End-1, WordApp.ActiveDocument.Paragraphs.Last.Range.End-1);
                //WordApp.ActiveDocument.Paragraphs.Last.FirstLineIndent = WordApp.CentimetersToPoints(float.Parse("0"));
                return WordApp.ActiveDocument.Paragraphs.Last.Range;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion




        /// <summary>
        /// 补齐删除的字段
        /// </summary>
        /// <param name="p_range"></param>
        /// <param name="p_strContext"></param>
        /// <returns></returns>
        public Word.Range AppendQuotationFieldAtRange(Word.Range p_range, string p_strContext)
        {
            try
            {
                string _strResult = string.Empty;
                string _strTemplet = p_strContext;
                if (p_range.End - p_range.Start > 1)
                {
                    p_range.SetRange(p_range.End - 1, p_range.End);
                }
                p_range.Text = p_strContext;
                return p_range;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        public void SetRangeStyle(Word.Range range, string styleFlag)
        {
            //Word.Bookmark _markTitle = GetBookMarkByName(WordApp, "QuotationTitle");
            //Word.Range _rangeTitle= _markTitle.Range;
            //_rangeTitle.Select();
            range.Font.Name = JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY"); ;
            range.Font.Size = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE"))); ;
            if (styleFlag == "9")
            {
                range.Font.Bold = 1;
                range.Font.Italic = 1;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (styleFlag == "8")
            {
                range.Font.Bold = 0;
                range.Font.Italic = 1;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (styleFlag == "6")
            {
                range.Font.Bold = 1;
                range.Font.Italic = 0;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (styleFlag == "5")
            {
                range.Font.Bold = 0;
                range.Font.Italic = 0;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (styleFlag == "4")
            {
                range.Font.Bold = 1;
                range.Font.Italic = 1;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (styleFlag == "3")
            {
                range.Font.Bold = 0;
                range.Font.Italic = 1;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (styleFlag == "1")
            {
                range.Font.Bold = 1;
                range.Font.Italic = 0;
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }


        }

        public void SetStyle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设置文末引文样式 缩进、段落、行距
        /// 2016-05-25
        /// wuhailong
        /// </summary>
        /// <param name="range"></param>
        public static void SetItemStyle(Word.Range range)
        {
            try
            {
                range.Font.Name = JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
                range.Font.Size = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE"))); ;
                ////左缩进
                //string _strLeftIndent = JsonHelper.GetValue("LEFTINDENT");
                range.ParagraphFormat.LeftIndent = wordApp.CentimetersToPoints(float.Parse("0"));
                //悬挂缩进
                range.ParagraphFormat.CharacterUnitFirstLineIndent = 0;
                range.ParagraphFormat.FirstLineIndent = 0;
                string _strXgsj = JsonHelper.GetValue("XGSJ_VALUE");
                range.Paragraphs.TabHangingIndent(short.Parse(_strXgsj));


            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
            }
        }

        ///  /// <summary>
        /// 刷新文末参考文献序号
        /// wuhailong
        /// 2016-07-16
        /// </summary>
        public void RefreshQuotatationItemIndex()
        {
            try
            {
                string _strPre = string.Empty;
                string _strSuff = string.Empty;
                string _strTemplet = JsonHelper.GetValue(QuotationItem.FLAG);
                if (_strTemplet.Contains("序号"))
                {
                    string _strReg = @"<([^<>]*)>";
                    var matches = Regex.Matches(_strTemplet, _strReg);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", string.Empty).Replace(">", string.Empty);
                        if (_strFieldAndStyleMix.Contains("序号") && i == 0)
                        {

                        }
                        else if (i + 1 <= matches.Count && i == 1 && _strFieldAndStyleMix.Contains("序号"))
                        {
                            _strPre = matches[i - 1].Captures[0].Value.Replace("<", string.Empty).Replace("_0>", string.Empty);
                            _strSuff = matches[i + 1].Captures[0].Value.Replace("<", string.Empty).Replace("_0>", string.Empty);
                        }
                    }
                    int index = 1;

                    foreach (Word.Field item in wordApp.ActiveDocument.Fields)
                    {
                        if (item.Code.Text.Contains(QuotationItem.FLAG))
                        {
                            if (_strPre != string.Empty)//序号有包裹
                            {
                                string _strFourChar = item.Result.Text.Substring(0, 4);
                                string _strThreeChar = item.Result.Text.Substring(0, 3);
                                if (_strFourChar.StartsWith(_strPre) && _strFourChar.EndsWith(_strSuff))//样式是这个样子的[12]
                                {
                                    string _strInValue = _strFourChar.Replace(_strPre, string.Empty).Replace(_strSuff, string.Empty);
                                    Word.Range _rangeRepalce = wordApp.ActiveDocument.Range(item.Result.Start + 1, item.Result.Start + 3);
                                    _rangeRepalce.Text = index.ToString();
                                }
                                else if (_strThreeChar.StartsWith(_strPre) && _strThreeChar.EndsWith(_strSuff))//样式是这个样子的[1]
                                {
                                    string _strInValue = _strThreeChar.Replace(_strPre, string.Empty).Replace(_strSuff, string.Empty);
                                    int _nStart = item.Result.Start + 1;
                                    Word.Range _rangeRepalce = wordApp.ActiveDocument.Range(_nStart, _nStart + 1);
                                    string _strText = _rangeRepalce.Text;
                                    _rangeRepalce.Text = index.ToString();
                                }
                            }
                            else//序号无包裹
                            {
                                string _strRegNo = @"^[1-9]\d*$";
                                string _strTwoChar = item.Result.Text.Substring(0, 2);
                                string _strOneChar = item.Result.Text.Substring(0, 1);
                                var matchesTwo = Regex.Matches(_strTwoChar, _strRegNo);
                                var matchesOne = Regex.Matches(_strOneChar, _strRegNo);
                                if (matchesTwo.Count > 0)//两位序号
                                {
                                    Word.Range _rangeRepalce = wordApp.ActiveDocument.Range(item.Result.Start, item.Result.Start + 2);
                                    _rangeRepalce.Text = index.ToString();
                                }
                                else if (matchesOne.Count > 0)//1位序号
                                {
                                    Word.Range _rangeRepalce = wordApp.ActiveDocument.Range(item.Result.Start, item.Result.Start + 1);
                                    _rangeRepalce.Text = index.ToString();
                                }
                            }
                            index++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
            }
        }

        /// <summary>
        /// 按照样式名称进行整体刷新
        /// wuhailong
        /// 2016-07-16
        /// </summary>
        /// <param name="styleName"></param>
        public void RefreshStyle(string styleName)
        {
            try
            {
                PublicVar.WriteIndex = false;
                QuotationSet quotationDate = new QuotationSet();
                string _strTemplet = JsonHelper.GetValue(QuotationItem.FLAG);
                foreach (Word.Field item in wordApp.ActiveDocument.Fields)
                {
                    //文中引文
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        if (item.Result.Text == null)
                        {
                            return;
                        }
                        item.Result.Text = string.Empty;// "\n";
                        string _strAuthorYear = CommonFunction.GetFieldAuthorYear(item, -1).Trim();
                        Quotation quotation = QuotationSet.GetQuotationByeAuthorYear(_strAuthorYear);
                        string _strReg = @"<([^<>]*)>";
                        var matches = Regex.Matches(_strTemplet, _strReg);
                        for (int i = 0; i < matches.Count; i++)
                        {
                            var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                            Word.Range _range = wordApp.ActiveDocument.Range(item.Result.End, item.Result.End);
                            CommonFunction.AddTextAtRangeForItem(wordApp, _strFieldAndStyleMix, _range, quotation);
                        }
                        SetItemStyle(item.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationItem), ex);
            }

        }

        /// <summary>
        /// 为样式切换而设计的序号计算方法
        /// 2016-05-19
        /// wuhailong
        /// </summary>
        /// <param name="quotation"></param>
        /// <returns></returns>
        internal static int GetQuotationItemOrder2(Quotation quotation)
        {
            try
            {
                int _index = 0;
                foreach (Word.Field item in wordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        ++_index;
                        string _strName1 = CommonFunction.GetFieldAuthorYear(item, -1).Trim();
                        string _strName2 = quotation.GetCurrentAuthorYear().Trim();
                        if (_strName1 == _strName2)
                        {
                            return _index;
                        }
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return -1;
            }
        }

        /// <summary>
        /// 获取文档中参考文献域集合
        /// wuhailong
        /// 2016-08-05
        /// </summary>
        /// <returns></returns>
        public List<Word.Field> GetDocFieldList()
        {
            try
            {
                List<Word.Field> listField = new List<Word.Field>();
                foreach (Word.Field item in wordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG))
                    {
                        listField.Add(item);
                    }
                }
                return listField;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 当文章中不再有引用此文献的地点时，删除文末参考文献
        /// wuhailong
        /// 2016-08-09
        /// </summary>
        /// <param name="authorYear"></param>
        public void DeleteItemField(string authorYear)
        {
            try
            {
                List<Word.Field> listItem = GetDocFieldList();
                foreach (Word.Field item in listItem)
                {
                    string currentAuthorYear = GetFieldAuthorYearInfo(item);
                    //文末引文
                    if (currentAuthorYear.Trim() == authorYear.Trim() && !QuotationIndex.GetInstance().ExistField(authorYear))
                    {
                        int _nstart = item.Code.Start - 1;
                        item.Delete();
                        Word.Range range = WordApplication.GetInstance().WordApp.ActiveDocument.Range(_nstart, _nstart + 1);
                        if (range.Text == "\r")
                        {
                            range.Text = string.Empty;
                        }
                        if (WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range.Text == "\r")
                        {//最后一个参考文献要特殊处理一下 wuhailong 2016-07-19
                            WordApplication.GetInstance().WordApp.ActiveDocument.Paragraphs.Last.Range.Delete();
                        }
                        RefreshAllQuotationItemLocation();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public float m_fFontSize { get; set; }

        public void InitStatus()
        {
            throw new NotImplementedException();
        }


        public bool ExistField(string authorYear)
        {
            List<Word.Field> list = GetDocFieldList();
            foreach (var item in list)
            {
                if (GetFieldAuthorYearInfo(item) == authorYear)
                {
                    return true;
                }
            }
            return false;

        }



        public string GetFieldAuthorYearInfo(Word.Field field)
        {
            try
            {
                string _strNeedClear = "KEYWORDS " + QuotationItem.FLAG + "_";
                string code = field.Code.Text.Replace(_strNeedClear, string.Empty);
                return code.Trim();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
