using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMTClassLibrary;
using BIMTClassLibrary.Json;
using Word = Microsoft.Office.Interop.Word;
using Log4Net;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 引文标题
    /// 内容一般中文：“参考文献” 英文：“Bibliography”
    /// 2016-04-05
    /// wuahilong
    /// </summary>
    public class QuotationTitle
    {
        public static readonly string FLAG = "QUOTATION_TITLE";
        string m_strTitle = string.Empty;
        string m_strStyle = string.Empty;
        string m_strFontFamily = "宋体";
        float m_fFontSize = 36;
        Microsoft.Office.Interop.Word.Application WordApp;


        public QuotationTitle(Microsoft.Office.Interop.Word.Application p_WordApp)
        {
            InitStatus();
            if (p_WordApp == null)
            {
                WordApp = WordApplication.GetInstance().WordApp;
            }
            else
            {
                WordApp = p_WordApp;
            }
        }

        public QuotationTitle()
        {
            WordApp = WordApplication.GetInstance().WordApp;
            InitStatus();
        }


        public void InitStatus()
        {
            try
            {
                m_strTitle = JsonHelper.GetValue("QUOTATION_TITLE");
                m_strStyle = JsonHelper.GetValue("QUOTATION_TITLE_STYLE_VALUE");
                m_strFontFamily = JsonHelper.GetValue("QUOTATION_TITLE_FONT_FAMILY");
                m_fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_TITLE_FONT_SIZE")));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationTitle), ex);
            }
           
        }

        /// <summary>
        /// 判断是否存在指定的bookmark,存在则返回此对象，否则返回null
        /// 2016-03-28
        /// wuhailong
        /// </summary>
        /// <param name="p_strBookMarkName"></param>
        /// <returns></returns>
        public  Word.Bookmark GetBookMarkByName(Microsoft.Office.Interop.Word.Application WordApp, string p_strBookMarkName)
        {
            foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
            {
                if (item.Name.ToString() == p_strBookMarkName)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 在文末添加段落
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public  Word.Paragraph AddEndParagraph(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                Word.Range _range = WordApp.ActiveDocument.Range(WordApp.ActiveDocument.Paragraphs.Last.Range.End - 1, WordApp.ActiveDocument.Paragraphs.Last.Range.End);
                Word.Paragraph paragraph = WordApp.ActiveDocument.Paragraphs.Add(_range);
                return paragraph;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void WriteContent()
        {
            string _strQuotationTitle = m_strTitle;
            Word.Field _markTitle =CommonFunction.GetFieldByCodeText(WordApp, QuotationTitle.FLAG);
            if (null != _markTitle)
            {
                return ;
            }
            else
            {
                Word.Paragraph paragraph = AddEndParagraph(WordApp);
                string[] _array =  _strQuotationTitle.Split('#');
                WordApp.ActiveDocument.Paragraphs.Last.Range.Text = _array[0];
                int _nStart = WordApp.ActiveDocument.Paragraphs.Last.Range.Start;
                int _nEnd = _nStart + _array[0].Length;
                Word.Range range = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                string _strMarkName = QuotationTitle.FLAG;
                Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, range);
                Word.Field _field = CommonFunction.AddField(WordApp,mark.Range,QuotationTitle.FLAG);

                //自定义域用来保存所有插入的文献信息
                //string _strText = p_range.Text;
                //object fieldType = Word.WdFieldType.wdFieldAddin;
                //object formula = "QUOTATION_SET";
                //object presrveFormatting = false;
                //Word.Range _rangeData = WordApp.ActiveDocument.Range(_field.Result.Start, _field.Result.Start);
                //Word.Field _fieldAddIn = WordApp.ActiveDocument.Fields.Add(_rangeData, ref fieldType, ref formula, ref presrveFormatting);
                //_fieldAddIn.ShowCodes = false;
                //_field.Result.Text = _strText;

                _field.Result.Font.Name = m_strFontFamily;
                _field.Result.Font.Size = m_fFontSize;
                if (_array[1].Contains("1"))
                {
                    _field.Result.Font.Bold = 1;
                }
                else if (_array[1].Contains("3"))
                {
                    _field.Result.Font.Italic = 1;
                }
                else if (true)
                {
                    _field.Result.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
                    //_field.Result. = 1;
                }
               
                return ;
            }
        }

        public void SetStyle()
        {
            Word.Bookmark _markTitle = GetBookMarkByName(WordApp, QuotationTitle.FLAG);
            Word.Range _rangeTitle= _markTitle.Range;
            _rangeTitle.Select();
           _rangeTitle.Font.Name = m_strFontFamily;
           _rangeTitle.Font.Size = m_fFontSize;
            if (m_strStyle=="9")
            {
               _rangeTitle.Font.Bold = 1;
               _rangeTitle.Font.Italic = 1;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (m_strStyle == "8")
            {
               _rangeTitle.Font.Bold = 0;
               _rangeTitle.Font.Italic = 1;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (m_strStyle == "6")
            {
               _rangeTitle.Font.Bold = 1;
               _rangeTitle.Font.Italic = 0;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (m_strStyle == "5")
            {
               _rangeTitle.Font.Bold = 0;
               _rangeTitle.Font.Italic = 0;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (m_strStyle == "4")
            {
               _rangeTitle.Font.Bold = 1;
               _rangeTitle.Font.Italic = 1;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (m_strStyle == "3")
            {
               _rangeTitle.Font.Bold = 0;
               _rangeTitle.Font.Italic = 1;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (m_strStyle == "1")
            {
               _rangeTitle.Font.Bold = 1;
               _rangeTitle.Font.Italic = 0;
               _rangeTitle.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            
        }


        public int GetMaxFieldNo(Word.Application WordApp)
        {
            throw new NotImplementedException();
        }

        public int GetNextFieldNo(Word.Application WordApp)
        {
            throw new NotImplementedException();
        }


        public Word.Range WriteQuotationFieldAtRange(Word.Application WordApp)
        {
            throw new NotImplementedException();
        }

        

        //Word.Range IQuotation.WriteQuotationFieldAtRange(Word.Range p_range)
        //{
        //    throw new NotImplementedException();
        //}


        public void RefreshStyle(string styleName)
        {
            throw new NotImplementedException();
        }


        public List<Word.Field> GetDocFieldList()
        {
            throw new NotImplementedException();
        }
    }
}
