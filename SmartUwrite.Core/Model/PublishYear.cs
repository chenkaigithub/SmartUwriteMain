using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 出版年字段
    /// </summary>
    class PublishYear : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (PublicVar.WriteIndex)
                {
                    if (quotation.publishInfo.publishYear == null || quotation.publishInfo.publishYear.Trim() == string.Empty)
                    {
                        result = "(no year)";// quotation.publishInfo.publishYear.Trim();
                    }
                    else
                    {
                        string four = JsonHelper.GetValue("USE_FOUR_NUM_YEAR");

                        if ("TRUE" == four.ToUpper())
                        {
                            result = quotation.publishInfo.publishYear.Trim();
                        }
                        else
                        {
                            result = quotation.publishInfo.publishYear.Substring(2).Trim();
                        }
                    }
                }
                else
                {
                    if (quotation.publishInfo.publishYear == null || quotation.publishInfo.publishYear.Trim() == string.Empty)
                    {
                        result = "(no year)";// quotation.publishInfo.publishYear.Trim();
                    }
                    else
                    {
                        result = quotation.publishInfo.publishYear.Trim();
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PublishYear(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
