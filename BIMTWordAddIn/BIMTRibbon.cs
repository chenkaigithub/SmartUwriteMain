using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Tools.Ribbon;
using BIMTClassLibrary;
using Microsoft.Office.Tools;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Log4Net;
using BIMTClassLibrary.styles;
using System.IO;
using System.Threading;
using BIMTClassLibrary.Upgrade;
using BIMTClassLibrary.WordTemplete;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;
using BIMTClassLibrary.EditStyle;
using BIMTClassLibrary.Model;
using BIMTClassLibrary.View;
using BIMTClassLibrary.Controller;
using BIMTClassLibrary.Controller.Service;
using BIMTClassLibrary.userBeheiverTrick;

namespace BIMTWordAddIn
{
    public partial class BIMTRibbon :  IRefreshViewable
    {
        SmartUwriteLoadController controller = new SmartUwriteLoadController();
        Dictionary<string, CustomTaskPane> paneDict = new Dictionary<string, CustomTaskPane>();
        string[] arrayKeys = { "BIMT文献推荐", "BIMT图片校验", "BIMT文献搜索", "BIMT杂志推荐", "BIMT审稿人推荐"};
        private void BIMTRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            try
            {
                InitStatus();
                controller.UseWord();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }

        }

       
        public void SetStyle(string name)
        {
            MagazineStyle se = MagazineStyle.GetInstance();
            se.Name = name;
            if (se.Exist())
            {
                cb_style.Text = name.Split('.')[0];
            }
        }

