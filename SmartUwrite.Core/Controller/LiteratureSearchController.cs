using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.Controller
{
    public class LiteratureSearchController:BaseController
    {
        string name;
        public LiteratureSearchController(IRefreshViewable view,string name) : base(view) {
            this.name = name;
        }

        public override void Do()
        {
            view.HideOtherPanel(name);
            ucLiteratureSearch uc = new ucLiteratureSearch();
            view.ShowTaskPane(name, uc);
        }
    }
}
