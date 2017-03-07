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
    public partial class ucFilter : UserControl
    {
        private ucLiteratureSearch ucLiteratureSearch;

       
        public ucFilter()
        {
            InitializeComponent();
        }

        public ucFilter(ucLiteratureSearch ucLiteratureSearch)
        {
            InitializeComponent();
            this.ucLiteratureSearch = ucLiteratureSearch;
        }

        private void ucFilter_Load(object sender, EventArgs e)
        {

        }

        public string ConvertParam(string p)
        {
            string _strR = string.Empty;
            if (p == "并含")
            {
                _strR = "AND";
            }
            else if (p == "或含")
            {
                _strR = "OR";
            }
            else if (p == "不含")
            {
                _strR = "NOT";

            }
            else if (p == "主题词")
            {
                _strR = "All";
            }
            else if (p == "标题")
            {
                _strR = "Topic";
            }
            else if (p == "关键词")
            {
                _strR = "Keyword";

            }
            else if (p == "作者")
            {
                _strR = "Author";
            }
            else if (p == "摘要")
            {
                _strR = "Abstract";
            }
            else if (p == "作者单位")
            {
                _strR = "Organization";

            }
            else if (p == "日期")
            {
                _strR = "PublishYear";

            }
            else if (p == "DOI")
            {
                _strR = "DOI";
            }
            else if (p == "PMID")
            {
                _strR = "PMID";
            }
            else if (p == "期刊名称")
            {
                _strR = "PublishSource";
            }
            else if (p == "期刊卷期")
            {
                _strR = "PublishIssue";
            }
            return _strR;
//            主题
//关键词
//全文
//文献
//作者
//摘要
        }

        public string getOp1()
        {
            return ConvertParam(comboBox1.Text);
        }

        public string getKey1()
        {
            return richTextBox1.Text.Trim();
        }

        public string getType1()
        {
            return ConvertParam(comboBox2.Text);
        }



        public string getOp2()
        {
            return ConvertParam(comboBox3.Text);
        }

        public string getKey2()
        {
            return richTextBox2.Text.Trim();
        }

        public string getType2()
        {
            return ConvertParam(comboBox4.Text);
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                ucLiteratureSearch.Search();
            }
        }

    }
}
