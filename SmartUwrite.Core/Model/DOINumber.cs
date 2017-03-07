using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// DOI号
    /// </summary>
    class DOINumber : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                //(no doi)
                if (quotation.extraInfo.doi == null || quotation.extraInfo.doi.Trim() == string.Empty)
                {
                    result = "(no doi)";
                }
                else
                {
                    result = quotation.extraInfo.doi;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DOINumber(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
