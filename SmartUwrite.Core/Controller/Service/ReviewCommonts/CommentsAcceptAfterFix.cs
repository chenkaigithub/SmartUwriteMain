using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
namespace BIMTClassLibrary.Controller.Service.ReviewCommonts
{
    class CommentsAcceptAfterFix : BaseComments
    {

        private static CommentsAcceptAfterFix instance;
        private CommentsAcceptAfterFix() { }


        public static CommentsAcceptAfterFix GetInstance()
        {
            if (instance == null)
            {
                instance = new CommentsAcceptAfterFix();
            }
            return instance;
        }

        public override void CommentPolitics()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "politics1", "√");
            }
            else
            {
                InsertValue(templet, "politics2", "√");
            }
        }

        public override void CommentScientific()
        {
            //scientific1
            if (IsOneinTwo())
            {
                InsertValue(templet, "scientific1", "√");
            }
            else
            {
                InsertValue(templet, "scientific2", "√");
            }
        }

        public override void CommentOriginal()
        {
            
                InsertValue(templet, "original2", "√");
            
        }

        public override void CommentPractical()
        {
            
                InsertValue(templet, "practical2", "√");
            
        }

        public override void CommentReadable()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "readable3", "√");
            }
            else
            {
                InsertValue(templet, "readable4", "√");
            }
        }

        public override void CommentDrawingandSheet()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "drawingandsheet3", "√");
            }
            else
            {
                InsertValue(templet, "drawingandsheet4", "√");
            }
        }

        public override void CommentReference()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "reference2", "√");
            }
            else
            {
                InsertValue(templet, "reference3", "√");
            }
        }

        public override void CommentGeneral()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "general2", "√");
            }
            else
            {
                InsertValue(templet, "general3", "√");
            }
        }

        public override void CommentDisposalIdea()
        {
            InsertValue(templet, "disposalIdea4", "√");
        }

        public override void CommentofEditorialDept()
        {
            
                InsertValue(templet, "editorialdept2", "√");
        }

        public override void CommentChiefEditor()
        {
            //InsertValue(doc, "chiefeditor1", "√");
        }

        public override bool IsMe(Microsoft.Office.Interop.Word._Document doc)
        {
            this.doc = doc;
            foreach (Word.Paragraph item in doc.Paragraphs)
            {
                if (item.Range.Text.Contains("请选择合适的方案"))
                {
                    return true;
                }
            }
            return false;
        }

        public override void FillComments()
        {
            string content = string.Empty;
            bool append = false;
            foreach (Word.Paragraph item in doc.Paragraphs)
            {
                if (item.Range.Text.Trim().EndsWith("："))
                {
                    append = true;
                }
                if (item.Range.Text.Trim().StartsWith("请您严格按照修改要求进行修改，修改部分请标红。"))
                {
                    break;
                }
                if (append)
                {
                    content += item.Range.Text + "\n";
                }
            }
            InsertValue(templet, "comments", content);
            //DoNotSaveChanges(doc);
        }
    }
}
