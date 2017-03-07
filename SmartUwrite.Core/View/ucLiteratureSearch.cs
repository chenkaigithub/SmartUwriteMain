using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.Json;
using Log4Net;
using BIMTClassLibrary.Service;
using System.Threading;
namespace BIMTClassLibrary
{
    public partial class ucLiteratureSearch : UserControl
    {
        private static ucLiteratureSearch m_ucLiteratureSearch = null;
        private Dictionary<string, ucFilter> m_dictUcFilter = new Dictionary<string, ucFilter>();
        private List<ucFilter> m_listUcFilter= new List<ucFilter>();
        public static Stack _stackUcFilter = new Stack();
        public static Stack _stackUcFilterVisible = new Stack();
        public string m_strSid = string.Empty;
        Thread thread = null;
        public ucLiteratureSearch()
        {
            InitializeComponent();
            _stackUcFilter.Push(ucFilter8);
            _stackUcFilter.Push(ucFilter7);
            _stackUcFilter.Push(ucFilter6);
            _stackUcFilter.Push(ucFilter5);

            _stackUcFilter.Push(ucFilter4);
            _stackUcFilter.Push(ucFilter3);
            _stackUcFilter.Push(ucFilter2);
            _stackUcFilter.Push(ucFilter1);
        }

       

        public static ucLiteratureSearch GetInstance()
        {
            if (m_ucLiteratureSearch ==null)
            {
                m_ucLiteratureSearch = new ucLiteratureSearch();
            }
            return m_ucLiteratureSearch;
        }

        public void InitData(string filter)
        {
            InitData(filter, 1);
        }

