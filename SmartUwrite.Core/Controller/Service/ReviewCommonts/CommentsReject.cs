using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
namespace BIMTClassLibrary.Controller.Service.ReviewCommonts
{
    class CommentsReject : BaseComments
    {
        private static CommentsReject instance;
        private CommentsReject() { }
        

        public static CommentsReject GetInstance()
        {
            if (instance == null)
            {
                instance = new CommentsReject();
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
                InsertValue(templet, "scientific3", "√");
            }
            else
            {
                InsertValue(templet, "scientific4", "√");
            }
        }

        public override void CommentOriginal()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "original3", "√");
            }
            else
            {
                InsertValue(templet, "original4", "√");
            }
        }

        public override void CommentPractical()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "practical3", "√");
            }
            else
            {
                InsertValue(templet, "practical4", "√");
            }
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
            Random r = new Random();
            int x = r.Next(1, 4);
            if (x == 1)
            {
                InsertValue(templet, "reference2", "√");
            }
            else if (x == 2)
            {
                InsertValue(templet, "reference3", "√");
            }
            else if (x == 3)
            {
                InsertValue(templet, "reference4", "√");
            }
            else
            {
                InsertValue(templet, "reference5", "√");
            }
        }

        public override void CommentGeneral()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "general3", "√");
            }
            else
            {
                InsertValue(templet, "general4", "√");
            }
        }

        public override void CommentDisposalIdea()
        {
            if (IsOneinTwo())
            {
                InsertValue(templet, "disposalIdea6", "√");
            }
            else
            {
                InsertValue(templet, "disposalIdea7", "√");
            }
        }

        public override void CommentofEditorialDept()
        {
           
                InsertValue(templet, "editorialdept3", "√");
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
                if (item.Range.Text.Contains("予以拒稿处理"))
                {
                    return true;
                }
            }
            return false;
        }

        public override void FillComments()
        {
            //DoNotSaveChanges(doc);
        }
    }
}
