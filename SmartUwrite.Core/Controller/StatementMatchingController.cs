using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.Model;
using System.Windows.Forms;

namespace BIMTClassLibrary.Controller
{
   public class StatementMatchingController:BaseController
    {
        string name,content;
        public StatementMatchingController(IRefreshViewable view, string name,string content)
            : base(view)
        {
            this.name = name;
            this.content = content;
        }

        public override void Do()
        {
            if (WordApplication.GetInstance().WordApp.Application.Selection.Text.Trim() == string.Empty)
            {
                MessageBox.Show(null, "请在文档中选择内容!", "文献推荐");
                return;
            }
            else
            {
                view.HideOtherPanel(name);
                ucLiteratureRecommend uc = new ucLiteratureRecommend(content);
                view.ShowTaskPane(name, uc);
            }
        }
    }
}