        public void DownloadStyles()
        {
            try
            {
                //StyleManager.DownLoadStyles(PublicVar.StyleDir);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }



        private void InitStatus()
        {
            UpdateController controller = new UpdateController(this);
            controller.CheckUpdate();
            //UpgradeService us = new UpgradeService(true);
            //us.SynCheckUpdate();
            MagazineStyle se = MagazineStyle.GetInstance();
            if (se.Exist())
            {
                cb_style.Text = se.Name;
            }
            //2016-06-13 测试 吴海龙
            WordApplication.GetInstance().WordApp = Globals.ThisAddIn.Application;
            //WordApplication.GetInstance().WordApp = Globals.ThisAddIn.Application;
            //日志目录
            if (!Directory.Exists("C:\\log\\"))
            {
                Directory.CreateDirectory("C:\\log\\");
            }
            //多线程下载样式避免，网络卡顿造成word 卡死。
            Thread t = new Thread(DownloadStyles);
            t.Start();
            RefreshStyleList();
        }

        /// <summary>
        /// 删除这个会导致再次安装出现bug的文件
        /// 2016-05-30
        /// wuhailong
        /// </summary>
        private void DelBugFile()
        {
            try
            {
                string _strPath = @"C:\Program Files (x86)\Common Files\microsoft shared\VSTO\10.0\VSTOInstaller.exe.config";
                if (File.Exists(_strPath))
                {
                    File.Delete(_strPath);
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }

        }

        
        

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {

            frmLiteratureStorage frm =  frmLiteratureStorage.GetInstance();
            frm.ShowDialog();
        }

        private void btn_lbase_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (new LoginController(this).IsLogin("登录之后才能使用我的文献库!"))
                {
                    frmLiteratureStorage frm = frmLiteratureStorage.GetInstance();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        public void showMyLiterature() {
            frmLiteratureStorage frm =  frmLiteratureStorage.GetInstance();
            
            frm.ShowDialog();
        }

        public void ShowTaskPane(string panel, UserControl uc)
        {
            CustomTaskPane pane = null;
            string key = Globals.ThisAddIn.Application.ActiveDocument.Name + panel;
            if (paneDict.Keys.Contains(key))
            {
                paneDict[key].Dispose();
                paneDict.Remove(key);
                pane = Globals.ThisAddIn.CustomTaskPanes.Add(uc, panel);
                paneDict.Add(key, pane);
                pane.Width = 545;
            }
            else
            {
                pane = Globals.ThisAddIn.CustomTaskPanes.Add(uc, panel);
                pane.Width = 545;
                paneDict.Add(key, pane);
            }
            pane.Visible = true;
        }

        private void btn_search_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                LiteratureSearchController controller = new LiteratureSearchController(this, "BIMT文献搜索");
                controller.Do();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void btn_statement_matching_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                PublicVar.MenuFlag = PublicVar.YJPP;
                StatementMatchingController controller = new StatementMatchingController(this, "BIMT文献推荐", Globals.ThisAddIn.Application.Selection.Text);
                controller.Do();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void edit_style_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (new LoginController(this).IsLogin("登录后才能进行样式编辑！请问是否立即登录？"))
                {
                    if (MagazineStyle.GetInstance().Name == "参考文献样式")
                    {
                        MessageBox.Show("请选择具体的参考文献样式后再编辑。");
                        return;
                    }
                    PublicVar.CNStyle = CommonFunction.IsCNStyle(MagazineStyle.GetInstance().Name);
                    frmTempletManager frm = new frmTempletManager(cb_style.Text);
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        RefreshStyleList();
                        cb_style.Text = frm.newStyle;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void btn_del_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DelLiteratureController controller = new DelLiteratureController(this);
                controller.Do();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void currentStyle_TextChanged(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(null, "是否应用" + cb_style.Text + "的参考文献样式?", "切换样式", MessageBoxButtons.YesNo))
                {
                    MagazineStyle _style = MagazineStyle.GetInstance();
                    _style.Name = cb_style.Text;
                    PublicVar.SetCurrentStyleJObject();
                    CommonFunction.RefreshStyle();
                    QuotationStyle style = new QuotationStyle(MagazineStyle.GetInstance().Name);
                    style.WriteContent();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void login_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                LoginController controller = new LoginController(this);
                controller.Do();
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), EX);
            }
        }

     
        private void btn_apply_style_Click(object sender, RibbonControlEventArgs e)
        {//更新样式
            try
            {
                MagazineStyle.GetInstance().Name = cb_style.Text;

                PublicVar.SetCurrentStyleJObject();

                CommonFunction.RefreshStyle();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        public void InitStylesList()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(DoWord));
                thread.Start();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        public delegate void InitItemInvoke(string str);

        public void DoWord()
        {
            try
            {
                int downLoadCount = StyleManager.DownLoadStyles(string.Empty);
                LogHelper.WriteLog(typeof(BIMTRibbon), string.Format("同步样式{0}条",downLoadCount));
                if (downLoadCount > 0)
                {
                    RefreshStyleList();
                    MessageBox.Show(null, "同步完成" + downLoadCount + "条样式！", "同步样式");
                }
                else
                {
                    MessageBox.Show(null, "同步同步样式失败！", "同步样式");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex.Message+"同步样式异常");
            }
        }

        private void button10_Click(object sender, RibbonControlEventArgs e)
        {//1.下载样式 2.刷新样式列表
            try
            {
                InitStylesList();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void btn_info_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://smartuwrite.bimt.com/details.html");
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), EX);
            }
        }

        /// <summary>
        /// 刷新样式列表
        /// 2016-06-23
        /// wuhailong
        /// </summary>
        public void RefreshStyleList()
        {
            try
            {
                cb_style.Items.Clear();
                //下拉框赋值
                List<string> _list = CommonFunction.GetFileName(PublicVar.StyleDir, "*.json");
                List<string> _listEn = new List<string>();
                List<string> _listCn = new List<string>();
                //_listCn.Add("参考文献样式");
                foreach (string item in _list)
                {
                    if (CommonFunction.IsCnString(item))
                    {
                        _listCn.Add(item);
                        //RibbonFactory rf = Globals.Factory.GetRibbonFactory();
                        //RibbonDropDownItem di = rf.CreateRibbonDropDownItem();
                        //di.Label = item;
                        //comboBox1.Items.Add(di);
                    }
                    else
                    {
                        _listEn.Add(item);
                    }
                }
                _listCn.Sort();
                string _strTemp = _listCn[0];
               
                int _myCount = 0;
                for (int i = 0; i < _listCn.Count; i++)
                {
                    if (_listCn[i]=="参考文献样式")
                    {
                        _myCount = i;
                        break;
                    }
                }
                _listCn[0] = "参考文献样式";
                _listCn[_myCount] = _strTemp;
                foreach (string item in _listCn)
                {
                    RibbonFactory rf = Globals.Factory.GetRibbonFactory();
                    RibbonDropDownItem di = rf.CreateRibbonDropDownItem();
                    di.Label = item;
                    cb_style.Items.Add(di);
                }
                _listEn.Sort();
                foreach (string item in _listEn)
                {
                    RibbonFactory rf = Globals.Factory.GetRibbonFactory();
                    RibbonDropDownItem di = rf.CreateRibbonDropDownItem();
                    di.Label = item;
                    cb_style.Items.Add(di);
                }
                PublicVar.SetCurrentStyleJObject();
                
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), EX);
            }
        }

        private void btn_feedback_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                FeedBackController controller = new FeedBackController(this);
                controller.Do();
            }
            catch (Exception EX)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), EX);
            }
        }


        private void button14_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                ofd_pic.ShowDialog();
                PicFixController controller = new PicFixController(this,"BIMT图片校验", ofd_pic.FileName);
                controller.Do();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void ofd_pic_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btn_rec_viewer_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                ViewerRecmmandController controller = new ViewerRecmmandController(this, "BIMT审稿人推荐");
                controller.Do();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void button15_Click_1(object sender, RibbonControlEventArgs e)
        {//"BIMT杂志推荐", "BIMT审稿人推荐"
            try
            {
                MagazineRecmmandController controller = new MagazineRecmmandController(this, "BIMT杂志推荐");
                controller.Do();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        private void button18_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Paragraph p = CommonFunction.AddParagraphAtSelection(WordApplication.GetInstance().WordApp);
        }

        private void button19_Click(object sender, RibbonControlEventArgs e)
        {
            //FtpHelper.Test();
            UpgradeService.DoUpgrade();
        }

        public int clickCount { get; set; }

        private void button20_Click(object sender, RibbonControlEventArgs e)
        {
            ++clickCount;
            if (clickCount == 3)
            {
                RefreshStyleList();
            }
        }

        private void btn_checkUpgrade_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                UpdateController controller = new UpdateController(this);
                controller.Do();
                //Thread thread = new Thread(new ThreadStart(controller.Do));
                //thread.Start();
                //UpgradeService us = new UpgradeService(false);
                //us.SynCheckUpdate();
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
           
        }

        public void SetEnable()
        {
            try
            {
                btn_search.Enabled = true;
                button22.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_doc_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                DocTempletController controller = new DocTempletController(this);
                controller.UseChargedFunction();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }
        }


        private void googlesearch_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                GoogleViewController controller = new GoogleViewController(this);
                controller.UseChargedFunction();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmGoogleSearch), ex);
            }
        }

        private void btn_buy_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                BuyController controller = new BuyController(this);
                controller.Do();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmPay), ex);
            }
        }

        private void btn_test_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                frmSettingCenter frm = new frmSettingCenter();
                //frmProcess frm = new frmProcess();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }


        public void Payed()
        {
            btn_payed.Label = string.Format(btn_payed.Label, User.GetInstance().Detail.result.overDate);
            btn_payed.Visible = true;
        }


        public void NonPay()
        {
            btn_payed.Visible = false;
            btn_payed.Label = "剩余{0}天";
            
        }

        public void Logined()
        {
            int _n = "登 录                 ".Length;
            string fill = User.GetInstance().Detail.result.name 
                ?? User.GetInstance().Detail.result.loginName
                ?? (User.GetInstance().Detail.result.lastCnname + User.GetInstance().Detail.result.firstCnname)
                ?? User.GetInstance().Detail.result.tel
                ?? User.GetInstance().Detail.result.email
                ?? "请到官网补充信息";
            btn_userName.Label = fill.ToUpper().PadRight(_n, ' ');
        }
        
        public void Logout()
        {
            HideAdminPanel();
            btn_userName.Label = "会员登录";
        }

        /// <summary>
        /// 设置不活动的面板不可见
        /// wuhailong
        /// 2016-07-06
        /// </summary>
        public void HideOtherPanel(string p_strCurrentPanel)
        {
            try
            {
                string _strCurrentPanel = p_strCurrentPanel;
                foreach (var item in arrayKeys)
                {
                    if (item == _strCurrentPanel)
                    {
                        continue;
                    }
                    CustomTaskPane m_customLiteratureRecommend = null;
                    string _strKeyRecommend = Globals.ThisAddIn.Application.ActiveDocument.Name + item;
                    if (paneDict.Keys.Contains(_strKeyRecommend))
                    {
                        m_customLiteratureRecommend = paneDict[_strKeyRecommend];
                        m_customLiteratureRecommend.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(BIMTRibbon), ex);
            }
        }

        public void ShowAdminPanel()
        {
            btn_test.Visible = true;
        }

        public void HideAdminPanel()
        {
            btn_test.Visible = false;
        }

        public void NeedUpdate()
        {
            btn_checkUpgrade.Visible = true;
        }
    }
}
