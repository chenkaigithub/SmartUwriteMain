using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 双引号
    /// </summary>
    class DoubleQuotationMarks : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                return  "\"";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DoubleQuotationMarks(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
