using System;

namespace BIMTClassLibrary
{
    partial class ucLiteratureRecommend
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.domainUpDown5 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown4 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(4, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 673);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::BIMTClassLibrary.Properties.Resources._476a3bdc992ae227fc3abb0407e4d78d;
            this.pictureBox1.Location = new System.Drawing.Point(212, 287);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "0 match";
            // 
            // domainUpDown5
            // 
            this.domainUpDown5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown5.Items.Add("期刊名称↑");
            this.domainUpDown5.Items.Add("期刊名称");
            this.domainUpDown5.Items.Add("期刊名称↓");
            this.domainUpDown5.Location = new System.Drawing.Point(446, 58);
            this.domainUpDown5.Name = "domainUpDown5";
            this.domainUpDown5.ReadOnly = true;
            this.domainUpDown5.Size = new System.Drawing.Size(80, 23);
            this.domainUpDown5.TabIndex = 1;
            this.domainUpDown5.Text = "期刊名称";
            this.domainUpDown5.Visible = false;
            this.domainUpDown5.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown4
            // 
            this.domainUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown4.Items.Add("题目↑");
            this.domainUpDown4.Items.Add("题目");
            this.domainUpDown4.Items.Add("题目↓");
            this.domainUpDown4.Location = new System.Drawing.Point(370, 58);
            this.domainUpDown4.Name = "domainUpDown4";
            this.domainUpDown4.ReadOnly = true;
            this.domainUpDown4.Size = new System.Drawing.Size(80, 23);
            this.domainUpDown4.TabIndex = 1;
            this.domainUpDown4.Text = "题目";
            this.domainUpDown4.Visible = false;
            this.domainUpDown4.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown3
            // 
            this.domainUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown3.Items.Add("作者↑");
            this.domainUpDown3.Items.Add("作者");
            this.domainUpDown3.Items.Add("作者↓");
            this.domainUpDown3.Location = new System.Drawing.Point(284, 58);
            this.domainUpDown3.Name = "domainUpDown3";
            this.domainUpDown3.ReadOnly = true;
            this.domainUpDown3.Size = new System.Drawing.Size(80, 23);
            this.domainUpDown3.TabIndex = 1;
            this.domainUpDown3.Text = "作者";
            this.domainUpDown3.Visible = false;
            this.domainUpDown3.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.domainUpDown2.Items.Add("出版日期↑");
            this.domainUpDown2.Items.Add("出版日期");
            this.domainUpDown2.Items.Add("出版日期↓");
            this.domainUpDown2.Location = new System.Drawing.Point(198, 58);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.ReadOnly = true;
            this.domainUpDown2.Size = new System.Drawing.Size(80, 23);
            this.domainUpDown2.TabIndex = 1;
            this.domainUpDown2.Text = "出版日期";
            this.domainUpDown2.Visible = false;
            this.domainUpDown2.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 686);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "页码";
            this.label2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(253, 682);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "▼标题";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(457, 9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(50, 21);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "降序";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(402, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 21);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "升序";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(335, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "出版日期：";
            // 
            // ucLiteratureRecommend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.domainUpDown5);
            this.Controls.Add(this.domainUpDown4);
            this.Controls.Add(this.domainUpDown3);
            this.Controls.Add(this.domainUpDown2);
            this.Name = "ucLiteratureRecommend";
            this.Size = new System.Drawing.Size(541, 708);
            this.Load += new System.EventHandler(this.ucLiteratureSearch_Load);
            this.SizeChanged += new System.EventHandler(this.ucLiteratureSearch_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DomainUpDown domainUpDown5;
        private System.Windows.Forms.DomainUpDown domainUpDown4;
        private System.Windows.Forms.DomainUpDown domainUpDown3;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
