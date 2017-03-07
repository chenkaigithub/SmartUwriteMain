using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 标题字段
    /// </summary>
    class Titile : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (quotation.title.EndsWith("?") || quotation.title.EndsWith("!"))
                {
                    PublicVar.m_strTitleSpecialChar = quotation.title.Substring(quotation.title.Length - 1, 1);
                    PublicVar.m_needChange = true;
                    result = quotation.title.Substring(0, quotation.title.Length - 1);
                }
                else
                {
                    result = quotation.title.Trim().Trim('.');//.Substring(0, title.Length - 1);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Titile(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
