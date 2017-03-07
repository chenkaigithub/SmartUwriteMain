using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public partial class frmUnderline : Form
    {
        private string _strUnderline;

        public frmUnderline()
        {
            InitializeComponent();
        }

        public frmUnderline(string _strUnderline)
        {
            InitializeComponent();
            this._strUnderline = _strUnderline;
            if (_strUnderline.Trim() == string.Empty)
            {
                richTextBox1.Text = "暂无相关信息";
            }
            else
            {
                richTextBox1.Text = _strUnderline;
            }
        }
    }
}
