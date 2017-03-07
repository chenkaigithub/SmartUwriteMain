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

namespace BIMTClassLibrary
{
    public partial class ucMagazineRecomand : UserControl, IBaseControl
    {
        private string _strKeyWord;

        public ucMagazineRecomand()
        {
            InitializeComponent();
        }

        public ucMagazineRecomand(string _strKeyWord)
        {
            InitializeComponent();
            this._strKeyWord = _strKeyWord;
            InitData();
        }

        public void InitData()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
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
                InitItemInvoke mi = new InitItemInvoke(InitMagazinItems);
                string _strPostData = "{"
                                    + "\"userId\": \"用户ID\","
                                    + "\"title\": \"论文标题\","
                                    + "\"keywords\": [\"" + _strKeyWord + "\"],"
                                    + "\"abstr\": \"摘要内容\","
                                    + "\"channel\": \"writeaid\","
                                    + "\"paging\": {"
                                    + "\"page\": "+page+","
                                    + "\"size\": 10"
                                    + "},"
                                    + "\"sorting\": {"
                                    + "\"property\": \"relevance\","
                                    + "\"direction\": \"DESC\""
                                    + "}"
                                    + "}";
                string result = BIMTService.CallPostService(PublicVar.recommandBaseUrl + "/journals/recJournals", _strPostData);
                BeginInvoke(mi, new object[] { result });
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord" + ex.Message);
            }
        }

        System.Int32 _nSum = 0;
        public void InitMagazinItems(string str)
        {

            try
            {
                string result = str;
                this.splitContainer1.Panel2.Controls.Clear();
                if (result == "-1")
                {
                    MessageBox.Show(null, "未查找到匹配期刊", "期刊推荐");
                }
                var quotations = CommonFunction.JsonToDictionary(result);
                //Dictionary<string, object> _dictCount = (Dictionary<string, object>)quotations["count"];
                Dictionary<string, object> _dictMagazine = (Dictionary<string, object>)quotations["response"];
                ArrayList _arrayQuotation = (ArrayList)_dictMagazine["list"];
                _nSum = (System.Int32)_dictMagazine["count"];
                this.listQuotation = _arrayQuotation;
                lab_page.Text = (page - 1) * 10+1 + "-" + page * 10;
                lab_count.Text = "共" + _nSum + "条";
                int _nCount = 0;
                foreach (var item in _arrayQuotation)
                {
                    try
                    {

                        Dictionary<string, object> dict = (Dictionary<string, object>)item;
                        Magazine _magazin = new Magazine(
                            dict["id"] == null ? string.Empty : dict["id"].ToString(),
                            dict["name"] == null ? string.Empty : dict["name"].ToString(),
                            dict["level"] == null ? string.Empty : dict["level"].ToString(),
                            dict["impactFactor"] == null ? string.Empty : dict["impactFactor"].ToString(),
                            float.Parse(dict["relevance"] == null ? "0" : dict["relevance"].ToString()),
                            bool.Parse(dict["isCol"] == null ? "false" : dict["isCol"].ToString())
                            );
                        ucMagazinItem uc = new ucMagazinItem(_magazin);
                        uc.Width = Width - 45;
                        uc.Location = new Point(10, 125 * _nCount + 10);
                        this.splitContainer1.Panel2.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord Item" + ex.Message);
                    }
                }
                //page++;
            }
            catch (Exception ex)
            {

                Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "InitMagazinItems" + ex.Message);
            }
        }


        private int page = 1;
        public void PageDown()
        {
            try
            {
                ++page;
                if ((page - 1) * 10 > _nSum)
                {
                    --page;
                    return;
                }
               
                this.splitContainer1.Panel2.Controls.Clear();
                lab_page.Text = (page - 1) * 10+1 + "-" + page * 10;
                InitData();//
                return;

                lab_count.Text = "共" + listQuotation.Count + "条";
                int _nCount = 0;
                foreach (var item in listQuotation)
                {
                    try
                    {
                        if (_nCount < (page - 1) * 10)
                        {
                            _nCount++;
                            continue;
                        }
                        if (_nCount > page * 10)
                        {
                            break;
                        }
                        Dictionary<string, object> _dict = (Dictionary<string, object>)item;
                        Magazine _magazin = new Magazine(_dict["id"].ToString(),_dict["name"].ToString(), _dict["level"].ToString(), _dict["impactFactor"].ToString(), float.Parse(_dict["relevance"].ToString()), bool.Parse(_dict["isCol"].ToString()));
                        ucMagazinItem uc = new ucMagazinItem(_magazin);
                        uc.Width = Width - 45;
                        uc.Location = new Point(10, 125 * ((_nCount - (page - 1) * 10) - 1) + 10);
                        this.splitContainer1.Panel2.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord Item" + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void PageUp()
        {
            try
            {
                --page;
                if (page <= 0)
                {
                    ++page;
                    return;
                }
                this.splitContainer1.Panel2.Controls.Clear();
                lab_page.Text = (page - 1) * 10 + 1 + "-" + page * 10;
                InitData();
                return;


                int _nCount = 0;
                foreach (var item in listQuotation)
                {
                    try
                    {
                        if (_nCount <= (page - 1) * 10)
                        {
                            _nCount++;
                            continue;
                        }
                        if (_nCount > page * 10)
                        {
                            break;
                        }
                        Dictionary<string, object> _dict = (Dictionary<string, object>)item;
                        Magazine _magazin = new Magazine(_dict["id"].ToString(),_dict["name"].ToString(), _dict["level"].ToString(), _dict["impactFactor"].ToString(), float.Parse(_dict["relevance"].ToString()), bool.Parse(_dict["isCol"].ToString()));
                        ucMagazinItem uc = new ucMagazinItem(_magazin);
                        uc.Width = Width - 45;
                        uc.Location = new Point(10, 125 * ((_nCount - (page - 1) * 10) - 1) + 10);
                        this.splitContainer1.Panel2.Controls.Add(uc);
                        _nCount++;
                    }
                    catch (Exception ex)
                    {
                        Log4Net.LogHelper.WriteLog(typeof(ucLiteratureRecommend), "DoWord Item" + ex.Message);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                PageUp();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucMagazineRecomand), ex);
            }
     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                PageDown();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucMagazineRecomand), ex);
            }
        }

        public ArrayList listQuotation { get; set; }
    }
}
