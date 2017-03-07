using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    class PublishPlace : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (quotation.publishInfo.periodicalInfo.place == string.Empty)
                {
                    result = JsonHelper.GetValue("EN_LOST_PUB_PLACE_REPLACE");
                }
                else
                {
                    result = quotation.publishInfo.periodicalInfo.place;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PublishPlace(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
