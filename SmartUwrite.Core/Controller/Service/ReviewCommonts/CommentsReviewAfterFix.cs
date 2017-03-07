using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
namespace BIMTClassLibrary.Controller.Service.ReviewCommonts
{
    class CommentsReviewAfterFix : BaseComments
    {

        private static CommentsReviewAfterFix instance;
        private CommentsReviewAfterFix() { }


        public static CommentsReviewAfterFix GetInstance()
        {
            if (instance == null)
            {
                instance = new CommentsReviewAfterFix();
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
            if (IsOneinTwo())
            {
                InsertValue(templet, "original2", "√");
            }
            else
            {
                InsertValue(templet, "original1", "√");
            }

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

            InsertValue(templet, "general3", "√");

        }

        public override void CommentDisposalIdea()
        {
            InsertValue(templet, "disposalIdea5", "√");
        }

        public override void CommentofEditorialDept()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "editorialdept2", "√");
            }
            else
            {
                InsertValue(templet, "editorialdept3", "√");
            }
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
                if (item.Range.Text.Contains("有两种方案供您选择"))
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
                if (item.Range.Text.Trim().StartsWith("有两种方案供您选择："))
                {
                    break;
                }
                if (append)
                {
                    content += item.Range.Text ;
                }
            }
            InsertValue(templet, "comments", content);
            //DoNotSaveChanges(doc);
        }
    }
}
