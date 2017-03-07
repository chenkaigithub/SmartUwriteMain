using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 空格字段
    /// </summary>
    class Space : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                return  " ";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Space(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
