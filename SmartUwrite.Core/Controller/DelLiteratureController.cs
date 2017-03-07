using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Model;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.Controller
{
    public class DelLiteratureController:BaseController
    {
        public DelLiteratureController(IRefreshViewable view) : base(view) { }
        public override void Do()
        {
            Microsoft.Office.Interop.Word.Field locatedField = CommonFunction.GetFieldBySection(WordApplication.GetInstance().WordApp);
            QuotationIndex quotationIndex = QuotationIndex.GetInstance(null);
            if (locatedField.Code.Text.Contains(QuotationIndex.FLAG))
            {
                QuotationIndex.GetInstance(null).DeleteIndexQuotation(locatedField);
            }
            else if (locatedField.Code.Text.Contains(QuotationItem.FLAG))
            {
                QuotationItem.GetInstance().DeleteItemQuotation(locatedField);
            }
            bool ok = QuotationIndex.IsOrderStyle();
            if (ok)
            {
                quotationIndex.RefreshIndex();
                QuotationItem quotationItem = QuotationItem.GetInstance();
                //QuotationItem.RefreshAllQuotationItemLocation();
                quotationItem.RefreshQuotatationItemIndex();
                //quotationItem.RefreshStyle(MagazineStyle.GetInstance().Name);
            }
        }
    }
}
