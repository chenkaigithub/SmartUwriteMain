using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BIMTClassLibrary.upgrade
{
    public partial class frmUpgradeInfo : Form
    {
        private List<string> list;
        private bool autoFlag;

        public frmUpgradeInfo()
        {
            InitializeComponent();
        }

        public frmUpgradeInfo(List<string> list)
        {
            try
            {
                InitializeComponent();
                // TODO: Complete member initialization
                this.list = list;
                foreach (var item in list)
                {
                    richTextBox1.Text += item.ToString() + "\n";
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUpgradeInfo), ex);
            }
            
        }

        public frmUpgradeInfo(List<string> list, bool autoFlag)
        {
            try
            {
                InitializeComponent();
                this.list = list;
                this.autoFlag = autoFlag;
                this.list = list;
                foreach (var item in list)
                {
                    richTextBox1.Text += item.ToString()+"\n";
                }
                if (!autoFlag)
                {
                    ck_ignore.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUpgradeInfo), ex);
            }
            
        }

        

        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.SaveConfig("IgnoreCurVersion", "TRUE");
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUpgradeInfo), ex);
            }
           
        }

        private void btn_upgrade_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://smartuwrite.bimt.com/");
                //string path = Application.StartupPath + "\\SmartUwriteDowloadApp.exe";
                ////string path =string.Empty;
                //System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUpgradeInfo), ex);
            }
        }

        private void ck_ignore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ck_ignore.Checked == true)
                {
                    CommonFunction.SaveConfig("IgnoreCurVersion", "TRUE");
                    this.FindForm().Close();
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmUpgradeInfo), ex);
            }
        }
    }
}
