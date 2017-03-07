using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public class ThreadQuotation
    {
        private Quotation quotation;

        public ThreadQuotation(DataGridViewRow _drCurrent)
        {
            this.dr = _drCurrent;
        }

        public ThreadQuotation(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }

        public void WriteQuuotation()
        {
            CommonFunction.WriteQuotation(dr);
        }

        public DataGridViewRow dr { get; set; }

        public void SynWriteQuuotation()
        {
            CommonFunction.WriteQuotation(quotation);
        }
    }
}
