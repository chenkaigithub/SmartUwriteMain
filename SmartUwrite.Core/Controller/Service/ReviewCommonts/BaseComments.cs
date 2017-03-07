using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.Controller.Service.ReviewCommonts
{
    public abstract class BaseComments : CommonExportProcess
    {
        Random r = new Random();
        //public CommonExportProcess commen = new CommonExportProcess();
        public Microsoft.Office.Interop.Word._Document templet;
        public Microsoft.Office.Interop.Word._Document doc;
        public abstract bool IsMe(Microsoft.Office.Interop.Word._Document doc);
        public abstract void CommentPolitics();
        public abstract void CommentScientific();
        public abstract void CommentOriginal();
        public abstract void CommentPractical();
        public abstract void CommentReadable();
        public abstract void CommentDrawingandSheet();
        public abstract void CommentReference();
        public abstract void CommentGeneral();
        public abstract void CommentDisposalIdea();
        public abstract void CommentofEditorialDept();
        public abstract void CommentChiefEditor();
        public abstract void FillComments();
        public void BuildComments(Microsoft.Office.Interop.Word._Document templet)
        {
            this.templet = templet;
            CommentPolitics();
            CommentScientific();
            CommentOriginal();
            CommentPractical();
            CommentReadable();
            CommentDrawingandSheet();
            CommentReference();
            CommentGeneral();
            CommentDisposalIdea();
            CommentofEditorialDept();
            CommentChiefEditor();
            FillComments();
        }

        public bool IsOneinTwo()
        {
            int x = r.Next(1, 2);
            if (x == 1)
            {
                return true;
            }
            return false;
        }
    }
}
