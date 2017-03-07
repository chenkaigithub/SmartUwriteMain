using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LiteratureManager;

namespace BIMTClassLibrary
{
    public partial class frmRenameClass : Form
    {
        private string oldCatagory;

        public frmRenameClass()
        {
            InitializeComponent();
        }

        public frmRenameClass(string oldCatagory)
        {
            InitializeComponent();
            this.oldCatagory = oldCatagory;
            this.textBox1.Text = oldCatagory;
            textBox1.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewDir = textBox1.Text.Trim();
            if (NewDir == string.Empty)
            {
                MessageBox.Show("名称不能为空");
                return;
            }
            else if (ExistDir())
            {
                return;
            }

            this.FindForm().Close();
        }

        public bool ExistDir()
        {
            try
            {
                if (Directory.Exists(FileStorageService.GetInstance().GetBaseDir() + NewDir))
                {
                    MessageBox.Show(null, "类别名称重复", "类别重命名");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmRenameClass), "重命名：" + ex.Message);
            }
            return false;
        }

        private string NewDir { get; set; }

        public string GetNewDir() {

            return NewDir;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
