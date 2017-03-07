using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// PMID号字段
    /// </summary>
    class PMIDNumber : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                return quotation.extraInfo.PMID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PMIDNumber(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
