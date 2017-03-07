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
using System.Threading;

namespace BIMTClassLibrary
{
    public partial class frmSelectQuotation : Form
    {
        QuotationItem quotationItem = null;
        public frmSelectQuotation(QuotationItem p_q)
        {
            InitializeComponent();
            //InitData();
            //quotationItem = p_q;
        }

        //public frmSelectQuotation()
        //{
        //    InitializeComponent();
        //    InitData();
        //}

        //private void InitData()
        //{
        //    //string _strDBFPath = @"C:\Users\jishu12\Desktop\literature.dbf";
        //    //DBFHelper dbfHelper = new DBFHelper(_strDBFPath);
        //    //DataSet _ds = LocalDBHelper.ExcuteQuery("select * from literature");
        //    dataGridView1.DataSource = PublicVar.Myliterature.GetAllLiteratures();//_ds.Tables[0].DefaultView;
        //    SetText();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.FindForm().Close();
        //    this.DialogResult = DialogResult.Cancel;
        //}

        //public void WriteQuotation() {
        //    try
        //    {
        //        DataGridViewRow _drCurrent = dataGridView1.CurrentRow;
        //        Quotation quotation = new Quotation(_drCurrent);
        //        //文中引文
        //        QuotationIndex index =  QuotationIndex.GetInstance(quotation);
        //        index.WriteContent();
        //        //印文标题
        //        QuotationTitle title = new QuotationTitle();
        //        title.WriteContent();
        //        //引文信息
        //        QuotationSet set = new QuotationSet();
        //        set.WriteContent();
        //        //文末引文
        //        QuotationItem item =  QuotationItem.GetInstance(quotation);
        //        item.WriteContent();

        //        this.DialogResult = DialogResult.OK;
                
              
        //        //quotation.SetQuotationContext(
        //        //    dr.Cells["title"].Value.ToString().Trim(),
        //        //    dr.Cells["title_type"].Value.ToString().Trim(),
        //        //    dr.Cells["author"].Value.ToString().Trim(),
        //        //    dr.Cells["pub_year"].Value.ToString().Trim(),
        //        //    dr.Cells["pub_place"].Value.ToString().Trim(),
        //        //    dr.Cells["pub_er"].Value.ToString().Trim(),
        //        //    dr.Cells["juan"].Value.ToString().Trim(),
        //        //    dr.Cells["qi"].Value.ToString().Trim(),
        //        //    dr.Cells["page_range"].Value.ToString().Trim(),
        //        //    dr.Cells["doi"].Value.ToString().Trim(),
        //        //    dr.Cells["country"].Value.ToString().Trim(),
        //        //    dr.Cells["pub_date"].Value.ToString().Trim(),
        //        //    dr.Cells["se_person"].Value.ToString().Trim(),
        //        //    dr.Cells["version"].Value.ToString().Trim(),
        //        //    dr.Cells["issn"].Value.ToString().Trim(),
        //        //    dr.Cells["pri_time"].Value.ToString().Trim(),
        //        //    dr.Cells["author_eng"].Value.ToString().Trim(),
        //        //    dr.Cells["title_eng"].Value.ToString().Trim(),
        //        //    dr.Cells["puber_eng"].Value.ToString().Trim(),
        //        //    dr.Cells["coun_eng"].Value.ToString().Trim(),
        //        //    //dr.Cells["pub_er"].Value.ToString(),
        //        //    dr.Cells["palce_eng"].Value.ToString().Trim(),
        //        //    dr.Cells["ver_eng"].Value.ToString().Trim(),
        //        //    dr.Cells["ref_date"].Value.ToString().Trim(), string.Empty, string.Empty,
        //        //     dr.Cells["author_json"].Value.ToString().Trim()
        //        //    );

               
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(typeof(frmEditQuotation), ex);
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //CommonFunction.WriteQuotation(dataGridView1.CurrentRow);
        //    Quotation quotatio = PublicVar.Myliterature.GetQuotationByName(dataGridView1.CurrentRow.Cells["类别"].Value.ToString(), dataGridView1.CurrentRow.Cells["标题"].Value.ToString());
        //    ThreadQuotation tq = new ThreadQuotation(quotatio);
        //    Thread t = new Thread(tq.SynWriteQuuotation);
        //    t.Start();
        //    //2016-06-06 wuhailong 选择某一篇文献插入后，选择引文界面就关闭了，需要重新点击开启，建议保留此窗口，可以引用多篇文献；
        //    //this.FindForm().Close();
        //    this.DialogResult = DialogResult.OK;
        //    //WriteQuotation();
           
