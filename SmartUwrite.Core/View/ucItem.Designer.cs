namespace BIMTClassLibrary.LearningNote
{
    partial class ucItem
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.btn_star = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_del);
            this.splitContainer1.Panel1.Controls.Add(this.btn_star);
            this.splitContainer1.Panel1.Controls.Add(this.lb_time);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(928, 282);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.pb_image);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtb_content);
            this.splitContainer2.Size = new System.Drawing.Size(928, 237);
            this.splitContainer2.SplitterDistance = 158;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // pb_image
            // 
            this.pb_image.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_image.Location = new System.Drawing.Point(0, 0);
            this.pb_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(928, 124);
            this.pb_image.TabIndex = 0;
            this.pb_image.TabStop = false;
            // 
            // rtb_content
            // 
            this.rtb_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_content.Location = new System.Drawing.Point(0, 0);
            this.rtb_content.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(928, 74);
            this.rtb_content.TabIndex = 0;
            this.rtb_content.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片笔记";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(89, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(705, 12);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(63, 17);
            this.lb_time.TabIndex = 2;
            this.lb_time.Text = "DateTime";
            // 
            // btn_star
            // 
            this.btn_star.Location = new System.Drawing.Point(788, 8);
            this.btn_star.Name = "btn_star";
            this.btn_star.Size = new System.Drawing.Size(44, 24);
            this.btn_star.TabIndex = 3;
            this.btn_star.Text = "star";
            this.btn_star.UseVisualStyleBackColor = true;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(838, 8);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(44, 24);
            this.btn_del.TabIndex = 3;
            this.btn_del.Text = "del";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // ucItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucItem";
            this.Size = new System.Drawing.Size(928, 282);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_star;
    }
}
