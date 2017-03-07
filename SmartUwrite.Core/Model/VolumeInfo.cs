using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 卷字段
    /// </summary>
    class VolumeInfo : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                if (quotation.publishInfo.volumeInfo == null || quotation.publishInfo.volumeInfo.Trim() == string.Empty)
                {
                    result = "(no volume)";
                }
                else
                {
                    result = quotation.publishInfo.volumeInfo.Replace("卷", string.Empty).Trim();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VolumeInfo(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
