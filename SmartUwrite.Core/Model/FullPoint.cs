using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 句点字段
    /// </summary>
    class FullPoint : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (PublicVar.m_needChange)
                {//标题为带？ 或！时
                    result = PublicVar.m_strTitleSpecialChar;
                    PublicVar.m_needChange = false;
                }
                else
                {
                    result = ".";
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FullPoint(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
