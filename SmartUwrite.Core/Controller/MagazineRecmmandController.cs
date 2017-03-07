using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Controller.Service;
using BIMTClassLibrary.Model;
using System.Windows.Forms;

namespace BIMTClassLibrary.Controller
{
    public class MagazineRecmmandController:BaseController
    {
        string name;
        public MagazineRecmmandController(IRefreshViewable view,string name)
            : base(view)
        {
            this.name = name;
        }

        public override void Do()
        {
              LoginController controller = new LoginController(view);
              if (controller.IsLogin("请登陆后使用推荐期刊！"))
              {
                  ExtractInfoService service = new ExtractInfoService(WordApplication.GetInstance().WordApp);
                  string keywords = service.ExtractCNKeywords() + service.ExtractENKeywords();
                  if (keywords == string.Empty)
                  {
                      MessageBox.Show(null, "文章格式不标准存在“关键词”或“Keywords”相关内容!", "期刊推荐");
                      return;
                  }
                  else
                  {
                      view.HideOtherPanel(name);
                      ucMagazineRecomand uc = new ucMagazineRecomand(keywords);
                      view.ShowTaskPane(name, uc);
                  }
              }
        }
    }
}
