namespace BIMTClassLibrary
{
    partial class ucReviewerRecommand
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_pageRange = new System.Windows.Forms.Label();
            this.btn_pageup = new System.Windows.Forms.Button();
            this.btn_pagedown = new System.Windows.Forms.Button();
            this.lab_author_count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pb_loading = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sfd_file = new System.Windows.Forms.SaveFileDialog();
            this.author = new System.Windows.Forms.DataGridViewLinkColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.norecommand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lab_pageRange);
            this.splitContainer1.Panel1.Controls.Add(this.btn_pageup);
            this.splitContainer1.Panel1.Controls.Add(this.btn_pagedown);
            this.splitContainer1.Panel1.Controls.Add(this.lab_author_count);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.pb_loading);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(541, 734);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(278, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "目前只支持英文审稿人推荐";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lab_pageRange
            // 
            this.lab_pageRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_pageRange.Location = new System.Drawing.Point(175, 8);
            this.lab_pageRange.Name = "lab_pageRange";
            this.lab_pageRange.Size = new System.Drawing.Size(49, 26);
            this.lab_pageRange.TabIndex = 11;
            this.lab_pageRange.Text = "0-0";
            this.lab_pageRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_pageup
            // 
            this.btn_pageup.BackColor = System.Drawing.Color.Transparent;
            this.btn_pageup.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.pre;
            this.btn_pageup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_pageup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pageup.ForeColor = System.Drawing.Color.Transparent;
            this.btn_pageup.Location = new System.Drawing.Point(142, 8);
            this.btn_pageup.Name = "btn_pageup";
            this.btn_pageup.Size = new System.Drawing.Size(26, 26);
            this.btn_pageup.TabIndex = 10;
            this.btn_pageup.UseVisualStyleBackColor = false;
            this.btn_pageup.Click += new System.EventHandler(this.btn_pageup_Click);
            // 
            // btn_pagedown
            // 
            this.btn_pagedown.BackColor = System.Drawing.Color.Transparent;
            this.btn_pagedown.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.next;
            this.btn_pagedown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pagedown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pagedown.ForeColor = System.Drawing.Color.Transparent;
            this.btn_pagedown.Location = new System.Drawing.Point(231, 8);
            this.btn_pagedown.Name = "btn_pagedown";
            this.btn_pagedown.Size = new System.Drawing.Size(26, 26);
            this.btn_pagedown.TabIndex = 9;
            this.btn_pagedown.UseVisualStyleBackColor = false;
            this.btn_pagedown.Click += new System.EventHandler(this.btn_pagedown_Click);
            // 
            // lab_author_count
            // 
            this.lab_author_count.AutoSize = true;
            this.lab_author_count.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_author_count.Location = new System.Drawing.Point(105, 13);
            this.lab_author_count.Name = "lab_author_count";
            this.lab_author_count.Size = new System.Drawing.Size(15, 17);
            this.lab_author_count.TabIndex = 1;
            this.lab_author_count.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "推荐审稿人数：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_bg_yinyong;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(436, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "一键导出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb_loading
            // 
            this.pb_loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_loading.Image = global::BIMTClassLibrary.Properties.Resources._476a3bdc992ae227fc3abb0407e4d78d;
            this.pb_loading.Location = new System.Drawing.Point(220, 298);
            this.pb_loading.Name = "pb_loading";
            this.pb_loading.Size = new System.Drawing.Size(100, 97);
            this.pb_loading.TabIndex = 1;
            this.pb_loading.TabStop = false;
            this.pb_loading.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.author,
            this.email,
            this.orag,
            this.recommand,
            this.norecommand});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(541, 693);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // sfd_file
            // 
            this.sfd_file.FileName = "推荐审稿人记录";
            this.sfd_file.Filter = "文本文件|*.txt";
            // 
            // author
            // 
            this.author.DataPropertyName = "author";
            this.author.HeaderText = "作者";
            this.author.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.author.LinkColor = System.Drawing.Color.Teal;
            this.author.Name = "author";
            this.author.ReadOnly = true;
            this.author.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.author.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "邮箱";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // orag
            // 
            this.orag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orag.DataPropertyName = "orag";
            this.orag.HeaderText = "单位";
            this.orag.Name = "orag";
            this.orag.ReadOnly = true;
            // 
            // recommand
            // 
            this.recommand.DataPropertyName = "recommand";
            this.recommand.HeaderText = "推荐审稿人";
            this.recommand.Name = "recommand";
            // 
            // norecommand
            // 
            this.norecommand.DataPropertyName = "norecommand";
            this.norecommand.HeaderText = "回避审稿人";
            this.norecommand.Name = "norecommand";
            // 
            // ucReviewerRecommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucReviewerRecommand";
            this.Size = new System.Drawing.Size(541, 734);
            this.Load += new System.EventHandler(this.ucReviewerRecommand_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog sfd_file;
        private System.Windows.Forms.Label lab_author_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_pageup;
        private System.Windows.Forms.Button btn_pagedown;
        private System.Windows.Forms.Label lab_pageRange;
        private System.Windows.Forms.PictureBox pb_loading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewLinkColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn orag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn recommand;
        private System.Windows.Forms.DataGridViewCheckBoxColumn norecommand;

    }
}
