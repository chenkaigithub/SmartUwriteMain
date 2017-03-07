using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 杂志
    /// </summary>
    class FieldMagazine : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                string IsShotHand = JsonHelper.GetValue("USE_PERIODICAL_SHORTHAND_NAME").ToUpper();
                if ("TRUE" == IsShotHand)
                {
                    result = quotation.publishInfo.periodicalInfo.nameAbbr;
                    if (result == null || result.Trim() == string.Empty)
                    {
                        result = quotation.publishInfo.periodicalInfo.name;
                    }
                }
                else
                {
                    result = quotation.publishInfo.periodicalInfo.name;
                }
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public FieldMagazine(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
