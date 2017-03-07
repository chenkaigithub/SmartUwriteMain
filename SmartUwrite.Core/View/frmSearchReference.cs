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
    public partial class frmSearchReference : Form
    {
        private static frmSearchReference _ucSearchReference = null;

        private frmSearchReference()
        {
            InitializeComponent();
        }

        public static frmSearchReference GetInstance() {
            if (_ucSearchReference==null )
            {
                _ucSearchReference = new frmSearchReference();
            }
            return _ucSearchReference;
        }

        private void ucSearchReference_Load(object sender, EventArgs e)
        {

        }

    }
}
