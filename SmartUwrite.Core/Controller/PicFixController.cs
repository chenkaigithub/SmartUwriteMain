using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.Controller
{
    public class PicFixController:BaseController
    {
        string path,name;        
        public PicFixController(IRefreshViewable view,string name, string path)
            : base(view)
        {
            this.name = name;
            this.path = path;
        }

        public override void Do()
        {
            view.HideOtherPanel(name);
            ucPictureTest uc = new ucPictureTest(path);
            view.ShowTaskPane(name, uc);
        }
    }
}
