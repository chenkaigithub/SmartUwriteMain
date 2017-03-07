namespace BIMTClassLibrary.View
{
    partial class frmProcess
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pb_output_word = new System.Windows.Forms.ProgressBar();
            this.btn_open_excel = new System.Windows.Forms.Button();
            this.btn_expot_comments = new System.Windows.Forms.Button();
            this.btn_upload_doc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(600, 452);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 472);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志信息";
            // 
            // btn_open
            // 
            this.btn_open.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_open.Location = new System.Drawing.Point(15, 70);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 40);
            this.btn_open.TabIndex = 2;
            this.btn_open.Text = "采集稿件信息";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(367, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "结束word进程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pb_output_word);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "进度";
            // 
            // pb_output_word
            // 
            this.pb_output_word.Location = new System.Drawing.Point(7, 18);
            this.pb_output_word.Name = "pb_output_word";
            this.pb_output_word.Size = new System.Drawing.Size(587, 23);
            this.pb_output_word.TabIndex = 0;
            // 
            // btn_open_excel
            // 
            this.btn_open_excel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_open_excel.Location = new System.Drawing.Point(96, 70);
            this.btn_open_excel.Name = "btn_open_excel";
            this.btn_open_excel.Size = new System.Drawing.Size(75, 40);
            this.btn_open_excel.TabIndex = 2;
            this.btn_open_excel.Text = "生成授权书与意见书";
            this.btn_open_excel.UseVisualStyleBackColor = true;
            this.btn_open_excel.Click += new System.EventHandler(this.btn_open_excel_Click);
            // 
            // btn_expot_comments
            // 
            this.btn_expot_comments.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_expot_comments.Location = new System.Drawing.Point(177, 70);
            this.btn_expot_comments.Name = "btn_expot_comments";
            this.btn_expot_comments.Size = new System.Drawing.Size(75, 40);
            this.btn_expot_comments.TabIndex = 2;
            this.btn_expot_comments.Text = "生成授权书与意见书2";
            this.btn_expot_comments.UseVisualStyleBackColor = true;
            this.btn_expot_comments.Click += new System.EventHandler(this.btn_expot_comments_Click);
            // 
            // btn_upload_doc
            // 
            this.btn_upload_doc.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_upload_doc.Location = new System.Drawing.Point(258, 70);
            this.btn_upload_doc.Name = "btn_upload_doc";
            this.btn_upload_doc.Size = new System.Drawing.Size(75, 40);
            this.btn_upload_doc.TabIndex = 2;
            this.btn_upload_doc.Text = "上传文件";
            this.btn_upload_doc.UseVisualStyleBackColor = true;
            this.btn_upload_doc.Click += new System.EventHandler(this.btn_upload_doc_Click);
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 600);
            this.Controls.Add(this.btn_upload_doc);
            this.Controls.Add(this.btn_expot_comments);
            this.Controls.Add(this.btn_open_excel);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProcess";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出操作";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_open_excel;
        private System.Windows.Forms.ProgressBar pb_output_word;
        private System.Windows.Forms.Button btn_expot_comments;
        private System.Windows.Forms.Button btn_upload_doc;
    }
}