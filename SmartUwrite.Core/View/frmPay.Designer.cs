namespace BIMTClassLibrary.RefreshView
{
    partial class frmPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPay));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_pay = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_done = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_day = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tp_pay.SuspendLayout();
            this.tp_done.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_pay);
            this.tabControl1.Controls.Add(this.tp_done);
            this.tabControl1.Location = new System.Drawing.Point(-2, -21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(516, 393);
            this.tabControl1.TabIndex = 4;
            // 
            // tp_pay
            // 
            this.tp_pay.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.矢量智能对象_拷贝_6;
            this.tp_pay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tp_pay.Controls.Add(this.label1);
            this.tp_pay.Controls.Add(this.button1);
            this.tp_pay.Controls.Add(this.linkLabel1);
            this.tp_pay.Controls.Add(this.label7);
            this.tp_pay.Controls.Add(this.label10);
            this.tp_pay.Controls.Add(this.label9);
            this.tp_pay.Controls.Add(this.label8);
            this.tp_pay.Location = new System.Drawing.Point(4, 22);
            this.tp_pay.Name = "tp_pay";
            this.tp_pay.Padding = new System.Windows.Forms.Padding(3);
            this.tp_pay.Size = new System.Drawing.Size(508, 367);
            this.tp_pay.TabIndex = 0;
            this.tp_pay.Text = "tabPage1";
            this.tp_pay.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.圆角矩形_1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(260, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "支付完成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkCyan;
            this.linkLabel1.Location = new System.Drawing.Point(108, 281);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "暂不付款,以后再说";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(224, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "购买付费版";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(165, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "请在新打开的页面完成付费！";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(117, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "完成付款后请根据您的情况点击下面按钮。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(163, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "付款完成前请不要关闭此窗口,";
            // 
            // tp_done
            // 
            this.tp_done.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.iconfont_wancheng1;
            this.tp_done.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tp_done.Controls.Add(this.label2);
            this.tp_done.Controls.Add(this.label4);
            this.tp_done.Controls.Add(this.lb_day);
            this.tp_done.Controls.Add(this.button3);
            this.tp_done.Controls.Add(this.label6);
            this.tp_done.Location = new System.Drawing.Point(4, 22);
            this.tp_done.Name = "tp_done";
            this.tp_done.Padding = new System.Windows.Forms.Padding(3);
            this.tp_done.Size = new System.Drawing.Size(508, 367);
            this.tp_done.TabIndex = 1;
            this.tp_done.Text = "tabPage2";
            this.tp_done.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(224, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "您已完成购买！";
            // 
            // lb_day
            // 
            this.lb_day.AutoSize = true;
            this.lb_day.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_day.ForeColor = System.Drawing.Color.DimGray;
            this.lb_day.Location = new System.Drawing.Point(192, 192);
            this.lb_day.Name = "lb_day";
            this.lb_day.Size = new System.Drawing.Size(139, 20);
            this.lb_day.TabIndex = 9;
            this.lb_day.Text = "付费剩余天数{0}天。";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.圆角矩形_1;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(183, 267);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "立即使用专业版";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(145, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "您已完成比美特写作助手专业版。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(484, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(485, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 369);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "付费";
            this.tabControl1.ResumeLayout(false);
            this.tp_pay.ResumeLayout(false);
            this.tp_pay.PerformLayout();
            this.tp_done.ResumeLayout(false);
            this.tp_done.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_pay;
        private System.Windows.Forms.TabPage tp_done;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_day;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}