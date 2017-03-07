using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
namespace BIMTClassLibrary.Controller.Service.ReviewCommonts
{
    public class CommentsAccept : BaseComments
    {
        //CommonExportProcess common = new CommonExportProcess();
        private static CommentsAccept instance;

        private CommentsAccept() { }


        public static CommentsAccept GetInstance()
        {
            if (instance == null)
            {
                instance = new CommentsAccept();
            }
            return instance;
        }

        public override bool IsMe(Microsoft.Office.Interop.Word._Document doc)
        {
            this.doc = doc;
            foreach (Word.Paragraph item in doc.Paragraphs)
            {
                if (item.Range.Text.Contains("予以录用"))
                {
                    return true;
                }
            }
            return false;
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
                InsertValue(templet, "original1", "√");
            }
            else
            {
                InsertValue(templet, "original2", "√");
            }
        }

        public override void CommentPractical()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "practical1", "√");
            }
            else
            {
                InsertValue(templet, "practical2", "√");
            }
        }

        public override void CommentReadable()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "readable1", "√");
            }
            else
            {
                InsertValue(templet, "readable2", "√");
            }
        }

        public override void CommentDrawingandSheet()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "drawingandsheet1", "√");
            }
            else
            {
                InsertValue(templet, "drawingandsheet2", "√");
            }
        }

        public override void CommentReference()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "reference1", "√");
            }
            else
            {
                InsertValue(templet, "reference2", "√");
            }
        }

        public override void CommentGeneral()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "general1", "√");
            }
            else
            {
                InsertValue(templet, "general2", "√");
            }
        }

        public override void CommentDisposalIdea()
        {
            InsertValue(templet, "disposalIdea1", "√");
        }

        public override void CommentofEditorialDept()
        {
            //editorialdept1
            InsertValue(templet, "editorialdept1", "√");
        }

        public override void CommentChiefEditor()
        {
            //InsertValue(doc, "chiefeditor1", "√");
        }

        public override void FillComments()
        {
            //DoNotSaveChanges(doc);
        }
    }
}
