using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BIMTClassLibrary.Service;
using System.Collections;
using System.IO;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.response;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;
namespace BIMTClassLibrary
{
    public partial class ucReviewerRecommand : UserControl, IBaseControl
    {
        private string keyWord;
        private const int size = 20;
        DataTable _dtReviwer = new DataTable();
        public ucReviewerRecommand()
        {
            InitializeComponent();
            //this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
        }

        public ucReviewerRecommand(string _strKeyWord)
        {
            InitializeComponent();
            this.keyWord = _strKeyWord;
            pageNo = 1;
            _dtReviwer.Columns.Add("author");
            _dtReviwer.Columns.Add("email");
            _dtReviwer.Columns.Add("orag");
            _dtReviwer.Columns.Add("recommand");
            _dtReviwer.Columns.Add("norecommand");
            InitData();
           
        }



        public void InitData()
        {
            try
            {
                pb_loading.Visible = true;
                _dtReviwer.Rows.Clear();
                dataGridView1.DataSource = _dtReviwer.DefaultView;
                Thread thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
                //DoWord();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucMagazineRecomand), ex.Message);
            }
        }

        public delegate void InitItemInvoke(string str);

        public void DoWord()
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    
                    InitItemInvoke mi = new InitItemInvoke(InitReviewerItems);
                    string url = PublicVar.recommandBaseUrl + "/reader/recReader";
                    //string postData = "{"
                    //                    + "\"userId\": \"用户ID\","
                    //                    + "\"title\": \"论文标题\","
                    //                    + "\"keywords\": [\""
                    //                    + _strKeyWord
                    //                    + "\"],"
                    //                    + "\"abstr\": \"摘要内容\""
                    //                    + "}";
                    string postData = "{"
                                    + "\"keywords\": [\"" + keyWord + "\"],"
                                    + "\"paging\": {"
                                    + "\"page\": "+pageNo+","
                                    + "\"size\": " + size + ""
                                    + "},"
                                    + "\"sortting\": {"
                                    + "\"property\": \"author\","
                                    + "\"direction\": \"desc\""
                                    +"}"
                                    +"}";
                    string header = string.Empty;
                    //string result = BIMTService.CallPostService(PublicVar.m_strRecomandBaseURL + "/reader/recReader", _strPostData);
                    string result = new RestHelper(url, postData, header).SendPost();
                    BeginInvoke(mi, new object[] { result });
                }
                //}
                //string header = string.Empty;
                ////string result = BIMTService.CallPostService(PublicVar.m_strRecomandBaseURL + "/reader/recReader", _strPostData);
                //string result = new RestHelper(url, postData, header).SendPost();
                //BeginInvoke(mi, new object[] { result });
                //InitReviewerItems(result);
                //}
                //else
                //{
                //    //ucReviewerRecommand uc = new ucReviewerRecommand();
                //    //uc.be
                //}
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        public static ArrayList listKeyword = null;

