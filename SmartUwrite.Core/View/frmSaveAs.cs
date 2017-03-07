using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Json;
using System.IO;
using BIMTClassLibrary.EditStyle;

namespace BIMTClassLibrary
{
    public partial class frmSaveAs : Form
    {
        private string p;
        private frmTempletManager frmTempletManager;

        public frmSaveAs()
        {
            InitializeComponent();
        }

        public frmSaveAs(string p)
        {
            InitializeComponent();
            this.p = p;
        }

        public frmSaveAs(string p, frmTempletManager frmTempletManager)
        {
            InitializeComponent();
            this.p = p;
            this.frmTempletManager = frmTempletManager;
            
        }

        private string styleName = string.Empty;

        public string GetStyleName()
        {

            return styleName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == MagazineStyle.GetInstance().Name)
                {
                    MessageBox.Show(null, "当前样式已存在！", "新建样式");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                styleName = textBox1.Text;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSaveAs), ex);
            }
            
        }

        private void CreateNewStyle()
        {
            frmTempletManager.SaveAllControlValue(frmTempletManager.Controls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                frmTempletManager.SetStyleName(textBox1.Text);
                frmTempletManager.SaveData(textBox1.Text);
                this.FindForm().Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.FindForm().Close();
        }
    }
}
