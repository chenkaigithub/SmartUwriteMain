using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 当前位置复合引文列表
    /// wuhailong 
    /// 2016-06-27
    /// </summary>
    public partial class frmDeleteQuotation : Form, IBaseControl
    {
        DataTable _dtSource = null;
        List<string> m_listQuotations = new List<string>();

        public List<string> ListQuotations
        {
            get { return m_listQuotations; }
            set { m_listQuotations = value; }
        }
        public frmDeleteQuotation()
        {
            InitializeComponent();
            InitData();
        }

        public frmDeleteQuotation(DataTable dt)
        {
            _dtSource = dt;
            InitializeComponent();
            InitData();
        }

        /// <summary>
        /// 获取删除的引文作者年
        /// wuhailong
        /// 2016-06-27
        /// </summary>
        /// <returns></returns>
        public string GetDeleteAuthorYear()
        {
            return deleteQuotation;
        }

        public void InitData()
        {
            dataGridView1.DataSource = _dtSource;
        }

        private void LocatedQuotationsView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0] == null)
                {
                    return;
                }
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string selectedAuthorYear = dataGridView1.SelectedRows[0].Cells["authorYear"].Value.ToString().Trim();
                    string temp = item.Cells["authorYear"].Value.ToString().Trim();
                    if (temp == selectedAuthorYear)
                    {
                        this.deleteQuotation = selectedAuthorYear;
                    }
                    else
                    {
                        ListQuotations.Add(temp);
                    }
                }
                this.DialogResult = DialogResult.Yes;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmDeleteQuotation), ex);
            }
        }

        public string deleteQuotation { get; set; }
    }
}
