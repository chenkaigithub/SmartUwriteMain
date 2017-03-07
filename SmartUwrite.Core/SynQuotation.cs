using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Log4Net;
using BIMTClassLibrary.quotation;
using Word = Microsoft.Office.Interop.Word;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 文献操作异步类
    /// wuhailong
    /// 2016-08-11
    /// </summary>
    public class SynQuotation
    {
        private Quotation quotation;

        public SynQuotation(DataGridViewRow _drCurrent)
        {
            this.dr = _drCurrent;
        }

        public SynQuotation(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }

        public void WriteQuuotation()
        {
            //CommonFunction.WriteQuotation(dr);
        }

        public DataGridViewRow dr { get; set; }

        public void SynWriteQuuotation()
        {
            CommonFunction.WriteQuotation(quotation);
        }
    }
}
