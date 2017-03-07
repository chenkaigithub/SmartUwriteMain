using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;
using BIMTClassLibrary.DBF;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using System.Runtime.Serialization;
using BIMTClassLibrary.quotation;

namespace BIMTClassLibrary
{
    public class Quotation
    {
        #region 内容字段
        [DataMember(Name = "did", IsRequired = false, Order = 0)]
        public string did = string.Empty;
        [DataMember(Name = "online", IsRequired = false, Order = 1)]
        public string online = string.Empty;
        [DataMember(Name = "title", IsRequired = false, Order = 2)]
        public string title = string.Empty;
        [DataMember(Name = "shortTitle", IsRequired = false, Order = 3)]
        public string shortTitle = string.Empty;
        [DataMember(Name = "otherTitle", IsRequired = false, Order = 4)]
        public string otherTitle = string.Empty;
        [DataMember(Name = "topics", IsRequired = false, Order = 5)]
        public string topics = string.Empty;
        [DataMember(Name = "keywords", IsRequired = false, Order = 6)]
        public string keywords = string.Empty;
        [DataMember(Name = "listAuthor", IsRequired = false, Order = 7)]
        public List<Author> listAuthor = new List<Author>();
        [DataMember(Name = "publishInfo", IsRequired = false, Order = 8)]
        public PublishInfo publishInfo;
        [DataMember(Name = "abstracts", IsRequired = false, Order = 9)]
        public string abstracts = string.Empty;// - 论文摘要，当前包含中文 / 英文摘要
        [DataMember(Name = "extraInfo", IsRequired = false, Order = 10)]
        public ExtraInfo extraInfo;
        [DataMember(Name = "authors", IsRequired = false, Order = 11)]
        public string authors = string.Empty;

        
        private System.Windows.Forms.DataGridViewRow _drCurrent;

        public Quotation(string p_strAuthor, string p_strYear)
        {
            // TODO: Complete member initialization
            //this.m_strAuthor = p_strAuthor;
            //this.m_strPubYear = p_strYear;
        }

        public Quotation()
        {
            // TODO: Complete member initialization
        }

        public Quotation(System.Windows.Forms.DataGridViewRow r)
        {
            try
            {
                // TODO: Complete member initialization
                this._drCurrent = r;
                did = r.Cells["ID"].Value.ToString();
                online = r.Cells["ONLINE"].Value.ToString();
                title = r.Cells["标题"].Value.ToString();
                shortTitle = r.Cells["简短标题"].Value.ToString();
                otherTitle = r.Cells["其他标题"].Value.ToString();
                keywords = r.Cells["关键词"].Value.ToString();
                topics = r.Cells["主题"].Value.ToString();
                string _strOrg = r.Cells["作者机构"].Value.ToString();
                string _strAdd = r.Cells["作者地址"].Value.ToString();
                DataSet _ds = LocalDBHelper.ExcuteQuery(string.Format("select * from authors where QUOTATION_ID = '{0}'", did));
                foreach (DataRow item in _ds.Tables[0].Rows)
                {
                    Name name = new Name(item["last_name"].ToString(), item["first_name"].ToString(), item["full_name"].ToString());
                    Author author = new Author(name, _strOrg, _strAdd);
                    listAuthor.Add(author);
                }
                //期刊名称
                publishInfo.periodicalInfo.name = r.Cells["作者地址"].Value.ToString();
                publishInfo.periodicalInfo.place = r.Cells["出版地点"].Value.ToString();
                publishInfo.periodicalInfo.press = r.Cells["出版社"].Value.ToString();
                publishInfo.periodicalInfo.originalPress = r.Cells["原出版社"].Value.ToString();
                publishInfo.periodicalInfo.reprintEdition = r.Cells["重印版次"].Value.ToString();
                publishInfo.periodicalInfo.ISBNISSN = r.Cells["ISBNISSN"].Value.ToString();
                publishInfo.publishYear = r.Cells["年份"].Value.ToString();
                publishInfo.volumeCount = r.Cells["卷数"].Value.ToString();
                publishInfo.volumeInfo = r.Cells["卷"].Value.ToString();
                publishInfo.issueInfo = r.Cells["期"].Value.ToString();
                publishInfo.column = r.Cells["栏目"].Value.ToString();
                publishInfo.pageRange = r.Cells["页码"].Value.ToString();
                publishInfo.wordsCount = r.Cells["字数"].Value.ToString();
                publishInfo.price = r.Cells["价格"].Value.ToString();
                abstracts = r.Cells["摘要"].Value.ToString();

                extraInfo.bibliographyType = r.Cells["题录类型"].Value.ToString();
                extraInfo.fundProject = r.Cells["基金"].Value.ToString();
                extraInfo.type = r.Cells["类型"].Value.ToString();
                extraInfo.subjectClassification = r.Cells["学科分类"].Value.ToString();
                extraInfo.catagory = r.Cells["分类"].Value.ToString();
                extraInfo.topic = r.Cells["主题"].Value.ToString();
                extraInfo.titleEntry = r.Cells["标题项"].Value.ToString();
                extraInfo.tags = r.Cells["标签"].Value.ToString();
                extraInfo.bibTex = r.Cells["BibTeX关键字"].Value.ToString();
                extraInfo.auxiliaryAuthors = r.Cells["辅助作者"].Value.ToString();
                extraInfo.commentItems = r.Cells["评述项"].Value.ToString();
                extraInfo.factor = r.Cells["影响因子"].Value.ToString();
                extraInfo.includedRange = r.Cells["收录范围"].Value.ToString();
                extraInfo.comments = r.Cells["注释"].Value.ToString();
                extraInfo.pics = r.Cells["图片"].Value.ToString();
                extraInfo.dataProvider = r.Cells["数据库提供者"].Value.ToString();
                extraInfo.lang = r.Cells["语言"].Value.ToString();
                extraInfo.nation = r.Cells["国别"].Value.ToString();
                extraInfo.citationCount = r.Cells["被引用次数"].Value.ToString();
                extraInfo.referenceDocumentsCount = r.Cells["引用参考文献数"].Value.ToString();
                extraInfo.referenceDocumentsList = r.Cells["引用参考文献"].Value.ToString();
                extraInfo.version = r.Cells["版本"].Value.ToString();
                extraInfo.doi = r.Cells["DOI"].Value.ToString();
                extraInfo.acquisitionNumber = r.Cells["获取号"].Value.ToString();
                extraInfo.acquisitionBookNumber = r.Cells["索书号"].Value.ToString();
                extraInfo.displayDate = r.Cells["显示日期"].Value.ToString();
                extraInfo.date = r.Cells["日期"].Value.ToString();
                extraInfo.modifyDate = string.Empty;// r.Cells["编辑日期"].Value.ToString();
                extraInfo.createDate = r.Cells["创建日期"].Value.ToString();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(Quotation), ex);
            }   
        }
        #endregion
        
