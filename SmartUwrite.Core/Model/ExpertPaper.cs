using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 专家论文信息
    /// </summary>
    public class ExpertPaper
    {
        private string m_strTitle;

        public string StrTitle
        {
            get { return m_strTitle; }
            set { m_strTitle = value; }
        }
        private string m_strPublishSource;

        public string StrPublishSource
        {
            get { return m_strPublishSource; }
            set { m_strPublishSource = value; }
        }
        private string m_strPublishDate;

        public string StrPublishDate
        {
            get { return m_strPublishDate; }
            set { m_strPublishDate = value; }
        }
        private string m_strDOI;

        public string StrDOI
        {
            get { return m_strDOI; }
            set { m_strDOI = value; }
        }
        private string m_strAbstract;

        public string StrAbstract
        {
            get { return m_strAbstract; }
            set { m_strAbstract = value; }
        }
        public string url = string.Empty;
        public bool exist = false;
        public ExpertPaper(string p_strTitle, string p_strPublishSource, string p_strPublishDate, string p_strDOI, string p_strAbstract,string url,bool exist)
        {
            this.m_strTitle = p_strTitle;
            this.m_strPublishSource = p_strPublishSource;
            this.m_strPublishDate = p_strPublishDate;
            this.m_strDOI = p_strDOI;
            this.m_strAbstract = p_strAbstract;
            this.url = url;
            this.exist = exist;
        }
    }
}
