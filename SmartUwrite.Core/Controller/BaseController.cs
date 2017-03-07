using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.Controller
{
    public abstract class BaseController
    {
        public IRefreshViewable view;

        public BaseController(IRefreshViewable view) {
            this.view = view; 
        }

        public abstract void Do();
    }
}
