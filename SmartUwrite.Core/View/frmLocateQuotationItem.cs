using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Log4Net;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    public partial class frmLocateQuotationItem : Form
    {
        private string p;

        public frmLocateQuotationItem()
        {
            InitializeComponent();
        }

        public frmLocateQuotationItem(string p)
        {
            InitializeComponent();
            try
            {
                DataTable _dt = new DataTable();
                _dt.Columns.Add("author");
                _dt.Columns.Add("pub_year");
                this.p = p;
                string _strR = p.Replace(QuotationIndex.FLAG + "_", string.Empty);
                string[] _array = _strR.Split('#');
                foreach (var item in _array)
                {
                    string[] _arrayAuthorYear = item.Split('_');
                    _dt.Rows.Add(_arrayAuthorYear[0], _arrayAuthorYear[1]);
                }
                dataGridView1.DataSource = _dt.DefaultView;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLocateQuotationItem), ex);
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string _strAuthorYear = dataGridView1.CurrentRow.Cells["author"].Value.ToString() + "_" + dataGridView1.CurrentRow.Cells["pub_year"].Value.ToString();
                QuotationIndex index = QuotationIndex.GetInstance(null);
                index.LocateQuotation(WordApplication.GetInstance().WordApp, _strAuthorYear);
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmLocateQuotationItem),ex);
            }
            
        }
    }
}