        public void InitReviewerItems(string result)
        {
            try
            {
                pb_loading.Visible = false;
                
                bool ok = new ResponseState().GetResponseState(result);//.GetResponse(result);
                //string result = ResponseState;
                if (!ok)
                {
                    MessageBox.Show(null, "未查找到适合审稿人", "审稿人推荐");
                }
                else
                {
                    var quotations = CommonFunction.JsonToDictionary(result);
                    Dictionary<string, object> response = (Dictionary<string, object>)quotations["response"];
                    Dictionary<string, object> magazine = (Dictionary<string, object>)response;// quotations["response"];
                    ArrayList _arrayQuotation = (ArrayList)response["list"];
                    listKeyword = (ArrayList)response["meta"];
                    lab_author_count.Text = response["count"].ToString();
                    sumCount = int.Parse(lab_author_count.Text);
                    lab_pageRange.Text = ((pageNo - 1) * size + 1) + "-" + pageNo * size;
                  
                    foreach (var item in _arrayQuotation)
                    {
                        try
                        {
                            Dictionary<string, object> _dict = (Dictionary<string, object>)item;
                            //Magazine _magazin = new Magazine(_dict["name"].ToString(), _dict["level"].ToString(), _dict["impactFactor"].ToString(), float.Parse(_dict["relevance"].ToString()));
                            ////ucMagazinItem uc = new ucMagazinItem(_magazin);
                            //uc.Width = Width - 45;
                            //uc.Location = new Point(10, 125 * _nCount + 10);
                            //this.Controls.Add(uc);
                            //_nCount++;
                            _dtReviwer.Rows.Add(_dict["name"].ToString(), _dict["email"].ToString(), _dict["orgnization"].ToString(), false, false);
                        }
                        catch (Exception ex)
                        {
                            Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord Item" + ex.Message);
                        }
                    }
                    dataGridView1.DataSource = _dtReviwer.DefaultView;
                }
               
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "InitMagazinItems" + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ExportTxt();
            SendReviewerInfo();
        }

        private void SendReviewerInfo()
        {
            try
            {
                List<ReviewerInfo> list = new List<ReviewerInfo>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string author = item.Cells["author"].Value.ToString();
                    string email = item.Cells["email"].Value.ToString();
                    string orag = item.Cells["orag"].Value.ToString();
                    string status = string.Empty;
                    if (item.Cells["recommand"].Value.ToString().ToUpper() == "TRUE")
                    {
                        status = "TRUE";
                    }else if (item.Cells["norecommand"].Value.ToString().ToUpper() == "TRUE")
                    {
                        status = "FALSE";
                    }
                    else
                    {
                        continue;
                    }
                    ReviewerInfo ri = new ReviewerInfo(author, email, orag, status);
                    list.Add(ri);
                }
                ReviewerPostEntity rpe = new ReviewerPostEntity(User.GetInstance().Key.id, string.Empty, string.Empty, keyWord, list, DateTime.Now.ToString());
                string url = PublicVar.recommandBaseUrl + "/reader/save";
                string postData = rpe.ToString();
                string header = string.Empty;
                string res = new RestHelper(url, postData, header).SendPost();
                bool ok = new ResponseState().GetResponseState(res);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucReviewerRecommand), ex);
            }
        }

        /// <summary>
        /// 将选中结果导出为txt文件
        /// 2016-07-12
        /// wuhailong
        /// </summary>
        private void ExportTxt()
        {
            try
            {
                if (DialogResult.OK == sfd_file.ShowDialog())
                {
                    string _strContent = string.Empty;
                    StreamWriter sw = new StreamWriter(sfd_file.FileName);
                    sw.WriteLine("推荐审稿人：");
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (item.Cells["recommand"].Value.ToString().ToUpper() == "TRUE")
                        {
                            _strContent = "作者:" + item.Cells["author"].Value.ToString().PadLeft(30) + "\t 邮箱：" + item.Cells["email"].Value.ToString().PadLeft(40);
                            sw.WriteLine(_strContent);
                        }
                    }
                    sw.WriteLine("=".PadLeft(88, '='));
                    sw.WriteLine("回避审稿人：");
                    _strContent = string.Empty;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {//email
                        if (item.Cells["norecommand"].Value.ToString().ToUpper() == "TRUE")
                        {
                            _strContent = "作者:" + item.Cells["author"].Value.ToString().PadLeft(30) + "\t 邮箱：" + item.Cells["email"].Value.ToString().PadLeft(40);
                            sw.WriteLine(_strContent);
                        }
                    }
                    //sw.Write(_strContent);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucReviewerRecommand), "ExportTxt" + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells[0].ColumnIndex==3)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                if (dataGridView1.Rows[rowIndex].Cells["recommand"].Value.ToString().ToUpper() == "TRUE")
                {
                    dataGridView1.Rows[rowIndex].Cells["recommand"].Value = false;
                    //dataGridView1.Rows[rowIndex].Cells["norecommand"].Value = true;
                }
                else
                {
                    //dataGridView1.CurrentRow.Cells["recommand"].Value = true;
                    dataGridView1.Rows[rowIndex].Cells["norecommand"].Value = false;
                }
            }
            if (dataGridView1.SelectedCells[0].ColumnIndex == 4)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                if (dataGridView1.Rows[rowIndex].Cells["norecommand"].Value.ToString().ToUpper() == "TRUE")
                {
                    dataGridView1.Rows[rowIndex].Cells["norecommand"].Value = false;
                    //dataGridView1.Rows[rowIndex].Cells["recommand"].Value = true;
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Cells["recommand"].Value = false;
                    //dataGridView1.CurrentRow.Cells["norecommand"].Value = true;
                }
            }
            if (dataGridView1.SelectedCells[0].ColumnIndex == 0)
            {//单机专家姓名弹出，专家论文信息
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                GetExpertPapers(dataGridView1.SelectedCells[0].Value.ToString());
            }
        }

        /// <summary>
        /// 获取专家的论文
        /// wuhailong
        /// 2016-07-15
        /// </summary>
        public void GetExpertPapers(string _strAuthor)
        {
            try
            {
                List<SortType> listSort = new List<SortType>();
                SortType st = new SortType();
                listSort.Add(st);

                List<Condition> listCon = new List<Condition>();
                Condition cAuthor = new Condition("AND",_strAuthor,"Author");
                string _strKeywords = string.Empty;
                foreach (string item in listKeyword)
                {
                    _strKeywords += item+"|";
                }
                listCon.Add(cAuthor);
                Condition cKeywords = new Condition("AND", _strKeywords, "Topic");
                listCon.Add(cKeywords);
                PageInfo pi = new PageInfo();
                DocumentSearchEntity dse = new DocumentSearchEntity(listSort, pi, listCon);
                string url = PublicVar.recommandBaseUrl + "/documents/search";
                string postData = dse.ToString();
                string header = string.Empty;
                string result = new RestHelper(url, postData, header).SendPost();// BIMTService.CallPostService(PublicVar.recommandBaseUrl + "/documents/search", postData);
                    //"{"
                    //                + "\"conditions\": [{"
                    //                + "\"oper\": \"AND\","
                    //                + "\"key\": \"" + _strAuthor + "\","
                    //                + "\"type\": \"Author\""
                    //                + "}],"
                    //                + "\"paging\": {"
                    //                + "\"page\": 1,"
                    //                + "\"size\": 10"
                    //                + "},"
                    //                + "\"sorting\": [{"
                    //                + "\"property\": \"Time\","
                    //                + "\"direction\": \"DESC\""
                    //                + "}]"
                    //                + "}";
                //string result = BIMTService.CallPostService(PublicVar.recommandBaseUrl + "/documents/search", _strPostData);
                var quotations = CommonFunction.JsonToDictionary(result);
                //ArrayList _arrayPapers = (ArrayList)
                Dictionary<string, object> _dictresponse = (Dictionary<string, object>)quotations["response"];
                ArrayList _arrayPapers = (ArrayList)_dictresponse["list"];
                frmExpertPaperInfo frm = new frmExpertPaperInfo();
                int _nCount = 0;
                foreach (var item in _arrayPapers)
                {

                    Dictionary<string, object> _dictPaper = (Dictionary<string, object>)item;
                    //标题
                    string _strTitle = string.Empty;
                    Dictionary<string, object> _dictTitle = (Dictionary<string, object>)_dictPaper["title"];//.ToString();
                    if (_dictTitle["cn"] != null)
                    {
                        _strTitle = _dictTitle["cn"].ToString();
                    }
                    else if (_dictTitle["en"] != null)
                    {
                        _strTitle = _dictTitle["en"].ToString();
                    }
                    //出版社
                    string _strPubSource = string.Empty;// _dictPaper["did"].ToString();
                    Dictionary<string, object> _dictPubSource = (Dictionary<string, object>)_dictPaper["publishSources"];//.ToString();
                    if (_dictPubSource["cn"] != null)
                    {
                        _strPubSource = _dictPubSource["cn"].ToString();
                    }
                    else if (_dictPubSource["en"] != null)
                    {
                        _strPubSource = _dictPubSource["en"].ToString();
                    }
                    //出版日期
                    string _strPubDate = _dictPaper["publishDate"] == null ? string.Empty : _dictPaper["publishDate"].ToString();
                    //DOI
                    string _strDOI = _dictPaper["doi"] == null ? string.Empty : _dictPaper["doi"].ToString();
                    //摘要
                    string _strAbs = _dictPaper["abstr"] == null ? string.Empty : _dictPaper["abstr"].ToString();

                    string docurl = _dictPaper["url"] == null ? string.Empty : _dictPaper["url"].ToString();
                    bool urlType = _dictPaper["urlType"] == null ? false: (bool)_dictPaper["urlType"];
                    ExpertPaper ep = new ExpertPaper(_strTitle, _strPubSource, _strPubDate, _strDOI, _strAbs, docurl, urlType);
                    ucExpertPaperiItem uc = new ucExpertPaperiItem(ep);
                    uc.Location = new Point(5, 15 + 230 * _nCount);
                    frm.Controls.Add(uc);
                    _nCount++;
                }
                frm.ShowDialog();
                
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucReviewerRecommand), ex.Message);
            }
        }

        public void ucReviewerRecommand_Load(object sender, EventArgs e)
        {
            
            InitData();
        }


        private int _pageNo;
        public int pageNo
        {
            get
            {
                return _pageNo;
            }
            set
            {
                if (value <= 0)
                    _pageNo = 1;
                else if (value > sumCount / size)
                    _pageNo = sumCount / size + 1;
                else
                    _pageNo = value;
            }
        }

        private void btn_pageup_Click(object sender, EventArgs e)
        {
            try
            {
                --pageNo;
                InitData();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucReviewerRecommand), ex);
            }
          
        }

        private void btn_pagedown_Click(object sender, EventArgs e)
        {
            try
            {
                ++pageNo;
                InitData();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucReviewerRecommand), ex);
            }
            
        }

        private int _sumCount;
        public int sumCount
        {
            get
            {
                if (_sumCount<=0)
                {
                    return size;
                }
                return _sumCount;
            }
            set
            {
                if (value <= 0)
                {
                    _sumCount = size;
                }
                else
                {
                    _sumCount = value;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
