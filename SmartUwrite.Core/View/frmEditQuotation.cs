using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMTClassLibrary.DBF;
using Log4Net;

namespace BIMTClassLibrary
{
    public partial class frmEditQuotation : Form
    {
        Dictionary<string, string> _dictDisplay = new Dictionary<string, string>();
        string[] arrayField =new string[]{"英文标题","中文标题"};
        //string[,] _array =new string[,] { { "title", "标题" }, { "title_type", "题录类型" }, { "author", "作者" }, { "pub_year", "出版年" }, { "pub_place", "出版地" },
        //                   { "pub_er", "出版者" }, { "juan", "卷" }, { "qi", "期" }, { "page_range", "页码范围" }, { "doi", "DOI" }, { "country", "国家和地区" },
        //                   { "pub_date", "出版日期" }, { "se_person", "第二责任人" }, { "version", "版本" }, { "issn", "ISSN" }, { "pri_time", "印次" },
        //                   { "author_eng", "作者英译" }, { "title_eng", "标题英译" }, { "puber_eng", "出版商英译" }, { "coun_eng", "国家英译" }, { "palce_eng", "出版地英译" },
        //                   { "ver_eng", "版本英译" }, { "ref_date", "引用日期" }, { "key_words", "关键词" }, { "outline", "引用日期" },{"create_date","收藏日期"},{"class","类别"},{"author_json","作者集合"} };
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn author;
        private string literatureId;
       
        public frmEditQuotation()
        {
            
            InitializeComponent();
            InitLiteratureInfo();
        }

        public frmEditQuotation(DataGridViewTextBoxColumn title, DataGridViewTextBoxColumn author)
        {
            InitializeComponent();
            this.title = title;
            this.author = author;
            InitLiteratureInfo();
        }

     

        public frmEditQuotation(string literatureId)
        {
            InitializeComponent();
            this.literatureId = literatureId;
            InitLiteratureInfo();
        }

        /// <summary>
        /// 是否为新的文献,加入为就问下你
        /// </summary>
        /// <param name="newLiterature">新文献为true </param>
        /// <param name="literatureId">文献id</param>
        public frmEditQuotation(bool newLiterature, string literatureId)
        {

            InitializeComponent();
            this.literatureId = literatureId;
            string _strSQL = string.Empty;
            if (!newLiterature)
            {
                InitLiteratureInfo();
            }
            else
            {
                InitEmptyLiterature();
            }
        }

        /// <summary>
        /// 创建一个指定类别的新文献
        /// </summary>
        /// <param name="p">true 新文献</param>
        /// <param name="literatureId">文献id</param>
        /// <param name="_strClass">类别名称</param>
        public frmEditQuotation(bool newLiterature, string literatureId, string _strClass)
        {
            InitializeComponent();
            this.literatureId = literatureId;
            if (!newLiterature)
            {
                InitLiteratureInfo();
            }
            else
            {
                InitEmptyLiterature(_strClass);
            }
        }

