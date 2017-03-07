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
    /// <summary>
    /// 展示专家的论文信息
    /// wuhailong
    /// 2016-07-15
    /// </summary>
    public partial class frmExpertPaperInfo : Form,IBaseControl
    {
        public frmExpertPaperInfo()
        {
            InitializeComponent();
        }

        public frmExpertPaperInfo(List<ExpertPaper> p_listExpertPaper)
        {
            this.m_listExperPaper = p_listExpertPaper;
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            int _nCount = 0;
            foreach (ExpertPaper item in m_listExperPaper)
            {
                ucExpertPaperiItem uc = new ucExpertPaperiItem();
                uc.Location = new Point(5, 5 + _nCount * uc.Height);
                this.Controls.Add(uc);
                _nCount++;
            }
        }

        public List<ExpertPaper> m_listExperPaper { get; set; }
    }
}
