using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.DBF;
using System.IO;
using LiteratureManager;

namespace BIMTClassLibrary
{
    public partial class frmAddClass : Form
    {
        private frmLiteratureStorage frmMyLiterature;
        private TreeView treeView1;

       

        public frmAddClass()
        {
            InitializeComponent();
        }

        public frmAddClass(frmLiteratureStorage frmMyLiterature)
        {
            InitializeComponent();
            this.frmMyLiterature = frmMyLiterature;
        }

        public frmAddClass(TreeView treeView1)
        {
            InitializeComponent();
            this.treeView1 = treeView1;
        }
        string newCatagoryName = string.Empty;

        public string GetNewCatagoryName()
        {
            return newCatagoryName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _strPath = FileStorageService.GetInstance().GetBaseDir() + textBox1.Text;
                if (Directory.Exists(_strPath))
                {
                    MessageBox.Show(null, "当前分类已存在！", "添加分类");
                }
                else
                {
                    newCatagoryName = textBox1.Text;
                    frmMyLiterature.Source.AddCategory(textBox1.Text);
                    this.DialogResult = DialogResult.OK;
                    this.FindForm().Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text=="")
            {
                return;
            }
            if (e.KeyChar == 13)
            {
                frmMyLiterature.Source.AddCategory(textBox1.Text);
                this.FindForm().Close();
            }
        }

        private void InsertClass()
        {
            int _n = LocalDBHelper.ExcuteNonQuery(string.Format("insert into  class(id,类别名称) values('{0}','{1}')", Guid.NewGuid(), textBox1.Text));
            if (_n == 1)
            {
                //MessageBox.Show("添加成功！");
                frmMyLiterature.InitData();
                this.FindForm().Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
