using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 作者字段
    /// </summary>
    class FieldAuthor : BaseField, IField
    {
        public FieldAuthor()
        {
        }

        public FieldAuthor(Quotation quotation)
        {
            this.quotation = quotation;
        }

        /// <summary>
        /// 判断是否是中文姓名
        /// 吴海龙
        /// 2016--11-06
        /// </summary>
        /// <returns></returns>
        //public bool IsCN() {
        //    this.GetAuthorName(this);
        //}

        public string GetValue()
        {
            try
            {
                if (PublicVar.WriteIndex)//文中引文
                {
                    string _strListAll = JsonHelper.GetValue("QUOTATION_INDEX_LIST_ALL_AUTHORS");
                    string _strListAllIfLessThenThree = JsonHelper.GetValue("QUOTATION_INDEX_LIST_ALL_AUTHORS_IF_LESS_THEN_THREE");
                    string _strListMax = JsonHelper.GetValue("QUOTATION_INDEX_LIST_AUTHOR_COUNT_EN");
                    int _nListMax = 0;// int.Parse(_strListMax == string.Empty ? "3" : _strListMax);
                    string _strOther = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS_EN");
                    if (frmTempletManager.IsCnStyle() && quotation.IsEnQuotation())//中文样式引用英文文献
                    {
                        _strOther = JsonHelper.GetValue("AUTHOR_LIST_OTHER_EN_CN_INDEX");
                    }
                    string _strOtherAuthorUseIlitic = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC");
                    string _charFist = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_SPLIT_CHAR_EN");//.Trim().ToCharArray()[0];
                    string _charLast = JsonHelper.GetValue("QUOTATION_INDEX_LAST_TWO_AUTHOR_SPLIT_CHAR_EN");//.Trim().ToCharArray()[0];
                    if ("TRUE" == _strListAll.ToUpper())//是否列出全部
                    {
                        _nListMax = 99;
                    }
                    else if ("TRUE" == _strListAllIfLessThenThree.ToUpper())
                    {//当作者多于2个则只列出第一个；否则列出全部
                        string _strMoreCount = JsonHelper.GetValue("QUOTATION_INDEX_LIST_AUTHOR_COUNT_OVER").ToString();
                        int _nMoreCount = int.Parse(_strMoreCount == string.Empty ? "0" : _strMoreCount);

                        string _strAtListCount = JsonHelper.GetValue("QUOTATION_INDEX_LIST_AUTHOR_COUNT_ONLY").ToString();
                        int _nAtListCount = int.Parse(_strAtListCount == string.Empty ? "0" : _strAtListCount);
                        if (quotation.listAuthor.Count > _nMoreCount)
                        {
                            _nListMax = _nAtListCount;
                        }
                        else
                        {
                            _nListMax = 99;
                        }
                    }
                    string _strAuthorList = string.Empty;
                    int _nCount = 0;
                    bool moreThenSetNum = false;
                    string _strAuthorChar = string.Empty;
                    foreach (Author item in quotation.listAuthor)
                    {
                        if (_nCount == (quotation.listAuthor.Count - 2))
                        {
                            _strAuthorChar = _charLast;
                        }
                        else
                        {
                            _strAuthorChar = _charFist;
                        }
                        if (_nCount == _nListMax)//超出最大列出作者数
                        {
                            moreThenSetNum = true;
                            break;
                        }
                        if (_nCount == 0)
                        {
                            _strAuthorList +=quotation.GetAuthorName(item, true, true) + _strAuthorChar;
                        }
                        else
                        {
                            _strAuthorList += quotation.GetAuthorName(item, false, true) + _strAuthorChar;
                        }
                        _nCount++;
                    }
                    _strAuthorList = _strAuthorList.Remove(_strAuthorList.LastIndexOf(_charFist));
                    //_strAuthorList = _strAuthorList.Trim().Trim();
                    if (moreThenSetNum && (quotation.listAuthor.Count > _nListMax))//多出作者数的替代符
                    {
                        //if (IsEnQuotation())
                        //{
                        _strAuthorList += "#" + _strOther; // JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS_EN");
                        //}
                        //else
                        //{
                        //    _strAuthorList += "#" + JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS");
                        //}
                    }
                    result = _strAuthorList;
                }
                else//文末引文
                {
                    if (quotation.listAuthor.Count == 0)
                    {
                        result = JsonHelper.GetValue("EN_LOST_AUTHOR_REPLACE");
                    }
                    else
                    {
                        string _strListAll = JsonHelper.GetValue("AUTHOR_LIST_ALL");
                        //string _strListMax = 0;// JsonHelper.GetValue("AUTHOR_LIST_MAX");
                        int _nListMax = 0;// int.Parse(JsonHelper.GetValue("AUTHOR_LIST_MAX") == string.Empty ? "0" : _strListMax);
                        int.TryParse(JsonHelper.GetValue("AUTHOR_LIST_MAX"), out _nListMax);
                        string _strOther = JsonHelper.GetValue("AUTHOR_LIST_OTHER");
                        if (frmTempletManager.IsCnStyle() && quotation.IsEnQuotation())//中文样式引用英文文献
                        {
                            _strOther = JsonHelper.GetValue("AUTHOR_LIST_OTHER_EN_CN");
                        }
                        string _strListNoMoreThen = JsonHelper.GetValue("QUOTATION_ITEM_LIST_NO_MORE_THEN_AUTHOR");//当作者超过N个时只列出前M个，否则列出全部
                        string _strListNoMoreThenCount = JsonHelper.GetValue("QUOTATION_ITEM_LIST_NO_MORE_COUNT");
                        int _nListNoMoreThenCount = 0;// int.Parse(_strListNoMoreThenCount == string.Empty ? "0" : _strListNoMoreThenCount);//指定不超过的作者数
                        int.TryParse(_strListNoMoreThenCount == null ? "" : _strListNoMoreThenCount, out _nListNoMoreThenCount);
                        int _nOnlyListCount = 0;
                        string onlyListCount = JsonHelper.GetValue("QUOTATION_ITEM_ONLY_LIST_COUNT");
                        int.TryParse(onlyListCount == null ? "" : onlyListCount, out _nOnlyListCount);// Parse(_strOnlyListCount == string.Empty ? "0" : _strOnlyListCount);//只列出作者数
                        string _charFist = JsonHelper.GetValue("AUTHOR_BETWEEN_CHAR");//.Trim().ToCharArray()[0];
                        string _charLast = JsonHelper.GetValue("AUTHOR_LAST_TWO_BETWEEN_CHAR");//.Trim().ToCharArray()[0];
                        if ("TRUE" == _strListAll.ToUpper())//是否列出全部
                        {
                            _nListMax = 99;
                        }
                        else if (_strListNoMoreThen != null && "TRUE" == _strListNoMoreThen.ToUpper())
                        {
                            if (quotation.listAuthor.Count > _nListNoMoreThenCount)
                            {
                                _nListMax = _nOnlyListCount;
                            }
                            else
                            {
                                _nListMax = 99;
                            }
                        }
                        string _strAuthorList = string.Empty;
                        int _nCount = 0;
                        bool moreThenSetNum = false;
                        string _strAuthorChar = string.Empty;
                        foreach (Author item in quotation.listAuthor)
                        {
                            if (_nCount == (quotation.listAuthor.Count - 2))
                            {
                                _strAuthorChar = _charLast;
                            }
                            else
                            {
                                _strAuthorChar = _charFist;
                            }
                            if (_nCount == _nListMax)//超出最大列出作者数
                            {
                                moreThenSetNum = true;
                                break;
                            }
                            if (_nCount == 0)
                            {
                                _strAuthorList += quotation.GetAuthorName(item, true, false) + _strAuthorChar;
                            }
                            else
                            {
                                _strAuthorList += quotation.GetAuthorName(item, false, false) + _strAuthorChar;
                            }
                            _nCount++;
                        }
                        _strAuthorList = _strAuthorList.Remove(_strAuthorList.LastIndexOf(_charFist));//.Trim(_charFist.Trim());
                        if (moreThenSetNum)//多出作者数的替代符
                        {
                            //if (IsEnQuotation())
                            //{
                            //_strAuthorList += _charLast + GetAuthorName(listAuthor[listAuthor.Count - 1], false) + "#" + JsonHelper.GetValue("EN_AUTHOR_LIST_OTHER");
                            _strAuthorList += "#" + _strOther;// JsonHelper.GetValue("AUTHOR_LIST_OTHER");
                            //}
                            //else
                            //{
                            //    _strAuthorList += _charLast + GetAuthorName(listAuthor[listAuthor.Count - 1], false) + "#" + JsonHelper.GetValue("CN_AUTHOR_LIST_OTHER");
                            //}
                        }
                        result = _strAuthorList;
                        bool ok = quotation.NeedTrimAuthor();
                        if (ok)//wuahilong 2016-07-22 对于作者姓名简写为“A.B.”或“A. B.”，作者最后字段不应该有两个符号，不应该是附图2中的结果，如应该是：Jame A., Jame B., Jame C. Cancer in tumor.
                        {
                            result = result.Trim().Trim('.');
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
