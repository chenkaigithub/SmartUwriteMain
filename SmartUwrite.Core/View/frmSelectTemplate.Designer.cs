namespace BIMTClassLibrary.WordTemplete
{
    partial class frmSelectTemplate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectTemplate));
            this.dgv_template = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ifvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_export = new System.Windows.Forms.Button();
            this.lb_count = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_od = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lL_create = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.ofd_template = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_template)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_template
            // 
            this.dgv_template.AllowUserToAddRows = false;
            this.dgv_template.AllowUserToDeleteRows = false;
            this.dgv_template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_template.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.level,
            this.ifvalue,
            this.templateUrl,
            this.id,
            this.quotationName,
            this.quotationUrl,
            this.templateName,
            this.text});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_template.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_template.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_template.Location = new System.Drawing.Point(0, 0);
            this.dgv_template.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_template.Name = "dgv_template";
            this.dgv_template.ReadOnly = true;
            this.dgv_template.RowHeadersWidth = 11;
            this.dgv_template.RowTemplate.Height = 23;
            this.dgv_template.Size = new System.Drawing.Size(760, 464);
            this.dgv_template.TabIndex = 0;
            this.dgv_template.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_template_CellContentClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "期刊名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // level
            // 
            this.level.DataPropertyName = "level";
            this.level.HeaderText = "级别";
            this.level.Name = "level";
            this.level.ReadOnly = true;
            // 
            // ifvalue
            // 
            this.ifvalue.DataPropertyName = "ifvalue";
            this.ifvalue.HeaderText = "影响因子";
            this.ifvalue.Name = "ifvalue";
            this.ifvalue.ReadOnly = true;
            // 
            // templateUrl
            // 
            this.templateUrl.DataPropertyName = "templateUrl";
            this.templateUrl.HeaderText = "templateUrl";
            this.templateUrl.Name = "templateUrl";
            this.templateUrl.ReadOnly = true;
            this.templateUrl.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // quotationName
            // 
            this.quotationName.DataPropertyName = "quotationName";
            this.quotationName.HeaderText = "样式名称";
            this.quotationName.Name = "quotationName";
            this.quotationName.ReadOnly = true;
            this.quotationName.Visible = false;
            // 
            // quotationUrl
            // 
            this.quotationUrl.DataPropertyName = "quotationUrl";
            this.quotationUrl.HeaderText = "样式链接";
            this.quotationUrl.Name = "quotationUrl";
            this.quotationUrl.ReadOnly = true;
            this.quotationUrl.Visible = false;
            // 
            // templateName
            // 
            this.templateName.DataPropertyName = "templateName";
            this.templateName.HeaderText = "templateName";
            this.templateName.Name = "templateName";
            this.templateName.ReadOnly = true;
            this.templateName.Visible = false;
            // 
            // text
            // 
            this.text.DataPropertyName = "text";
            this.text.HeaderText = "投稿模板";
            this.text.Name = "text";
            this.text.ReadOnly = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_cancle);
            this.splitContainer1.Panel2.Controls.Add(this.btn_od);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_path);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lL_create);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 532);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_export);
            this.splitContainer2.Panel1.Controls.Add(this.lb_count);
            this.splitContainer2.Panel1.Controls.Add(this.txt_name);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_template);
            this.splitContainer2.Size = new System.Drawing.Size(760, 500);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(673, 6);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 26);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Visible = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(524, 8);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(0, 17);
            this.lb_count.TabIndex = 2;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(50, 6);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(404, 23);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索:";
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(445, 65);
            this.btn_cancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 26);
            this.btn_cancle.TabIndex = 7;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_od
            // 
            this.btn_od.Location = new System.Drawing.Point(445, 30);
            this.btn_od.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_od.Name = "btn_od";
            this.btn_od.Size = new System.Drawing.Size(75, 26);
            this.btn_od.TabIndex = 8;
            this.btn_od.Text = "确定";
            this.btn_od.UseVisualStyleBackColor = true;
            this.btn_od.Click += new System.EventHandler(this.btn_od_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(115, 67);
            this.txt_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(324, 23);
            this.txt_path.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "官网地址：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "期刊全称：";
            // 
            // lL_create
            // 
            this.lL_create.AutoSize = true;
            this.lL_create.Location = new System.Drawing.Point(210, 5);
            this.lL_create.Name = "lL_create";
            this.lL_create.Size = new System.Drawing.Size(68, 17);
            this.lL_create.TabIndex = 1;
            this.lL_create.TabStop = true;
            this.lL_create.Text = "向我们反馈";
            this.lL_create.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lL_create_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "如果以上没有所需期刊，您可以          。";
            // 
            // ofd_template
            // 
            this.ofd_template.Filter = "docx|*.docx|doc|*.doc";
            // 
            // frmSelectTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 532);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectTemplate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择要出版的投稿物";
            this.Load += new System.EventHandler(this.frmSelectTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_template)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_template;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lL_create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_od;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofd_template;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn level;
        private System.Windows.Forms.DataGridViewTextBoxColumn ifvalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.Button btn_export;
    }
}