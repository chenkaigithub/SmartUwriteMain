using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 引文序号字段类
    /// wuahilong
    /// 2016-08-10
    /// </summary>
    class CitationNumber : BaseField, IField
    {
        //public CitationNumber(Quotation quotation)
        //{
        //    this.quotation = quotation;
        //}

        public string GetValue()
        {
            try
            {
                return "{0}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CitationNumber(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