        /// <summary>
        /// 生成显示条目
        /// 2016-05-07
        /// wuhailong
        /// </summary>
        /// <param name="p_strFilter">过滤条件</param>
        /// <param name="page">页码</param>
        public void InitItem(string p_strResult)
        {
            try
            {
                //panel1.Controls.Clear();
                _listQuotation.Clear();
                _listQuotationOrg.Clear();
                //string _strPostData = "{\"conditions\": [" + p_strFilter + "],\"paging\": {\"page\": " + page + ",\"size\": 30},\"sorting\": [{\"property\": \"Topic\",\"direction\": \"DESC\"}]}";
                //string result = BIMTService.CallPostService(PublicVar.BaseUrl + "/documents/search", _strPostData);
                //if (result == "-1")
                //{
                //    MessageBox.Show("无法访问服务器！");
                //}
                string result = p_strResult;
                var quotations = CommonFunction.JsonToDictionary(result);
                Dictionary<string, object> _dictMeta = (Dictionary<string, object>)quotations["meta"];
                string _strSid = (string)_dictMeta["sid"];
                Int32 _strSum = (Int32)_dictMeta["recordCount"];
                
                m_strSid = _strSid;
                ArrayList _arrayQuotation = (ArrayList)quotations["list"];
                int _nCount = 0; 

                foreach (var item in _arrayQuotation)
                {
                    try
                    {
                        
                        Dictionary<string, object> _dictDid = (Dictionary<string, object>)item;
                        Quotation quotation = new Quotation();
                        quotation.did = _dictDid["did"] == null ? string.Empty : _dictDid["did"].ToString();
                        quotation.online = _dictDid["online"] == null ? string.Empty : _dictDid["online"].ToString();
                        //result = BIMTService.CallGetService(PublicVar.BaseUrl + "/documents/" + quotation.did, string.Empty, string.Empty, false);
                        Dictionary<string, object> _dict = _dictDid;// (Dictionary<string, object>)CommonFunction.JsonToDictionary(result);

                        ArrayList _arrayTitle = (ArrayList)_dict["titles"];
                        Dictionary<string, object> _dictTitle = (Dictionary<string, object>)_arrayTitle[0];//.ToString();
                        if (_dictTitle["cn"] != null)
                        {
                            quotation.title = _dictTitle["cn"].ToString();
                        }
                        else if (_dictTitle["en"] != null)
                        {
                            quotation.title = _dictTitle["en"].ToString();
                        }
                        //关键词
                        Dictionary<string, object> _dictKeywords = (Dictionary<string, object>)_dict["keywords"];//.ToString();
                        if (_dictKeywords["cn"] != null)
                        {
                            foreach (var itemKey in (ArrayList)_dictKeywords["cn"])
                            {
                                quotation.keywords += itemKey + ",";
                            }
                        }
                        else if (_dictKeywords["en"] != null)
                        {
                            foreach (var itemKey in (ArrayList)_dictKeywords["en"])
                            {
                                quotation.keywords += itemKey + ",";
                            }
                        }
                        quotation.shortTitle = _dict["shortTitle"] == null ? string.Empty : _dict["shortTitle"].ToString();
                        quotation.otherTitle = _dict["otherTitle"] == null ? string.Empty : _dict["otherTitle"].ToString();
                        quotation.topics = _dict["topics"] == null ? string.Empty : _dict["topics"].ToString();
                        //作者
                        string _strAuthors = string.Empty;
                        Dictionary<string, object> _listtAuthors = (Dictionary<string, object>)_dict["authors"];
                        foreach (var authorinfo in (ArrayList)_listtAuthors["names"])
                        {
                            Dictionary<string, object> _dictAuthorInfo = (Dictionary<string, object>)authorinfo;

                            string _strlast = _dictAuthorInfo["last"] == null ? string.Empty : _dictAuthorInfo["last"].ToString();
                            string _strfore = _dictAuthorInfo["fore"] == null ? string.Empty : _dictAuthorInfo["fore"].ToString();
                            string _strfull = _dictAuthorInfo["full"] == null ? string.Empty : _dictAuthorInfo["full"].ToString();
                            Name name = new Name(_strlast, _strfore, _strfull);
                            string _strOrganizations = string.Empty;
                            foreach (var organization in (ArrayList)_listtAuthors["organizations"])
                            { _strOrganizations += organization.ToString(); }

                            string _strAddresses = string.Empty;
                            foreach (var addresses in (ArrayList)_listtAuthors["addresses"])
                            { _strAddresses += addresses.ToString(); }
                            Author a = new Author(name, _strOrganizations, _strAddresses);

                            quotation.listAuthor.Add(a);
                            _strAuthors += a.ToString() + ",";
                        }
                        //无作者的无用文献不显示 wuhailong 2016-05-30
                        //if (quotation.listAuthor.Count == 0)
                        //{
                        //    continue;
                        //}
                        quotation.authors = _strAuthors.Trim(',');
                        //出版信息
                        //PublishInfo publishInfo = new PublishInfo();
                        Dictionary<string, object> _dictPublishInfo = (Dictionary<string, object>)_dict["publishInfo"];
                        Dictionary<string, object> _dictPeriodicalInfo = (Dictionary<string, object>)_dictPublishInfo["periodicalInfo"];
                        quotation.publishInfo.periodicalInfo.place = _dictPeriodicalInfo["place"] == null ? string.Empty : _dictPeriodicalInfo["place"].ToString();
                        quotation.publishInfo.periodicalInfo.press = _dictPeriodicalInfo["press"] == null ? string.Empty : _dictPeriodicalInfo["press"].ToString();
                        quotation.publishInfo.periodicalInfo.originalPress = _dictPeriodicalInfo["originalPress"] == null ? string.Empty : _dictPeriodicalInfo["originalPress"].ToString();
                        quotation.publishInfo.periodicalInfo.reprintEdition = _dictPeriodicalInfo["reprintEdition"] == null ? string.Empty : _dictPeriodicalInfo["reprintEdition"].ToString();
                        quotation.publishInfo.periodicalInfo.ISBNISSN = _dictPeriodicalInfo["ISBN/ISSN"] == null ? string.Empty : _dictPeriodicalInfo["ISBN/ISSN"].ToString();
                        //quotation.publishInfo.periodicalInfo.nameAbbr = _dictPeriodicalInfo["nameAbbr"] == null ? string.Empty : _dictPeriodicalInfo["nameAbbr"].ToString();
                        Dictionary<string, object> _dictPeriodicalInfoName = (Dictionary<string, object>)_dictPeriodicalInfo["name"];
                        if (_dictPeriodicalInfoName["cn"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["cn"].ToString();
                        }
                        else if (_dictPeriodicalInfoName["en"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["en"].ToString();
                        }
                        //期刊简写
                        //Dictionary<string, object> _dictPeriodicalInfoNameAbbr = (String)_dictPeriodicalInfo["nameAbbr"];
                        //if (_dictPeriodicalInfoNameAbbr != null && _dictPeriodicalInfoNameAbbr["cn"] != null)
                        //{
                        //    quotation.publishInfo.periodicalInfo.nameAbbr = _dictPeriodicalInfoNameAbbr["cn"].ToString();
                        //}
                        //else if (_dictPeriodicalInfoNameAbbr != null && _dictPeriodicalInfoNameAbbr["en"] != null)
                        //{
                        //    quotation.publishInfo.periodicalInfo.nameAbbr = _dictPeriodicalInfoNameAbbr["en"].ToString();
                        //}
                        if (_dictPeriodicalInfo != null && _dictPeriodicalInfo["nameAbbr"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.nameAbbr = (String)_dictPeriodicalInfo["nameAbbr"];
                        }
                        quotation.publishInfo.publishYear = _dictPublishInfo["publishYear"] == null ? string.Empty : _dictPublishInfo["publishYear"].ToString();
                        quotation.publishInfo.volumeCount = _dictPublishInfo["volumeCount"] == null ? string.Empty : _dictPublishInfo["volumeCount"].ToString();
                        quotation.publishInfo.volumeInfo = _dictPublishInfo["volumeInfo"] == null ? string.Empty : _dictPublishInfo["volumeInfo"].ToString();
                        quotation.publishInfo.issueInfo = _dictPublishInfo["issueInfo"] == null ? string.Empty : _dictPublishInfo["issueInfo"].ToString();
                        quotation.publishInfo.column = _dictPublishInfo["column"] == null ? string.Empty : _dictPublishInfo["column"].ToString();
                        quotation.publishInfo.pageRange = _dictPublishInfo["pageRange"] == null ? string.Empty : _dictPublishInfo["pageRange"].ToString();
                        quotation.publishInfo.wordsCount = _dictPublishInfo["wordsCount"] == null ? string.Empty : _dictPublishInfo["wordsCount"].ToString();
                        quotation.publishInfo.price = _dictPublishInfo["price"] == null ? string.Empty : _dictPublishInfo["price"].ToString();
                        Dictionary<string, object> _dictAbstracts = (Dictionary<string, object>)_dict["abstracts"];
                        if (_dictAbstracts != null && _dictAbstracts["cn"] != null)
                        {
                            quotation.abstracts = _dictAbstracts["cn"].ToString();
                        }
                        else if (_dictAbstracts != null && _dictAbstracts["en"] != null)
                        {
                            quotation.abstracts = _dictAbstracts["en"].ToString();
                        }

                        Dictionary<string, object> _dictExtraInfo = (Dictionary<string, object>)_dict["extraInfo"];
                        if (_dictExtraInfo != null)
                        {
                            quotation.extraInfo.bibliographyType = _dictExtraInfo["bibliographyType"] == null ? string.Empty : _dictExtraInfo["bibliographyType"].ToString();
                            quotation.extraInfo.fundProject = _dictExtraInfo["fundProject"] == null ? string.Empty : _dictExtraInfo["fundProject"].ToString();
                            quotation.extraInfo.type = _dictExtraInfo["type"] == null ? string.Empty : _dictExtraInfo["type"].ToString();
                            quotation.extraInfo.subjectClassification = _dictExtraInfo["subjectClassification"] == null ? string.Empty : _dictExtraInfo["subjectClassification"].ToString();
                            quotation.extraInfo.catagory = _dictExtraInfo["catagory"] == null ? string.Empty : _dictExtraInfo["catagory"].ToString();
                            quotation.extraInfo.topic = _dictExtraInfo["topic"] == null ? string.Empty : _dictExtraInfo["topic"].ToString();
                            quotation.extraInfo.titleEntry = _dictExtraInfo["titleEntry"] == null ? string.Empty : _dictExtraInfo["titleEntry"].ToString();
                            quotation.extraInfo.tags = _dictExtraInfo["tags"] == null ? string.Empty : _dictExtraInfo["tags"].ToString();
                            quotation.extraInfo.bibTex = _dictExtraInfo["bibTex"] == null ? string.Empty : _dictExtraInfo["bibTex"].ToString();
                            quotation.extraInfo.auxiliaryAuthors = _dictExtraInfo["auxiliaryAuthors"] == null ? string.Empty : _dictExtraInfo["auxiliaryAuthors"].ToString();
                            quotation.extraInfo.commentItems = _dictExtraInfo["commentItems"] == null ? string.Empty : _dictExtraInfo["commentItems"].ToString();
                            quotation.extraInfo.factor = _dictExtraInfo["factor"] == null ? string.Empty : _dictExtraInfo["factor"].ToString();
                            quotation.extraInfo.includedRange = _dictExtraInfo["includedRange"] == null ? string.Empty : _dictExtraInfo["includedRange"].ToString();
                            quotation.extraInfo.comments = _dictExtraInfo["comments"] == null ? string.Empty : _dictExtraInfo["comments"].ToString();
                            quotation.extraInfo.pics = _dictExtraInfo["pics"] == null ? string.Empty : _dictExtraInfo["pics"].ToString();
                            quotation.extraInfo.dataProvider = _dictExtraInfo["dataProvider"] == null ? string.Empty : _dictExtraInfo["dataProvider"].ToString();
                            quotation.extraInfo.lang = _dictExtraInfo["lang"] == null ? string.Empty : _dictExtraInfo["lang"].ToString();
                            quotation.extraInfo.nation = _dictExtraInfo["nation"] == null ? string.Empty : _dictExtraInfo["nation"].ToString();
                            quotation.extraInfo.citationCount = _dictExtraInfo["citationCount"] == null ? string.Empty : _dictExtraInfo["citationCount"].ToString();
                            quotation.extraInfo.referenceDocumentsCount = _dictExtraInfo["referenceDocumentsCount"] == null ? string.Empty : _dictExtraInfo["referenceDocumentsCount"].ToString();
                            quotation.extraInfo.referenceDocumentsList = _dictExtraInfo["referenceDocumentsList"] == null ? string.Empty : _dictExtraInfo["referenceDocumentsList"].ToString();
                            quotation.extraInfo.version = _dictExtraInfo["version"] == null ? string.Empty : _dictExtraInfo["version"].ToString();
                            quotation.extraInfo.doi = _dictExtraInfo["doi"] == null ? string.Empty : _dictExtraInfo["doi"].ToString();
                            quotation.extraInfo.acquisitionNumber = _dictExtraInfo["acquisitionNumber"] == null ? string.Empty : _dictExtraInfo["acquisitionNumber"].ToString();
                            quotation.extraInfo.acquisitionBookNumber = _dictExtraInfo["acquisitionBookNumber"] == null ? string.Empty : _dictExtraInfo["acquisitionBookNumber"].ToString();
                            quotation.extraInfo.displayDate = _dictExtraInfo["displayDate"] == null ? string.Empty : _dictExtraInfo["displayDate"].ToString();
                            quotation.extraInfo.date = _dictExtraInfo["date"] == null ? string.Empty : _dictExtraInfo["date"].ToString();
                            quotation.extraInfo.inspectionDate = _dictExtraInfo["inspectionDate"] == null ? string.Empty : _dictExtraInfo["inspectionDate"].ToString();
                            quotation.extraInfo.modifyDate = _dictExtraInfo["modifyDate"] == null ? string.Empty : _dictExtraInfo["modifyDate"].ToString();
                            quotation.extraInfo.createDate = _dictExtraInfo["createDate"] == null ? string.Empty : _dictExtraInfo["createDate"].ToString();
                            quotation.extraInfo.localPath = _dictExtraInfo["localPath"] == null ? string.Empty : _dictExtraInfo["localPath"].ToString();
                            quotation.extraInfo.email = _dictExtraInfo["email"] == null ? string.Empty : _dictExtraInfo["email"].ToString();
                            quotation.extraInfo.PMID = _dictExtraInfo.Keys.Contains("PMID") && _dictExtraInfo["PMID"] != null ? _dictExtraInfo["PMID"].ToString() : string.Empty;
                            quotation.extraInfo.referenceList = _dictExtraInfo["referenceList"] == null ? string.Empty : _dictExtraInfo["referenceList"].ToString();
                            quotation.extraInfo.clazzId = _dictExtraInfo["clazzId"] == null ? string.Empty : _dictExtraInfo["clazzId"].ToString();
                        }
                       
                        _listQuotation.Add(quotation);
                        _listQuotationOrg.Add(quotation);
                        ucSearchItem uc = new ucSearchItem(quotation);
                        uc.Width = panel1.Width - 30;
                        uc.Location = new Point(0, 125 * _nCount + 10);
                        panel1.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
                        continue;
                    }
                }
                //try
                //{
                //_nCount = _strSum;
                //}
                //catch (Exception ex)
                //{
                //    LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
                //}

                if (_strSum > 30)
                {
                    //if (page*30>_strSum)
                    //{

                    //}
                    //else
                    //{
                        label1.Text = page * 30 + "/" + _strSum.ToString();
                    //}
                }
                else
                {
                    label1.Text = _strSum.ToString() ;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }
        }

        public delegate void InitItemInvoke(string str);

        public void DoWord()
        {
            try
            {
                InitItemInvoke mi = new InitItemInvoke(InitQuotationItems);
                string _strPostData = "{\"conditions\": [" + searchTerms + "],\"paging\": {\"page\": 1,\"size\": 30}}";
                string result = BIMTService.CallPostService(PublicVar.literatureBaseUrl + "/documents/search", _strPostData);
                BeginInvoke(mi, new object[] { result });
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        public void DoPageWord()
        {
            try
            {
                InitItemInvoke mi = new InitItemInvoke(InitQuotationItems);
                string result = BIMTService.CallGetService(PublicVar.literatureBaseUrl + "/documents/search/" + m_strSid + "?pageNo=" + m_nPage, string.Empty, string.Empty, false);
                BeginInvoke(mi, new object[] { result });
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        public void InitQuotationItems(string str)
        {
            pictureBox3.Visible = false;
            btn_query.Enabled = true;
            InitItem(str);
            thread.Abort();
        }

        /// <summary>
        /// 初始化首页数据
        /// wuhailong
        /// 2016-07-01
        /// </summary>
        /// <param name="page"></param>
        public void InitData()
        {
            try
            {

                panel1.Controls.Clear();
                panel1.Controls.Add(pictureBox3);
                pictureBox3.Location = new Point(200, 275);
                pictureBox3.Visible = true;
                thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
                
            }
            catch (Exception ex)
            {
                //throw;
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "InitData" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化第n页数据
        /// </summary>
        /// <param name="page"></param>
        public void InitData(int page)
        {
            try
            {
                m_nPage = page;
                panel1.Controls.Clear();
                panel1.Controls.Add(pictureBox3);
                pictureBox3.Location = new Point(200, 275);
                pictureBox3.Visible = true;
                Thread thread = new Thread(new ThreadStart(DoPageWord));
                thread.Start();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "InitData" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化数据，页码
        /// 2016-05-07
        /// wuhailong
        /// </summary>
        /// <param name="p_strFilter">过滤条件</param>
        /// <param name="page">页码</param>
        public void InitData(string p_strFilter,decimal page)
        {
            try
            {
               
                
                string _strPostData = "{\"conditions\": [" + p_strFilter + "],\"paging\": {\"page\": " + page + ",\"size\": 30}}";
                //string _strPostData = "{\"conditions\": [" + p_strFilter + "],\"paging\": {\"page\": " + page + ",\"size\": 30},\"sorting\": [{\"property\": \"Topic\",\"direction\": \"DESC\"}]}";
                string result = BIMTService.CallPostService(PublicVar.literatureBaseUrl + "/documents/search", _strPostData);
                if (result == "-1")
                {
                    MessageBox.Show(null, "内容太复杂，找不到匹配文献！", "语句匹配");
                }
                InitItem(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }

            //    var quotations = CommonFunction.JsonToDictionary(result);
            //    Dictionary<string, object> _dictMeta = (Dictionary<string, object>)quotations["meta"];
            //    string _strSid = (string)_dictMeta["sid"];
            //    m_strSid = _strSid;
            //    ArrayList _arrayQuotation = (ArrayList)quotations["list"];
            //    int _nCount = 0;
            //    foreach (var item in _arrayQuotation)
            //    {
            //        try
            //        {
            //            Dictionary<string, object> _dictDid = (Dictionary<string, object>)item;
            //            Quotation quotation = new Quotation();
            //            quotation.did = _dictDid["did"] == null ? string.Empty : _dictDid["did"].ToString();

            //            result = BIMTService.CallGetService(PublicVar.BaseUrl + "/documents/" + quotation.did, string.Empty, string.Empty, false);
            //            Dictionary<string, object> _dict = (Dictionary<string, object>)CommonFunction.JsonToDictionary(result);

            //            ArrayList _arrayTitle = (ArrayList)_dict["titles"];
            //            Dictionary<string, object> _dictTitle = (Dictionary<string, object>)_arrayTitle[0];//.ToString();
            //            if (_dictTitle["cn"] != null)
            //            {
            //                quotation.title = _dictTitle["cn"].ToString();
            //            }
            //            else if (_dictTitle["en"] != null)
            //            {
            //                quotation.title = _dictTitle["en"].ToString();
            //            }
            //            //关键词
            //            Dictionary<string, object> _dictKeywords = (Dictionary<string, object>)_dict["keywords"];//.ToString();
            //            if (_dictKeywords["cn"] != null)
            //            {
            //                foreach (var itemKey in (ArrayList)_dictKeywords["cn"])
            //                {
            //                    quotation.keywords += itemKey + ",";
            //                }
            //            }
            //            else if (_dictKeywords["en"] != null)
            //            {
            //                foreach (var itemKey in (ArrayList)_dictKeywords["en"])
            //                {
            //                    quotation.keywords += itemKey + ",";
            //                }
            //            }
            //            quotation.shortTitle = _dict["shortTitle"] == null ? string.Empty : _dict["shortTitle"].ToString();
            //            quotation.otherTitle = _dict["otherTitle"] == null ? string.Empty : _dict["otherTitle"].ToString();
            //            quotation.topics = _dict["topics"] == null ? string.Empty : _dict["topics"].ToString();
            //            //作者
            //            Dictionary<string, object> _listtAuthors = (Dictionary<string, object>)_dict["authors"];
            //            foreach (var authorinfo in (ArrayList)_listtAuthors["names"])
            //            {
            //                Dictionary<string, object> _dictAuthorInfo = (Dictionary<string, object>)authorinfo;

            //                string _strlast = _dictAuthorInfo["last"] == null ? string.Empty : _dictAuthorInfo["last"].ToString();
            //                string _strfore = _dictAuthorInfo["fore"] == null ? string.Empty : _dictAuthorInfo["fore"].ToString();
            //                string _strfull = _dictAuthorInfo["full"] == null ? string.Empty : _dictAuthorInfo["full"].ToString();
            //                Name name = new Name(_strlast, _strfore, _strfull);
            //                string _strOrganizations = string.Empty;
            //                foreach (var organization in (ArrayList)_listtAuthors["organizations"])
            //                { _strOrganizations += organization.ToString(); }

            //                string _strAddresses = string.Empty;
            //                foreach (var addresses in (ArrayList)_listtAuthors["addresses"])
            //                { _strAddresses += addresses.ToString(); }
            //                Author a = new Author(name, _strOrganizations, _strAddresses);

            //                quotation.listAuthor.Add(a);
            //            }
            //            //出版信息
            //            //PublishInfo publishInfo = new PublishInfo();
            //            Dictionary<string, object> _dictPublishInfo = (Dictionary<string, object>)_dict["publishInfo"];
            //            Dictionary<string, object> _dictPeriodicalInfo = (Dictionary<string, object>)_dictPublishInfo["periodicalInfo"];
            //            quotation.publishInfo.periodicalInfo.place = _dictPeriodicalInfo["place"] == null ? string.Empty : _dictPeriodicalInfo["place"].ToString();
            //            quotation.publishInfo.periodicalInfo.press = _dictPeriodicalInfo["press"] == null ? string.Empty : _dictPeriodicalInfo["press"].ToString();
            //            quotation.publishInfo.periodicalInfo.originalPress = _dictPeriodicalInfo["originalPress"] == null ? string.Empty : _dictPeriodicalInfo["originalPress"].ToString();
            //            quotation.publishInfo.periodicalInfo.reprintEdition = _dictPeriodicalInfo["reprintEdition"] == null ? string.Empty : _dictPeriodicalInfo["reprintEdition"].ToString();
            //            quotation.publishInfo.periodicalInfo.ISBNISSN = _dictPeriodicalInfo["ISBN/ISSN"] == null ? string.Empty : _dictPeriodicalInfo["ISBN/ISSN"].ToString();

            //            Dictionary<string, object> _dictPeriodicalInfoName = (Dictionary<string, object>)_dictPeriodicalInfo["name"];
            //            if (_dictPeriodicalInfoName["cn"] != null)
            //            {
            //                quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["cn"].ToString();
            //            }
            //            else if (_dictPeriodicalInfoName["en"] != null)
            //            {
            //                quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["en"].ToString();
            //            }

            //            quotation.publishInfo.publishYear = _dictPublishInfo["publishYear"] == null ? string.Empty : _dictPublishInfo["publishYear"].ToString();
            //            quotation.publishInfo.volumeCount = _dictPublishInfo["volumeCount"] == null ? string.Empty : _dictPublishInfo["volumeCount"].ToString();
            //            quotation.publishInfo.volumeInfo = _dictPublishInfo["volumeInfo"] == null ? string.Empty : _dictPublishInfo["volumeInfo"].ToString();
            //            quotation.publishInfo.issueInfo = _dictPublishInfo["issueInfo"] == null ? string.Empty : _dictPublishInfo["issueInfo"].ToString();
            //            quotation.publishInfo.column = _dictPublishInfo["column"] == null ? string.Empty : _dictPublishInfo["column"].ToString();
            //            quotation.publishInfo.pageRange = _dictPublishInfo["pageRange"] == null ? string.Empty : _dictPublishInfo["pageRange"].ToString();
            //            quotation.publishInfo.wordsCount = _dictPublishInfo["wordsCount"] == null ? string.Empty : _dictPublishInfo["wordsCount"].ToString();
            //            quotation.publishInfo.price = _dictPublishInfo["price"] == null ? string.Empty : _dictPublishInfo["price"].ToString();
            //            Dictionary<string, object> _dictAbstracts = (Dictionary<string, object>)_dict["abstracts"];
            //            if (_dictAbstracts != null && _dictAbstracts["cn"] != null)
            //            {
            //                quotation.abstracts = _dictAbstracts["cn"].ToString();
            //            }
            //            else if (_dictAbstracts != null && _dictAbstracts["en"] != null)
            //            {
            //                quotation.abstracts = _dictAbstracts["en"].ToString();
            //            }

            //            Dictionary<string, object> _dictExtraInfo = (Dictionary<string, object>)_dict["extraInfo"];
            //            if (_dictExtraInfo != null)
            //            {
            //                quotation.extraInfo.bibliographyType = _dictExtraInfo["bibliographyType"] == null ? string.Empty : _dictExtraInfo["bibliographyType"].ToString();
            //                quotation.extraInfo.fundProject = _dictExtraInfo["fundProject"] == null ? string.Empty : _dictExtraInfo["fundProject"].ToString();
            //                quotation.extraInfo.type = _dictExtraInfo["type"] == null ? string.Empty : _dictExtraInfo["type"].ToString();
            //                quotation.extraInfo.subjectClassification = _dictExtraInfo["subjectClassification"] == null ? string.Empty : _dictExtraInfo["subjectClassification"].ToString();
            //                quotation.extraInfo.catagory = _dictExtraInfo["catagory"] == null ? string.Empty : _dictExtraInfo["catagory"].ToString();
            //                quotation.extraInfo.topic = _dictExtraInfo["topic"] == null ? string.Empty : _dictExtraInfo["topic"].ToString();
            //                quotation.extraInfo.titleEntry = _dictExtraInfo["titleEntry"] == null ? string.Empty : _dictExtraInfo["titleEntry"].ToString();
            //                quotation.extraInfo.tags = _dictExtraInfo["tags"] == null ? string.Empty : _dictExtraInfo["tags"].ToString();
            //                quotation.extraInfo.bibTex = _dictExtraInfo["bibTex"] == null ? string.Empty : _dictExtraInfo["bibTex"].ToString();
            //                quotation.extraInfo.auxiliaryAuthors = _dictExtraInfo["auxiliaryAuthors"] == null ? string.Empty : _dictExtraInfo["auxiliaryAuthors"].ToString();
            //                quotation.extraInfo.commentItems = _dictExtraInfo["commentItems"] == null ? string.Empty : _dictExtraInfo["commentItems"].ToString();
            //                quotation.extraInfo.factor = _dictExtraInfo["factor"] == null ? string.Empty : _dictExtraInfo["factor"].ToString();
            //                quotation.extraInfo.includedRange = _dictExtraInfo["includedRange"] == null ? string.Empty : _dictExtraInfo["includedRange"].ToString();
            //                quotation.extraInfo.comments = _dictExtraInfo["comments"] == null ? string.Empty : _dictExtraInfo["comments"].ToString();
            //                quotation.extraInfo.pics = _dictExtraInfo["pics"] == null ? string.Empty : _dictExtraInfo["pics"].ToString();
            //                quotation.extraInfo.dataProvider = _dictExtraInfo["dataProvider"] == null ? string.Empty : _dictExtraInfo["dataProvider"].ToString();
            //                quotation.extraInfo.lang = _dictExtraInfo["lang"] == null ? string.Empty : _dictExtraInfo["lang"].ToString();
            //                quotation.extraInfo.nation = _dictExtraInfo["nation"] == null ? string.Empty : _dictExtraInfo["nation"].ToString();
            //                quotation.extraInfo.citationCount = _dictExtraInfo["citationCount"] == null ? string.Empty : _dictExtraInfo["citationCount"].ToString();
            //                quotation.extraInfo.referenceDocumentsCount = _dictExtraInfo["referenceDocumentsCount"] == null ? string.Empty : _dictExtraInfo["referenceDocumentsCount"].ToString();
            //                quotation.extraInfo.referenceDocumentsList = _dictExtraInfo["referenceDocumentsList"] == null ? string.Empty : _dictExtraInfo["referenceDocumentsList"].ToString();
            //                quotation.extraInfo.version = _dictExtraInfo["version"] == null ? string.Empty : _dictExtraInfo["version"].ToString();
            //                quotation.extraInfo.doi = _dictExtraInfo["doi"] == null ? string.Empty : _dictExtraInfo["doi"].ToString();
            //                quotation.extraInfo.acquisitionNumber = _dictExtraInfo["acquisitionNumber"] == null ? string.Empty : _dictExtraInfo["acquisitionNumber"].ToString();
            //                quotation.extraInfo.acquisitionBookNumber = _dictExtraInfo["acquisitionBookNumber"] == null ? string.Empty : _dictExtraInfo["acquisitionBookNumber"].ToString();
            //                quotation.extraInfo.displayDate = _dictExtraInfo["displayDate"] == null ? string.Empty : _dictExtraInfo["displayDate"].ToString();
            //                quotation.extraInfo.date = _dictExtraInfo["date"] == null ? string.Empty : _dictExtraInfo["date"].ToString();
            //                quotation.extraInfo.inspectionDate = _dictExtraInfo["inspectionDate"] == null ? string.Empty : _dictExtraInfo["inspectionDate"].ToString();
            //                quotation.extraInfo.modifyDate = _dictExtraInfo["modifyDate"] == null ? string.Empty : _dictExtraInfo["modifyDate"].ToString();
            //                quotation.extraInfo.createDate = _dictExtraInfo["createDate"] == null ? string.Empty : _dictExtraInfo["createDate"].ToString();
            //                quotation.extraInfo.localPath = _dictExtraInfo["localPath"] == null ? string.Empty : _dictExtraInfo["localPath"].ToString();
            //                quotation.extraInfo.email = _dictExtraInfo["email"] == null ? string.Empty : _dictExtraInfo["email"].ToString();
            //                quotation.extraInfo.PMID = _dictExtraInfo["PMID"] == null ? string.Empty : _dictExtraInfo["PMID"].ToString();
            //                quotation.extraInfo.referenceList = _dictExtraInfo["referenceList"] == null ? string.Empty : _dictExtraInfo["referenceList"].ToString();
            //                quotation.extraInfo.clazzId = _dictExtraInfo["clazzId"] == null ? string.Empty : _dictExtraInfo["clazzId"].ToString();
            //            }
            //            ucSearchItem uc = new ucSearchItem(quotation);
            //            uc.Width = Width - 80;
            //            uc.Location = new Point(10, 125 * _nCount + 10);
            //            panel1.Controls.Add(uc);
            //            _nCount++;
            //        }
            //        catch (Exception ex)
            //        {
            //            LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            //        }
            //    }
            //    if (_nCount > 1)
            //    {
            //        label1.Text = _nCount + " matches";
            //    }
            //    else
            //    {
            //        label1.Text = _nCount + " match";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            //}
                //-----------------------------------
            //JObject jo = JsonHelper.GetObj(result);
            //string ss = jo["list"][0]["titles"]["cn"].ToString();
            //int _nCount = 0;
            //foreach (var item in jo["list"])
            //{
            //    try
            //    {
            //        string titles = item["titles"]["cn"].ToString();
            //        string keywords = item["keywords"]["en"].ToString();

            //        string organization = item["authors"][0]["organization"].ToString();
            //        string lastname = item["authors"][0]["lastname"].ToString();
            //        string fullname = item["authors"][0]["fullname"].ToString();
            //        string forename = item["authors"][0]["forename"].ToString();

            //        string publishSources = item["publishSources"]["en"].ToString();
            //        string publishIssue = item["publishIssue"].ToString();
            //        string publishYear = item["publishYear"].ToString();
            //        string abstracts = item["abstracts"].ToString();
            //        string extraInfo = item["extraInfo"].ToString();
            //        string did = item["did"].ToString();
            //        string authorJson = item["authors"].ToString();
            //        Quotation quotation = new Quotation();
            //        quotation.SetQuotationContext(
            //            titles, string.Empty, forename + "*" + lastname + "*" + fullname, publishYear, publishSources,
            //           publishSources, publishIssue, string.Empty, string.Empty, string.Empty,
            //            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
            //            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
            //            string.Empty, string.Empty, string.Empty, keywords, abstracts, authorJson);
            //        ucSearchItem uc = new ucSearchItem(quotation);
            //        uc.Width = Width - 80;
            //        uc.Location = new Point(10, 150 * _nCount+10);
            //        panel1.Controls.Add(uc);
            //        _nCount++;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            //    }
            //}
            //label1.Text = quotations["list"]. + " matches";


        }


        private object ValueOfDict(Dictionary<string, object> _dict, string p)
        {
            if (_dict.Keys.Contains(p))
            {
                return _dict[p];
            }
            return null;
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if (m_listUcFilter.Count<2)
            //{
            //    ucFilter uc = new ucFilter();
            //    uc.Location = new Point(20, (m_listUcFilter.Count + 1) * 30 + 10);
            //    this.Controls.Add(uc);
            //    m_listUcFilter.Add(uc);
            //}
            //if (ucFilter1.Visible == false)
            //{
            //    ucFilter1.Visible = true;
            //}
            //else if (ucFilter2.Visible == false)
            //{
            //    ucFilter2.Visible = true;
            //}
            if (_stackUcFilter.Count>0)
            {
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 36);
                panel2.Height = panel2.Height - 36;
                object _obj = _stackUcFilter.Pop();
                _stackUcFilterVisible.Push(_obj);
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (m_listUcFilter.Count - 1>=0)
            //{
            //    ucFilter uc = m_listUcFilter[m_listUcFilter.Count - 1];
            //    m_listUcFilter.Remove(uc);
            //    this.Controls.Remove(uc);
            //}
            //if (ucFilter2.Visible == true)
            //{
            //    ucFilter2.Visible = false;
            //}
            //else if (ucFilter1.Visible == true)
            //{
            //    ucFilter1.Visible = false;
            //}
            if (_stackUcFilterVisible.Count > 0 && _stackUcFilterVisible.Count <= 8)
            {
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 36);
                panel2.Height = panel2.Height + 36;
                object _obj = _stackUcFilterVisible.Pop();
                _stackUcFilter.Push(_obj);
            }
           
        }

        private void ucLiteratureSearch_SizeChanged(object sender, EventArgs e)
        {
            panel2.Height = this.Height - 45;
            panel1.Height = panel2.Height - 37;
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            //panel1.Height = panel1.Height - 83;
        }

        private void ucLiteratureSearch_Load(object sender, EventArgs e)
        {

        }

        public string FormatString(string p_strOP, string p_strKey, string p_strType)
        {
            return "{\"oper\": \"" + p_strOP + "\",\"key\": \"" + p_strKey + "\",\"type\": \"" + p_strType + "\"}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btn_query.Enabled = false;
                page = 1;
                pictureBox3.Location = new Point(panel2.Width / 2 - pictureBox3.Width / 2, panel2.Height / 2 - pictureBox3.Height);
                pictureBox3.Visible = true;

                SetSortStatus();
                Search();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureSearch), ex);
            }
           
        }

        private string searchTerms = string.Empty;
        int m_nPage = 1;
        public void Search()
        {
            try
            {
                string _strFilter = InistFilter();
                if (_strFilter == "{\"oper\": \"AND\",\"key\": \"\",\"type\": \"All\"}")
                {
                    MessageBox.Show(null,"搜索条件不能为空！","文献搜索");
                    pictureBox3.Visible = false;
                    return;
                }
                searchTerms = _strFilter;
                using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
                {
                    ubts.SynDoTrick("文献检索","搜索",searchTerms);
                }
                //PublicVar.userTrick.SynDoTrick("文献检索","搜索",searchTerms);
                InitData();
                //radioButton1.Checked = false;
                //radioButton2.Checked = false;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// 生成过滤条件json字符串
        /// 2016-05-07
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public string InistFilter()
        {
            try
            {
                string _strFilter = FormatString("AND", richTextBox1.Text, ucFilter1.ConvertParam(comboBox1.Text));
                if (richTextBox2.Text != string.Empty)
                {
                    _strFilter += "," + FormatString(ucFilter1.ConvertParam(comboBox2.Text), richTextBox2.Text, ucFilter1.ConvertParam(comboBox3.Text));
                }
                foreach (ucFilter item in _stackUcFilterVisible)
                {
                    if (item.getKey1() != string.Empty)
                    {
                        _strFilter += "," + FormatString(item.getOp1(), item.getKey1(), item.getType1());
                    }

                    if (item.getKey2() != string.Empty)
                    {
                        _strFilter += "," + FormatString(item.getOp2(), item.getKey2(), item.getType2());
                    }
                }
                return _strFilter;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            //panel1.Height = panel2.Height - 37;

        }

        private void domainUpDown2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string _strFilter = InistFilter();
            string result = BIMTService.CallGetService(PublicVar.literatureBaseUrl + "/documents/search/" + m_strSid + "?pageNo=" + numericUpDown1.Value, string.Empty, string.Empty, false);
            //InitData(_strFilter, numericUpDown1.Value);
            InitItem(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = ++numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value>numericUpDown1.Minimum)
            {
                numericUpDown1.Value = --numericUpDown1.Value;
            }
           
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string _strField = ((DomainUpDown)sender).Text;
            int _nKind = 0;
            if (_strField.Contains("↑"))
            {
                _strField = _strField.Replace("↑", string.Empty);
                _nKind = -1;
            }
            else if (_strField.Contains("↓"))
            {
                _strField = _strField.Replace("↓", string.Empty);
                _nKind = 1;
            }
            List<Quotation> _list = SortQuotation(_strField, _nKind);
            InitData(_list);
        }

        /// <summary>
        /// 按照输入条件排列搜索到的文献
        /// </summary>
        /// <param name="p_strSortField">排序字段名称：出版日期；作者；题目；期刊名称</param>
        /// <param name="p_nSortKind">排序方式 小于0降序排 ；大于0升序排列 </param>
        public List<Quotation> SortQuotation(string p_strSortField, int p_nSortKind)
        {
            Quotation temp = null;
            string _strCompareField = string.Empty;
            if ("出版日期" == p_strSortField)
            {
                if (p_nSortKind > 0)
                {
                    for (int i = 0; i < _listQuotation.Count; i++)
                    {
                        for (int j = i; j < _listQuotation.Count; j++)
                        {
                            if (_listQuotation[i].publishInfo.publishYear.CompareTo(_listQuotation[j].publishInfo.publishYear) > 0)
                            {
                                temp = _listQuotation[i];
                                _listQuotation[i] = _listQuotation[j];
                                _listQuotation[j] = temp;
                            }
                        }
                    }
                }
                else if (p_nSortKind < 0)
                {
                    for (int i = 0; i < _listQuotation.Count; i++)
                    {
                        for (int j = i; j < _listQuotation.Count; j++)
                        {
                            if (_listQuotation[i].publishInfo.publishYear.CompareTo(_listQuotation[j].publishInfo.publishYear) < 0)
                            {
                                temp = _listQuotation[i];
                                _listQuotation[i] = _listQuotation[j];
                                _listQuotation[j] = temp;
                            }
                        }
                    }
                }
                return _listQuotation;
            }
            else
            {
                List<Quotation> listQ = new List<Quotation>();
                for (int i = _listQuotationOrg.Count - 1; i >= 0; i--)
                {
                    listQ.Add(_listQuotationOrg[i]);
                }
                _listQuotationOrg = listQ;
                return listQ;
            }
            
        }

            //else if ("作者" == p_strSortField)
            //{
            //    if (p_nSortKind > 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].authors.CompareTo(_listQuotation[j].authors) > 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //    else if (p_nSortKind < 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].authors.CompareTo(_listQuotation[j].authors) < 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //}
            //else if ("题目" == p_strSortField)
            //{
            //    if (p_nSortKind > 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].title.CompareTo(_listQuotation[j].title) > 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //    else if (p_nSortKind < 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].title.CompareTo(_listQuotation[j].title) < 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //}
            //else if ("期刊名称" == p_strSortField)
            //{
            //    if (p_nSortKind > 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].publishInfo.periodicalInfo.name.CompareTo(_listQuotation[j].publishInfo.periodicalInfo.name) > 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //    else if (p_nSortKind < 0)
            //    {
            //        for (int i = 0; i < _listQuotation.Count; i++)
            //        {
            //            for (int j = i; j < _listQuotation.Count; j++)
            //            {
            //                if (_listQuotation[i].publishInfo.periodicalInfo.name.CompareTo(_listQuotation[j].publishInfo.periodicalInfo.name) < 0)
            //                {
            //                    temp = _listQuotation[i];
            //                    _listQuotation[i] = _listQuotation[j];
            //                    _listQuotation[j] = temp;
            //                }
            //            }
            //        }
            //    }
            //}
           
        /// <summary>
        /// 将输入 的 引文list载入 到界面中
        /// </summary>
        /// <param name="p_listQ"></param>
        public void InitData(List<Quotation> p_listQ)
        {
            try
            {
                panel1.Controls.Clear();
                //_listQuotation.Clear();
                int _nCount = 0;
                foreach (Quotation item in p_listQ)
                {
                    try
                    {
                        ucSearchItem uc = new ucSearchItem(item);
                        uc.Width = Width - 65;
                        uc.Location = new Point(10, 125 * _nCount + 10);
                        panel1.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
                    }
                }
                //if (_nCount > 1)
                //{
                //    label1.Text = _nCount + " matches";
                //}
                //else
                //{
                //    label1.Text = _nCount + " match";
                //}

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }
        }


        public List<Quotation> _listQuotation = new List<Quotation>();
        public List<Quotation> _listQuotationOrg = new List<Quotation>();
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                richTextBox2.Focus();
            }
        }

        /// <summary>
        /// 设置搜索的初始化状态；
        /// wuhailong
        /// 2016-07-08
        /// </summary>
        public void SetSortStatus()
        {
            button7.BackgroundImage = Properties.Resources.btn_soucangriqi_huise;
            button7.Tag = -1;

            button6.BackgroundImage = Properties.Resources.btn_soucangriqi_huise;
            button6.Tag = -1;
        }
        int page = 1;
        private void button4_Click(object sender, EventArgs e)
        {
            SetSortStatus();
            //panel1.Controls.Clear();
            //换一批功能 wuhailong 2016-06-03
            ++page;
            if (page>333)
            {
                page %= 333;
            }
           

            string _strFilter = InistFilter();
            searchTerms = _strFilter;
            InitData(page);
            //string result = BIMTService.CallGetService(PublicVar.BaseUrl + "/documents/search/" + m_strSid + "?pageNo=" + page, string.Empty, string.Empty, false);
            ////InitData(_strFilter, numericUpDown1.Value);
            //InitItem(result);
            //radioButton1.Checked = false;
            //radioButton2.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            // if (radioButton2.Checked)
            //{
            //    List<Quotation> _list = SortQuotation("出版日期", -1);
            //    InitData(_list);
            //}
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetSortStatus();
            //换一批功能 wuhailong 2016-06-03
            --page;
            if (page<=1)
            {
                page = 1;
            }
            string _strFilter = InistFilter();
            searchTerms = _strFilter;
            InitData(page);
            
            //string result = BIMTService.CallGetService(PublicVar.BaseUrl + "/documents/search/" + m_strSid + "?pageNo=" + page, string.Empty, string.Empty, false);
            ////InitData(_strFilter, numericUpDown1.Value);
            //InitItem(result);
            //radioButton1.Checked = false;
            //radioButton2.Checked = false;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {//最久出版
            //if (radioButton1.Checked)
            //{
            //    List<Quotation> _list = SortQuotation("出版日期", 1);
            //    InitData(_list);
            //}
        }

        private void rb_search_CheckedChanged(object sender, EventArgs e)
        {//匹配度最高
             if (rb_search.Checked)
            {
                Search();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.BackgroundImage = Properties.Resources.btn_soucangriqi_huise;
            Button btn = sender as Button;
            SetBakImageUp(btn);
            //SortLiteraturePanel(btn);
        }

        private void SortLiteraturePanel(Button btn)
        {
            if (btn.BackgroundImage == Properties.Resources.btn_soucanriqi_up)
            {//最久出版
                List<Quotation> _list = SortQuotation("出版日期", 1);
                InitData(_list);
            }
            else if (btn.BackgroundImage == Properties.Resources.btn_shoucangriqi_down)
            {
                List<Quotation> _list = SortQuotation("出版日期", -1);
                InitData(_list);
            }
        }



        /// <summary>
        /// 设置按钮背景图片
        /// </summary>
        /// <param name="btn"></param>
        private void SetBakImageUp(Button btn)
        {
            int _nFlge = int.Parse(btn.Tag.ToString());
            _nFlge *= -1;
            btn.Tag = _nFlge;
            string _strFilter = btn.Text;
            if (_nFlge > 0)
            {
                btn.BackgroundImage = Properties.Resources.btn_soucanriqi_up;
                //最久出版
                List<Quotation> _list = SortQuotation(_strFilter, 1);
                InitData(_list);
            }
            else if (_nFlge < 0)
            {
                btn.BackgroundImage = Properties.Resources.btn_shoucangriqi_down;
                List<Quotation> _list = SortQuotation(_strFilter, -1);
                InitData(_list);
            }
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.btn_soucangriqi_huise;
            Button btn = sender as Button;
            SetBakImageUp(btn);
            //SortLiteraturePanel(btn);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}
