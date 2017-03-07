namespace BIMTWordAddIn
{
    partial class BIMTRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BIMTRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonButton button4;
            this.BIMT = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btn_userName = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.btn_search = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.button22 = this.Factory.CreateRibbonButton();
            this.cb_style = this.Factory.CreateRibbonComboBox();
            this.button8 = this.Factory.CreateRibbonButton();
            this.button10 = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.button15 = this.Factory.CreateRibbonButton();
            this.button16 = this.Factory.CreateRibbonButton();
            this.button14 = this.Factory.CreateRibbonButton();
            this.separator5 = this.Factory.CreateRibbonSeparator();
            this.button11 = this.Factory.CreateRibbonButton();
            this.button12 = this.Factory.CreateRibbonButton();
            this.btn_checkUpgrade = this.Factory.CreateRibbonButton();
            this.button23 = this.Factory.CreateRibbonButton();
            this.btn_payed = this.Factory.CreateRibbonButton();
            this.btn_test = this.Factory.CreateRibbonButton();
            this.ofd_pic = new System.Windows.Forms.OpenFileDialog();
            button4 = this.Factory.CreateRibbonButton();
            this.BIMT.SuspendLayout();
            this.group2.SuspendLayout();
            // 
            // button4
            // 
            button4.Description = "message";
            button4.Image = global::BIMTWordAddIn.Properties.Resources.编辑样式11;
            button4.Label = "编辑样式";
            button4.Name = "button4";
            button4.ScreenTip = "编辑当前选自定义定样式的规则设置，同时可将样式另存为新的自定义样式；假如未登录则不允许操作；";
            button4.ShowImage = true;
            button4.SuperTip = "设置引文样式。";
            button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.edit_style_Click);
            // 
            // BIMT
            // 
            this.BIMT.Groups.Add(this.group2);
            this.BIMT.Label = "SmartUwrite";
            this.BIMT.Name = "BIMT";
            // 
            // group2
            // 
            this.group2.Items.Add(this.btn_userName);
            this.group2.Items.Add(this.separator2);
            this.group2.Items.Add(this.button6);
            this.group2.Items.Add(this.button7);
            this.group2.Items.Add(this.btn_search);
            this.group2.Items.Add(this.separator4);
            this.group2.Items.Add(this.button3);
            this.group2.Items.Add(this.button5);
            this.group2.Items.Add(this.separator3);
            this.group2.Items.Add(this.button22);
            this.group2.Items.Add(this.cb_style);
            this.group2.Items.Add(button4);
            this.group2.Items.Add(this.button8);
            this.group2.Items.Add(this.button10);
            this.group2.Items.Add(this.separator1);
            this.group2.Items.Add(this.button15);
            this.group2.Items.Add(this.button16);
            this.group2.Items.Add(this.button14);
            this.group2.Items.Add(this.separator5);
            this.group2.Items.Add(this.button11);
            this.group2.Items.Add(this.button12);
            this.group2.Items.Add(this.btn_checkUpgrade);
            this.group2.Items.Add(this.button23);
            this.group2.Items.Add(this.btn_payed);
            this.group2.Items.Add(this.btn_test);
            this.group2.Label = "BIMT";
            this.group2.Name = "group2";
            // 
            // btn_userName
            // 
            this.btn_userName.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_userName.Description = "2";
            this.btn_userName.Image = global::BIMTWordAddIn.Properties.Resources.登录_01;
            this.btn_userName.Label = "会员登录";
            this.btn_userName.Name = "btn_userName";
            this.btn_userName.ScreenTip = "登录到BIMT，登录后可进行样式编辑操作；";
            this.btn_userName.ShowImage = true;
            this.btn_userName.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.login_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // button6
            // 
            this.button6.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button6.Image = global::BIMTWordAddIn.Properties.Resources.文献检索;
            this.button6.Label = "文献检索";
            this.button6.Name = "button6";
            this.button6.ScreenTip = "根据所展示的条件搜索过滤匹配的文献；";
            this.button6.ShowImage = true;
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_search_Click);
            // 
            // button7
            // 
            this.button7.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button7.Image = global::BIMTWordAddIn.Properties.Resources.语句匹配3;
            this.button7.Label = "语句匹配";
            this.button7.Name = "button7";
            this.button7.ScreenTip = "划取文档中一段文字，点击推荐文献将自动匹配相关文献；";
            this.button7.ShowImage = true;
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_statement_matching_Click);
            // 
            // btn_search
            // 
            this.btn_search.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_search.Image = global::BIMTWordAddIn.Properties.Resources.谷歌学术;
            this.btn_search.Label = "Google学术";
            this.btn_search.Name = "btn_search";
            this.btn_search.ScreenTip = "使用Google学术进行搜索；（付费功能）";
            this.btn_search.ShowImage = true;
            this.btn_search.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.googlesearch_Click);
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Image = global::BIMTWordAddIn.Properties.Resources.我的文献11;
            this.button3.Label = "我的文献";
            this.button3.Name = "button3";
            this.button3.ScreenTip = "显示用户所收藏的文献和引用过的文献；";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_lbase_Click);
            // 
            // button5
            // 
            this.button5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button5.Image = global::BIMTWordAddIn.Properties.Resources.删除引文_01;
            this.button5.Label = "删除引文";
            this.button5.Name = "button5";
            this.button5.ScreenTip = "将光标放到文中引文或文末参考文献处，点击此按钮将删除对应的文末参考文献或文中引文；";
            this.button5.ShowImage = true;
            this.button5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_del_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // button22
            // 
            this.button22.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button22.Image = global::BIMTWordAddIn.Properties.Resources.写作模版_011;
            this.button22.Label = "写作模板";
            this.button22.Name = "button22";
            this.button22.ScreenTip = "下载对应期刊的的格式要求模板；（收费功能）";
            this.button22.ShowImage = true;
            this.button22.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_doc_Click);
            // 
            // cb_style
            // 
            this.cb_style.Label = "选择样式";
            this.cb_style.MaxLength = 50;
            this.cb_style.Name = "cb_style";
            this.cb_style.ScreenTip = "样式列表";
            this.cb_style.ShowLabel = false;
            this.cb_style.Text = "参考文献样式";
            this.cb_style.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.currentStyle_TextChanged);
            // 
            // button8
            // 
            this.button8.Image = global::BIMTWordAddIn.Properties.Resources.应用样式21;
            this.button8.Label = "应用样式";
            this.button8.Name = "button8";
            this.button8.ScreenTip = "将样式列表选中的样式规则应用到当前文档";
            this.button8.ShowImage = true;
            this.button8.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_apply_style_Click);
            // 
            // button10
            // 
            this.button10.Image = global::BIMTWordAddIn.Properties.Resources.刷新1;
            this.button10.Label = "同步样式";
            this.button10.Name = "button10";
            this.button10.ScreenTip = "当用户未登录时下载基础样式到本地，当用户登录时下载自定义及基础样式到本地；";
            this.button10.ShowImage = true;
            this.button10.ShowLabel = false;
            this.button10.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button10_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // button15
            // 
            this.button15.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button15.Image = global::BIMTWordAddIn.Properties.Resources.qikantuijain;
            this.button15.Label = "推荐期刊";
            this.button15.Name = "button15";
            this.button15.ScreenTip = "用户选择后，根据文章的关键词进行匹配，为用户推荐适合投稿期刊；";
            this.button15.ShowImage = true;
            this.button15.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button15_Click_1);
            // 
            // button16
            // 
            this.button16.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button16.Image = global::BIMTWordAddIn.Properties.Resources.tuijianshengaoren_;
            this.button16.Label = "推荐审稿人";
            this.button16.Name = "button16";
            this.button16.ScreenTip = "用户选择后，根据文章的关键词进行匹配，为用户推荐审稿人，同时用户可对审稿人进行分类为\"推荐审稿人\"和\"回避审稿人\"并进行导出存储;";
            this.button16.ShowImage = true;
            this.button16.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_rec_viewer_Click);
            // 
            // button14
            // 
            this.button14.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button14.Image = global::BIMTWordAddIn.Properties.Resources.tupianjiance;
            this.button14.Label = "图片校验";
            this.button14.Name = "button14";
            this.button14.ScreenTip = "校验所提交的图片是否符合杂志社要求，点击下载图片可将图片转换为符合要求的图片；";
            this.button14.ShowImage = true;
            this.button14.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button14_Click);
            // 
            // separator5
            // 
            this.separator5.Name = "separator5";
            // 
            // button11
            // 
            this.button11.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button11.Image = global::BIMTWordAddIn.Properties.Resources.帮助说明1;
            this.button11.Label = "使用说明";
            this.button11.Name = "button11";
            this.button11.ScreenTip = "链接软件的使用说明网页；";
            this.button11.ShowImage = true;
            this.button11.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_info_Click);
            // 
            // button12
            // 
            this.button12.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button12.Image = global::BIMTWordAddIn.Properties.Resources.bimt_yijianfankui;
            this.button12.Label = "用户反馈";
            this.button12.Name = "button12";
            this.button12.ScreenTip = "将反馈意见提交到BIMT网络，帮助我们改进；";
            this.button12.ShowImage = true;
            this.button12.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_feedback_Click);
            // 
            // btn_checkUpgrade
            // 
            this.btn_checkUpgrade.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_checkUpgrade.Image = global::BIMTWordAddIn.Properties.Resources.star_512px_1175870_easyicon_net;
            this.btn_checkUpgrade.Label = "有更新啦";
            this.btn_checkUpgrade.Name = "btn_checkUpgrade";
            this.btn_checkUpgrade.ScreenTip = "点击按钮进行更新，更新时需要关闭word.";
            this.btn_checkUpgrade.ShowImage = true;
            this.btn_checkUpgrade.Visible = false;
            this.btn_checkUpgrade.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_checkUpgrade_Click);
            // 
            // button23
            // 
            this.button23.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button23.Image = global::BIMTWordAddIn.Properties.Resources.收费;
            this.button23.Label = "购买付费版";
            this.button23.Name = "button23";
            this.button23.ShowImage = true;
            this.button23.Visible = false;
            this.button23.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_buy_Click);
            // 
            // btn_payed
            // 
            this.btn_payed.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_payed.Image = global::BIMTWordAddIn.Properties.Resources.剩余天数;
            this.btn_payed.Label = "剩余{0}天";
            this.btn_payed.Name = "btn_payed";
            this.btn_payed.ScreenTip = "软件付费功能剩余天数；";
            this.btn_payed.ShowImage = true;
            this.btn_payed.Visible = false;
            // 
            // btn_test
            // 
            this.btn_test.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_test.Image = global::BIMTWordAddIn.Properties.Resources.settings38;
            this.btn_test.Label = "SettingCenter";
            this.btn_test.Name = "btn_test";
            this.btn_test.ShowImage = true;
            this.btn_test.Visible = false;
            this.btn_test.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_test_Click);
            // 
            // ofd_pic
            // 
            this.ofd_pic.Filter = "图片|*.*";
            this.ofd_pic.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_pic_FileOk);
            // 
            // BIMTRibbon
            // 
            this.Name = "BIMTRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.BIMT);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.BIMTRibbon_Load);
            this.BIMT.ResumeLayout(false);
            this.BIMT.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab BIMT;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_userName;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cb_style;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button11;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button10;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button12;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_payed;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button14;
        private System.Windows.Forms.OpenFileDialog ofd_pic;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button15;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button16;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_checkUpgrade;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button22;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_search;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button23;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_test;
    }

    partial class ThisRibbonCollection
    {
        internal BIMTRibbon BIMTRibbon
        {
            get { return this.GetRibbon<BIMTRibbon>(); }
        }
    }
}