        //}

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //richTextBox1.Visible = true;
        //    SetText();
        //}

        ///// <summary>
        ///// 设置显示关键词摘要
        ///// 2016-05-07
        ///// wuhailong
        ///// </summary>
        //public void SetText()
        //{
        //    try
        //    {
        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            if (dataGridView1.CurrentRow != null)
        //            {
        //                DataGridViewRow dr = dataGridView1.CurrentRow;
        //                richTextBox1.Text = "关键词：" + dr.Cells["关键词"].Value.ToString().Trim() + "\r" +
        //                                    "摘  要：" + dr.Cells["摘要"].Value.ToString().Trim();
        //            }
        //            else
        //            {
        //                DataGridViewRow dr = dataGridView1.Rows[0];
        //                richTextBox1.Text = "关键词：" + dr.Cells["关键词"].Value.ToString().Trim() + "\r" +
        //                                    "摘  要：" + dr.Cells["摘要"].Value.ToString().Trim();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(typeof(frmSelectQuotation), ex);
        //    }
        //}

        //public void FilterLiterature()
        //{
        //    try
        //    {
        //        string _strFilter = string.Format("标题 like '%{0}%' or 作者 like '%{0}%' or 年份 like '%{0}%' or 卷 like '%{0}%' or 期 like '%{0}%' or 摘要 like '%{0}%' or 关键词 like '%{0}%'", textBox1.Text);
        //        DataTable _Source = PublicVar.Myliterature.GetAllLiteratures();
        //        if (textBox1.Text == "")
        //        {
        //            dataGridView1.DataSource = _Source.DefaultView;
        //        }
        //        else
        //        {
        //            DataRow[] _array = _Source.Select(_strFilter);
        //            DataTable _dt = _Source.Clone();
        //            if (_array.Length >= 1)
        //            {
        //                foreach (DataRow item in _array)
        //                {
        //                    _dt.Rows.Add(item.ItemArray);
        //                }
        //            }
        //            dataGridView1.DataSource = _dt.DefaultView;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(typeof(frmSelectQuotation), ex);
        //    }

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FilterLiterature();
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    FilterLiterature();
        //    //try
        //    //{
        //    //    DataSet _ds = LocalDBHelper.ExcuteQuery("select * from literature");
        //    //    string _strFilter = string.Format("标题 like '%{0}%' or 作者 like '%{0}%' or 期刊名称 like '%{0}%'  or 题录类型 like '%{0}%' or 出版地点 like '%{0}%' or  年份 like '%{0}%' or 出版社 like '%{0}%' or 卷 like '%{0}%' or 期 like '%{0}%' or 关键词 like '%{0}%' or 摘要 like '%{0}%'", textBox1.Text);
        //    //    if (_ds.Tables.Count < 1)
        //    //    {
        //    //        return;
        //    //    }
        //    //    DataRow[] _array = _ds.Tables[0].Select(_strFilter);
        //    //    DataTable _dt = _ds.Tables[0].Clone();
        //    //    if (_array.Length >= 1)
        //    //    {
        //    //        foreach (DataRow item in _array)
        //    //        {
        //    //            _dt.Rows.Add(item.ItemArray);
        //    //        }
        //    //    }
        //    //    dataGridView1.DataSource = _dt.DefaultView;

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(typeof(frmSelectQuotation), ex);
        //    //}
            
        //}

        //private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //CommonFunction.WriteQuotation(dataGridView1.CurrentRow);
        //    //this.DialogResult = DialogResult.OK;
        //    Quotation quotatio = PublicVar.Myliterature.GetQuotationByName(dataGridView1.CurrentRow.Cells["类别"].Value.ToString(), dataGridView1.CurrentRow.Cells["标题"].Value.ToString());
        //    ThreadQuotation tq = new ThreadQuotation(quotatio);
        //    Thread t = new Thread(tq.SynWriteQuuotation);
        //    t.Start();
        //    this.FindForm().Close();
        //    this.DialogResult = DialogResult.OK;
        //}


    }
}
