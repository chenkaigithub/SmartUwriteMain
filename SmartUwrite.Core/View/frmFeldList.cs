using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public partial class frmFeldList : Form
    {
        private frmTempletManager frmTempletManager;
        private int p;

        //private frmTempletManager frmTempletManager;

        public frmFeldList()
        {
            InitializeComponent();
        }

        public frmFeldList(frmTempletManager frmTempletManager)
        {
            // TODO: Complete member initialization
            this.frmTempletManager = frmTempletManager;
            InitializeComponent();
        }

        public frmFeldList(BIMTClassLibrary.frmTempletManager frmTempletManager, int p)
        {
            // TODO: Complete member initialization
            this.frmTempletManager = frmTempletManager;
            this.p = p;
            InitializeComponent();
        }

        //public frmFeldList(frmTempletManager frmTempletManager)
        //{
        //    this.frmTempletManager = frmTempletManager;
        //}

     

        private void button1_Click(object sender, EventArgs e)
        {
            string _strResult = FixValue((Button)sender);
            frmTempletManager.SetTempletField(_strResult);
            this.FindForm().Close();
        }

        /// <summary>
        /// 粗体值为1；斜体3；下划线5
        /// 在末尾加上数字以标识此字段是否带有样式
        /// 2016-04-06
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private string FixValue(Button sender)
        {
            int _nflag = 0;
            if (ckBlod.Checked)
            {
                _nflag += 1;
            }
            if (ckItalic.Checked)
            {
                _nflag += 3;
            }
            if (ckUnderline.Checked)
            {
                _nflag += 5;
            }
            return sender.Text +"_"+ _nflag.ToString();
        }
    }
}
