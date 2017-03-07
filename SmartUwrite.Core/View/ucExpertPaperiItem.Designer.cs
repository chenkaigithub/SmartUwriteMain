namespace BIMTClassLibrary
{
    partial class ucExpertPaperiItem
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
            this.rtb_abstract = new System.Windows.Forms.RichTextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_baseInfo = new System.Windows.Forms.TextBox();
            this.lb_title = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // rtb_abstract
            // 
            this.rtb_abstract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.rtb_abstract.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_abstract.Location = new System.Drawing.Point(8, 68);
            this.rtb_abstract.Name = "rtb_abstract";
            this.rtb_abstract.Size = new System.Drawing.Size(509, 144);
            this.rtb_abstract.TabIndex = 0;
            this.rtb_abstract.Text = "";
            // 
            // txt_title
            // 
            this.txt_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.txt_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_title.Location = new System.Drawing.Point(8, 10);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(509, 16);
            this.txt_title.TabIndex = 1;
            this.txt_title.Visible = false;
            this.txt_title.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_baseInfo
            // 
            this.txt_baseInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.txt_baseInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_baseInfo.Location = new System.Drawing.Point(8, 39);
            this.txt_baseInfo.Name = "txt_baseInfo";
            this.txt_baseInfo.Size = new System.Drawing.Size(509, 16);
            this.txt_baseInfo.TabIndex = 1;
            this.txt_baseInfo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.LinkColor = System.Drawing.Color.Teal;
            this.lb_title.Location = new System.Drawing.Point(8, 10);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(55, 17);
            this.lb_title.TabIndex = 2;
            this.lb_title.TabStop = true;
            this.lb_title.Text = "doc_link";
            this.lb_title.Visible = false;
            this.lb_title.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_title_LinkClicked);
            // 
            // ucExpertPaperiItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.txt_baseInfo);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.rtb_abstract);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucExpertPaperiItem";
            this.Size = new System.Drawing.Size(523, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_abstract;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_baseInfo;
        private System.Windows.Forms.LinkLabel lb_title;
    }
}
