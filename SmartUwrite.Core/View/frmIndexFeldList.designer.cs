namespace BIMTClassLibrary
{
    partial class frmIndexFeldList
    {

        #region Windows Form Designer generated code

        #endregion

        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.CheckBox ckBlod;
        private System.Windows.Forms.CheckBox ckItalic;
        private System.Windows.Forms.CheckBox ckUnderline;
        private System.Windows.Forms.Panel panel1;
        private void InitializeComponent()
        {
            this.button15 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.ckBlod = new System.Windows.Forms.CheckBox();
            this.ckItalic = new System.Windows.Forms.CheckBox();
            this.ckUnderline = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(95, 23);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "作者";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button1_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(176, 23);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 0;
            this.button17.Text = "出版年";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button1_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(14, 23);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 0;
            this.button39.Text = "序号";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckBlod
            // 
            this.ckBlod.AutoSize = true;
            this.ckBlod.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckBlod.Location = new System.Drawing.Point(19, 22);
            this.ckBlod.Name = "ckBlod";
            this.ckBlod.Size = new System.Drawing.Size(83, 16);
            this.ckBlod.TabIndex = 1;
            this.ckBlod.Text = "粗体（B）";
            this.ckBlod.UseVisualStyleBackColor = true;
            // 
            // ckItalic
            // 
            this.ckItalic.AutoSize = true;
            this.ckItalic.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckItalic.Location = new System.Drawing.Point(115, 22);
            this.ckItalic.Name = "ckItalic";
            this.ckItalic.Size = new System.Drawing.Size(78, 16);
            this.ckItalic.TabIndex = 2;
            this.ckItalic.Text = "斜体（I）";
            this.ckItalic.UseVisualStyleBackColor = true;
            // 
            // ckUnderline
            // 
            this.ckUnderline.AutoSize = true;
            this.ckUnderline.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckUnderline.Location = new System.Drawing.Point(222, 22);
            this.ckUnderline.Name = "ckUnderline";
            this.ckUnderline.Size = new System.Drawing.Size(90, 16);
            this.ckUnderline.TabIndex = 3;
            this.ckUnderline.Text = "下划线（U）";
            this.ckUnderline.UseVisualStyleBackColor = true;
            this.ckUnderline.CheckedChanged += new System.EventHandler(this.ckUnderline_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 166);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button25);
            this.groupBox2.Controls.Add(this.button24);
            this.groupBox2.Controls.Add(this.button23);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button39);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "字段";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckBlod);
            this.groupBox1.Controls.Add(this.ckItalic);
            this.groupBox1.Controls.Add(this.ckUnderline);
            this.groupBox1.Location = new System.Drawing.Point(4, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "样式";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(257, 23);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 1;
            this.button16.Text = "题录类型";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button1_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(338, 23);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 2;
            this.button18.Text = "出版地";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button1_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(14, 52);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 3;
            this.button19.Text = "出版者";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button1_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(338, 52);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 4;
            this.button21.Text = "卷";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button1_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(257, 52);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 23);
            this.button23.TabIndex = 5;
            this.button23.Text = "页码范围";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button1_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(176, 52);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 23);
            this.button24.TabIndex = 6;
            this.button24.Text = "DOI";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button1_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(95, 52);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(75, 23);
            this.button25.TabIndex = 7;
            this.button25.Text = "国家和地区";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button1_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(419, 23);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 8;
            this.button13.Text = "空格";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmIndexFeldList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 166);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIndexFeldList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFeldList";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button13;
    }
}