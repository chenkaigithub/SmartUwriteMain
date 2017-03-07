namespace BIMTClassLibrary
{
    partial class ucMagazinItem
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
            this.btn_online_submission = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rtb_baseInfo = new System.Windows.Forms.RichTextBox();
            this.rtb_ttile = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_online_submission
            // 
            this.btn_online_submission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_online_submission.BackColor = System.Drawing.Color.Snow;
            this.btn_online_submission.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_bg_yinyong;
            this.btn_online_submission.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_online_submission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_online_submission.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_online_submission.ForeColor = System.Drawing.Color.Transparent;
            this.btn_online_submission.Location = new System.Drawing.Point(399, 86);
            this.btn_online_submission.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_online_submission.Name = "btn_online_submission";
            this.btn_online_submission.Size = new System.Drawing.Size(118, 30);
            this.btn_online_submission.TabIndex = 9;
            this.btn_online_submission.Text = "在线投稿";
            this.btn_online_submission.UseVisualStyleBackColor = false;
            this.btn_online_submission.Visible = false;
            this.btn_online_submission.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.btn_bg_yinyong;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(399, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "绿色通道投稿服务";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button3_Click);
            // 
            // rtb_baseInfo
            // 
            this.rtb_baseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_baseInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.rtb_baseInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_baseInfo.Location = new System.Drawing.Point(12, 37);
            this.rtb_baseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_baseInfo.Name = "rtb_baseInfo";
            this.rtb_baseInfo.Size = new System.Drawing.Size(501, 47);
            this.rtb_baseInfo.TabIndex = 18;
            this.rtb_baseInfo.Text = "e Medicine 出版年：2010作者：罗洁敏,李沛 期刊：World Chinese Medicine 出版年：2010";
            // 
            // rtb_ttile
            // 
            this.rtb_ttile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_ttile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.rtb_ttile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_ttile.Location = new System.Drawing.Point(12, 8);
            this.rtb_ttile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_ttile.Name = "rtb_ttile";
            this.rtb_ttile.Size = new System.Drawing.Size(501, 23);
            this.rtb_ttile.TabIndex = 17;
            this.rtb_ttile.Text = "作者：罗洁敏,李沛 期刊：World Chinese Medicine 出版年：2010";
            // 
            // ucMagazinItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.bg_border1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.rtb_baseInfo);
            this.Controls.Add(this.rtb_ttile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_online_submission);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucMagazinItem";
            this.Size = new System.Drawing.Size(525, 122);
            this.Load += new System.EventHandler(this.ucMagazinItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_online_submission;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtb_baseInfo;
        private System.Windows.Forms.RichTextBox rtb_ttile;
    }
}
