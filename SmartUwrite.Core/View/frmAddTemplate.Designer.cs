namespace BIMTClassLibrary.WordTemplate
{
    partial class frmAddTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTemplate));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_od = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.ofd_template = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "出版物名称：";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(116, 37);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(224, 23);
            this.txt_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "文         件：";
            // 
            // txt_path
            // 
            this.txt_path.Enabled = false;
            this.txt_path.Location = new System.Drawing.Point(116, 77);
            this.txt_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(143, 23);
            this.txt_path.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_od
            // 
            this.btn_od.Location = new System.Drawing.Point(107, 145);
            this.btn_od.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_od.Name = "btn_od";
            this.btn_od.Size = new System.Drawing.Size(75, 26);
            this.btn_od.TabIndex = 2;
            this.btn_od.Text = "完成";
            this.btn_od.UseVisualStyleBackColor = true;
            this.btn_od.Click += new System.EventHandler(this.btn_od_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(188, 145);
            this.btn_cancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 26);
            this.btn_cancle.TabIndex = 2;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // ofd_template
            // 
            this.ofd_template.Filter = "docx|*.docx|doc|*.doc";
            // 
            // frmAddTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 193);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_od);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAddTemplate";
            this.Text = "自建";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_od;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.OpenFileDialog ofd_template;
    }
}