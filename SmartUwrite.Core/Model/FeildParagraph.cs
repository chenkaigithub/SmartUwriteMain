using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    class FeildParagraph : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                return "\n";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FeildParagraph(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
