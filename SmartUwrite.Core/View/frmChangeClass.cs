using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.DBF;

namespace BIMTClassLibrary
{
    public partial class frmChangeClass : Form
    {

        private frmLiteratureStorage frmMyLiterature;


        [method: Obsolete("该方法已经过时", true)]
        public frmChangeClass()
        {
            InitializeComponent();
            DataTable dt = frmMyLiterature.Source.GetCategorys();
            dataGridView1.DataSource = dt;
            //frm.Source.InitCatagory(dataGridView1);
        }

        [method: Obsolete("该方法已经过时", true)]
        public frmChangeClass(string p)
        {
            InitializeComponent();
            InitData();
        }

        [method: Obsolete("该方法已经过时", true)]
        public frmChangeClass(string p, frmLiteratureStorage frmMyLiterature)
        {
            InitializeComponent();
            InitData();

        }

        [method: Obsolete("该方法已经过时", true)]
        public frmChangeClass(TreeNode treeNode, frmLiteratureStorage frmMyLiterature)
        {

            this.frmMyLiterature = frmMyLiterature;
        }

        [method: Obsolete("该方法已经过时", true)]
        public frmChangeClass(TreeNode treeNode)
        {
            InitializeComponent();
        }

        public frmChangeClass(BIMTClassLibrary.frmLiteratureStorage frmMyLiterature)
        {
            InitializeComponent();
            this.frmMyLiterature = frmMyLiterature;
            DataTable dt = frmMyLiterature.Source.GetCategorys();
            dataGridView1.DataSource = dt;
        }



        private void InitData()
        {
            //DataSet _dsClass = LocalDBHelper.ExcuteQuery("select ID,类别名称 from class");
            //foreach (DataRow item in _dsClass.Tables[0].Rows)
            //{
            //    listView1.Items.Add(item["ID"].ToString(), item["类别名称"].ToString(), 0);
            //}

            //dataGridView1.DataSource = _dsClass.Tables[0].DefaultView;
            //DataTable dt = new DataTable();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return;
                }
                this.newCatagoryName = dataGridView1.CurrentRow.Cells["class_name"].Value.ToString();
                this.DialogResult = DialogResult.Yes;
                //frm.Source.UpdateLiteratureCategory(treeNode.Text, treeNode.Parent.Name, dataGridView1.CurrentRow.Cells["class_name"].Value.ToString(), treeNode.TreeView);
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmChangeClass), ex);
            }

            //string _strSQL = string.Format("update literature set CLASS_ID = '{0}' where ID = '{1}'", dataGridView1.CurrentRow.Cells["ID"].Value.ToString(),p);
            //int _nR = LocalDBHelper.ExcuteNonQuery(_strSQL);
            //if (_nR != 1)
            //{
            //    Log4Net.LogHelper.WriteLog(typeof(frmChangeClass), "类别转换失败：" + _strSQL);
            //    this.Text = "类别转换失败";
            //}
            //else
            //{
            //    frm.MoveNodetoAnother(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());//.InitData();
            //    this.Text = "类别转换成功";
            //    this.FindForm().Close();
            //}

        }

        public string newCatagoryName { get; set; }
    }
}
