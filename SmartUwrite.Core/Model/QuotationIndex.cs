using BIMTClassLibrary.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using BIMTClassLibrary;
using System.Text.RegularExpressions;
using Log4Net;
using System.Data;
using System.Windows.Forms;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 文中引文
    /// 分为作者出版年制&顺序排列制
    /// 2016-04-05
    /// wuahilong
    /// </summary>
    public class QuotationIndex : IQuotation
    {
        public static readonly string FLAG = "QUOTATION_INDEX";
        private static string Font = string.Empty;
        /// <summary>
        /// 文中引文书签标志
        /// </summary>
        string m_strQuotationIndexBookMarkFlag = "BIMT";
        static Microsoft.Office.Interop.Word.Application wordApp = WordApplication.GetInstance().WordApp;
        private  Quotation quotation = null;
        private static QuotationIndex qIndex = null;

        public static QuotationIndex GetInstance()
        {
            try
            {
                if (qIndex == null)
                {
                    qIndex = new QuotationIndex();
                }
                qIndex.listAuthorYear = qIndex.GetDocAuthorYearList();
                qIndex.listFeild = qIndex.GetDocFieldList();
                return qIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static QuotationIndex GetInstance(Quotation quotation)
        {
            try
            {
                if (qIndex == null)
                {
                    qIndex = new QuotationIndex();
                }
                //PublicVar.WriteIndex = true;
                qIndex.quotation = quotation;
                qIndex.listAuthorYear = qIndex.GetDocAuthorYearList();
                qIndex.listFeild = qIndex.GetDocFieldList();
                return qIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        private QuotationIndex()
        {
            PublicVar.WriteIndex = true;
        }

      


        /// <summary>
        /// 合并域
        /// 2016-05-13
        /// wuhailong
        /// </summary>
        /// <param name="p_fieldNew"></param>
        /// <returns></returns>
        public Word.Field MergeIndex(Word.Field p_fieldNew)
        {
            Word.Field _fieldR = null;
            string _strIndexTemp = JsonHelper.GetValue("QUOTATION_INDEX");
            if (_strIndexTemp.Contains("序号"))
            {
                _fieldR = MergeOrderCodeIndex(p_fieldNew);
            }
            else
            {
                _fieldR = MergeAuthorYearIndex2(p_fieldNew);
            }
            return _fieldR;
        }

        /// <summary>
        /// 合并作者年制域,传入新生成的域与当前光标位置域判断是否应该合并
        /// 2016-05-13
        /// wuhailong
        /// </summary>
        /// <param name="p_fieldNew">新生成的域</param>
        private Word.Field MergeAuthorYearIndex(Word.Field p_fieldNew)
        {
            try
            {
                Word.Field _field = CommonFunction.GetFieldBySection(wordApp);
                if (_field != null)
                {
                    //int num1 = CommonFunction.GetNum(_field.Result.Text);
                    //int num2 = num1 + Regex.Matches(_field.Code.Text, @"#").Count + 1;//当前引文已经是多少个引文的组合
                    string _strTemplet = JsonHelper.GetValue(QuotationIndex.FLAG); ;
                    string _strReg = @"<([^<>]*)>";
                    var matches = Regex.Matches(_strTemplet, _strReg);
                    string _strFormat = string.Empty;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                        _strFormat += quotation.GetFieldValue(wordApp, _strFieldAndStyleMix.Split('_')[0]);
                    }
                    string _strFill = string.Empty;

                    string[] _arrayAuthorYear = CommonFunction.GetFieldAuthorYear(_field).Split('#');
                    foreach (var item in _arrayAuthorYear)
                    {
                        string[] _arrayItem = item.Split('_');
                        _strFill += _arrayItem[0] + " " + _arrayItem[1] + "; ";
                    }
                    string[] _arrayNew = CommonFunction.GetFieldAuthorYear(p_fieldNew).Split('_');
                    _strFill += _arrayNew[0] + " " + _arrayNew[1] + "; ";
                    _strFill = _strFill.Trim().Trim(';');
                    _strFormat = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX") + "{0}" + JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                    string _strIndex = string.Format(_strFormat, _strFill);
                    p_fieldNew.Result.Text = _strIndex;

                    p_fieldNew.Code.Text = QuotationIndex.FLAG + "_" + CommonFunction.GetFieldAuthorYear(_field) + "#" + CommonFunction.GetFieldAuthorYear(p_fieldNew);
                    _field.Delete();
                    return p_fieldNew;
                }
                return p_fieldNew;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 合并作者年制域,传入当前光标位置域假如为空则直接进行插入，否则进行合并操作
        /// 2016-05-13
        /// wuhailong
        /// </summary>
        /// <param name="fieldLocate">当前光标位置域</param>
        private Word.Field MergeAuthorYearIndex2(Word.Field fieldLocate)
        {
            try
            {
                if (fieldLocate != null)
                {
                    List<Quotation> listQuotation= GetUnionQuotationList(fieldLocate);
                    listQuotation= SortQuotationList(listQuotation);
                    //fieldLocate = UnionQuotationListAtField(fieldLocate, listQuotation);
                    fieldLocate = CommonFunction.WriteQuotationFieldAtRange(wordApp, fieldLocate, QuotationIndex.FLAG, listQuotation);
                    SetQuotationIndexCodeText(fieldLocate, listQuotation);
                    return fieldLocate;
                   }
                else
                {//当前位置没有域进行生成新域操作 2016-05-13 wuhailong
                    int _nStart = wordApp.Selection.Range.Start;
                    Word.Range _rangeField = wordApp.ActiveDocument.Range(_nStart, _nStart);
                    fieldLocate = CommonFunction.WriteQuotationFieldAtRange(wordApp, _rangeField, QuotationIndex.FLAG, quotation);
                }
                return fieldLocate;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 将作者年代的样式合并到域
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="listQuotation"></param>
        /// <returns></returns>
        public static Word.Field UnionQuotationListAtField(Word.Field field, List<Quotation> listQuotation)
        {
            try
            {
                string splitChar = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_YEAR_CHAR");
                string preChar = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                string suffChar = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                string templet = JsonHelper.GetValue(QuotationIndex.FLAG); ;
                string reg = @"<([^<>]*)>";
                var matches = Regex.Matches(templet, reg);
                int start = field.Code.Start;
                field.Result.Text = string.Empty;
                Word.Range range = wordApp.ActiveDocument.Range(field.Result.Start, field.Result.Start);
                field.Delete();
                range = CommonFunction.AppendTextAtRange2(preChar + "_0", range);
                foreach (Quotation currentQuotation in listQuotation)
                {
                    field = CommonFunction.WriteQuotationFieldAtRange(wordApp, range, QuotationIndex.FLAG, currentQuotation);
                    int index = listQuotation.FindIndex(s => s.title == currentQuotation.title);
                    if (!(index + 1 == listQuotation.Count))
                    {
                        range = CommonFunction.AppendTextAtRange2(splitChar + "_0", range);
                    }
                }
                range = CommonFunction.AppendTextAtRange2(preChar + "_0", range);
                Word.Field temp = CommonFunction.AddField(wordApp, range, string.Empty);
                return temp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 移除字符串末尾的 的指定字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string TrimEnd(string value, string end)
        {
            try
            {
                if (value.EndsWith(end))
                {
                    value = value.Remove(value.LastIndexOf(end));
                }
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("FixStringEnd",ex);
            }
        }


        /// <summary>
        /// 按照设置将文献排序，以供写入
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="listQuotation"></param>
        /// <returns></returns>
        public static List<Quotation> SortQuotationList(List<Quotation> listQuotation)
        {
            try
            {
                string sortType = GetQuotationIndexSortType();
                switch (sortType)
                {
                    case "APPEAR_ORDER":
                        //出现的顺序
                        break;
                    case "AUTHOR_TITLE":
                        //作者标题
                        Quotation tempQuotation = null;
                        for (int i = 0; i < listQuotation.Count; i++)
                        {
                            for (int j = i; j < listQuotation.Count; j++)
                            {
                                Quotation q1 = listQuotation[i];
                                Quotation q2 = listQuotation[j];
                                string _strA = q1.GetAuthor() + q1.title;
                                string _strB = q2.GetAuthor() + q2.title;
                                if (_strA.CompareTo(_strB) > 0)
                                {
                                    tempQuotation = listQuotation[i];
                                    listQuotation[i] = listQuotation[j];
                                    listQuotation[j] = tempQuotation;
                                }
                            }
                        }
                        break;
                    case "YEAR_AUTHOR":
                        //年代 作者
                        tempQuotation = null;
                        for (int i = 0; i < listQuotation.Count; i++)
                        {
                            for (int j = i; j < listQuotation.Count; j++)
                            {
                                Quotation q1 = listQuotation[i];
                                Quotation q2 = listQuotation[j];
                                string _strA = q1.publishInfo.publishYear + q1.GetAuthor();
                                string _strB = q2.publishInfo.publishYear + q2.GetAuthor();
                                if (_strA.CompareTo(_strB) > 0)
                                {
                                    tempQuotation = listQuotation[i];
                                    listQuotation[i] = listQuotation[j];
                                    listQuotation[j] = tempQuotation;
                                }
                            }
                        }
                        break;
                    case "AUTHOR_YEAR_TITLE":
                        //作者 年代 标题
                        tempQuotation = null;
                        for (int i = 0; i < listQuotation.Count; i++)
                        {
                            for (int j = i; j < listQuotation.Count; j++)
                            {
                                Quotation q1 = listQuotation[i];
                                Quotation q2 = listQuotation[j];
                                string _strA = q1.GetAuthor() + q1.publishInfo.publishYear + q1.title;
                                string _strB = q2.GetAuthor() + q2.publishInfo.publishYear + q2.title;
                                if (_strA.CompareTo(_strB) > 0)
                                {
                                    tempQuotation = listQuotation[i];
                                    listQuotation[i] = listQuotation[j];
                                    listQuotation[j] = tempQuotation;
                                }
                            }
                        }
                        break;
                    case "FIRST_YEAR_OTHER":
                        //第一作者 年代 其他
                        tempQuotation = null;
                        for (int i = 0; i < listQuotation.Count; i++)
                        {
                            for (int j = i; j < listQuotation.Count; j++)
                            {
                                Quotation q1 = listQuotation[i];
                                Quotation q2 = listQuotation[j];
                                string _strA = q1.GetFirstAuthor() + q1.publishInfo.publishYear + q1.title;
                                string _strB = q2.GetFirstAuthor() + q2.publishInfo.publishYear + q2.title;
                                if (_strA.CompareTo(_strB) > 0)
                                {
                                    tempQuotation = listQuotation[i];
                                    listQuotation[i] = listQuotation[j];
                                    listQuotation[j] = tempQuotation;
                                }
                            }
                        }
                        break;
                    case "FIRST_ALL_YEAR":
                        //第一作者 全部作者 年代
                        tempQuotation = null;
                        for (int i = 0; i < listQuotation.Count; i++)
                        {
                            for (int j = i; j < listQuotation.Count; j++)
                            {
                                Quotation q1 = listQuotation[i];
                                Quotation q2 = listQuotation[j];
                                string _strA = q1.GetAuthor() + q1.publishInfo.publishYear;
                                string _strB = q2.GetAuthor() + q2.publishInfo.publishYear;
                                if (_strA.CompareTo(_strB) > 0)
                                {
                                    tempQuotation = listQuotation[i];
                                    listQuotation[i] = listQuotation[j];
                                    listQuotation[j] = tempQuotation;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                return listQuotation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取合并引文对象的集合
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="filedLocate"></param>
        public List<Quotation> GetUnionQuotationList(Word.Field filedLocate)
        {
            try
            {
                string[] arrayAuthorYear = QuotationIndex.GetInstance().GetFieldAuthorYearArray(filedLocate);
                List<Quotation> listQuotation = new List<Quotation>();
               
                foreach (string authorYear in arrayAuthorYear)
                {
                    Quotation currentQuotation = QuotationSet.GetQuotationByeAuthorYear(authorYear);
                    listQuotation.Add(currentQuotation);
                }
                if (this.quotation!=null)
                {
                    listQuotation.Add(this.quotation);    
                }
                return listQuotation;
            }
            catch (Exception)
            {
                throw;
            }
        }

     

        /// <summary>
        /// 设置文中引文的code text
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="listQuotation"></param>
        public static void SetQuotationIndexCodeText(Word.Field field, List<Quotation> listQuotation)
        {
            try
            {
                string authorYear = string.Empty;
                foreach (Quotation item in listQuotation)
                {
                    authorYear += item.GetCurrentAuthorYear() + "#";
                }
                authorYear = authorYear.Trim('#');
                field.Code.Text = "KEYWORDS " + QuotationIndex.FLAG + "_" + authorYear;
                string s = field.Code.Text;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取域的表格
        /// </summary>
        /// <param name="fieldSection"></param>
        /// <returns></returns>
        public static DataTable GetFieldQuotationTable(Word.Field fieldSection)
        {
            try
            {
                string authorYears = CommonFunction.GetFieldAuthorYear(fieldSection);
                string[] arrayAuthorYear = authorYears.Split('#');
                DataTable dt = new DataTable();
                dt.Columns.Add("Title");
                dt.Columns.Add("Author");//authorValue
                dt.Columns.Add("authorYear");
                dt.Columns.Add("PubYear");
                foreach (string item in arrayAuthorYear)
                {
                    Quotation quotation = QuotationSet.GetQuotationByeAuthorYear(item.Trim());
                    if (quotation==null)
                    {
                        LogHelper.WriteLog(typeof(QuotationIndex),item.Trim()+"不存在于QuotationSet中");
                        continue;
                    }
                    string authorYear = quotation.GetCurrentAuthorYear();
                    dt.Rows.Add(quotation.title.Trim(), quotation.authors, authorYear, quotation.publishInfo.publishYear.Trim());
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("GetFieldQuotationTable",ex);
            }

        }

        /// <summary>
        /// 判断所选域是否为复合引文
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="usrName"></param>
        /// <returns></returns>
        public static bool IsMultipleQuotation(Word.Field field)
        {
            try
            {
                string _strAuthorYear = CommonFunction.GetFieldAuthorYear(field);
                if (_strAuthorYear.Contains("#"))
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 将作者年list 转换为 文献对象 list
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="listAuthorYear"></param>
        /// <returns></returns>
        public static List<Quotation> ConvertAuthorYearToQuotation(List<string> listAuthorYear)
        {
            try
            {
                List<Quotation> listQuotation = new List<Quotation>();
                foreach (string currentAuthorYear in listAuthorYear)
                {
                    Quotation currentQuotation = QuotationSet.GetQuotationByeAuthorYear(currentAuthorYear);
                    listQuotation.Add(currentQuotation);
                }
                return listQuotation;
            }
            catch (Exception ex)
            {
                throw new Exception("ConvertAuthorYearToQuotation",ex);
            }
        }

        /// <summary>
        /// 删除文中引文的域；假如为复合引文的重新UNION
        /// wuahilong
        /// 2016-08-09
        /// </summary>
        /// <param name="fieldSection">选定删除的域</param>
        public  string DeleteIndexField(Word.Field fieldSection)
        {
            try
            {
                string deleteAuthorYear = string.Empty;
                bool isMulty = IsMultipleQuotation(fieldSection);
                if (isMulty)
                {
                    DataTable dtQuotationInfo = GetFieldQuotationTable(fieldSection);
                    frmDeleteQuotation qv = new frmDeleteQuotation(dtQuotationInfo);
                    
                    if (qv.ShowDialog() != DialogResult.Yes)
                    {
                        return string.Empty;
                    }
                    deleteAuthorYear = qv.GetDeleteAuthorYear();
                    string[] arrayQuotation = GetFieldAuthorYearArray(fieldSection);
                    List<string> fieldAuthorYearList = arrayQuotation.ToList<string>();
                    fieldAuthorYearList.Remove(deleteAuthorYear);
                    List<Quotation> listQuotation = ConvertAuthorYearToQuotation(fieldAuthorYearList);
                    listQuotation = SortQuotationList(listQuotation);
                    fieldSection = UnionQuotationListAtField(fieldSection, listQuotation);
                    SetQuotationIndexCodeText(fieldSection, listQuotation);
                    QuotationIndex.SetIndexStyle(fieldSection.Result);
                }
                else
                {
                    deleteAuthorYear = GetFieldAuthorYearArray(fieldSection)[0];
                    fieldSection.Delete();
                }
                listAuthorYear = GetDocAuthorYearList();
                return deleteAuthorYear;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除文中引文联动删除文末引文
        /// wuhailong
        /// 2016-06-27
        /// </summary>
        public  void DeleteIndexQuotation(Word.Field fieldSection)
        {
            try
            {
                string aurhotYear = DeleteIndexField(fieldSection);
                QuotationItem.GetInstance().DeleteItemField(aurhotYear);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
            }
        }

        /// <summary>
        /// 判断是否还存在文中引文假如存在的话就不能删除文末引文
        /// wuhailong
        /// 2016-06-27
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        public  bool ExistField(string authorYear)
        {
            try
            {
                bool isExist = false;
                List<Word.Field> listIndex = GetDocFieldList();
                foreach (Word.Field item in listIndex)
                {
                    string[] arrayAuthorYear = GetFieldAuthorYearArray(item);
                    //文末引文
                    if (arrayAuthorYear.Contains(authorYear))
                    {
                        isExist = true;
                        break;
                    }
                }
                return isExist;
            }
            catch (Exception ex)
            {
                throw new Exception("ExistQuotationIndex", ex);
            }
        }

        /// <summary>
        /// 合并指定位置的作者年制的引文
        /// 2016-05-20
        /// wuhailong
        /// </summary>
        /// <param name="p_fieldLocate"></param>
        /// <param name="_start"></param>
        /// <returns></returns>
        private Word.Field MergeAuthorYearIndex2(Word.Field p_fieldLocate, int _start, Quotation quotation)
        {
            try
            {
                Word.Field _field = p_fieldLocate;
                if (_field != null)
                {
                    string _strTemplet = JsonHelper.GetValue(QuotationIndex.FLAG).Split('#')[1];
                    string _strReg = @"<([^<>]*)>";
                    var matches = Regex.Matches(_strTemplet, _strReg);
                    string _strFormat = string.Empty;
                    string _strQuotationSortStyle = GetQuotationIndexSortType();
                    Word.Range _range = null;
                    if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_APPEAR")
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_AND_TITLE")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_YEAR_AND_TITLE")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_YEAR_AND_OTHER_AUTHOR")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_ALL_AND_YEAR")
                    {

                    }
                    else
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                    }

                    if (quotation.IsEnQuotation())
                    {
                        _range.Text = JsonHelper.GetValue("CHAR_BETWEEN_QUOTATION_INDEX_EN");
                    }
                    else
                    {
                        _range.Text = JsonHelper.GetValue("CHAR_BETWEEN_QUOTATION_INDEX_CN");
                    }
                    for (int i = 0; i < matches.Count; i++)
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                        CommonFunction.AddTextAtRange(wordApp, _strFieldAndStyleMix, _range, quotation);
                    }
                }
                return p_fieldLocate;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 第一个引文前不用分隔符
        /// 2016-05-20
        /// wuhailong
        /// </summary>
        /// <param name="p_fieldLocate"></param>
        /// <param name="_start"></param>
        /// <param name="quotation"></param>
        /// <returns></returns>
        private Word.Field MergeAuthorYearIndex3(Word.Field p_fieldLocate, int _start, Quotation quotation)
        {
            try
            {
                Word.Field _field = p_fieldLocate;
                if (_field != null)
                {
                    string _strTemplet = JsonHelper.GetValue(QuotationIndex.FLAG).Split('#')[1];
                    string _strReg = @"<([^<>]*)>";
                    var matches = Regex.Matches(_strTemplet, _strReg);
                    string _strFormat = string.Empty;
                    string _strQuotationSortStyle = GetQuotationIndexSortType();
                    Word.Range _range = null;
                    if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_APPEAR")
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_AND_TITLE")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_YEAR_AND_TITLE")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_YEAR_AND_OTHER_AUTHOR")
                    {

                    }
                    else if (_strQuotationSortStyle == "QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_ALL_AND_YEAR")
                    {

                    }
                    else
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                    }
                    //if (_range.Text.Length > 2)//不是前后缀元素
                    //{
                    //    if (quotation.IsEnQuotation())
                    //    {
                    //        _range.Text = JsonHelper.GetValue("CHAR_BETWEEN_QUOTATION_INDEX_EN");
                    //    }
                    //    else
                    //    {
                    //        _range.Text = JsonHelper.GetValue("CHAR_BETWEEN_QUOTATION_INDEX_CN");
                    //    }
                    //}
                    for (int i = 0; i < matches.Count; i++)
                    {
                        _range = wordApp.ActiveDocument.Range(p_fieldLocate.Result.End - 1, p_fieldLocate.Result.End - 1);
                        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                        CommonFunction.AddTextAtRange(wordApp, _strFieldAndStyleMix, _range, quotation);
                    }
                }
                return p_fieldLocate;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 获取文中合并的引文排序方式
        /// QUOTATION_INDEX_AUTHOR_LIST_BY_APPEAR 出现顺序
        /// QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_AND_TITLE 作者+标题 综合排序
        /// QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_YEAR_AND_TITLE 作者+年代+标题 综合排序
        /// QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_YEAR_AND_OTHER_AUTHOR 第一作者+ 年代+其他作者
        /// QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_ALL_AND_YEAR  第一作者+全部作者+年代
        /// wuhailong
        /// 2016-05-13
        /// </summary>
        /// <returns></returns>
        private static string GetQuotationIndexSortType()
        {
            try
            {
                if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_APPEAR").ToUpper())
                {
                    return "APPEAR_ORDER";
                }
                else if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_AND_TITLE").ToUpper())
                {
                    return "AUTHOR_TITLE";
                }
                else if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_YEAR_AUTHOR").ToUpper())
                {
                    return "YEAR_AUTHOR";
                }
                else if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_AUTHOR_YEAR_AND_TITLE").ToUpper())
                {
                    return "AUTHOR_YEAR_TITLE";
                }
                else if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_YEAR_AND_OTHER_AUTHOR").ToUpper())
                {
                    return "FIRST_YEAR_OTHER";
                }
                else if ("TRUE" == JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_LIST_BY_FIRST_AUTHOR_ALL_AND_YEAR").ToUpper())
                {
                    return "FIRST_ALL_YEAR";
                }
                return "-1";
            }
            catch (Exception ex)
            {
                throw new Exception("GetQuotationIndexSortType",ex);
            }
           
        }

        /// <summary>
        /// 获取当前位置前有多少个引文
        /// </summary>
        /// <param name="_listIndexFields"></param>
        /// <returns></returns>
        public int GetOrder()
        {
            int count = 1;
            int _nStart = wordApp.Selection.Start;
            List<Word.Field> _listIndexFields = new List<Word.Field>();
            foreach (Word.Field item in wordApp.ActiveDocument.Fields)
            {
                if (item.Code.Text.Contains(QuotationIndex.FLAG))
                {
                    _listIndexFields.Add(item);
                }
            }
            foreach (Word.Field item in _listIndexFields)
            {
                if (item.Result.End < _nStart)
                {
                    count += Regex.Matches(item.Code.Text, @"#").Count + 1;
                }
            }
            return count;
        }

        /// <summary>
        /// 获取文中引文的模板
        /// 2016-05-18
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public string GetIndexTemplet()
        {
            string _strTemplet = JsonHelper.GetValue(QuotationIndex.FLAG);
            string _strFormat = string.Empty;
            string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
            string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
            _strTemplet = "<" + _strPrefix + "_0>" + _strTemplet.Split('#')[1] + "<" + _strSuffix + "_0>";
            string _strReg = @"<([^<>]*)>";
            var matches = Regex.Matches(_strTemplet, _strReg);
            for (int i = 0; i < matches.Count; i++)
            {
                var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                _strFormat += quotation.GetFieldValue(wordApp, _strFieldAndStyleMix.Split('_')[0]);
            }

            return _strFormat;
        }

        /// <summary>
        /// 获取文中引文集合
        /// 2016-05-18
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public List<Word.Field> GetIndexFieldList()
        {
            List<Word.Field> _listIndexFields = new List<Word.Field>();
            foreach (Word.Field item in wordApp.ActiveDocument.Fields)
            {
                if (item.Code.Text.Contains(QuotationIndex.FLAG))
                {
                    _listIndexFields.Add(item);
                }
            }
            return _listIndexFields;
        }

        /// <summary>
        /// 将制定内容直接写入当前光标位置，并生成域
        /// 2016-05-18
        /// wuhailong
        /// </summary>
        /// <param name="WordApp">word对象</param>
        /// <param name="range">光标位置</param>
        /// <param name="templetName">标志名称</param>
        /// <param name="content">内容</param>
        /// <param name="quotation">引文对象</param>
        /// <returns></returns>
        public Word.Field WriteQuotationFieldAtRange(Microsoft.Office.Interop.Word.Application WordApp, Word.Range range, string templetName, string content, Quotation quotation)
        {
            //先加域，再组织内容
            try
            {
                string _strResult = content;
                WordApp.ActiveDocument.Range(range.Start, range.Start).Text = content;
                Word.Range _rangeDone = WordApp.ActiveDocument.Range(range.Start, range.Start + _strResult.Length);
                //SetIndexStyle(_rangeDone);
                Word.Field _field = CommonFunction.AddField(WordApp, _rangeDone, templetName + "_" + quotation.GetCurrentAuthorYear());
                return _field;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 合并顺序编码制的文中引文
        /// 2016-04-20
        /// wuhailong
        /// </summary>
        /// <param name="p_fieldLocate"></param>
        private Word.Field MergeOrderCodeIndex(Word.Field p_fieldLocate)
        {
            try
            {
                Word.Field _fieldNew = null;
                string _strFormat = GetIndexTemplet();
                string content = string.Empty;
                
                int index = GetQuotationIndexOrder(quotation);// GetOrder();
                if (p_fieldLocate == null)//不需要合并
                {
                    content = string.Format(_strFormat, index.ToString());
                    int _nStart = wordApp.Selection.Start;
                    Word.Range _rangeField = wordApp.ActiveDocument.Range(_nStart, _nStart);
                    _fieldNew = WriteQuotationFieldAtRange(wordApp, _rangeField, QuotationIndex.FLAG, content, quotation);
                }
                else
                {
                    int start = p_fieldLocate.Code.Start;
                    string _strResult = string.Empty;
                    if (p_fieldLocate.Code.Text.Contains("#"))//复合引文
                    {
                        _strResult = p_fieldLocate.Result.Text;
                        string _strReg = @"(\d+)";
                        var matches = Regex.Matches(_strResult, _strReg);

                        int _nNew1 = int.Parse(matches[0].Captures[0].Value);// + 1;
                        int _nNew2 = int.Parse(matches[1].Captures[0].Value) + 1;
                        _strResult = string.Format(_strFormat, _nNew1 + "-" + _nNew2);//_ _strResult.Replace((_nNew2 - 1).ToString(), _nNew2.ToString());//.Replace((_nNew1 - 1).ToString(), _nNew1.ToString());
                        //p_fieldLocate.Result.Text = _strResult;
                    }
                    else//单一引文变复合引文
                    {

                        _strResult = p_fieldLocate.Result.Text;
                        string _strReg = @"(\d+)";
                        var matches = Regex.Matches(_strResult, _strReg);

                        int _nOld = int.Parse(matches[0].Captures[0].Value);
                        int _nNew = _nOld + 1;
                        string _strChar = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_YEAR_CHAR");
                        if (_strChar == string.Empty)
                        {
                            _strChar = ",";
                        }
                        _strResult = string.Format(_strFormat, _nOld + _strChar + _nNew);
                        //p_fieldLocate.Result.Text = _strResult;
                    }
                    string _strOldCode = CommonFunction.GetFieldAuthorYear(p_fieldLocate).Trim();
                    string _strNewCode = quotation.GetCurrentAuthorYear().Trim();
                    string _strCombineCode = "KEYWORDS " + QuotationIndex.FLAG + "_" + _strOldCode + "#" + _strNewCode;
                    p_fieldLocate.Code.Text = _strCombineCode;
                    p_fieldLocate.Result.Text = string.Empty;
                    p_fieldLocate.Result.Text = _strResult;
                    p_fieldLocate.Result.SetRange(start, start + _strResult.Length);
                    _fieldNew = p_fieldLocate;
                }
                List<Word.Field> _listIndexFields = GetIndexFieldList();
                string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                for (int i = index; i < _listIndexFields.Count; i++)//i=index
                {
                    if (_listIndexFields[i].Code.Text.Contains('#'))//引文为复合引文
                    {
                        if (_strFormat.Contains("序号"))
                        {
                            string _strQuotations = CommonFunction.GetFieldAuthorYear(_listIndexFields[i]);
                            string[] _arrayQuotation = _strQuotations.Replace("QUOTATION_INDEX_", string.Empty).Trim().Split('#');
                            List<Quotation> _listQuotation = new List<Quotation>();
                            foreach (string authorYear in _arrayQuotation)
                            {
                                Quotation quotationItem = QuotationSet.GetQuotationByeAuthorYear(authorYear.Trim());
                                _listIndexFields[i].Result.Text = string.Empty;
                                //string _strAuthorYear = CommonFunction.GetFieldAuthorYear(item);
                                //Quotation quotation = QuotationData.GetQuotationByeAuthorYear(_strAuthorYear);
                                _listQuotation.Add(quotationItem);
                            }
                            if (2 == _listQuotation.Count)//只有两个引文
                            {
                                int a = QuotationItem.GetQuotationOrder(_listQuotation[0].GetCurrentAuthorYear());
                                int b = QuotationItem.GetQuotationOrder(_listQuotation[1].GetCurrentAuthorYear());
                                if (a > b)
                                {
                                    _listIndexFields[i].Result.Text = _strPrefix + b + "," + a + _strSuffix;
                                }
                                else
                                {
                                    _listIndexFields[i].Result.Text = _strPrefix + a + "," + b + _strSuffix;
                                }
                                //item.Result.Text = _strPrefix + index + "," + (index + 1) + _strSuffix;
                            }
                            else
                            {
                                List<int> listOrder = new List<int>();
                                foreach (Quotation currentQuotation in _listQuotation)
                                {
                                    int _nOrder = QuotationItem.GetQuotationOrder(currentQuotation.GetCurrentAuthorYear());
                                    listOrder.Add(_nOrder);
                                }
                                listOrder.Sort();
                                _listIndexFields[i].Result.Text = _strPrefix + listOrder[0] + "-" + listOrder[listOrder.Count - 1] + _strSuffix;
                                //item.Result.Text = _strPrefix + index + "-" + (index + _listQuotation.Count - 1) + _strSuffix;
                            }
                        }
                    }
                    else//单一引文
                    {
                        index += 1;
                        content = string.Format(_strFormat, (index).ToString());
                        _listIndexFields[i].Result.Text = content;
                    }
                }
                return _fieldNew;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 1 为顺序编码制
        /// 2 为作者出版年制
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public void GetQuotationIndexType()
        {

        }

        #region 顺序编码制

        /// <summary>
        /// 获取是否上标
        /// </summary>
        /// <returns></returns>
        public void IsSuperScript()
        {


        }

        /// <summary>
        /// 将当前range块添加为引文索引，书签格式为BIMT开头
        /// 注书签操作方式
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_rangMark"></param>
        /// <returns></returns>
        private Word.Bookmark WriteOrderCodingQuotationIndexOfBookMark()
        {
            try
            {
                int _nNo = GetNextMarkNo(wordApp);
                string _strIndex = string.Format(@"[{0}]", _nNo);
                Word.Range _rangeMark = AddSuperscriptText(wordApp, _strIndex);
                string _strMarkName = m_strQuotationIndexBookMarkFlag + GetNextMarkNo(wordApp).ToString();
                Word.Bookmark mark = wordApp.ActiveDocument.Bookmarks.Add(_strMarkName, _rangeMark);
                return mark;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将当前range块添加为引文索引，书签格式为BIMT开头
        /// 注：域操作方式
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_rangMark"></param>
        /// <returns></returns>
        private Word.Field WriteOrderCodingQuotationIndexOfField()
        {
            //try
            //{
            //    int _nNo =CommonFunction.GetNextFieldNo(WordApp);
            //    string _strIndex = string.Format(@"[{0}]", _nNo);

            //    int _nStart = WordApp.Selection.Range.Start;
            //    Word.Range _rangeTemp = WordApp.Selection.Range;
            //    _rangeTemp.Text = _strIndex;
            //    Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nStart + _strIndex.Length);
            //    if (m_boolIsSuperScript)
            //    {
            //        _rangeMark.Font.Superscript = 1;
            //    }


            //    string _strMarkName = m_strQuotationIndexBookMarkFlag + _nNo.ToString();
            //    //Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, _rangeMark);
            //    Word.Field _field = CommonFunction.AddField(WordApp, _rangeMark, _strMarkName);
            //    return _field;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }



        #region 添加上角标
        /// <summary>
        /// 添加上角标文字
        /// 2016-03-24
        /// wuhailong
        /// </summary>
        /// <param name="p_strText"></param>
        public Word.Range AddSuperscriptText(Microsoft.Office.Interop.Word.Application WordApp, string p_strText)
        {
            //try
            //{
            //    int _nStart = WordApp.Selection.Range.Start;
            //    Word.Range range = WordApp.Selection.Range;
            //    range.Text = p_strText;
            //    Word.Range rangeSuper = WordApp.ActiveDocument.Range(_nStart, _nStart + p_strText.Length);
            //    if (m_boolIsSuperScript)
            //    {
            //        rangeSuper.Font.Superscript = 1;
            //    }
            //    rangeSuper.Text = p_strText;
            //    return rangeSuper;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }
        #endregion

        #region 获取下一个bookbook
        /// <summary>
        /// 返回下一个BIMT书签应该的标志
        /// </summary>
        /// <returns></returns>
        public int GetNextMarkNo(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nMax = GetMaxMarkNo(WordApp);
                return ++_nMax;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 获取最大的bookmark NO

        /// <summary>
        /// 获取最大的bookmark NO ,没有返回 0
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public int GetMaxMarkNo(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nTemp = 0;
                foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
                {
                    if (item.Name.StartsWith("BIMT"))
                    {
                        string _strName = item.Name.Replace("BIMT", "");
                        int _nNo = int.Parse(_strName);
                        if (_nNo > _nTemp)
                        {
                            _nTemp = _nNo;
                        }
                    }
                }
                return _nTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #endregion


        //#region 通过光标返回所在引文
        ///// <summary>
        ///// 通过光标返回所在引文
        ///// </summary>
        ///// <param name="WordApp"></param>
        ///// <returns></returns>
        //public static Word.Field GetFieldBySection(Microsoft.Office.Interop.Word.Application WordApp)
        //{
        //    int _nLocationStart = WordApp.Selection.Start;
        //    int _nLocationEnd = WordApp.Selection.End;
        //    foreach (Word.Field item in WordApp.ActiveDocument.Fields)
        //    {
        //        if (item.Result.Start <= _nLocationStart && _nLocationEnd <= item.Result.End)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}

        //#endregion

        #region 定位引文

        /// <summary>
        /// 通过光标停驻的位置匹配获取引文索引
        /// 再通过引文索引定位引文
        /// 2016-03-28
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public void LocateQuotation(Microsoft.Office.Interop.Word.Application WordApp)
        {
            Word.Field _fieldSelectIndex = CommonFunction.GetFieldBySection(WordApp);
            //string _strIndex = ClearIndex(_markSelectIndex);
            string _strIndex = _fieldSelectIndex.Code.Text.Replace("KEYWORDS", string.Empty).Replace(QuotationIndex.FLAG + "_", "");
            //Word.Field _markSelectQuotation = GetFieldByCodeText(WordApp, QuotationItem.FLAG.Trim()+ _strIndex.Trim());
            //_markSelectQuotation.Select();
            LocateQuotation(WordApp, _strIndex);
        }

        /// <summary>
        /// 通过光标停驻的位置匹配获取引文索引
        /// 再通过引文索引定位引文
        /// 2016-03-28
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public void LocateQuotation(Microsoft.Office.Interop.Word.Application WordApp, string _strAuthorYear)
        {

            string _strIndex = _strAuthorYear;
            Word.Field _markSelectQuotation = GetFieldByCodeText(WordApp, QuotationItem.FLAG.Trim() + "_" + _strIndex.Trim());
            _markSelectQuotation.Select();
        }


        /// <summary>
        /// 通过data 获取域
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public Word.Field GetFieldByCodeText(Microsoft.Office.Interop.Word.Application WordApp, string p_strCodeText)
        {
            try
            {
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(p_strCodeText))
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string ClearIndex(Word.Bookmark _markSelected)
        {
            string _strStartFlag = "[";
            string _strEndFlag = "]";
            return _markSelected.Range.Text.Replace(_strStartFlag, "").Replace(_strEndFlag, "");
        }

        #endregion

        /// <summary>
        /// 设置Index的样式；包括上角标、小角标、字体、字号
        /// 2016-05-25
        /// wuhailong
        /// </summary>
        /// <param name="range"></param>
        public static void SetIndexStyle(Word.Range range)
        {
            try
            {
                //上角标
                string _strSuper = JsonHelper.GetValue("USING_SUPERSCRIPT");
                if (_strSuper.ToUpper() == "TRUE")
                {
                    range.Font.Superscript = 1;
                }
                //下角标
                string _strSub = JsonHelper.GetValue("USING_SUBSCRIPT");
                if (_strSub.ToUpper() == "TRUE")
                {
                    range.Font.Subscript = 1;
                }
                //字体
                //string _strFontName = JsonHelper.GetValue("QUOTATION_INDEX_FONT_FAMILY");
                //默认为正文字体
                range.Font.Name = Font;
                //字号
                string _strFontSize = JsonHelper.GetValue("QUOTATION_INDEX_FONT_SIZE");
                float _fFontSize = float.Parse(_strFontSize);
                range.Font.Size = _fFontSize;
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// 判断当前样式是否为顺序编码制
        /// wuhailong
        /// 2016-07-23
        /// </summary>
        /// <returns></returns>
        public static bool IsOrderStyle()
        {
            try
            {
                string _strTemplet = JsonHelper.GetValue("QUOTATION_INDEX");
                if (_strTemplet.Contains("序号"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 统一书写文中引文标签 Word.Field _field = CommonFunction.GetFieldBySection(WordApp);
        /// </summary>
        public void WriteContent()
        {
            //先判断短浅选择位置是否有域，再合并。
            try
            {
                PublicVar.WriteIndex = true;
                int _nStart = wordApp.Selection.Range.Start;
                Font = wordApp.Selection.Range.Font.Name;
                Word.Field _LocationField = CommonFunction.GetFieldBySection(wordApp);
                if (_LocationField != null)
                {
                    _nStart = _LocationField.Result.End + 1;
                }
                if (IsSameQuotation(_LocationField))
                {
                    return;
                }
                _LocationField = MergeIndex(_LocationField);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex.Message + wordApp.Version);
            }
        }
       
        /// <summary>
        /// 想插入的文献是否在当前光标点的引文已经存在了
        /// </summary>
        /// <param name="_fieldR"></param>
        /// <returns></returns>
        private bool IsSameQuotation(Word.Field _fieldR)
        {
            try
            {
                if (_fieldR == null)
                {
                    return false;
                }
                string _strLocateQuotation = CommonFunction.GetFieldAuthorYear(_fieldR);
                string _strNewQuotation = quotation.GetCurrentAuthorYear();
                if (_strLocateQuotation.Contains(_strNewQuotation))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return false;
            }
        }

        /// <summary>
        /// 将文献对象写入文章作者为英文
        /// 2016-05-11
        /// wuhailong
        /// </summary>
        /// <param name="quotation"></param>
        public void WriteContent(Quotation quotation)
        {
            try
            {
                PublicVar.WriteIndex = true;
                bool _needSort = NeedSort();
                int _nStart = wordApp.Selection.Range.Start;
                Word.Field _LocationField = CommonFunction.GetFieldBySection(wordApp);
                if (_LocationField != null)
                {
                    _nStart = _LocationField.Result.End + 1;
                }
                Word.Range _rangeField = wordApp.ActiveDocument.Range(_nStart, _nStart);
                Word.Field _fieldR = CommonFunction.WriteQuotationFieldAtRange(wordApp, _rangeField, QuotationIndex.FLAG, quotation);

                _fieldR = MergeIndex(_fieldR);
                //设置样式
                //上角标
                string _strSuper = JsonHelper.GetValue("USING_SUPERSCRIPT");
                if (_strSuper.ToUpper() == "TRUE")
                {
                    _fieldR.Result.Font.Superscript = 1;
                }
                //下角标
                string _strSub = JsonHelper.GetValue("USING_SUBSCRIPT");
                if (_strSub.ToUpper() == "TRUE")
                {
                    _fieldR.Result.Font.Subscript = 1;
                }
                //字体
                string _strFontName = JsonHelper.GetValue("QUOTATION_INDEX_FONT_FAMILY");
                _fieldR.Result.Font.Name = _strFontName;
                //字号
                string _strFontSize = JsonHelper.GetValue("QUOTATION_INDEX_FONT_FAMILY");
                float _fFontSize = float.Parse(_strFontSize);
                _fieldR.Result.Font.Size = _fFontSize;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
            }
        }

        /// <summary>
        /// 返回文中引文模板是否包含序号假如包含返回true ，否则 false
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        private bool NeedSort()
        {
            string _strIndexText = JsonHelper.GetValue(QuotationIndex.FLAG);
            return NeedSort(_strIndexText);
        }

        /// <summary>
        /// 返回文中引文模板是否包含序号假如包含返回true ，否则 false
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        private bool NeedSort(string _strIndexText)
        {
            if (_strIndexText.Contains("序号"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回文中引文模板是否包含序号假如包含返回true ，否则 false
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        private bool GetSortType()
        {
            return false;
        }

        #region 作者出版年制

        /// <summary>
        /// 作者出版年制
        /// </summary>
        private void WriteAuthorPubYearQuotationIndex()
        {
            //try
            //{
            //    string _strIndex = string.Format(@"({0} {1})", m_strAuthor, m_strPubYear);
            //    Word.Range _rangeMark = AddSuperscriptText(WordApp, _strIndex);
            //    string _strMarkName = m_strQuotationIndexBookMarkFlag + GetNextMarkNo(WordApp).ToString();
            //    Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, _rangeMark);
            //    string _strFieldName = QuotationIndex.FLAG + m_strAuthor.Trim() + "_" + m_strPubYear.Trim() + "_" + CommonFunction.GetNextFieldNo(WordApp); ;
            //    CommonFunction.AddField(WordApp, mark.Range, _strFieldName);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        #endregion


        public void SetStyle()
        {
            throw new NotImplementedException();
        }




        void IQuotation.InitStatus()
        {
            throw new NotImplementedException();
        }

        void IQuotation.WriteContent()
        {
            throw new NotImplementedException();
        }

        void IQuotation.SetStyle()
        {
            throw new NotImplementedException();
        }

        public Word.Range WriteQuotationFieldAtRange(Word.Range p_range)
        {
            try
            {
                string _strResult = string.Empty;
                string _strTemplet = JsonHelper.GetValue("QUOTATION_INDEX_TEMPLET"); ;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                //int _nMaxtFieldNo = GetMaxFieldNo(WordApp);
                //Word.Paragraph paragraph = AddParagraphAtEnd(WordApp);
                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    Word.Range _range = wordApp.ActiveDocument.Range(p_range.Start + _strResult.Length, p_range.Start + _strResult.Length);
                    _strResult += CommonFunction.AddTextAtRange(wordApp, _strFieldAndStyleMix, _range, null);
                }
                return wordApp.ActiveDocument.Range(p_range.Start, p_range.Start + _strResult.Length); ;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 应用所选中的样式
        /// 2016-05-13
        /// wuhailong
        /// </summary>
        /// <param name="styleName"></param>
        public void RefreshStyle(string styleName)
        {
            try
            {
                PublicVar.WriteIndex = true;
                List<Word.Field> listQuotationIndexField = GetDocFieldList();
                foreach (Word.Field item in listQuotationIndexField)
                {

                    List<Quotation> listQuotation = GetUnionQuotationList(item);
                    listQuotation = SortQuotationList(listQuotation);
                    //fieldLocate = UnionQuotationListAtField(fieldLocate, listQuotation);
                    CommonFunction.WriteQuotationFieldAtRange(wordApp, item, QuotationIndex.FLAG, listQuotation);
                    SetQuotationIndexCodeText(item, listQuotation);

                    //List<Quotation> listQuotation = GetFieldQuotationList(item);
                    //UnionQuotationListAtField(item, listQuotation);
                    //SetQuotationIndexCodeText(item, listQuotation);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
            }
        }

        /// <summary>
        /// 合并顺序编码制的文中引文
        /// wuhailong
        /// 2016-05-20
        /// </summary>
        /// <param name="_listQuotation">文献列表</param>
        /// <param name="item">写入的域</param>
        private void UnionAuthorYearQuotationIndex(List<Quotation> _listQuotation, Word.Field item)
        {
            try
            {
                int _nStart = item.Code.Start;
                string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                item.Result.Text = _strPrefix + _strSuffix;
                int _nIndex = 0;
                foreach (Quotation quotation in _listQuotation)
                {
                    if (_nIndex == 0)
                    {
                        item = MergeAuthorYearIndex3(item, _nStart, quotation);
                    }
                    else
                    {
                        item = MergeAuthorYearIndex2(item, _nStart, quotation);
                    }
                    _nIndex++;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
            }
        }

        /// <summary>
        /// 合并作者年制的文中引文
        /// 2016-05-20
        /// wuhailong
        /// </summary>
        /// <param name="_listQuotation">文献列表</param>
        /// <param name="item">写入的域</param>
        private void UnionOrderCodingQuotationIndex(List<Quotation> _listQuotation, Word.Field item)
        {
            try
            {
                string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                if (2 == _listQuotation.Count)//只有两个引文
                {
                    int a = QuotationItem.GetQuotationOrder(_listQuotation[0].GetCurrentAuthorYear());
                    int b = QuotationItem.GetQuotationOrder(_listQuotation[1].GetCurrentAuthorYear());
                    if (a > b)
                    {
                        item.Result.Text = _strPrefix + b + "," + a + _strSuffix;
                    }
                    else
                    {
                        item.Result.Text = _strPrefix + a + "," + b + _strSuffix;
                    }
                }
                else
                {
                    List<int> listOrder = new List<int>();
                    foreach (Quotation quotation in _listQuotation)
                    {
                        int i = QuotationItem.GetQuotationOrder(quotation.GetCurrentAuthorYear());
                        listOrder.Add(i);
                    }
                    listOrder.Sort();
                    item.Result.Text = _strPrefix + listOrder[0] + "-" + listOrder[listOrder.Count - 1] + _strSuffix;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取文中引文的对象的序号位置
        /// 2016-05-18
        /// wuhailong
        /// </summary>
        /// <param name="quotation"></param>
        /// <returns></returns>
        public int GetQuotationIndexOrder(Quotation quotation)
        {
            try
            {
                string currentAurhorYear = quotation.GetCurrentAuthorYear();
               
                return GetQuotationIndex(currentAurhorYear);
            }
            catch (Exception ex)
            {
                throw new Exception("GetQuotationIndexOrder", ex);
            }
        }

        private List<string> listAuthorYear = null;
        private List<Word.Field> listFeild = null;

        /// <summary>
        /// 获取文中引文的对象的序号位置
        /// 2016-05-18
        /// wuhailong
        /// </summary>
        /// <param name="quotation"></param>
        /// <returns></returns>
        public int GetQuotationIndex(string authorYear)
        {
            try
            {
                int index = 0;
                foreach (var item in listAuthorYear)
                {
                    index++;
                    if (authorYear == item)
                    {
                        break;
                    }
                }
                return index;
            }
            catch (Exception ex)
            {
                throw new Exception("GetQuotationIndexOrder", ex);
            }
        }

        /// <summary>
        /// 返回域代码的引文对象作者年标志
        /// wuhailong
        /// 2016-07-19
        /// </summary>
        /// <param name="p_strCodeText"></param>
        /// <returns></returns>
        public static string ClearQuotationIndexFieldCodeText(string p_strCodeText)
        {
            try
            {
                return p_strCodeText.Replace("QUOTATION_INDEX_", string.Empty).Replace("KEYWORDS",string.Empty).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("清理引文域",ex);
            }
        }

        /// <summary>
        /// 返回域引文的作者年标志数组
        /// wuhailong
        /// 2016-07-19
        /// </summary>
        /// <param name="usrName">域对象</param>
        /// <returns></returns>
        public string[] GetFieldAuthorYearArray(Word.Field field)
        {
            try
            {
                string authorYearInfo = GetFieldAuthorYearInfo(field);
                return authorYearInfo.Split('#');
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除文中引文的依赖项
        /// wuhailong
        /// 2016-08-09
        /// </summary>
        /// <param name="authorYear">指定删除的作者年</param>
        public  void DeleteIndexQuotation(string authorYear)
        {
            try
            {
                listFeild = qIndex.GetDocFieldList();
                foreach (Word.Field item in listFeild)
                {
                    string[] arrayAuthorYear = QuotationIndex.GetInstance().GetFieldAuthorYearArray(item);
                    //文末引文
                    if (arrayAuthorYear.Contains(authorYear.Trim()))
                    {
                        if (!item.Code.Text.Contains("#"))
                        {
                            item.Delete();
                        }
                        else//复合引文
                        {
                            arrayAuthorYear = QuotationIndex.GetInstance().GetFieldAuthorYearArray(item);
                            List<string> fieldAuthorYearList = arrayAuthorYear.ToList<string>();
                            fieldAuthorYearList.Remove(authorYear.Trim());
                            List<Quotation> listQuotation = ConvertAuthorYearToQuotation(fieldAuthorYearList);
                            QuotationIndex.UnionQuotationListAtField(item, listQuotation);
                            SetQuotationIndexCodeText(item, listQuotation);
                            SetIndexStyle(item.Result);
                        }
                    }
                }
                listAuthorYear = GetDocAuthorYearList();
                listFeild = qIndex.GetDocFieldList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取域的quotation 对象list
        /// wuhailong
        /// 2016-08-09
        /// </summary>
        /// <param name="usrName"></param>
        /// <returns></returns>
        public List<Quotation> GetFieldQuotationList(Word.Field field)
        {
            try
            {
                List<Quotation> listQuotation = new List<Quotation>();
                string[] arrayAuthorYear = GetFieldAuthorYearArray(field);
                foreach (string item in arrayAuthorYear)
                {
                    Quotation currentQuotation = QuotationSet.GetQuotationByeAuthorYear(item.Trim());
                    listQuotation.Add(currentQuotation);
                }
                return listQuotation;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 返回域引文的作者年标志数组
        /// wuhailong
        /// 2016-07-19
        /// </summary>
        /// <param name="p_fieldQuotationIndex">域代码</param>
        /// <returns></returns>
        //public  string[] GetFieldAuthorYearArray(string codeText)
        //{
        //    try
        //    {
        //        string authorYearInfo = GetFieldAuthorYearInfo(
        //        string[] _arrayAuthorYears = ClearQuotationIndexFieldCodeText(codeText).Trim().Split('#'); // _strAuthorYear.Replace("QUOTATION_INDEX_", string.Empty).Split('#');
        //        return _arrayAuthorYears;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("获取域作者年数组",ex);
        //    }
        //}

        /// <summary>
        /// 获取文档的作者年列表，排除重复的英文中引文
        /// wuhailong
        /// 2016-08-04
        /// </summary>
        /// <returns></returns>
        public  List<string> GetDocAuthorYearList()
        {
            try
            {
                Microsoft.Office.Interop.Word.Application WordApp = WordApplication.GetInstance().WordApp;
                List<Word.Field> listQuotationIndexField = GetDocFieldList();
                List<string> listAuthorYear = new List<string>();
                foreach (Word.Field item in listQuotationIndexField)
                {
                    string authorYears = CommonFunction.GetFieldAuthorYear(item).Trim();
                    authorYears = ClearQuotationIndexFieldCodeText(authorYears).Trim();
                    if (item.Code.Text.Contains("#"))
                    {//多条引文
                        string[] _array = authorYears.Split('#');
                        foreach (var author_year in _array)
                        {
                            if (!listAuthorYear.Contains(author_year.Trim()))
                            {
                                listAuthorYear.Add(author_year.Trim());
                            }
                        }
                    }
                    else
                    {
                        if (!listAuthorYear.Contains(authorYears.Trim()))
                        {
                            listAuthorYear.Add(authorYears.Trim());
                        }
                    }
                }
                return listAuthorYear;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAuthorYearList", ex);
            }
        }

        /// <summary>
        /// 刷新文中引文序号
        /// wuahilong
        /// 2016-07-18
        /// </summary>
        public void RefreshIndex()
        {
            string pre = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
            string suff = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
            try
            {
                foreach (Word.Field item in listFeild)
                {
                    string result = string.Empty;
                    string[] arrayAuthorYear = GetFieldAuthorYearArray(item);
                    if (arrayAuthorYear.Length>1)//复合引文
                    {
                        List<int> listIndex = new List<int>();
                        foreach (string currentAuthorYear in arrayAuthorYear)
                        {
                            int index = GetQuotationIndex(currentAuthorYear.Trim());
                            listIndex.Add(index);
                        }
                        listIndex.Sort();
                        //---//
                        string _strChar = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_YEAR_CHAR");
                        if (listIndex.Count == 2)
                        {
                            result = listIndex[0] + _strChar + listIndex[1];
                        }
                        else if (listIndex.Count == 3)
                        {
                            //result = listOrder[0] + "," + listOrder[1];
                            if (IsSerialList(listIndex))//连续引文
                            {
                                result = listIndex[0] + "-" + listIndex[listIndex.Count - 1];
                            }
                            else//分散引文
                            {
                                foreach (int _nOrder in listIndex)
                                {
                                    result += _nOrder + _strChar;
                                }
                                result = result.Trim().Trim(',');
                            }
                        }
                        else
                        {//有可能为， -的组合情况
                            result = FixIndexList(listIndex);
                        }
                    }
                    else//单一引文
                    {
                        int order = GetQuotationIndex(arrayAuthorYear[0].Trim());
                        result = order.ToString();
                    }
                    item.Result.Text = pre + result + suff;
                    SetIndexStyle(item.Result);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
            }
            //按照文末序号排列文中序号
            //string _strPre = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
            //string _strSuff = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
            //try
            //{
            //    foreach (Word.Field item in WordApp.ActiveDocument.Fields)
            //    {
                    
            //        string _strResult = string.Empty;
            //        if (item.Code.Text.Contains(QuotationIndex.FLAG))
            //        {
            //            string _strAuthorYear = CommonFunction.GetFieldAuthorYear(item);
            //            if (_strAuthorYear.Contains("#"))//复合引文
            //            {
            //                List<int> _listOrder = new List<int>();
            //                string[] _arrayAuthorYears = GetFieldQuotationArray(item);// _strAuthorYear.Replace("QUOTATION_INDEX_", string.Empty).Split('#');
            //                foreach (string _strUnionItem in _arrayAuthorYears)
            //                {
            //                    int _nOrder = QuotationItem.GetQuotationOrder(_strUnionItem.Trim());
            //                    _listOrder.Add(_nOrder);
            //                }
            //                _listOrder.Sort();

            //                if (_listOrder.Count == 2)
            //                {
            //                    _strResult = _listOrder[0] + "," + _listOrder[1];
            //                }
            //                else
            //                {
            //                    if (IsSerialList(_listOrder))//连续引文
            //                    {
            //                        _strResult = _listOrder[0] + "-" + _listOrder[_listOrder.Count - 1];
            //                    }
            //                    else//分散引文
            //                    {
            //                        foreach (int _nOrder in _listOrder)
            //                        {
            //                            _strResult += _nOrder + ",";
            //                        }
            //                        _strResult = _strResult.Trim(',');
            //                    }
            //                }
            //            }
            //            else//单一引文
            //            {
            //                int _nOrder = QuotationItem.GetQuotationOrder(_strAuthorYear);
            //                _strResult = _nOrder.ToString();
            //            }
            //            item.Result.Text = _strPre + _strResult + _strSuff;
            //            SetIndexStyle(item.Result);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(QuotationIndex), ex);
            //}
        }

        /// <summary>
        /// 针对有可能为， -的组合情况
        /// 生成的序号格式
        /// wuhailong
        /// 2016-08-08
        /// </summary>
        /// <param name="listOrder"></param>
        /// <returns></returns>
        public static string FixIndexList(List<int> listOrder)
        {
            try
            {
                string result = listOrder[0].ToString();
                int count = 1;
                string temp = string.Empty;
                for (int i = 0; i < listOrder.Count; )
                {
                    if (i + 1 < listOrder.Count)
                    {
                        if (listOrder[i] + 1 == listOrder[i + 1])
                        {
                            count++;
                            temp += "," + listOrder[i].ToString();
                            i = i + 1;

                            continue;
                        }
                        else
                        {
                            if (count >= 3)
                            {
                                temp = string.Empty;
                                count = 1;
                                result += "-" + listOrder[i].ToString();
                                i = i + 1;

                            }
                            else if (count == 2)
                            {
                                count = 1;
                                result += temp;
                            }
                            else if (count == 1)
                            {
                                temp = string.Empty;
                                if (i == 0)
                                {
                                    count = 1;
                                    i = i + 1;
                                    result += "," + listOrder[i].ToString();
                                }
                                else
                                {
                                    count = 1;
                                    result += "," + listOrder[i].ToString();
                                    i = i + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (count >= 3)
                        {
                            result += "-" + listOrder[i].ToString();
                        }
                        else
                        {
                            result += "," + listOrder[i].ToString();
                        }
                        i = i + 1;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("FixIndexList", ex);
            }
        }

        /// <summary>
        /// 判断这个list是否为连续的
        /// wuhailong
        /// 2016-07-18
        /// </summary>
        /// <param name="_listOrder"></param>
        /// <returns></returns>
        private bool IsSerialList(List<int> _listOrder)
        {
            try
            {
                for (int i = 0; i < _listOrder.Count; i++)
                {
                    if (i + 1 < _listOrder.Count)
                    {
                        if (_listOrder[i] == _listOrder[i + 1] - 1)
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_listOrder[i] == _listOrder[i - 1] + 1)
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return false;
            }
        }

       

        //public List<Word.Field> GetDocQuotationIndexFieldList()
        //{
        //    throw new NotImplementedException();
        //}


       

        public List<Word.Field> GetDocFieldList()
        {
            try
            {
                List<Word.Field> listField = new List<Word.Field>();
                foreach (Word.Field item in wordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationIndex.FLAG))
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


        public Word.Field GetFieldByAuthorYear(string authorYear)
        {
            throw new NotImplementedException();
        }


        public string GetFieldAuthorYearInfo(Word.Field field)
        {
            try
            {
                string _strNeedClear = "KEYWORDS " + QuotationIndex.FLAG + "_";
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
