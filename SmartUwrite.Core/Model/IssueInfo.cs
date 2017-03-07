using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 期字段
    /// </summary>
    class IssueInfo : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                //(no volume)
                if (quotation.publishInfo.issueInfo == null || quotation.publishInfo.issueInfo.Trim() == string.Empty)
                {
                    result = "no issue";
                }
                else
                {
                    result = quotation.publishInfo.issueInfo.Replace("期", string.Empty).Trim();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IssueInfo(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
