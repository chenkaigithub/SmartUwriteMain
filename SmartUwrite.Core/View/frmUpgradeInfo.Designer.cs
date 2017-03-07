namespace BIMTClassLibrary.upgrade
{
    partial class frmUpgradeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpgradeInfo));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ck_ignore = new System.Windows.Forms.CheckBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_upgrade = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ck_ignore);
            this.splitContainer1.Panel2.Controls.Add(this.btn_close);
            this.splitContainer1.Panel2.Controls.Add(this.btn_upgrade);
            this.splitContainer1.Size = new System.Drawing.Size(562, 383);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 1;
            // 
            // ck_ignore
            // 
            this.ck_ignore.AutoSize = true;
            this.ck_ignore.Location = new System.Drawing.Point(377, 7);
            this.ck_ignore.Name = "ck_ignore";
            this.ck_ignore.Size = new System.Drawing.Size(84, 24);
            this.ck_ignore.TabIndex = 1;
            this.ck_ignore.Text = "不再提示";
            this.ck_ignore.UseVisualStyleBackColor = true;
            this.ck_ignore.CheckedChanged += new System.EventHandler(this.ck_ignore_CheckedChanged);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(157, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(88, 28);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "忽略此版本";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Visible = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_upgrade
            // 
            this.btn_upgrade.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upgrade.Location = new System.Drawing.Point(467, 4);
            this.btn_upgrade.Name = "btn_upgrade";
            this.btn_upgrade.Size = new System.Drawing.Size(88, 28);
            this.btn_upgrade.TabIndex = 0;
            this.btn_upgrade.Text = "下载更新";
            this.btn_upgrade.UseVisualStyleBackColor = true;
            this.btn_upgrade.Click += new System.EventHandler(this.btn_upgrade_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(562, 341);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // frmUpgradeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 383);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUpgradeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartUwirte有新版本啦！！！";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_upgrade;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.CheckBox ck_ignore;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}