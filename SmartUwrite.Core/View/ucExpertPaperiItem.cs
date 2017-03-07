using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public partial class ucExpertPaperiItem : UserControl
    {
        private ExpertPaper ep;

        public ucExpertPaperiItem()
        {
            InitializeComponent();
        }

        public ucExpertPaperiItem(ExpertPaper ep)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.ep = ep;
            if (ep.exist)
            {
                lb_title.Text = ep.StrTitle;
                lb_title.Visible = true;
            }
            else
            {
                txt_title.Text = ep.StrTitle;
                txt_title.Visible = true;
            }
            
            txt_baseInfo.Text = "期刊："+ep.StrPublishSource+"  出版日期："+ep.StrPublishDate+"  DOI："+ep.StrDOI;
            rtb_abstract.Text = ep.StrAbstract;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_title_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ep.url);
        }
    }
}
