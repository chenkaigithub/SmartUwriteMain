namespace BIMTClassLibrary.View
{
    partial class frmRuning
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
            this.lb_message = new System.Windows.Forms.Label();
            this.lb_close = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_message
            // 
            this.lb_message.BackColor = System.Drawing.Color.Transparent;
            this.lb_message.Location = new System.Drawing.Point(-3, 190);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(404, 34);
            this.lb_message.TabIndex = 2;
            this.lb_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_close
            // 
            this.lb_close.BackColor = System.Drawing.Color.Transparent;
            this.lb_close.Location = new System.Drawing.Point(378, 0);
            this.lb_close.Name = "lb_close";
            this.lb_close.Size = new System.Drawing.Size(23, 21);
            this.lb_close.TabIndex = 3;
            this.lb_close.Text = "x";
            this.lb_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_close.Click += new System.EventHandler(this.lb_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BIMTClassLibrary.Properties.Resources.runig4;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmRuning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 224);
            this.Controls.Add(this.lb_close);
            this.Controls.Add(this.lb_message);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRuning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRuning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Label lb_close;
    }
}