        public string GetCurrentAuthorYear()
        {
            string _strAuthorList = string.Empty;
            foreach (Author item in listAuthor)
            {
                _strAuthorList += item.ToString();
            }
            return _strAuthorList + "_" + publishInfo.publishYear.Trim();
        }

        /// <summary>
        /// 获取作者列表以|分隔
        /// 2016-05-24
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            string _strAuthorList = string.Empty;
            foreach (Author item in listAuthor)
            {
                _strAuthorList += item.ToString()+"|";
            }
            return _strAuthorList;// +"_" + publishInfo.publishYear;
        }

        public string GetFirstAuthor()
        {
            try
            {
                return listAuthor[0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Quotation GetQuotationByAuthorYear(string p_strAuthor, string p_strPubYear)
        {

            return null;
        }

      
        /// <summary>
        /// 根据作者后面的字段判断是否应该省略作者最后的那个.
        /// wuhailong
        /// 2016-07-26
        /// </summary>
        /// <returns></returns>
        public bool NeedTrimAuthor()
        {
            try
            {
                string _strTemp = JsonHelper.GetValue(QuotationItem.FLAG);
                string _strTemplet = _strTemp.Split('#')[1];

                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                int _nAuthorNo = 0;
                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    if (_strFieldAndStyleMix.Contains("作者"))
                    {
                        _nAuthorNo = i;
                    }
                }
                if (_nAuthorNo + 1 < matches.Count)
                {
                    string _strNext = matches[_nAuthorNo + 1].Captures[0].Value.Replace("<", "").Replace(">", "");
                    if (_strNext.Contains("."))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

         /// <summary>
        /// 获取修正后真正的值
        /// 2016-04-06
        /// wuhailong
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public  string GetFieldValue(Microsoft.Office.Interop.Word.Application WordApp,string fieldName)
        {
            try
            {
                IField field = null;
                string _strResult = string.Empty;
                switch (fieldName)
                {
                    case "序号":
                        field = new CitationNumber(this);
                        break;
                    case "空格":
                        field = new Space(this);

                        break;
                    case "“":
                        field = new DoubleQuotationMarks(this);
                        break;
                    case "段落":
                        field = new FeildParagraph(this);
                        break;
                    case "作者":
                        field = new FieldAuthor(this);
                        break;
                    case "年份":
                        field = new PublishYear(this);
                        break;
                    case "标题"://wuhailong 2016-07-22 对参考文献标题以问号或叹号结尾的，以问号或叹号为标题后的符号，如：Author. Cancer in tumor [J]? 1999...
                        field = new Titile(this);
                        break;
                    case ".":
                        field = new FullPoint(this);
                        break;
                    case "卷":
                        field = new VolumeInfo(this);
                        break;
                    case "期":
                        field = new IssueInfo(this);
                        break;
                    case "页码":
                        field = new PageRange(this);
                        break;
                    case "PMID号":
                        field = new PMIDNumber(this);
                        break;
                    case "DOI号":
                        field = new DOINumber(this);
                        break;
                    case "制表符":
                        field = new Tabs(this);
                        break;
                    case "出版地点":
                        field = new PublishPlace(this);
                        break;
                    case "出版社":
                        field = new Press(this);
                        break;
                    case "期刊":
                        field = new FieldMagazine(this);
                        break;
                    case "出版日期":
                        field = new PublishDate(this);
                        break;
                    default:
                        field = new EmptyField(fieldName);
                        break;
                }
                return field.GetValue();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.ToString() + "字段内容提取错误+GetFieldValue" + fieldName);
                return "[" + fieldName + "]";
            }
        }

        ///// <summary>
        ///// 获取修正后真正的值
        ///// 2016-04-06
        ///// wuhailong
        ///// </summary>
        ///// <param name="p_strFieldName"></param>
        ///// <returns></returns>
        //public  string GetFieldValue2(Microsoft.Office.Interop.Word.Application WordApp, string p_strFieldName)
        //{
        //    try
        //    {
        //        string _strResult = string.Empty;
        //        switch (p_strFieldName)
        //        {
        //            case "序号":
        //                _strResult = "{0}";
        //                break;
        //            case "空格":
        //                _strResult = " ";
        //                break;
        //            case "段落":
        //                _strResult = "\n";
        //                break;
        //            case "作者":
        //                if (PublicVar.WriteIndex)//文中引文
        //                {
        //                    string _strListAll = JsonHelper.GetValue("QUOTATION_INDEX_LIST_ALL_AUTHORS");
        //                    string _strListMax = JsonHelper.GetValue("QUOTATION_INDEX_LIST_AUTHOR_COUNT");
        //                    int _nListMax = int.Parse(_strListMax == string.Empty ? "3" : _strListMax);
        //                    string _strOther = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS");
        //                    string _strOtherAuthorUseIlitic = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC");
        //                    char _charFist = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_SPLIT_CHAR").Trim().ToCharArray()[0];
        //                    char _charLast = JsonHelper.GetValue("QUOTATION_INDEX_LAST_TWO_AUTHOR_SPLIT_CHAR").Trim().ToCharArray()[0];
        //                    if ("TRUE" == _strListAll.ToUpper())//是否列出全部
        //                    {
        //                        _nListMax = 99;
        //                    }
        //                    string _strAuthorList = string.Empty;
        //                    int _nCount = 0;
        //                    bool moreThenSetNum = false;
        //                    foreach (Author item in listAuthor)
        //                    {
        //                        if (_nCount == _nListMax)//超出最大列出作者数
        //                        {
        //                            moreThenSetNum = true;
        //                            break;
        //                        }
        //                        if (_nCount == 0)
        //                        {
        //                            _strAuthorList += GetAuthorName(item) + _charFist;
        //                        }
        //                        else
        //                        {
        //                            _strAuthorList += GetAuthorName(item, false) + _charFist;
        //                        }
        //                        _nCount++;
        //                    }
        //                    _strAuthorList = _strAuthorList.Trim(_charFist);
        //                    if (moreThenSetNum && (listAuthor.Count > _nListMax))//多出作者数的替代符
        //                    {
        //                        //if (IsEnQuotation())
        //                        //{
        //                        _strAuthorList += "#" + JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS_EN");
        //                        //}
        //                        //else
        //                        //{
        //                        //    _strAuthorList += "#" + JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHORS");
        //                        //}
        //                    }
        //                    _strResult = _strAuthorList;
        //                }
        //                else//文末引文
        //                {
        //                    string _strListAll = JsonHelper.GetValue("AUTHOR_LIST_ALL");
        //                    int _nListMax = int.Parse(JsonHelper.GetValue("AUTHOR_LIST_MAX"));
        //                    string _strOther = JsonHelper.GetValue("AUTHOR_LIST_OTHER");
        //                    char _charFist = JsonHelper.GetValue("AUTHOR_BETWEEN_CHAR").Trim().ToCharArray()[0];
        //                    char _charLast = JsonHelper.GetValue("AUTHOR_LAST_TWO_BETWEEN_CHAR").Trim().ToCharArray()[0];
        //                    if ("TRUE" == _strListAll.ToUpper())//是否列出全部
        //                    {
        //                        _nListMax = 99;
        //                    }
        //                    string _strAuthorList = string.Empty;
        //                    int _nCount = 0;
        //                    bool moreThenSetNum = false;
        //                    foreach (Author item in listAuthor)
        //                    {
        //                        if (_nCount == _nListMax - 1)//超出最大列出作者数
        //                        {
        //                            moreThenSetNum = true;
        //                            break;
        //                        }
        //                        if (_nCount == 0)
        //                        {
        //                            _strAuthorList += GetAuthorName(item) + _charFist;
        //                        }
        //                        else
        //                        {
        //                            _strAuthorList += GetAuthorName(item, false) + _charFist;
        //                        }
        //                        _nCount++;
        //                    }
        //                    _strAuthorList = _strAuthorList.Trim(_charFist);
        //                    if (moreThenSetNum)//多出作者数的替代符
        //                    {
        //                        //if (IsEnQuotation())
        //                        //{//AUTHOR_LIST_OTHER
        //                        _strAuthorList += _charLast + GetAuthorName(listAuthor[listAuthor.Count - 1], false) + "#" + JsonHelper.GetValue("AUTHOR_LIST_OTHER");
        //                        //}
        //                        //else
        //                        //{
        //                        //    _strAuthorList += _charLast + GetAuthorName(listAuthor[listAuthor.Count - 1], false) + "#" + JsonHelper.GetValue("CN_AUTHOR_LIST_OTHER");
        //                        //}
        //                    }
        //                    _strResult = _strAuthorList;
        //                }
        //                break;
        //            case "年份":
        //                if (PublicVar.WriteIndex)
        //                {
        //                    string _strFour = JsonHelper.GetValue("USE_FOUR_NUM_YEAR");
        //                    if ("TRUE" == _strFour.ToUpper())
        //                    {
        //                        _strResult = publishInfo.publishYear;
        //                    }
        //                    else
        //                    {
        //                        _strResult = publishInfo.publishYear.Substring(2);
        //                    }
        //                }
        //                else
        //                {
        //                    _strResult = publishInfo.publishYear;
        //                }

        //                break;
        //            case "标题":
        //                _strResult = title;
        //                break;
        //            case "卷":
        //                _strResult = publishInfo.volumeInfo;
        //                break;
        //            case "期":
        //                _strResult = publishInfo.issueInfo;
        //                break;

        //            //case "页码":
        //            //    string _strQuotationType = m_strTitleType;
        //            //    string[] _arrayPages = m_strPageRange.Split('-');
        //            //    if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_NONE"))
        //            //    {
        //            //        _strResult = m_strPageRange;
        //            //    }
        //            //    else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_PRE_ONLY"))
        //            //    {
        //            //        _strResult = _arrayPages[0];
        //            //    }
        //            //    else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_LAST_ONE_WORD"))
        //            //    {
        //            //        int _start = _arrayPages[1].Length-1;

        //            //        _strResult = _arrayPages[0] + _arrayPages[1].Substring(_start, 1);
        //            //    }
        //            //    else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_LAST_TWO_WORD") && _arrayPages[1].Length >= 2)
        //            //    {
        //            //        int _start = _arrayPages[1].Length - 2;

        //            //        _strResult = _arrayPages[0] + _arrayPages[1].Substring(_start, 2);
        //            //    }
        //            //    else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_FULL"))
        //            //    {
        //            //        _strResult = m_strPageRange;
        //            //    }
        //            //    else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_FOR") && _strQuotationType=="期刊")
        //            //    {
        //            //        _strResult = _arrayPages[0];
        //            //    }
        //            //    else
        //            //    {
        //            //        _strResult = m_strPageRange;
        //            //    }

        //            //    break;
        //            //case "连接符":
        //            //    _strResult = "-";
        //            //    break;
        //            //case "分隔符":
        //            //    _strResult = "|";
        //            //    break;
        //            //case "优先级":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "星标":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "链接":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "第二作者":
        //            //    if (listAuthor.Count > 1)
        //            //    {
        //            //        _strResult = listAuthor[1].name.cn;
        //            //    }
        //            //    break;
        //            //case "第二作者译名":
        //            //    if (listAuthor.Count > 12)
        //            //    {
        //            //        _strResult = listAuthor[1].name.en;
        //            //    }
        //            //    break;
        //            //case "第二标题":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "第二标题翻译":
        //            //    _strResult = "*";
        //            //    break;
        //            case "出版地点":
        //                if (publishInfo.periodicalInfo.place.Trim() == string.Empty )
        //                {
        //                    _strResult = JsonHelper.GetValue("EN_LOST_PUB_PLACE_REPLACE");
        //                }
        //                //else if (publishInfo.periodicalInfo.place.Trim() == string.Empty )
        //                //{
        //                //    _strResult = JsonHelper.GetValue("CN_LOST_PUB_PLACE_REPLACE");
        //                //}
        //                else
        //                {
        //                    _strResult = publishInfo.periodicalInfo.place;
        //                }
        //                break;
        //            case "出版社":
        //                if (publishInfo.periodicalInfo.press == string.Empty)
        //                {
        //                    _strResult = JsonHelper.GetValue("EN_LOST_PUBER_REPLACE");
        //                }
        //                //else if (publishInfo.periodicalInfo.press == string.Empty)
        //                //{
        //                //    _strResult = JsonHelper.GetValue("CN_LOST_PUBER_REPLACE");
        //                //}
        //                else
        //                {
        //                    _strResult = publishInfo.periodicalInfo.press;
        //                }
        //                break;
        //            case "期刊":
        //                _strResult = publishInfo.periodicalInfo.name;
        //                break;
        //            case "DOI号":
        //                _strResult = extraInfo.doi; ;
        //                break;
        //            //case "卷数":
        //            //    _strResult = publishInfo.volumeCount;
        //            //    break;
        //            //case "栏目":
        //            //    _strResult = publishInfo.column;
        //            //    break;
        //            //case "第三作者":
        //            //    if (listAuthor.Count > 2)
        //            //    {
        //            //        _strResult = listAuthor[2].name.cn;
        //            //    }
        //            //    break;
        //            //case "第三作者译名":
        //            //    if (listAuthor.Count > 2)
        //            //    {
        //            //        _strResult = listAuthor[2].name.en;
        //            //    }
        //            //    break;
        //            //case "第三标题":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "第三标题翻译":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "引用参考文献数":
        //            //    _strResult = extraInfo.referenceDocumentsCount;
        //            //    break;
        //            //case "引用参考文献":
        //            //    _strResult = extraInfo.referenceDocumentsList;
        //            //    break;
        //            //case "版本":
        //            //    _strResult = extraInfo.version; ;
        //            //    break;
                    
        //            //case "显示日期":
        //            //    _strResult = extraInfo.displayDate; ;
        //            //    break;
        //            //case "日期":
        //            //    _strResult = extraInfo.date;
        //            //    break;
        //            //case "类型":
        //            //    _strResult = extraInfo.catagory;
        //            //    break;
        //            //case "辅助作者":
        //            //    _strResult = extraInfo.auxiliaryAuthors;
        //            //    break;
        //            //case "简短标题":
        //            //    _strResult = shortTitle;
        //            //    break;
        //            //case "其他标题":
        //            //    _strResult = otherTitle;
        //            //    break;
        //            //case "ISBN/ISSN":
        //            //    _strResult = publishInfo.periodicalInfo.ISBNISSN;
        //            //    break;
        //            //case "原出版社":
        //            //    _strResult = publishInfo.periodicalInfo.originalPress;
        //            //    break;
        //            //case "重印版次":
        //            //    _strResult = publishInfo.periodicalInfo.reprintEdition;
        //            //    break;
        //            //case "评述项":
        //            //    _strResult = extraInfo.commentItems;
        //            //    break;
        //            //case "获取号":
        //            //    _strResult = extraInfo.acquisitionNumber;
        //            //    break;
        //            //case "索书号":
        //            //    _strResult = extraInfo.acquisitionBookNumber;
        //            //    break;
        //            //case "学科分类":
        //            //    _strResult = extraInfo.subjectClassification;
        //            //    break;
        //            //case "分类":
        //            //    _strResult = extraInfo.catagory;
        //            //    break;
        //            //case "标签":
        //            //    _strResult = extraInfo.tags;
        //            //    break;
        //            //case "BibTeX关键字":
        //            //    _strResult = extraInfo.bibTex;
        //            //    break;
        //            //case "关键词":
        //            //    _strResult = keywords;
        //            //    break;
        //            //case "主题词":
        //            //    _strResult = topics;
        //            //    break;
        //            //case "摘要":
        //            //    _strResult = abstracts;
        //            //    break;
        //            //case "影响因子":
        //            //    _strResult = extraInfo.factor;
        //            //    break;
        //            //case "收录范围":
        //            //    _strResult = extraInfo.includedRange;
        //            //    break;
        //            //case "主题":
        //            //    _strResult = extraInfo.topic;
        //            //    break;
        //            //case "注释":
        //            //    _strResult = extraInfo.comments;
        //            //    break;
        //            //case "图片":
        //            //    _strResult = extraInfo.pics;
        //            //    break;
        //            //case "基金":
        //            //    _strResult = extraInfo.fundProject;
        //            //    break;
        //            //case "作者机构":
        //            //    _strResult = listAuthor[0].organizations;
        //            //    break;
        //            //case "作者地址":
        //            //    _strResult = listAuthor[0].addresses; ;
        //            //    break;
        //            //case "标题项":
        //            //    _strResult = extraInfo.titleEntry;
        //            //    break;
        //            //case "作者译名":
        //            //    _strResult = listAuthor[0].name.en;
        //            //    break;
        //            //case "出版地译名":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "出版社译名":
        //            //    _strResult = "*";
        //            //    break;
        //            //case "数据库提供者":
        //            //    _strResult = extraInfo.dataProvider;
        //            //    break;
        //            //case "语言":
        //            //    _strResult = extraInfo.lang;
        //            //    break;
        //            //case "国别":
        //            //    _strResult = extraInfo.nation;
        //            //    break;
        //            default:
        //                _strResult = p_strFieldName;
        //                break;

        //        }
        //        return _strResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.ToString() + "字段内容提取错误+GetFieldValue");
        //        return "-1";
        //    }
        //}

        /// <summary>
        /// 获取作者姓名
        /// 2016-05-05
        /// wuhailong
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetAuthorName(Author item)
        {
            try
            {
                return GetAuthorName(item, true);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// 判断是否为英文文献,
        /// 2016-05-05
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public bool IsEnQuotation()
        {
            string _strTemplet = title;
            string _strReg = @"[^\x00-\xff]";
            var matches = Regex.Matches(_strTemplet, _strReg);
            if (matches.Count >0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 返回作者姓大小写设置格式化结果
        /// wuhailong
        /// 2016-06-30
        /// </summary>
        /// <param name="_strFirstName"></param>
        /// <returns></returns>
        public string GetFixFirstName(string _strFirstName)
        {
            return GetFixFirstName(_strFirstName,true);
            //try
            //{
            //    string _strFritNameStyle = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_NAME_UPLOW");
            //    if (_strFritNameStyle == "首字母大写")
            //    {
            //        _strFirstName = _strFirstName.ToLower();
            //        _strFirstName = _strFirstName.Substring(0, 1).ToUpper() + _strFirstName.Substring(1);
            //    }
            //    else if (_strFritNameStyle == "全部大写")
            //    {
            //        _strFirstName = _strFirstName.ToUpper();
            //    }
            //    return _strFirstName;
            //}
            //catch (Exception ex)
            //{
            //    Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.Message);
            //    return _strFirstName;
            //}
        }

        /// <summary>
        ///  /// 返回作者名大小写设置格式化结果,是否为
        /// wuhailong
        /// 2016-06-30
        /// </summary>
        /// <param name="_strFirstName"></param>
        /// <param name="isIndex"></param>
        /// <returns></returns>
        public string GetFixFirstName(string _strFirstName, bool isIndex)
        {
            try
            {
                string _strStyle = string.Empty;
                if (isIndex)
                {
                    _strStyle = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_NAME_SIMPLE");
                }
                else
                {
                    _strStyle = JsonHelper.GetValue("QUOTATION_ITEM_AUTHOR_NAME_SIMPLE");
                }
                string[] arrayLastName = _strFirstName.Trim().Split(' ');
                _strFirstName = string.Empty;
                foreach (var item in arrayLastName)
                {
                    if (_strStyle == "不缩写")
                    {
                        _strFirstName += item;
                    }
                    else if (_strStyle == "缩写为首字母大写，如AB")
                    {
                        _strFirstName += item.Substring(0, 1).ToUpper();// _strLastName.ToUpper();
                    }
                    else if (_strStyle == "缩写为首字母大写和“.”，如A.B.")
                    {
                        _strFirstName += item.Substring(0, 1).ToUpper() + ".";
                    }
                    else if (_strStyle == "缩写为首字母大写和空格，如A B")
                    {
                        _strFirstName += item.Substring(0, 1).ToUpper() + " ";
                    }
                    else if (_strStyle == "缩写为首字母大写，“.”和空格，如A. B.")
                    {
                        _strFirstName += item.Substring(0, 1).ToUpper() + ". ";
                       
                    }
                }
                //最后空格取消 
                if (_strStyle == "缩写为首字母大写，“.”和空格，如A. B.")
                {
                    _strFirstName = _strFirstName.Trim();
                }
                return _strFirstName;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.Message);
                return _strFirstName;
            }

            //try
            //{
            //    string _strStyle = string.Empty;
            //    if (isIndex)
            //    {
            //        _strStyle = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_NAME_UPLOW");
            //    }
            //    else
            //    {
            //        _strStyle = JsonHelper.GetValue("QUOTATION_ITEM_AUTHOR_NAME_UPLOW");
            //    }
               
            //    if (_strStyle == "首字母大写")
            //    {
            //        _strFirstName = _strFirstName.ToLower();
            //        _strFirstName = _strFirstName.Substring(0, 1).ToUpper() + _strFirstName.Substring(1);
            //    }
            //    else if (_strStyle == "全部大写")
            //    {
            //        _strFirstName = _strFirstName.ToUpper();
            //    }
            //    return _strFirstName;
            //}
            //catch (Exception ex)
            //{
            //    Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.Message);
            //    return _strFirstName;
            //}
        }

        /// <summary>
        /// 获取作者名称 的格式化
        /// 不缩写
        /// 缩写为首字母大写，如AB
        /// 缩写为首字母大写和“.”，如A.B.
        /// 缩写为首字母大写和空格，如A B
        /// 缩写为首字母大写，“.”和空格，如A. B.
        /// wuhailong
        /// 2016-06-30
        /// </summary>
        /// <param name="_strLastName"></param>
        /// <returns></returns>
        public string GetFixLastName(string _strLastName)
        {
            return GetFixLastName(_strLastName,true);
        }

       /// <summary>
        /// 获取作者姓称 的格式化,是否为文中引文
        /// 不缩写
        /// 缩写为首字母大写，如AB
        /// 缩写为首字母大写和“.”，如A.B.
        /// 缩写为首字母大写和空格，如A B
        /// 缩写为首字母大写，“.”和空格，如A. B.
        /// wuhailong
        /// 2016-06-30
        /// </summary>
        /// <param name="_strLastName"></param>
        /// <returns></returns>
        public string GetFixLastName(string _strLastName, bool isIndex)
        {

            try
            {
                _strLastName = _strLastName.Trim();
                string _strStyle = string.Empty;
                if (isIndex)
                {
                    _strStyle = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_NAME_UPLOW");
                }
                else
                {
                    _strStyle = JsonHelper.GetValue("QUOTATION_ITEM_AUTHOR_NAME_UPLOW");
                }

                if (_strStyle == "首字母大写")
                {
                    _strLastName = _strLastName.ToLower();
                    _strLastName = _strLastName.Substring(0, 1).ToUpper() + _strLastName.Substring(1);
                }
                else if (_strStyle == "全部大写")
                {
                    _strLastName = _strLastName.ToUpper();
                }
                return _strLastName;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.Message);
                return _strLastName;
            }
            //try
            //{
            //     string _strStyle = string.Empty;
            //    if (isIndex)
            //    {
            //        _strStyle = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_NAME_SIMPLE");
            //    }
            //    else
            //    {
            //        _strStyle = JsonHelper.GetValue("QUOTATION_ITEM_AUTHOR_NAME_SIMPLE");
            //    }
            //    string[] arrayLastName = _strLastName.Split(' ');
            //    _strLastName = string.Empty;
            //    foreach (var item in arrayLastName)
            //    {
            //        if (_strStyle == "缩写为首字母大写，如AB")
            //        {
            //            _strLastName += item.Substring(0, 1).ToUpper();// _strLastName.ToUpper();
            //        }
            //        else if (_strStyle == "缩写为首字母大写和“.”，如A.B.")
            //        {
            //            _strLastName += item.Substring(0, 1).ToUpper() + ".";
            //        }
            //        else if (_strStyle == "缩写为首字母大写和空格，如A B")
            //        {
            //            _strLastName += item.Substring(0, 1).ToUpper() + " ";
            //        }
            //        else if (_strStyle == "缩写为首字母大写，“.”和空格，如A. B.")
            //        {
            //            _strLastName += item.Substring(0, 1).ToUpper() + ". ";
            //        }
            //    }
            //    return _strLastName;
            //}
            //catch (Exception ex)
            //{
            //    Log4Net.LogHelper.WriteLog(typeof(Quotation), ex.Message);
            //    return _strLastName;
            //}
        }


        /// <summary>
        /// 获取作者姓名,是否为第一作者
        /// 2016-05-05
        /// wuhailong
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetAuthorName(Author item, bool firstAuthor)
        {
            return GetAuthorName( item,firstAuthor,true);

            //bool IsEn = IsEnQuotation();
            //英文作者有 fore 和 last
            //if (item.name.fore != string.Empty && item.name.last != string.Empty)
            //{
            //    string _strAuthorNameStyle = string.Empty;
            //    if (firstAuthor)
            //    {
            //        _strAuthorNameStyle = JsonHelper.GetValue("FIRST_AUTHOR_NAME_STYLE");
            //    }
            //    else
            //    {
            //        _strAuthorNameStyle = JsonHelper.GetValue("OTHER_AUTHOR_STYLE");
            //    }
            //    //名姓
            //    //姓名
            //    //姓,名
            //    //仅显示姓氏
            //    if ("名姓" == _strAuthorNameStyle)
            //    {
            //        return item.name.last + " " + item.name.fore;
            //    }
            //    else if ("姓名" == _strAuthorNameStyle)
            //    {
            //        return item.name.fore + " " + item.name.last;
            //    }
            //    else if ("姓,名" == _strAuthorNameStyle)
            //    {
            //        return item.name.fore + "," + item.name.last;
            //    }
            //    else if ("仅显示姓氏" == _strAuthorNameStyle)
            //    {
            //        return item.name.fore;
            //    }
            //    Log4Net.LogHelper.WriteLog(typeof(Quotation), "[未知姓名格式设置：" + _strAuthorNameStyle + "]");
            //    return string.Empty;// "[未知姓名格式设置：" + _strAuthorNameStyle + "]";
            //}
            //else if (item.name.full != string.Empty)
            //{
            //    string _strAddSpace = JsonHelper.GetValue("ADD_SPACE_BETWEEN_TWO_WORD_NAME");
            //    if (item.name.full.Length == 2 && "TRUE" == _strAddSpace.ToUpper())
            //    {
            //        return item.name.full.Substring(0, 1) + " " + item.name.full.Substring(1);
            //    }
            //    return item.name.full;
            //}
            //Log4Net.LogHelper.WriteLog(typeof(Quotation), "无可识别作者信息作者信息]" + item.name.fore + "-" + item.name.last + "-" + item.name.full);
            //return string.Empty;//JsonHelper.GetValue("EN_LOST_AUTHOR_EMPTY");

        }

        /// <summary>
        /// 当文献中有作者信息不完整时返回false
        /// 作者只（有姓||名） 且 （无全称）
        /// wuhailong
        /// 2016-08-05
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorInfoComplete()
        {
            try
            {
                foreach (Author item in listAuthor)
                {
                    if ((item.name.fore.Trim() == string.Empty || item.name.last.Trim() == string.Empty) && item.name.full == string.Empty)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("作者信息不完整", ex);
            }
        }



        /// <summary>
        /// 获取作者姓名,是否为第一作者,是否为文中引文
        /// 2016-05-05
        /// wuhailong
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetAuthorName(Author item, bool firstAuthor,bool isIndex)
        {
            try
            {
                //bool IsEn = IsEnQuotation();
                //英文作者有 fore 和 last
                if (item.name.fore != string.Empty && item.name.last != string.Empty)
                {
                    string _strAuthorNameStyle = string.Empty;
                    if (firstAuthor)
                    {
                        if (isIndex)
                        {
                            _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_INDEX_FIRST_AUTHOR");
                        }
                        else
                        {
                            _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_ITEM_FIRST_AUTHOR");
                        }
                    }
                    else
                    {
                        if (isIndex)
                        {
                            _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR");
                        }
                        else
                        {
                            _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_ITEM_OTHER_AUTHOR");
                        }
                    }
                    string _CnTwoWord = JsonHelper.GetValue("CN_AUTHOR_TWO_WORD_ADD_SPACE");
                    if (item.IsCN() && _CnTwoWord.ToString() == "TRUE" && item.name.full.Length == 2)
                    {//是中文，启用中文姓名使用两个字符中间带空格，名字长度为2
                        return GetFixLastName(item.name.last, isIndex) + " " + GetFixFirstName(item.name.fore, isIndex);
                    }
                    //名姓
                    //姓名
                    //姓,名
                    //仅显示姓氏
                    if ("名姓" == _strAuthorNameStyle)
                    {
                        return GetFixFirstName(item.name.fore, isIndex) + " " + GetFixLastName(item.name.last, isIndex);
                    }
                    else if ("姓名" == _strAuthorNameStyle)
                    {
                        return GetFixLastName(item.name.last, isIndex) + " " + GetFixFirstName(item.name.fore, isIndex);
                    }
                    else if ("姓,名" == _strAuthorNameStyle)
                    {
                        return GetFixLastName(item.name.last, isIndex) + ", " + GetFixFirstName(item.name.fore, isIndex);
                    }
                    else if ("姓, 名" == _strAuthorNameStyle)
                    {
                        return GetFixLastName(item.name.last, isIndex) + ", " + GetFixFirstName(item.name.fore, isIndex);
                    }
                    else if ("仅显示姓氏" == _strAuthorNameStyle)
                    {
                        return GetFixLastName(item.name.last, isIndex);
                    }
                    Log4Net.LogHelper.WriteLog(typeof(Quotation), "[未知姓名格式设置：" + _strAuthorNameStyle + "]");
                    return string.Empty;// "[未知姓名格式设置：" + _strAuthorNameStyle + "]";
                }
                else if (item.name.full != string.Empty)
                {
                    string _strAddSpace = JsonHelper.GetValue("ADD_SPACE_BETWEEN_TWO_WORD_NAME");
                    if (item.name.full.Length == 2 && "TRUE" == _strAddSpace.ToUpper())
                    {
                        return item.name.full.Substring(0, 1) + " " + item.name.full.Substring(1);
                    }
                    return item.name.full.Trim();
                }
                Log4Net.LogHelper.WriteLog(typeof(Quotation), "无可识别作者信息作者信息]" + item.name.fore + "-" + item.name.last + "-" + item.name.full);
                return string.Empty;//JsonHelper.GetValue("EN_LOST_AUTHOR_EMPTY");
            }
            catch (Exception ex)
            {
                throw new Exception("GetAuthorName",ex);
            }
        }

      /// <summary>
      /// 获取作者
      /// </summary>
      /// <param name="item">作者对象</param>
      /// <param name="firstAuthor">是否第一作者</param>
      /// <param name="isQuotationItem">是否文末引文作者</param>
      /// <returns></returns>
        //private string GetAuthorName(Author item, bool firstAuthor, bool isQuotationItem)
        //{
        //    //英文作者有 fore 和 last
        //    if (item.name.fore != string.Empty && item.name.last != string.Empty)
        //    {
        //        string _strAuthorNameStyle = string.Empty;
        //        if (firstAuthor)
        //        {
        //            if (isQuotationItem)
        //            {
        //                _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_ITEM_FIRST_AUTHOR");
        //            }
        //            else
        //            {
        //                _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_ITEM_OTHER_AUTHOR");
        //            }
        //        }
        //        else
        //        {
        //            if (isQuotationItem)
        //            {
        //                _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_INDEX_FIRST_AUTHOR");
        //            }
        //            else
        //            {
        //                _strAuthorNameStyle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR");
        //            }
        //        }
        //        //名姓
        //        //姓名
        //        //姓,名
        //        //仅显示姓氏
        //        if ("名姓" == _strAuthorNameStyle)
        //        {
        //            return GetFixFirstName(); item.name.last + " " + item.name.fore;
        //        }
        //        else if ("姓名" == _strAuthorNameStyle)
        //        {
        //            return item.name.fore + " " + item.name.last;
        //        }
        //        else if ("姓,名" == _strAuthorNameStyle)
        //        {
        //            return item.name.fore + "," + item.name.last;
        //        }
        //        else if ("仅显示姓氏" == _strAuthorNameStyle)
        //        {
        //            return item.name.fore;
        //        }
        //        else
        //        {
        //            Log4Net.LogHelper.WriteLog(typeof(Quotation), "[未知姓名格式设置：" + _strAuthorNameStyle + "]");
        //            return string.Empty;// "[未知姓名格式设置：" + _strAuthorNameStyle + "]";
        //        }
                
        //    }
        //    else if (item.name.full != string.Empty)
        //    {
        //        string _strAddSpace = JsonHelper.GetValue("ADD_SPACE_BETWEEN_TWO_WORD_NAME");
        //        if (item.name.full.Length == 2 && "TRUE" == _strAddSpace.ToUpper())
        //        {
        //            return item.name.full.Substring(0, 1) + " " + item.name.full.Substring(1);
        //        }
        //        return item.name.full;
        //    }
        //    Log4Net.LogHelper.WriteLog(typeof(Quotation), "无可识别作者信息作者信息]" + item.name.fore + "-" + item.name.last + "-" + item.name.full);
        //    return string.Empty;//JsonHelper.GetValue("EN_LOST_AUTHOR_EMPTY");
            //else
            //{
            //    //缺省
            //    if (IsEn)//英文
            //    {
            //        string _strIsEmpty = JsonHelper.GetValue("EN_LOST_AUTHOR_EMPTY");
            //        if ("TRUE" == _strIsEmpty)
            //        {
            //            return string.Empty;
            //        }
            //        else
            //        {
            //            return JsonHelper.GetValue("EN_LOST_AUTHOR_REPLACE");
            //        }
            //    }
            //    else//中文
            //    {
            //        string _strIsEmpty = JsonHelper.GetValue("CN_LOST_AUTHOR_EMPTY");
            //        if ("TRUE" == _strIsEmpty)
            //        {
            //            return string.Empty;
            //        }
            //        else
            //        {
            //            return JsonHelper.GetValue("CN_LOST_AUTHOR_REPLACE");
            //        }
            //    }
            //}
        //}

        /// <summary>
        /// 收藏文献
        /// 2016-05-04
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        internal int Collection()
        {
            try
            {
                string _strSQL = string.Empty;
                int _nReault = 0;
                string _strAuthor = string.Empty;
                foreach (Author item in listAuthor)
                {
                    _strSQL = string.Format(@"insert into authors (id,first_name,last_name,full_name,quotation_id) values('{0}','{1}','{2}','{3}','{4}')", Guid.NewGuid().ToString(), item.name.fore, item.name.last, item.name.full, did);
                    if (item.name.fore != string.Empty && item.name.last != string.Empty)
                    {
                        _strAuthor += item.name.last + " " + item.name.fore + ",";
                    }
                    else
                    {
                        _strAuthor += item.name.full + ",";
                    }
                    
                    _nReault += LocalDBHelper.ExcuteNonQuery(_strSQL);
                }
                _strAuthor = _strAuthor.Trim(',');
                string _strAuthorId = Guid.NewGuid().ToString();
                 _strSQL = string.Format(@"insert into literature 
                                            (标题,作者,题录类型,年份,出版地点,
                                            出版社,卷,期,卷数,页码,
                                            字数,价格,栏目,第二作者,第二作者译名,
                                            第二标题,第二标题译名,第三作者,第三作者译名,第三标题,
                                            第三标题译名,被引用次数,引用参考文献数,引用参考文献,版本,
                                            DOI,显示日期,日期,类型,辅助作者,
                                            简短标题,其他标题,ISBNISSN,原出版社,重印版次,
                                            评述项,获取号,索书号,学科分类,分类,
                                            标签,BibTex关键字,关键词,主题词,摘要,
                                            影响因子,收录范围,主题,注释,图片,
                                            基金,作者机构,作者地址,标题项,作者译名,
                                            标题译名,出版地译名,数据库提供者,语言,国别,
                                            查阅日期,CLASS_ID,创建日期,AUTHORS,id,期刊名称,ONLINE) 
                                            values
                                           ('{0}','{1}','{2}','{3}','{4}',
                                            '{5}','{6}','{7}','{8}','{9}',
                                            '{10}','{11}','{12}','{13}','{14}',
                                            '{15}','{16}','{17}','{18}','{19}',
                                            '{20}','{21}','{22}','{23}','{24}',
                                            '{25}','{26}','{27}','{28}','{29}',
                                            '{30}','{31}','{32}','{33}','{34}',
                                            '{35}','{36}','{37}','{38}','{39}',
                                            '{40}','{41}','{42}','{43}','{44}',
                                            '{45}','{46}','{47}','{48}','{49}',
                                            '{50}','{51}','{52}','{53}','{54}',
                                            '{55}','{56}','{57}','{58}','{59}',
                                            '{60}','{61}','{62}','{63}','{64}',
                                            '{65}','{66}')",
                  title, _strAuthor, extraInfo.bibliographyType, publishInfo.publishYear, publishInfo.periodicalInfo.place,
                  publishInfo.periodicalInfo.press, publishInfo.volumeInfo, publishInfo.issueInfo, string.Empty, publishInfo.pageRange,
                  publishInfo.wordsCount, publishInfo.price, publishInfo.column, string.Empty, string.Empty,
                  string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                  string.Empty, string.Empty, extraInfo.referenceDocumentsCount, extraInfo.referenceDocumentsList, extraInfo.version,
                  extraInfo.doi, extraInfo.displayDate, extraInfo.date, extraInfo.type, extraInfo.auxiliaryAuthors,
                  shortTitle, otherTitle, publishInfo.periodicalInfo.ISBNISSN, publishInfo.periodicalInfo.originalPress, publishInfo.periodicalInfo.reprintEdition,
                  extraInfo.commentItems, extraInfo.acquisitionNumber, extraInfo.acquisitionBookNumber, extraInfo.subjectClassification, extraInfo.catagory,
                  extraInfo.tags, extraInfo.bibTex, keywords, topics, abstracts,
                  extraInfo.factor, extraInfo.includedRange, extraInfo.topic, extraInfo.comments, extraInfo.pics,
                  extraInfo.fundProject, listAuthor[0].organizations, listAuthor[0].addresses, extraInfo.titleEntry, string.Empty,
                  string.Empty, string.Empty, string.Empty, extraInfo.lang, extraInfo.nation,
                  extraInfo.inspectionDate, extraInfo.clazzId, DateTime.Now.ToString(), string.Empty, did, publishInfo.periodicalInfo.name,online);
                 _nReault += LocalDBHelper.ExcuteNonQuery(_strSQL);

              
                return _nReault;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(Quotation), ex);
                return -1;
            }
        }

    }
}
