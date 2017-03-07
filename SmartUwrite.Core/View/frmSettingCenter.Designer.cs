namespace BIMTClassLibrary.View
{
    partial class frmSettingCenter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingCenter));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_bucket = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.rb_x86 = new System.Windows.Forms.RadioButton();
            this.rb_x64 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listFile = new System.Windows.Forms.ListBox();
            this.btn_del_file = new System.Windows.Forms.Button();
            this.btn_upload_file = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_de = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_Info = new System.Windows.Forms.RichTextBox();
            this.pb_runing = new System.Windows.Forms.ProgressBar();
            this.rb_proxy = new System.Windows.Forms.RadioButton();
            this.rb_styles = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 179);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 402);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btn_del_file);
            this.tabPage1.Controls.Add(this.btn_upload_file);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(832, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "软件更新";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_bucket);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 231);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bucket";
            // 
            // cmb_bucket
            // 
            this.cmb_bucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_bucket.FormattingEnabled = true;
            this.cmb_bucket.Items.AddRange(new object[] {
            "bimt-smartuwrite",
            "smartuwrite-for-x86-office",
            "smartuwrite-for-x64-office"});
            this.cmb_bucket.Location = new System.Drawing.Point(55, 22);
            this.cmb_bucket.Name = "cmb_bucket";
            this.cmb_bucket.Size = new System.Drawing.Size(299, 25);
            this.cmb_bucket.TabIndex = 0;
            this.cmb_bucket.SelectedIndexChanged += new System.EventHandler(this.cmb_bucket_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rb_all);
            this.groupBox5.Controls.Add(this.rb_x86);
            this.groupBox5.Controls.Add(this.rb_styles);
            this.groupBox5.Controls.Add(this.rb_proxy);
            this.groupBox5.Controls.Add(this.rb_x64);
            this.groupBox5.Location = new System.Drawing.Point(6, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 177);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Folder";
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(15, 33);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(40, 21);
            this.rb_all.TabIndex = 0;
            this.rb_all.Text = "All";
            this.rb_all.UseVisualStyleBackColor = true;
            this.rb_all.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_x86
            // 
            this.rb_x86.AutoSize = true;
            this.rb_x86.Checked = true;
            this.rb_x86.Location = new System.Drawing.Point(15, 60);
            this.rb_x86.Name = "rb_x86";
            this.rb_x86.Size = new System.Drawing.Size(181, 21);
            this.rb_x86.TabIndex = 0;
            this.rb_x86.TabStop = true;
            this.rb_x86.Text = "SmartUwrite_for_x86_office";
            this.rb_x86.UseVisualStyleBackColor = true;
            this.rb_x86.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_x64
            // 
            this.rb_x64.AutoSize = true;
            this.rb_x64.Location = new System.Drawing.Point(15, 87);
            this.rb_x64.Name = "rb_x64";
            this.rb_x64.Size = new System.Drawing.Size(181, 21);
            this.rb_x64.TabIndex = 0;
            this.rb_x64.Text = "SmartUwrite_for_x64_office";
            this.rb_x64.UseVisualStyleBackColor = true;
            this.rb_x64.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listFile);
            this.groupBox2.Location = new System.Drawing.Point(413, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 167);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FileList";
            // 
            // listFile
            // 
            this.listFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFile.FormattingEnabled = true;
            this.listFile.ItemHeight = 17;
            this.listFile.Location = new System.Drawing.Point(3, 19);
            this.listFile.Name = "listFile";
            this.listFile.Size = new System.Drawing.Size(405, 145);
            this.listFile.TabIndex = 4;
            // 
            // btn_del_file
            // 
            this.btn_del_file.Location = new System.Drawing.Point(413, 212);
            this.btn_del_file.Name = "btn_del_file";
            this.btn_del_file.Size = new System.Drawing.Size(75, 26);
            this.btn_del_file.TabIndex = 1;
            this.btn_del_file.Text = "删除";
            this.btn_del_file.UseVisualStyleBackColor = true;
            this.btn_del_file.Click += new System.EventHandler(this.btn_del_file_Click);
            // 
            // btn_upload_file
            // 
            this.btn_upload_file.Location = new System.Drawing.Point(413, 180);
            this.btn_upload_file.Name = "btn_upload_file";
            this.btn_upload_file.Size = new System.Drawing.Size(75, 26);
            this.btn_upload_file.TabIndex = 1;
            this.btn_upload_file.Text = "上传";
            this.btn_upload_file.UseVisualStyleBackColor = true;
            this.btn_upload_file.Click += new System.EventHandler(this.btn_upload_file_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(832, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "加密";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_de);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(8, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(816, 97);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Encrypt";
            // 
            // btn_de
            // 
            this.btn_de.Location = new System.Drawing.Point(89, 34);
            this.btn_de.Name = "btn_de";
            this.btn_de.Size = new System.Drawing.Size(75, 26);
            this.btn_de.TabIndex = 2;
            this.btn_de.Text = "解密";
            this.btn_de.UseVisualStyleBackColor = true;
            this.btn_de.Click += new System.EventHandler(this.btn_de_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "加密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lb_Info);
            this.groupBox3.Location = new System.Drawing.Point(4, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 134);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // lb_Info
            // 
            this.lb_Info.BackColor = System.Drawing.Color.Black;
            this.lb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Info.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Info.ForeColor = System.Drawing.Color.LimeGreen;
            this.lb_Info.Location = new System.Drawing.Point(3, 19);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(826, 112);
            this.lb_Info.TabIndex = 0;
            this.lb_Info.Text = "";
            // 
            // pb_runing
            // 
            this.pb_runing.Location = new System.Drawing.Point(4, 149);
            this.pb_runing.Name = "pb_runing";
            this.pb_runing.Size = new System.Drawing.Size(832, 23);
            this.pb_runing.TabIndex = 7;
            // 
            // rb_proxy
            // 
            this.rb_proxy.AutoSize = true;
            this.rb_proxy.Location = new System.Drawing.Point(15, 114);
            this.rb_proxy.Name = "rb_proxy";
            this.rb_proxy.Size = new System.Drawing.Size(59, 21);
            this.rb_proxy.TabIndex = 0;
            this.rb_proxy.Text = "proxy";
            this.rb_proxy.UseVisualStyleBackColor = true;
            this.rb_proxy.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_styles
            // 
            this.rb_styles.AutoSize = true;
            this.rb_styles.Location = new System.Drawing.Point(15, 141);
            this.rb_styles.Name = "rb_styles";
            this.rb_styles.Size = new System.Drawing.Size(58, 21);
            this.rb_styles.TabIndex = 0;
            this.rb_styles.Text = "styles";
            this.rb_styles.UseVisualStyleBackColor = true;
            this.rb_styles.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // frmSettingCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 581);
            this.Controls.Add(this.pb_runing);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettingCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置中心";
            this.Load += new System.EventHandler(this.frmSettingCenter_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmb_bucket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listFile;
        private System.Windows.Forms.Button btn_del_file;
        private System.Windows.Forms.Button btn_upload_file;
        private System.Windows.Forms.Button btn_de;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox lb_Info;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rb_x86;
        private System.Windows.Forms.RadioButton rb_x64;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.ProgressBar pb_runing;
        private System.Windows.Forms.RadioButton rb_styles;
        private System.Windows.Forms.RadioButton rb_proxy;
    }
}