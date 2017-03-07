namespace BIMTClassLibrary
{
    partial class ucAuthorInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.first = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.last = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.full = new System.Windows.Forms.TextBox();
            this.no = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(81, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // first
            // 
            this.first.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.first.Location = new System.Drawing.Point(155, 5);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(100, 23);
            this.first.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(263, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Last Name:";
            // 
            // last
            // 
            this.last.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.last.Location = new System.Drawing.Point(335, 5);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(100, 23);
            this.last.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(456, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Full Name:";
            // 
            // full
            // 
            this.full.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.full.Location = new System.Drawing.Point(527, 5);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(145, 23);
            this.full.TabIndex = 1;
            // 
            // no
            // 
            this.no.AutoSize = true;
            this.no.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no.Location = new System.Drawing.Point(17, 8);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(51, 17);
            this.no.TabIndex = 2;
            this.no.Text = "第1作者";
            // 
            // ucAuthorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.full);
            this.Controls.Add(this.last);
            this.Controls.Add(this.first);
            this.Controls.Add(this.no);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAuthorInfo";
            this.Size = new System.Drawing.Size(681, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox first;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox last;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox full;
        private System.Windows.Forms.Label no;
    }
}
