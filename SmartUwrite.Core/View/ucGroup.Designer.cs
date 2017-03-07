namespace BIMTClassLibrary.LearningNote
{
    partial class ucGroup
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
            this.ll_title = new System.Windows.Forms.LinkLabel();
            this.lb_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ll_title
            // 
            this.ll_title.AutoSize = true;
            this.ll_title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_title.LinkColor = System.Drawing.Color.Navy;
            this.ll_title.Location = new System.Drawing.Point(17, 17);
            this.ll_title.Name = "ll_title";
            this.ll_title.Size = new System.Drawing.Size(43, 22);
            this.ll_title.TabIndex = 0;
            this.ll_title.TabStop = true;
            this.ll_title.Text = "title";
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_count.Location = new System.Drawing.Point(77, 21);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(47, 17);
            this.lb_count.TabIndex = 1;
            this.lb_count.Text = "共{0}个";
            // 
            // ucGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.ll_title);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucGroup";
            this.Size = new System.Drawing.Size(936, 189);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ll_title;
        private System.Windows.Forms.Label lb_count;
    }
}
