using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 出版社
    /// </summary>
    class PeriodicalInfo : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (quotation.publishInfo.periodicalInfo.press == string.Empty)
                {
                    result = JsonHelper.GetValue("EN_LOST_PUBER_REPLACE");
                }
                else
                {
                    result = quotation.publishInfo.periodicalInfo.press;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
