using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BIMTClassLibrary.Service;
using BIMTClassLibrary.Json;
using Newtonsoft.Json.Linq;
using  Log4Net;
using System.Threading;
namespace BIMTClassLibrary
{
    public partial class ucLiteratureRecommend : UserControl
    {
        private static ucLiteratureRecommend m_ucLiteratureSearch = null;
        private Dictionary<string, ucFilter> m_dictUcFilter = new Dictionary<string, ucFilter>();
        private List<ucFilter> m_listUcFilter= new List<ucFilter>();
        private List<Quotation> _listQuotation = new List<Quotation>();
        private string searchText = string.Empty;
        private string p;
        public ucLiteratureRecommend()
        {
            InitializeComponent();
        }

        public ucLiteratureRecommend(string _searchText)
        {
            InitializeComponent();
            searchText = _searchText;
        }

        public static ucLiteratureRecommend GetInstance()
        {
            if (m_ucLiteratureSearch ==null)
            {
                m_ucLiteratureSearch = new ucLiteratureRecommend();
            }
            return m_ucLiteratureSearch;
        }

        public delegate void InitItemInvoke(string str);

        public void DoWord()
        {
            try
            {
                InitItemInvoke mi = new InitItemInvoke(InitQuotationItems);
                RecommendDataEntity rd = new RecommendDataEntity(searchText, 50);
                string _strPostData = rd.ToString();// "{\"words\": \"" + m_strSelectText.Replace("/r",string.Empty) + "\",\"docAmount\": 50}";
                string result = BIMTService.CallPostService(PublicVar.literatureBaseUrl + "/documents/analysis/recommandDocs", _strPostData);
                BeginInvoke(mi, new object[] { result });
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        public void InitQuotationItems(string str)
        {
            try
            {
                string result = str;
                if (result == "-1")
                {
                    MessageBox.Show(null, "内容太复杂，找不到匹配文献！", "语句匹配");
                }
                pictureBox1.Visible = false;
                var quotations = CommonFunction.JsonToDictionary(result);
                int docCount = (int)((Dictionary<string, object>)quotations["meta"])["docCount"];
                ArrayList _arrayQuotation = (ArrayList)quotations["list"];
                Dictionary<string, object> _dictMeta = (Dictionary<string, object>)quotations["meta"];
                int _nCount = 0;
                foreach (var item in _arrayQuotation)
                {
                    try
                    {
                        Dictionary<string, object> _dict = (Dictionary<string, object>)item;
                        Quotation quotation = new Quotation();
                        quotation.did = _dict["did"] == null ? string.Empty : _dict["did"].ToString();
                        quotation.online = _dict["online"] == null ? string.Empty : _dict["online"].ToString();

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
                            _strAuthors += a.ToString() + ",";
                            quotation.listAuthor.Add(a);
                        }
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
                        if (_dictPeriodicalInfoName != null && _dictPeriodicalInfoName["cn"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["cn"].ToString();
                        }
                        else if (_dictPeriodicalInfoName != null && _dictPeriodicalInfoName["en"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.name = _dictPeriodicalInfoName["en"].ToString();
                        }
                        //期刊简写
                        Dictionary<string, object> _dictPeriodicalInfoNameAbbr = (Dictionary<string, object>)_dictPeriodicalInfo["nameAbbr"];
                        if (_dictPeriodicalInfoNameAbbr != null && _dictPeriodicalInfoNameAbbr["en"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.nameAbbr = _dictPeriodicalInfoNameAbbr["en"].ToString();
                        }
                        else if (_dictPeriodicalInfoNameAbbr != null && _dictPeriodicalInfoNameAbbr["cn"] != null)
                        {
                            quotation.publishInfo.periodicalInfo.nameAbbr = _dictPeriodicalInfoNameAbbr["cn"].ToString();
                        }


                        quotation.publishInfo.publishYear = _dictPublishInfo["publishYear"] == null ? string.Empty : _dictPublishInfo["publishYear"].ToString();
                        quotation.publishInfo.volumeCount = _dictPublishInfo["volumeCount"] == null ? string.Empty : _dictPublishInfo["volumeCount"].ToString();
                        quotation.publishInfo.volumeInfo = _dictPublishInfo["volumeInfo"] == null ? string.Empty : _dictPublishInfo["volumeInfo"].ToString();
                        quotation.publishInfo.issueInfo = _dictPublishInfo["issueInfo"] == null ? string.Empty : _dictPublishInfo["issueInfo"].ToString();
                        quotation.publishInfo.column = _dictPublishInfo["column"] == null ? string.Empty : _dictPublishInfo["column"].ToString();
                        quotation.publishInfo.pageRange = _dictPublishInfo["pageRange"] == null ? string.Empty : _dictPublishInfo["pageRange"].ToString();
                        quotation.publishInfo.wordsCount = _dictPublishInfo["wordsCount"] == null ? string.Empty : _dictPublishInfo["wordsCount"].ToString();
                        quotation.publishInfo.price = _dictPublishInfo["price"] == null ? string.Empty : _dictPublishInfo["price"].ToString();
                       
                        //其他信息没有就不要赋值啦，2016-06-02 wuhailong
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
                            quotation.extraInfo.PMID = _dictExtraInfo["PMID"] == null ? string.Empty : _dictExtraInfo["PMID"].ToString();
                            quotation.extraInfo.referenceList = _dictExtraInfo["referenceList"] == null ? string.Empty : _dictExtraInfo["referenceList"].ToString();
                            quotation.extraInfo.clazzId = _dictExtraInfo["clazzId"] == null ? string.Empty : _dictExtraInfo["clazzId"].ToString();
                        }
                        //无作者的无用文献不显示 wuhailong 2016-05-30
                        if (quotation.listAuthor.Count == 0)
                        {
                            continue;
                        }
                        _listQuotation.Add(quotation);
                        ucSearchItem uc = new ucSearchItem(quotation);
                        uc.Width = Width - 45;
                        uc.Location = new Point(10, 125 * _nCount + 10);
                        panel1.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
                    }
                }

                if (docCount > 1)
                {
                    label1.Text = docCount + " matches";
                }
                else
                {
                    label1.Text = docCount + " match";
                }
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }
       
        }


        public void InitData()
        {
            try
            {
                InitData(searchText);

                using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
                {
                    ubts.SynDoTrick("语句匹配", "搜索", searchText);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

        /// <summary>
        /// 初始化信息
        /// wuhailong
        /// 2016-05-10
        /// </summary>
        /// <param name="p_strFilter"></param>
        public void InitData(string p_strFilter)
        {
            try
            {

                Thread thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
                
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }
           
           
        }

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
                foreach (Quotation item in _listQuotation)
                {
                    try
                    {
                        ucSearchItem uc = new ucSearchItem(item);
                        uc.Width = Width - 45;
                        uc.Location = new Point(10, 125 * _nCount + 10);
                        panel1.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
                    }
                }
                if (_nCount > 1)
                {
                    label1.Text = _nCount + " matches";
                }
                else
                {
                    label1.Text = _nCount + " match";
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(ucLiteratureRecommend), ex);
            }
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

            }
            else if ("作者" == p_strSortField)
            {
                if (p_nSortKind > 0)
                {
                    for (int i = 0; i < _listQuotation.Count; i++)
                    {
                        for (int j = i; j < _listQuotation.Count; j++)
                        {
                            if (_listQuotation[i].authors.CompareTo(_listQuotation[j].authors) > 0)
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
                            if (_listQuotation[i].authors.CompareTo(_listQuotation[j].authors) < 0)
                            {
                                temp = _listQuotation[i];
                                _listQuotation[i] = _listQuotation[j];
                                _listQuotation[j] = temp;
                            }
                        }
                    }
                }
            }
            else if ("题目" == p_strSortField)
            {
                if (p_nSortKind > 0)
                {
                    for (int i = 0; i < _listQuotation.Count; i++)
                    {
                        for (int j = i; j < _listQuotation.Count; j++)
                        {
                            if (_listQuotation[i].title.CompareTo(_listQuotation[j].title) > 0)
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
                            if (_listQuotation[i].title.CompareTo(_listQuotation[j].title) < 0)
                            {
                                temp = _listQuotation[i];
                                _listQuotation[i] = _listQuotation[j];
                                _listQuotation[j] = temp;
                            }
                        }
                    }
                }
            }
            else if ("期刊名称" == p_strSortField)
            {
                if (p_nSortKind > 0)
                {
                    for (int i = 0; i < _listQuotation.Count; i++)
                    {
                        for (int j = i; j < _listQuotation.Count; j++)
                        {
                            if (_listQuotation[i].publishInfo.periodicalInfo.name.CompareTo(_listQuotation[j].publishInfo.periodicalInfo.name) > 0)
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
                            if (_listQuotation[i].publishInfo.periodicalInfo.name.CompareTo(_listQuotation[j].publishInfo.periodicalInfo.name) < 0)
                            {
                                temp = _listQuotation[i];
                                _listQuotation[i] = _listQuotation[j];
                                _listQuotation[j] = temp;
                            }
                        }
                    }
                }
            }
            return _listQuotation;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (m_listUcFilter.Count<2)
            {
                ucFilter uc = new ucFilter();
                uc.Location = new Point(20, (m_listUcFilter.Count + 1) * 30 + 10);
                this.Controls.Add(uc);
                m_listUcFilter.Add(uc);
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (m_listUcFilter.Count - 1>=0)
            {
                ucFilter uc = m_listUcFilter[m_listUcFilter.Count - 1];
                m_listUcFilter.Remove(uc);
                this.Controls.Remove(uc);
            }
           
        }

        private void ucLiteratureSearch_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.Height - 40;
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = panel1.Height - 116;
        }

        private void ucLiteratureSearch_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            InitData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="▼标题")
            {
                button1.Text = "▲标题";
            }
            else
            {
                button1.Text = "▼标题";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                List<Quotation> _list = SortQuotation("出版日期", 1);
                InitData(_list);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//降序
            if (radioButton2.Checked)
            {
                List<Quotation> _list = SortQuotation("出版日期", -1);
                InitData(_list);
            }
        }

        
    }
}
