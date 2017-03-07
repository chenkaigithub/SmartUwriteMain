using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;
using BIMTClassLibrary;
using BIMTClassLibrary.styles;
using BIMTClassLibrary.Model;

namespace BIMTWordAddIn
{
    public partial class ThisAddIn
    {
        Office.CommandBarButton addBtn = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //string _str = Application.StartupPath;
            //PublicVar.StyleDir = _str;
            //StyleManager.DownStyles(_str);
            // 添加右键按钮
            //addBtn = (Office.CommandBarButton)Application.CommandBars["Standard"].Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, missing, false);
            //// 开始一个新Group，即在我们添加的Menu前加一条分割线   
            //addBtn.BeginGroup = true;
            ////addBtn.Id = "DelQuotation";
            //// 为按钮设置Tag
            //addBtn.Tag = "DelQuotation";
            //// 添加按钮上的文字
            //addBtn.Caption = "[删除引文]";
            //// 将按钮初始设为不激活状态
            //addBtn.Enabled = false;
            //addBtn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(addBtn_Click);

            ////Application.CommandBars["Standard"].Visible = false;
            //Application.WindowBeforeRightClick += new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(Application_WindowBeforeRightClick);
            //Application.WindowSelectionChange += new Word.ApplicationEvents4_WindowSelectionChangeEventHandler(Application_WindowSelectionChange);
            //string StyleDir = CommonFunction.GetBIMTDIR();
        }

        void Application_WindowBeforeRightClick(Word.Selection Sel, ref bool Cancel)
        {
            Word.Field _field = CommonFunction.GetFieldBySection(WordApplication.GetInstance().WordApp);
            if (_field==null)
            {
                return;
            }
            if (_field.Code.Text.Contains(QuotationItem.FLAG)||_field.Code.Text.Contains(QuotationItem.FLAG))
            {
                addBtn.Enabled = true;
                WordApplication.GetInstance().WordApp.ActiveDocument.Range(_field.Result.End + 1, _field.Result.End + 1).Select();
            }
           
        }

        void addBtn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            CommonFunction.DeleteQuotation(Globals.ThisAddIn.Application);
        }

     

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            addBtn.Delete(true);
            //RemoveRightBtns();
        }

       

        /// <summary>
        /// 选取变化发生的事件
        /// </summary>
        /// <param name="Sel"></param>
        void Application_WindowSelectionChange(Word.Selection Sel)
        {
            //效率问题临时注释 2016-05-16 wuhailong
            CommonFunction.DeleteQuotation(Globals.ThisAddIn.Application);
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        
    }
}
