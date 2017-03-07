using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary
{
    public class Magazine
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string m_strName;

        public string StrName
        {
            get { return m_strName; }
            set { m_strName = value; }
        }
        private string m_strLevel;

        public string StrLevel
        {
            get { return m_strLevel; }
            set { m_strLevel = value; }
        }
        private string impactFactor;

        public string StrDoi
        {
            get { return impactFactor; }
            set { impactFactor = value; }
        }
        private float m_fMatch;

        public float FMatch
        {
            get { return m_fMatch; }
            set { m_fMatch = value; }
        }

        private bool isCol;

        public bool IsCol
        {
            get { return isCol; }
            set { isCol = value; }
        }

        public Magazine(string id, string p_strName, string p_strLevel, string p_strDoi, float p_fMatch, bool isCol)
        {
            this.Id = id;
            this.m_strName = p_strName;
            this.m_strLevel = p_strLevel;
            this.impactFactor = p_strDoi;
            this.FMatch = p_fMatch;
            this.IsCol = isCol;
        }
    }
}