        private void InitEmptyLiterature(string _strClass)
        {
            //DataTable _dt = new DataTable();
            //_dt.Columns.Add("key");
            //_dt.Columns.Add("value");
            //for (int i = 0; i < _array.Length / 2; i++)
            //{
            //    if (_array[i, 1]=="类别")
            //    {
            //        _dt.Rows.Add(_array[i, 1], _strClass);
            //    }
            //    else
            //    {
            //        _dt.Rows.Add(_array[i, 1], string.Empty);
            //    }
                
            //}
            //dataGridView1.DataSource = _dt.DefaultView;
            try
            {
                DataTable _dt = new DataTable();
                _dt.Columns.Add("key");
                _dt.Columns.Add("value");
                DataSet _ds = LocalDBHelper.ExcuteQuery("select * from literature where 1=0");
                foreach (DataColumn item in _ds.Tables[0].Columns)
                {
                    if (item.Caption == "CLASS_ID")
                    {
                        _dt.Rows.Add(item.Caption, _strClass);
                    }
                    else
                    {
                        _dt.Rows.Add(item.Caption, string.Empty);
                    }
                }
                dataGridView1.DataSource = _dt.DefaultView;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmEditQuotation), ex);
            }
        }

        /// <summary>
        /// 初始化空的文献
        /// 2016-04-16
        /// wuhailong
        /// </summary>
        private void InitEmptyLiterature()
        {
            try
            {
                DataTable _dt = new DataTable();
                _dt.Columns.Add("key");
                _dt.Columns.Add("value");
                DataSet _ds = LocalDBHelper.ExcuteQuery("select * from literature where 1=0");
                foreach (DataColumn item in _ds.Tables[0].Columns)
                {
                    _dt.Rows.Add(item.Caption, string.Empty);
                }
                dataGridView1.DataSource = _dt.DefaultView;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmEditQuotation), ex);
            }
        }

        private void InitLiteratureInfo()
        {
            try
            {
                string _strSQL = string.Format("select * from literature where id = '{0}'", literatureId);
                DataTable _dt = new DataTable();
                _dt.Columns.Add("key");
                _dt.Columns.Add("value");
                DataSet _ds = LocalDBHelper.ExcuteQuery(_strSQL);
                foreach (DataColumn item in _ds.Tables[0].Columns)
                {
                    if (item.Caption=="ID"||item.Caption=="CLASS_ID"||item.Caption=="AUTHORS")
                    {
                        continue;
                    }
                    if (item.Caption=="ONLINE")
                    {
                        if (_ds.Tables[0].Rows[0][item].ToString().ToUpper()=="TRUE")
                        {
                            linkLabel1.Enabled = true;
                        }
                    }
                    _dt.Rows.Add(item.Caption, _ds.Tables[0].Rows[0][item].ToString());
                }
                dataGridView1.DataSource = _dt.DefaultView;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmEditQuotation), ex);
            }
        }

        private void GetLiteratureInfo(string p_strSql)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("key");
            _dt.Columns.Add("value");
            DataSet _ds = LocalDBHelper.ExcuteQuery(p_strSql);
            foreach (DataColumn item in _ds.Tables[0].Columns)
            {
                _dt.Rows.Add(GetDisplayName(item.Caption),_ds.Tables[0].Rows[0][item].ToString());  
            }
            dataGridView1.DataSource = _dt.DefaultView;
        }

        public string GetDisplayName(string p_strKey)
        {
            //for (int i = 0; i < _array.Length / 2; i++)
            //{
            //    if (_array[i, 0].ToUpper() == p_strKey.ToUpper())
            //    {
            //        return _array[i, 1];
            //    }
            //}
            return "-1";
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteLiterature();
            InsertLiterature();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                UpdateLiterature(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString().Trim());
            }
            this.DialogResult = DialogResult.OK;
        }

        private string FixValue(string p)
        {
            if (p==string.Empty)
            {
                return "-";
            }
            return p;
        }

        /// <summary>
        /// 删除文献
        /// 2016-04-15
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public int DeleteLiterature()
        {
            //try
            //{
            //    DataRow _dr = PublicVar.literature.Tables["literature"].Rows.Find(literatureId.Trim());
            //    _dr.Delete();
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmEditQuotation),ex);
            //}

            //PublicVar.literature.Tables["literature"].Rows.Remove(_dr);
            string _strSQL = string.Format(string.Format(@"delete  from literature where id = '{0}'", literatureId.Trim()));
            int _nReault = LocalDBHelper.ExcuteNonQuery(_strSQL);
            return _nReault;
        }

        /// <summary>
        /// 插入空文献
        /// 2016-04-16
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public int InsertLiterature()
        {
            //DataRow _dr = PublicVar.literature.Tables["literature"].NewRow();//.Find(literatureId.Trim());
            //_dr["id"] = literatureId;
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    string _strColumn = GetKey(item.Cells[0].Value.ToString());
            //    string _strValue = FixValue(item.Cells[1].Value.ToString());
            //    _dr[_strColumn] =_strValue;
            //    //UpdateLiterature(item.Cells[0].Value.ToString(), FixValue(item.Cells[1].Value.ToString()));
            //}
            //PublicVar.literature.Tables["literature"].Rows.Add(_dr);
            string _strSQL = string.Format(string.Format(@"insert into  literature(id) values('{0}')", literatureId.Trim()));
            int _nReault = LocalDBHelper.ExcuteNonQuery(_strSQL);
            return _nReault;
        }
        /// <summary>
        /// 更新字段数据
        /// 2016-04-14
        /// wuahilong
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        /// <returns></returns>
        public  int UpdateLiterature(string p_strKey, string p_strValue)
        {
            //p_strKey = GetKey(p_strKey);
            if (p_strKey.ToUpper()=="创建日期")
            {
                p_strValue = DateTime.Now.ToShortDateString();
            }
            if (p_strKey.ToUpper()=="ID")
            {
                return -1;
            }
            string _strSQL = string.Format(string.Format(@"update literature  set {0}='{1}' where id = '{2}'",
                    p_strKey.Trim(), p_strValue.Trim(),literatureId.Trim()));
            int _nReault = LocalDBHelper.ExcuteNonQuery(_strSQL);
            return _nReault;
        }

        /// <summary>
        /// 通过显示值获取真实字段值
        /// </summary>
        /// <param name="p_strDisplay"></param>
        /// <returns></returns>
        private string GetKey(string p_strDisplay)
        {
            //for (int i = 0; i < _array.Length / 2; i++)
            //{
            //    if (_array[i, 1] == p_strDisplay)
            //    {
            //        return _array[i, 0];
            //    }
            //}
            return "-1";
        }

