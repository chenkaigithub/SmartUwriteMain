using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using System.Windows.Forms;
using BIMTClassLibrary.Controller.Service;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.Controller
{
    public class ViewerRecmmandController:BaseController
    {
        string name;
        public ViewerRecmmandController(IRefreshViewable view,string name) : base(view) {
            this.name = name;
        }
        public override void Do()
        {
            ExtractInfoService service = new ExtractInfoService(WordApplication.GetInstance().WordApp);
            string keywords = service.ExtractCNKeywords() + service.ExtractENKeywords();
            if (keywords == string.Empty)
            {
                MessageBox.Show(null, "文章格式不标准存在“关键词”或“Keywords”相关内容!", "审稿人推荐");
            }
            else
            {

                view.HideOtherPanel(name);
                ucReviewerRecommand uc = new ucReviewerRecommand(keywords);
                view.ShowTaskPane(name, uc);
            }
        }
    }
}
