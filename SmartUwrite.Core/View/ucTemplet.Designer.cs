namespace BIMTClassLibrary
{
    partial class ucTemplet
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
            this.rtb_display = new System.Windows.Forms.RichTextBox();
            this.rtb_values = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_display
            // 
            this.rtb_display.Location = new System.Drawing.Point(49, 3);
            this.rtb_display.Name = "rtb_display";
            this.rtb_display.Size = new System.Drawing.Size(321, 96);
            this.rtb_display.TabIndex = 0;
            this.rtb_display.Text = "";
            // 
            // rtb_values
            // 
            this.rtb_values.Location = new System.Drawing.Point(316, 41);
            this.rtb_values.Name = "rtb_values";
            this.rtb_values.Size = new System.Drawing.Size(100, 96);
            this.rtb_values.TabIndex = 1;
            this.rtb_values.Text = "";
            // 
            // ucTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtb_values);
            this.Controls.Add(this.rtb_display);
            this.Name = "ucTemplet";
            this.Size = new System.Drawing.Size(477, 137);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_display;
        private System.Windows.Forms.RichTextBox rtb_values;
    }
}
