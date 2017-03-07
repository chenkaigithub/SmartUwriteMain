namespace BIMTClassLibrary
{
    partial class frmSendEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.add = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.ofd_file = new System.Windows.Forms.OpenFileDialog();
            this.option1 = new System.Windows.Forms.Button();
            this.option2 = new System.Windows.Forms.Button();
            this.option3 = new System.Windows.Forms.Button();
            this.option4 = new System.Windows.Forms.Button();
            this.option5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "主题：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(58, 18);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(436, 23);
            this.txt_title.TabIndex = 1;
            // 
            // rtb_content
            // 
            this.rtb_content.Location = new System.Drawing.Point(8, 58);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(567, 395);
            this.rtb_content.TabIndex = 2;
            this.rtb_content.Text = "";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(754, -8);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 27);
            this.add.TabIndex = 3;
            this.add.Text = "添加附件";
            this.add.UseVisualStyleBackColor = true;
            this.add.Visible = false;
            this.add.Click += new System.EventHandler(this.button1_Click);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(500, 16);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 27);
            this.send.TabIndex = 3;
            this.send.Text = "发送";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // option1
            // 
            this.option1.Dock = System.Windows.Forms.DockStyle.Left;
            this.option1.Location = new System.Drawing.Point(324, 0);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(108, 27);
            this.option1.TabIndex = 4;
            this.option1.Text = "附件1";
            this.option1.UseVisualStyleBackColor = true;
            this.option1.Visible = false;
            this.option1.Click += new System.EventHandler(this.button3_Click);
            // 
            // option2
            // 
            this.option2.Dock = System.Windows.Forms.DockStyle.Left;
            this.option2.Location = new System.Drawing.Point(108, 0);
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(108, 27);
            this.option2.TabIndex = 4;
            this.option2.Text = "附件2";
            this.option2.UseVisualStyleBackColor = true;
            this.option2.Visible = false;
            this.option2.Click += new System.EventHandler(this.button3_Click);
            // 
            // option3
            // 
            this.option3.Dock = System.Windows.Forms.DockStyle.Left;
            this.option3.Location = new System.Drawing.Point(0, 0);
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(108, 27);
            this.option3.TabIndex = 4;
            this.option3.Text = "附件3";
            this.option3.UseVisualStyleBackColor = true;
            this.option3.Visible = false;
            this.option3.Click += new System.EventHandler(this.button3_Click);
            // 
            // option4
            // 
            this.option4.Dock = System.Windows.Forms.DockStyle.Left;
            this.option4.Location = new System.Drawing.Point(216, 0);
            this.option4.Name = "option4";
            this.option4.Size = new System.Drawing.Size(108, 27);
            this.option4.TabIndex = 4;
            this.option4.Text = "附件4";
            this.option4.UseVisualStyleBackColor = true;
            this.option4.Visible = false;
            this.option4.Click += new System.EventHandler(this.button3_Click);
            // 
            // option5
            // 
            this.option5.Dock = System.Windows.Forms.DockStyle.Left;
            this.option5.Location = new System.Drawing.Point(432, 0);
            this.option5.Name = "option5";
            this.option5.Size = new System.Drawing.Size(108, 27);
            this.option5.TabIndex = 4;
            this.option5.Text = "附件5";
            this.option5.UseVisualStyleBackColor = true;
            this.option5.Visible = false;
            this.option5.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.option5);
            this.panel1.Controls.Add(this.option1);
            this.panel1.Controls.Add(this.option4);
            this.panel1.Controls.Add(this.option2);
            this.panel1.Controls.Add(this.option3);
            this.panel1.Location = new System.Drawing.Point(39, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 27);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(567, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "我们会及时处理每一位用户的反馈，您提出的每一份意见和建议都是我们提高的动力，我们会对提出5条以上建设性意见和建议的用户给予一定的积分感谢，您可以在我们的平台折抵现" +
    "金进行消费。";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(567, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "您也可以联系我们的客服（QQ 4006120585；Tel 4006-120-585）";
            // 
            // frmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.send);
            this.Controls.Add(this.add);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发送消息";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.OpenFileDialog ofd_file;
        private System.Windows.Forms.Button option1;
        private System.Windows.Forms.Button option2;
        private System.Windows.Forms.Button option3;
        private System.Windows.Forms.Button option4;
        private System.Windows.Forms.Button option5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}