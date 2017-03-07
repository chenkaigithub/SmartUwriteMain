using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 审稿人
    /// wuhailong
    /// 2016-07-11
    /// </summary>
    public class Reviewer
    {
        private string m_strName;

        public string StrName
        {
            get { return m_strName; }
            set { m_strName = value; }
        }
        private string m_strEmail;

        public string StrEmail
        {
            get { return m_strEmail; }
            set { m_strEmail = value; }
        }
        private string m_strOrganization;

        public string StrOrganization
        {
            get { return m_strOrganization; }
            set { m_strOrganization = value; }
        }

        public Reviewer(string p_strName, string p_strEmail, string p_strOrag)
        {
            this.m_strEmail = p_strEmail;
            this.m_strOrganization = p_strOrag;
            this.m_strName = p_strName;
        }
    }
}
