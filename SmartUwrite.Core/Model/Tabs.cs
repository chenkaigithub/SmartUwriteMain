using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 制表符字段
    /// </summary>
    class Tabs : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                return "\t";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Tabs(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