//        public  int UpdateLiterature(string p_strTitle, string p_strTitleType, string p_strAuthor, string p_strPubYear, string p_strPubPlace, string p_strPubPersion, string p_strJuan,
//            string p_strQi, string p_strPageRange, string p_strDOI, string p_strCountry, string p_strPubDate, string p_strSecondPersion, string p_strVersion,
//            string p_strISSN, string p_strPrintTime, string p_strAuthorInEng, string p_strTitleInEng, string p_strPubPersionInEng, string p_strCountryInEng, string p_strPubPlaceInEng,
//            string p_strVersionInEng, string p_strRefDate, string p_strkey_words, string p_strOutline)
//        {
//            string _strSQL = string.Format(@"update literature 
//                                            set title='{0}',title_type='{1}',author='{2}',pub_year='{3}',pub_place='{4}',
//                                            pub_er ='{5}',juan ='{6}',qi ='{7}',page_range ='{8}',doi ='{9}',
//                                            country ='{10}',pub_date ='{11}',se_person ='{12}',version ='{13}',issn ='{14}',
//                                            pri_time ='{15}',author_eng ='{16}',title_eng ='{17}',puber_eng ='{18}',coun_eng ='{19}',
//                                            palce_eng ='{20}',ver_eng ='{21}',ref_date ='{22}',key_words ='{23}',outline ='{24}') ",
//                 p_strTitle, p_strTitleType, p_strAuthor, p_strPubYear, p_strPubPlace, p_strPubPersion, p_strJuan,
//              p_strQi, p_strPageRange, p_strDOI, p_strCountry, p_strPubDate, p_strSecondPersion, p_strVersion,
//              p_strISSN, p_strPrintTime, p_strAuthorInEng, p_strTitleInEng, p_strPubPersionInEng, p_strCountryInEng, p_strPubPlaceInEng,
//              p_strVersionInEng, p_strRefDate, p_strkey_words, p_strOutline
//                 );
//            int _nReault = DBFHelper.ExcuteNonQuery(_strSQL);
//            return _nReault;
//        }

        public static int UpdateLiterature(string p_strTitle, string p_strTitleType, string p_strAuthor, string p_strPubYear, string p_strPubPlace, string p_strPubPersion, string p_strJuan,
            string p_strQi, string p_strPageRange, string p_strDOI, string p_strCountry, string p_strPubDate, string p_strSecondPersion, string p_strVersion,
            string p_strISSN, string p_strPrintTime, string p_strAuthorInEng, string p_strTitleInEng, string p_strPubPersionInEng, string p_strCountryInEng, string p_strPubPlaceInEng,
            string p_strVersionInEng, string p_strRefDate, string p_strkey_words, string p_strOutline)
        {
            string _strSQL = string.Format(@"update literature 
                                            set title='{0}',title_type='{1}',author='{2}',pub_year='{3}',pub_place='{4}',
                                            pub_er ='{5}',juan ='{6}',qi ='{7}',page_range ='{8}',doi ='{9}',
                                            country ='{10}',pub_date ='{11}',se_person ='{12}',version ='{13}',issn ='{14}',
                                            pri_time ='{15}',author_eng ='{16}',title_eng ='{17}',puber_eng ='{18}',coun_eng ='{19}',
                                            palce_eng ='{20}',ver_eng ='{21}',ref_date ='{22}',key_words ='{23}',outline ='{24}') ",
                p_strTitle, p_strTitleType, p_strAuthor, p_strPubYear, p_strPubPlace, p_strPubPersion, p_strJuan,
             p_strQi, p_strPageRange, p_strDOI, p_strCountry, p_strPubDate, p_strSecondPersion, p_strVersion,
             p_strISSN, p_strPrintTime, p_strAuthorInEng, p_strTitleInEng, p_strPubPersionInEng, p_strCountryInEng, p_strPubPlaceInEng,
             p_strVersionInEng, p_strRefDate, p_strkey_words, p_strOutline
                );
            int _nReault = LocalDBHelper.ExcuteNonQuery(_strSQL);
            return _nReault;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PublicVar.literatureBaseUrl + "/documents/" + literatureId + "/online"); 
        }

       
    }
}
