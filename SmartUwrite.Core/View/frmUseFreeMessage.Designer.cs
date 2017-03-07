namespace BIMTClassLibrary.View
{
    partial class frmUseFreeMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUseFreeMessage));
            this.btn_buy = new System.Windows.Forms.Button();
            this.btn_usefree = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buy
            // 
            this.btn_buy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buy.BackgroundImage")));
            this.btn_buy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buy.ForeColor = System.Drawing.Color.White;
            this.btn_buy.Location = new System.Drawing.Point(195, 296);
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(97, 27);
            this.btn_buy.TabIndex = 0;
            this.btn_buy.Text = "立即购买";
            this.btn_buy.UseVisualStyleBackColor = true;
            this.btn_buy.Visible = false;
            this.btn_buy.Click += new System.EventHandler(this.btn_buy_Click);
            // 
            // btn_usefree
            // 
            this.btn_usefree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_usefree.BackgroundImage")));
            this.btn_usefree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_usefree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_usefree.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_usefree.ForeColor = System.Drawing.Color.White;
            this.btn_usefree.Location = new System.Drawing.Point(346, 323);
            this.btn_usefree.Name = "btn_usefree";
            this.btn_usefree.Size = new System.Drawing.Size(100, 31);
            this.btn_usefree.TabIndex = 0;
            this.btn_usefree.Text = "继续试用";
            this.btn_usefree.UseVisualStyleBackColor = true;
            this.btn_usefree.Click += new System.EventHandler(this.btn_usefree_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BIMTClassLibrary.Properties.Resources.charge_function;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lb_info
            // 
            this.lb_info.BackColor = System.Drawing.Color.Transparent;
            this.lb_info.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info.Location = new System.Drawing.Point(35, 321);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(189, 34);
            this.lb_info.TabIndex = 2;
            this.lb_info.Text = "您还有{0}次试用机会！";
            this.lb_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmUseFreeMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BIMTClassLibrary.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(508, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_usefree);
            this.Controls.Add(this.btn_buy);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUseFreeMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUseFreeMessage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buy;
        private System.Windows.Forms.Button btn_usefree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Label label1;
    }
}