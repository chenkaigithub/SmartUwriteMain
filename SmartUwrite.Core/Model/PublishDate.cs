using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 出版日期字段
    /// </summary>
    class PublishDate : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (quotation.extraInfo.createDate == null || quotation.extraInfo.createDate.Trim() == string.Empty)//(no data)
                {
                    result = "(no data)";
                }
                else
                {
                    result = quotation.extraInfo.createDate;
                }
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public PublishDate(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
