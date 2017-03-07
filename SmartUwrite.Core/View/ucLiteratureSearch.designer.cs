using System;

namespace BIMTClassLibrary
{
    partial class ucLiteratureSearch
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLiteratureSearch));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.domainUpDown5 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown4 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.rb_search = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucFilter8 = new BIMTClassLibrary.ucFilter();
            this.ucFilter7 = new BIMTClassLibrary.ucFilter();
            this.ucFilter6 = new BIMTClassLibrary.ucFilter();
            this.ucFilter5 = new BIMTClassLibrary.ucFilter();
            this.ucFilter4 = new BIMTClassLibrary.ucFilter();
            this.ucFilter3 = new BIMTClassLibrary.ucFilter();
            this.ucFilter2 = new BIMTClassLibrary.ucFilter();
            this.ucFilter1 = new BIMTClassLibrary.ucFilter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "主题词",
            "标题",
            "关键词",
            "作者",
            "摘要",
            "作者单位",
            "日期",
            "DOI",
            "PMID",
            "期刊名称",
            "期刊卷期"});
            this.comboBox1.Location = new System.Drawing.Point(210, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(60, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "主题词";
            // 
            // comboBox2
            // 
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "并含",
            "或含",
            "不含"});
            this.comboBox2.Location = new System.Drawing.Point(278, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(60, 20);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "并含";
            // 
            // comboBox3
            // 
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox3.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "主题词",
            "标题",
            "关键词",
            "作者",
            "摘要",
            "作者单位",
            "日期",
            "DOI",
            "PMID",
            "期刊名称",
            "期刊卷期"});
            this.comboBox3.Location = new System.Drawing.Point(463, 20);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(60, 20);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.Text = "主题词";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(13, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 651);
            this.panel1.TabIndex = 3;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::BIMTClassLibrary.Properties.Resources._476a3bdc992ae227fc3abb0407e4d78d;
            this.pictureBox3.Location = new System.Drawing.Point(202, 277);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 97);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // domainUpDown5
            // 
            this.domainUpDown5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown5.Items.Add("期刊名称↑");
            this.domainUpDown5.Items.Add("期刊名称");
            this.domainUpDown5.Items.Add("期刊名称↓");
            this.domainUpDown5.Location = new System.Drawing.Point(432, 49);
            this.domainUpDown5.Name = "domainUpDown5";
            this.domainUpDown5.ReadOnly = true;
            this.domainUpDown5.Size = new System.Drawing.Size(72, 23);
            this.domainUpDown5.TabIndex = 1;
            this.domainUpDown5.Text = "期刊名称";
            this.domainUpDown5.Visible = false;
            this.domainUpDown5.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown4
            // 
            this.domainUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown4.Items.Add("题目↑");
            this.domainUpDown4.Items.Add("题目");
            this.domainUpDown4.Items.Add("题目↓");
            this.domainUpDown4.Items.Add("");
            this.domainUpDown4.Location = new System.Drawing.Point(346, 49);
            this.domainUpDown4.Name = "domainUpDown4";
            this.domainUpDown4.ReadOnly = true;
            this.domainUpDown4.Size = new System.Drawing.Size(72, 23);
            this.domainUpDown4.TabIndex = 1;
            this.domainUpDown4.Text = "题目";
            this.domainUpDown4.Visible = false;
            this.domainUpDown4.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown3
            // 
            this.domainUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown3.Items.Add("作者↑");
            this.domainUpDown3.Items.Add("作者");
            this.domainUpDown3.Items.Add("作者↓");
            this.domainUpDown3.Location = new System.Drawing.Point(260, 49);
            this.domainUpDown3.Name = "domainUpDown3";
            this.domainUpDown3.ReadOnly = true;
            this.domainUpDown3.Size = new System.Drawing.Size(72, 23);
            this.domainUpDown3.TabIndex = 1;
            this.domainUpDown3.Text = "作者";
            this.domainUpDown3.Visible = false;
            this.domainUpDown3.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown2.Items.Add("出版日期↑");
            this.domainUpDown2.Items.Add("出版日期");
            this.domainUpDown2.Items.Add("出版日期↓");
            this.domainUpDown2.Location = new System.Drawing.Point(181, 48);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.ReadOnly = true;
            this.domainUpDown2.Size = new System.Drawing.Size(72, 23);
            this.domainUpDown2.TabIndex = 1;
            this.domainUpDown2.Text = "出版日期";
            this.domainUpDown2.Visible = false;
            this.domainUpDown2.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            this.domainUpDown2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.domainUpDown2_MouseClick);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown1.Location = new System.Drawing.Point(88, 49);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.ReadOnly = true;
            this.domainUpDown1.Size = new System.Drawing.Size(72, 23);
            this.domainUpDown1.TabIndex = 1;
            this.domainUpDown1.Text = "收藏日期";
            this.domainUpDown1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(93, 19);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(117, 22);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(346, 19);
            this.richTextBox2.Multiline = false;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(117, 22);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.domainUpDown1);
            this.panel2.Controls.Add(this.domainUpDown2);
            this.panel2.Controls.Add(this.domainUpDown3);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.domainUpDown4);
            this.panel2.Controls.Add(this.domainUpDown5);
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 688);
            this.panel2.TabIndex = 10;
            this.panel2.SizeChanged += new System.EventHandler(this.panel2_SizeChanged);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_soucangriqi_huise;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.ImageIndex = 2;
            this.button6.Location = new System.Drawing.Point(339, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 27);
            this.button6.TabIndex = 17;
            this.button6.Tag = "-1";
            this.button6.Text = "匹 配 度   ";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_soucangriqi_huise;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.ImageIndex = 0;
            this.button7.Location = new System.Drawing.Point(252, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 27);
            this.button7.TabIndex = 17;
            this.button7.Tag = "-1";
            this.button7.Text = "出版日期";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(317, 660);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(138, 660);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "上一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 665);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "页码";
            this.label2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDown1.Location = new System.Drawing.Point(250, 661);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.pre;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(156, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 6;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.next;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(188, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_query
            // 
            this.btn_query.BackColor = System.Drawing.Color.Transparent;
            this.btn_query.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_bg_yinyong1;
            this.btn_query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.Color.White;
            this.btn_query.Location = new System.Drawing.Point(426, 6);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(82, 27);
            this.btn_query.TabIndex = 6;
            this.btn_query.Text = "搜   索";
            this.btn_query.UseVisualStyleBackColor = false;
            this.btn_query.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_search
            // 
            this.rb_search.AutoSize = true;
            this.rb_search.Checked = true;
            this.rb_search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_search.Location = new System.Drawing.Point(257, 0);
            this.rb_search.Name = "rb_search";
            this.rb_search.Size = new System.Drawing.Size(62, 21);
            this.rb_search.TabIndex = 15;
            this.rb_search.TabStop = true;
            this.rb_search.Text = "匹配度";
            this.rb_search.UseVisualStyleBackColor = true;
            this.rb_search.Visible = false;
            this.rb_search.CheckedChanged += new System.EventHandler(this.rb_search_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn_shoucangriqi_down.png");
            this.imageList1.Images.SetKeyName(1, "btn_soucangriqi_huise.png");
            this.imageList1.Images.SetKeyName(2, "btn_soucanriqi_up.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BIMTClassLibrary.Properties.Resources.减号;
            this.pictureBox2.Location = new System.Drawing.Point(56, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::BIMTClassLibrary.Properties.Resources.加号;
            this.pictureBox1.Image = global::BIMTClassLibrary.Properties.Resources.加号;
            this.pictureBox1.Location = new System.Drawing.Point(21, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ucFilter8
            // 
            this.ucFilter8.Location = new System.Drawing.Point(19, 297);
            this.ucFilter8.Name = "ucFilter8";
            this.ucFilter8.Size = new System.Drawing.Size(511, 36);
            this.ucFilter8.TabIndex = 9;
            // 
            // ucFilter7
            // 
            this.ucFilter7.Location = new System.Drawing.Point(19, 261);
            this.ucFilter7.Name = "ucFilter7";
            this.ucFilter7.Size = new System.Drawing.Size(511, 36);
            this.ucFilter7.TabIndex = 9;
            // 
            // ucFilter6
            // 
            this.ucFilter6.Location = new System.Drawing.Point(19, 225);
            this.ucFilter6.Name = "ucFilter6";
            this.ucFilter6.Size = new System.Drawing.Size(511, 36);
            this.ucFilter6.TabIndex = 9;
            // 
            // ucFilter5
            // 
            this.ucFilter5.Location = new System.Drawing.Point(19, 189);
            this.ucFilter5.Name = "ucFilter5";
            this.ucFilter5.Size = new System.Drawing.Size(511, 36);
            this.ucFilter5.TabIndex = 9;
            // 
            // ucFilter4
            // 
            this.ucFilter4.Location = new System.Drawing.Point(19, 153);
            this.ucFilter4.Name = "ucFilter4";
            this.ucFilter4.Size = new System.Drawing.Size(511, 36);
            this.ucFilter4.TabIndex = 9;
            // 
            // ucFilter3
            // 
            this.ucFilter3.Location = new System.Drawing.Point(19, 117);
            this.ucFilter3.Name = "ucFilter3";
            this.ucFilter3.Size = new System.Drawing.Size(511, 36);
            this.ucFilter3.TabIndex = 9;
            // 
            // ucFilter2
            // 
            this.ucFilter2.Location = new System.Drawing.Point(19, 81);
            this.ucFilter2.Name = "ucFilter2";
            this.ucFilter2.Size = new System.Drawing.Size(511, 36);
            this.ucFilter2.TabIndex = 9;
            // 
            // ucFilter1
            // 
            this.ucFilter1.Location = new System.Drawing.Point(19, 45);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(511, 36);
            this.ucFilter1.TabIndex = 9;
            // 
            // ucLiteratureSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rb_search);
            this.Controls.Add(this.ucFilter8);
            this.Controls.Add(this.ucFilter7);
            this.Controls.Add(this.ucFilter6);
            this.Controls.Add(this.ucFilter5);
            this.Controls.Add(this.ucFilter4);
            this.Controls.Add(this.ucFilter3);
            this.Controls.Add(this.ucFilter2);
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucLiteratureSearch";
            this.Size = new System.Drawing.Size(541, 734);
            this.Load += new System.EventHandler(this.ucLiteratureSearch_Load);
            this.SizeChanged += new System.EventHandler(this.ucLiteratureSearch_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.DomainUpDown domainUpDown5;
        private System.Windows.Forms.DomainUpDown domainUpDown4;
        private System.Windows.Forms.DomainUpDown domainUpDown3;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private ucFilter ucFilter1;
        private ucFilter ucFilter2;
        private System.Windows.Forms.Panel panel2;
        private ucFilter ucFilter3;
        private ucFilter ucFilter4;
        private ucFilter ucFilter5;
        private ucFilter ucFilter6;
        private ucFilter ucFilter7;
        private ucFilter ucFilter8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton rb_search;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button6;
    }
}
