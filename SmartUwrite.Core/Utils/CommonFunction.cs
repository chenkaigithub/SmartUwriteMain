using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using BIMTClassLibrary;
using Log4Net;
using BIMTClassLibrary.Json;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using BIMTClassLibrary.EditStyle;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 2016-03-10
    /// wuhailong
    /// 操作word工具类
    /// </summary>
    public class CommonFunction
    {
        #region 内容字段
        static string m_strAuthor = string.Empty;
        static string m_strTitleType = string.Empty;
        static string m_strPubYear = string.Empty;
        static string m_strPubPlace = string.Empty;
        static string m_strPubPersion = string.Empty;
        static string m_strTitle = string.Empty;
        static string m_strJuan = string.Empty;
        static string m_strQi = string.Empty;
        static string m_strPageRange = string.Empty;
        static string m_strDOI = string.Empty;
        static string m_strCountry = string.Empty;
        static string m_strPubDate = string.Empty;
        static string m_strSecondPersion = string.Empty;
        static string m_strVersion = string.Empty;
        static string m_strISSN = string.Empty;
        static string m_strPrintTime = string.Empty;
        static string m_strAuthorInEng = string.Empty;
        static string m_strTitleInEng = string.Empty;
        static string m_strPubPlaceInEng = string.Empty;
        static string m_strPubPersionInEng = string.Empty;
        static string m_strCountryInEng = string.Empty;
        static string m_strVersionInEng = string.Empty;
        static string m_strRefDate = string.Empty;
        #endregion

        //private static Word._Application wordApp = null;
        //private static Word._Document wordDoc = null;
        static Object Nothing = System.Reflection.Missing.Value;
        //public CommonFunction(Word._Application p_wordApp, Word._Document p_wordDoc)
        //{
        //    wordApp = p_wordApp;
        //    wordDoc = p_wordDoc;
        //}

        public struct BookMarkStruct
        {
            public int _nStart;
            public int _nEnd;
            public string _strContext;
        }

        public static string GetInstallDir()
        {
            return Assembly.GetExecutingAssembly().CodeBase;
        }

        #region 更新range内容
        /// <summary>
        /// 2016-03-10
        /// wuhailong
        /// 更新range内容
        /// </summary>
        /// <param name="p_range">range对象</param>
        /// <param name="p_strContext">文本内容</param>
        public static void UpdateContext(Word.Range p_range, string p_strContext)
        {
            Word.Range range = p_range;
            if (range != null)
            {
                range.Text = p_strContext;
            }
        }
        #endregion

        #region 在指定书签（BM_TEST）处插入内容
        /// <summary>
        /// 2016-03-10
        /// wuahilong
        /// 在指定书签（BM_TEST）处插入内容
        /// </summary>
        /// <param name="word">word对象</param>
        /// <param name="p_strContext">文本内容</param>
        public static void UpdateBookMark(Word.Document word, string p_strContext)
        {
            if (word.Bookmarks.Exists("BM_TEST"))
            {
                object tmp = "BM_TEST";
                word.Bookmarks.get_Item(ref tmp).Range.Text = p_strContext; // 插入文本
            }
        }
        #endregion

        #region 杀掉winword.exe进程
        /// <summary>
        /// 杀掉winword.exe进程
        /// </summary>
        public static void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
        #endregion

        #region 检测office版本

        /// <summary>
        /// 检测office版本,假如同时安装了两个版本的 office则返回高版本的office
        /// 返回值：2003、2007、2010、2013、2016
        /// 2016-03-17
        /// wuhailong
        /// </summary>
        /// <returns>2003、2007、2010、2013、2016</returns>
        public static string CheckOfficeVersion()
        {
            return "";
            //string _strVersion = string.Empty;
            //RegistryKey rk = Registry;
            ////office2016
            //RegistryKey office2016 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\16.0\\Word\\InstallRoot\\");
            ////office2013
            //RegistryKey office2013 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\15.0\\Word\\InstallRoot\\");
            ////office2010
            //RegistryKey office2010 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\14.0\\Word\\InstallRoot\\");
            ////office2007
            //RegistryKey office2007 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\12.0\\Word\\InstallRoot\\");
            ////office 2003
            //RegistryKey office2003 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\11.0\\Word\\InstallRoot\\");

            //if (office2003 != null)
            //{
            //    string file03 = office2010.GetValue("Path").ToString();
            //    if (File.Exists(file03 + "Word.exe"))
            //    {
            //        _strVersion = "2003";
            //    }
            //}

            //if (office2007 != null)
            //{
            //    string file2007 = office2007.GetValue("Path").ToString();
            //    if (File.Exists(file2007 + "Excel.exe"))
            //    {
            //        _strVersion = "2007";
            //    }
            //}

            //if (office2010 != null)
            //{
            //    string file2010 = office2010.GetValue("Path").ToString();
            //    if (File.Exists(file2010 + "Excel.exe"))
            //    {
            //        _strVersion = "2010";
            //    }
            //}

            //if (office2013 != null)
            //{
            //    string file2013 = office2013.GetValue("Path").ToString();
            //    if (File.Exists(file2013 + "Excel.exe"))
            //    {
            //        _strVersion = "2013";
            //    }
            //}

            //if (office2016 != null)
            //{
            //    string file2016 = office2016.GetValue("Path").ToString();
            //    if (File.Exists(file2016 + "Excel.exe"))
            //    {
            //        _strVersion = "2016";
            //    }
            //}

            //return _strVersion;
        }


        #endregion

        #region 移动焦点并换行
        /// <summary>
        /// 移动焦点并换行
        /// 2016-03-24
        /// wuhailong 
        /// </summary>
        public static void NewParagraph(Microsoft.Office.Interop.Word.Application WordApp)
        {
            object count = 14;
            object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
            WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
            WordApp.Selection.TypeParagraph();//插入段
        }
        #endregion

        #region 创建域
        /// <summary>
        /// 测试创建域
        /// </summary>
        /// <param name="WordApp">活动文档</param>
        public static void TestNewField(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                Word.Range range = WordApp.Selection.Range;
                object fieldType = Word.WdFieldType.wdFieldAddin;//.wdFieldEmpty;
                object formula = @"SET A";//公式一
                object preserveFormatting = false;
                //字体设置
                range.Text = "HAHA";
                int _nStart = range.Start;
                int _nEnd = range.Start + range.Text.Length;
                Word.Range range2 = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                range2.Text = range.Text;
                range2.Font.Size = 12;//字体大小
                range2.Font.Bold = 0;//粗体
                range2.Font.Subscript = 0;//是否为下标1为下标
                range2.Font.Color = Word.WdColor.wdColorBlack;//所选字体颜色     
                //WordApp.ActiveDocument.Fields.Add(range2, ref fieldType, "haha", ref preserveFormatting);//插入第一个公式
                //WordApp.ActiveDocument.Fields[1].Data = "bimt";
                //WordApp.ActiveDocument.Fields[1].Result.Text = "haha2";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 定位到wordz最后一行
        /// <summary>
        /// 定位到word最后一行
        /// </summary>
        /// <param name="thisDocument"></param>
        public static void GotoLastLine(Microsoft.Office.Interop.Word.Application WordApp)
        {
            object dummy = System.Reflection.Missing.Value;
            object what = Word.WdGoToItem.wdGoToLine;
            object which = Word.WdGoToDirection.wdGoToLast;
            object count = 99999999;
            WordApp.Application.Selection.GoTo(ref what, ref which, ref count, ref dummy);
        }
        #endregion

        #region 定位word最后一个字符
        /// <summary>
        /// 将光标移动到最后一个字符后
        /// </summary>
        /// <param name="WordApp">活动文档</param>
        public static void GotoLastCharacter(Microsoft.Office.Interop.Word.Application WordApp)
        {
            GotoLastLine(WordApp);
            object dummy = System.Reflection.Missing.Value;
            object count = 99999999;
            object Unit = Word.WdUnits.wdCharacter;
            WordApp.ActiveDocument.Application.Selection.MoveRight(ref Unit, ref count, ref dummy);
        }
        #endregion

        #region 添加上角标
        /// <summary>
        /// 添加上角标文字
        /// 2016-03-24
        /// wuhailong
        /// </summary>
        /// <param name="p_strText"></param>
        public static Word.Range AddSuperscriptText(Microsoft.Office.Interop.Word.Application WordApp, string p_strText)
        {
            try
            {
                int _nStart = WordApp.Selection.Range.Start;
                Word.Range range = WordApp.Selection.Range;
                range.Text = p_strText;
                Word.Range rangeSuper = WordApp.ActiveDocument.Range(_nStart, _nStart + p_strText.Length);
                rangeSuper.Font.Superscript = 1;
                rangeSuper.Text = p_strText;
                return rangeSuper;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加引文

        /// <summary>
        /// 将当前range块添加为引文索引，书签格式为BIMT开头
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_rangMark"></param>
        /// <returns></returns>
        public static Word.Bookmark AddQuotationBookMarkIndex(Microsoft.Office.Interop.Word.Application WordApp, string p_strIndex)
        {
            try
            {
                Word.Range _rangeMark = AddSuperscriptText(WordApp, p_strIndex);
                string _strMarkName = "BIMT" + GetNextMarkNo(WordApp).ToString();
                Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, _rangeMark);
                //mark.Column
                return mark;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断是否存在指定的bookmark,存在则返回此对象，否则返回null
        /// 2016-03-28
        /// wuhailong
        /// </summary>
        /// <param name="p_strBookMarkName"></param>
        /// <returns></returns>
        public static Word.Bookmark GetBookMarkByName(Microsoft.Office.Interop.Word.Application WordApp, string p_strBookMarkName)
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
        /// 添加添加引文标题 一般为 “参考文献” 四个字
        /// 2016-03-25
        /// wuahilong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Bookmark AddQuotationBookMarkTitle(Microsoft.Office.Interop.Word.Application WordApp)
        {

            //string _strQuotationTitle = "参考文献";
            //Word.Bookmark _markTitle = GetBookMarkByName(WordApp, "Quotation");
            //if (null!= _markTitle)
            //{
            //    return _markTitle;
            //}
            //else
            //{
            //    GotoLastCharacter(WordApp);
            //    Word.Paragraph paragraph = AddParagraph(WordApp, WordApp.Selection.Range);
            //    GotoLastCharacter(WordApp);
            //    WordApp.Selection.Range.Text = _strQuotationTitle;
            //    int _nStart = WordApp.Selection.Start;
            //    int _nEnd = _nStart + _strQuotationTitle.Length;
            //    Word.Range range = WordApp.ActiveDocument.Range(_nStart, _nEnd);
            //    string _strMarkName = "Quotation";
            //    Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, range);
            //    return mark;
            //}

            string _strQuotationTitle = "参考文献";
            Word.Bookmark _markTitle = GetBookMarkByName(WordApp, "QuotationTitle");
            if (null != _markTitle)
            {
                return _markTitle;
            }
            else
            {
                Word.Paragraph paragraph = AddEndParagraph(WordApp);
                WordApp.ActiveDocument.Paragraphs.Last.Range.Text = _strQuotationTitle;
                int _nStart = WordApp.ActiveDocument.Paragraphs.Last.Range.Start;
                int _nEnd = _nStart + _strQuotationTitle.Length;
                Word.Range range = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                string _strMarkName = "QuotationTitle";
                Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, range);
                return mark;
            }
        }



        /// <summary>
        /// 添加引文条目
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Bookmark AddQuotationBookMarkItem(Microsoft.Office.Interop.Word.Application WordApp, string p_strContenxt)
        {
            //int _nNextBookMarkNo = GetMaxMarkNo(WordApp);
            //GotoLastCharacter(WordApp);
            //Word.Paragraph paragraph = AddParagraph(WordApp, WordApp.Selection.Range);
            //GotoLastCharacter(WordApp);
            //WordApp.Selection.Range.Text = p_strContenxt;
            //int _nStart = WordApp.Selection.Start;
            //int _nEnd = _nStart + p_strContenxt.Length;
            //Word.Range range = WordApp.ActiveDocument.Range(_nStart, _nEnd);
            //string _strMarkName = "QuotationItem" + _nNextBookMarkNo.ToString();
            //Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, range);
            //return mark;
            int _nNextBookMarkNo = GetMaxMarkNo(WordApp);
            Word.Paragraph paragraph = AddEndParagraph(WordApp);
            WordApp.ActiveDocument.Paragraphs.Last.Range.Text = p_strContenxt;
            int _nStart = WordApp.ActiveDocument.Paragraphs.Last.Range.Start;
            int _nEnd = _nStart + p_strContenxt.Length;
            Word.Range range = WordApp.ActiveDocument.Range(_nStart, _nEnd);
            string _strMarkName = "QuotationItem" + _nNextBookMarkNo.ToString();
            Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strMarkName, range);
            return mark;
        }

        #endregion


        #region 获取因为索引
        /// <summary>
        /// 获取引文索引
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Bookmark GetQuotationIndex(Microsoft.Office.Interop.Word.Application WordApp)
        {
            int _nLocationStart = WordApp.Selection.Start;
            int _nLocationEnd = WordApp.Selection.End;
            foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
            {
                if (item.Start <= _nLocationStart && _nLocationEnd <= item.End)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion

        #region 定位引文

        /// <summary>
        /// 通过光标停驻的位置匹配获取引文索引
        /// 再通过引文索引定位引文
        /// 2016-03-28
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public static void LocateQuotation(Microsoft.Office.Interop.Word.Application WordApp)
        {
            Word.Bookmark _markSelectIndex = GetQuotationIndex(WordApp);
            //string _strIndex = ClearIndex(_markSelectIndex);
            string _strIndex = _markSelectIndex.Name.Replace("BIMT","");
            Word.Bookmark _markSelectQuotation = GetBookMarkByName(WordApp, "QuotationItem" + _strIndex);
            _markSelectQuotation.Select();
        }

        public static string ClearIndex(Word.Bookmark _markSelected)
        {
            string _strStartFlag = "[";
            string _strEndFlag = "]";
            return _markSelected.Range.Text.Replace(_strStartFlag, "").Replace(_strEndFlag, "");
        }

        #endregion

        #region 获取下一个bookbook
        /// <summary>
        /// 返回下一个BIMT书签应该的标志
        /// </summary>
        /// <returns></returns>
        public static int GetNextMarkNo(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nMax = GetMaxMarkNo(WordApp);
                return ++_nMax;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 跳转到引文索引位置
        /// <summary>
        /// 将光标移动到最新引文索引位置
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        public static void GotoQuotationIndex(Microsoft.Office.Interop.Word.Application WordApp)
        {
            int _nMax = GetMaxMarkNo(WordApp);
            Word.Bookmark _mark = GetBookMarkByName(WordApp, "BIMT" + _nMax);
            _mark.Range.Select();
        }

        #endregion

        #region 通过计算插入引文的位置计算合适的引文序号

        /// <summary>
        /// 通过计算插入引文的位置格式化合适的引文序号
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        public static List<int> AdjustQuotationIndexByPosition(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nStart = WordApp.Selection.Start;
                int _nEnd = WordApp.Selection.End;
                if (_nStart != _nEnd)
                {
                    return null;
                }
                List<Word.Bookmark> _listMarks = new List<Word.Bookmark>();
                foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
                {
                    if (item.Name.StartsWith("BIMT"))
                    {
                        _listMarks.Add(item);
                    }
                }
                Word.Bookmark _markTemp = null;
                for (int i = 0; i < _listMarks.Count; i++)
                {
                    for (int j = i; j < _listMarks.Count; j++)
                    {
                        int _nStartA = _listMarks[i].Start;
                        int _nStartB = _listMarks[j].Start;
                        if (_nStartA > _nStartB)
                        {
                            _markTemp = _listMarks[i];
                            _listMarks[i] = _listMarks[j];
                            _listMarks[j] = _markTemp;
                        }
                    }
                }
                int _nIndex = 1;
                foreach (Word.Bookmark item in _listMarks)
                {
                    string _strIndex = string.Format("[{0}]", _nIndex);
                    string _strNmae = item.Name;
                    Word.Range _rangeTemp = WordApp.ActiveDocument.Range(item.Start, item.End);
                    _rangeTemp.Text = _strIndex;
                    Word.Bookmark mark = WordApp.ActiveDocument.Bookmarks.Add(_strNmae, _rangeTemp);
                    _nIndex++;
                }

                List<int> _listBookMarkNo = new List<int>();
                foreach (Word.Bookmark item in _listMarks)
                {
                    _listBookMarkNo.Add(int.Parse(item.Name.Replace("BIMT", "")));
                }
                return _listBookMarkNo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #endregion

        #region 通过引文序号的调整，修正引文条目



        /// <summary>
        /// 通过引文序号的调整，修正引文条目
        /// </summary>
        /// <param name="_listBookMark"></param>
        private static void AdjustQuotationItemByIndex(Microsoft.Office.Interop.Word.Application WordApp, List<int> _listBookMarkNo)
        {
            try
            {
                //获取引文条目list
                List<Word.Bookmark> _listMarks = new List<Word.Bookmark>();
                Dictionary<string, BookMarkStruct> _dictBookMarkContextInfo = new Dictionary<string, BookMarkStruct>();
                Dictionary<string, BookMarkStruct> _dictBookMarkRangeInfo = new Dictionary<string, BookMarkStruct>();
           
                _dictBookMarkContextInfo = GetBookMarkContextInfo(WordApp);
                _dictBookMarkRangeInfo = SortedDictionary(_dictBookMarkContextInfo);
                
                int _nI = 1;
                //交换引文位置
                foreach (int item in _listBookMarkNo)
                {
                    string _strNewBookMarkName = "QuotationItem" + item;
                    if (WordApp.ActiveDocument.Bookmarks.Exists(_strNewBookMarkName))
                    {
                        WordApp.ActiveDocument.Bookmarks.get_Item(_strNewBookMarkName).Delete();
                    }
                    BookMarkStruct _structBookMarkRangeInfo = _dictBookMarkRangeInfo["QuotationItem" + _nI];
                    BookMarkStruct _structBookMarkContextInfo = _dictBookMarkContextInfo[_strNewBookMarkName];
                    Word.Range _tempRange = WordApp.ActiveDocument.Range(_structBookMarkRangeInfo._nStart, _structBookMarkRangeInfo._nEnd);
                    string _tempContext = FormatQuotationItem(_structBookMarkContextInfo._strContext, _nI);
                    _tempRange.Text = _tempContext;
                    
                    WordApp.ActiveDocument.Bookmarks.Add(_strNewBookMarkName, _tempRange);
                  
                    _nI++;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 获取书签内容及range信息
        /// 2016-03-30
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        private static Dictionary<string, BookMarkStruct> GetBookMarkContextInfo(Word.Application WordApp)
        {
            Dictionary<string, BookMarkStruct> _dictBookMarkContextInfo = new Dictionary<string, BookMarkStruct>();
            int _nPositionIndex = 1;
            foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
            {
                if (item.Name.StartsWith("QuotationItem"))
                {
                    string _strKey = "QuotationItem" + _nPositionIndex;
                    BookMarkStruct _structBookMark;
                    _structBookMark._nStart = item.Start;
                    _structBookMark._nEnd = item.End;
                    _structBookMark._strContext = item.Range.Text;

                    _dictBookMarkContextInfo.Add(_strKey, _structBookMark);
                    _nPositionIndex++;
                }
            }
            return _dictBookMarkContextInfo;
        }

        /// <summary>
        /// 将key按照bookmark的 start 的顺序重命名
        /// </summary>
        /// <param name="_dictBookMark"></param>
        /// <returns></returns>
        private static Dictionary<string, BookMarkStruct> SortedDictionary(Dictionary<string, BookMarkStruct> _dictBookMark)
        {
            List<BookMarkStruct> _listBookMark = new List<BookMarkStruct>();
            foreach (var item in _dictBookMark)
            {
                _listBookMark.Add(item.Value);
            }
            for (int i = 0; i < _listBookMark.Count; i++)
            {
                for (int j = i; j < _listBookMark.Count; j++)
                {
                    BookMarkStruct _temp;
                    if (_listBookMark[i]._nStart > _listBookMark[j]._nStart)
                    {
                        _temp = _listBookMark[i];
                        _listBookMark[i] = _listBookMark[j];
                        _listBookMark[j] = _temp;
                    }
                }
            }
            Dictionary<string, BookMarkStruct> _dictSort = new Dictionary<string, BookMarkStruct>();
            int _nIndex = 1;
            foreach (var item in _listBookMark)
            {
                _dictSort.Add("QuotationItem" + _nIndex, item);
                _nIndex++;
            }
            return _dictSort;
        }

        /// <summary>
        /// 格式化引文条目；实现引文序号按顺序排列但是引文内容改变的功能
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string FormatQuotationItem(string p_strQuotation, int p_nQuotationIndex)
        {
            string _strStart = "[";
            string _strEnd = "]";
            //\[[^\[^\]]*\]
            string _strReg = @"\" + _strStart + _strStart + @"^\" + _strStart + @"^\" + _strEnd + _strEnd + @"*\" + _strEnd;
            var match = Regex.Match(p_strQuotation, _strReg);
            var result = match.Captures[0].Value;
            string _strNewResult = _strStart + p_nQuotationIndex.ToString() + _strEnd;
            p_strQuotation = p_strQuotation.Replace(result, _strNewResult);
            return p_strQuotation;
        }



        #endregion

        #region 获取最大的bookmark NO

        /// <summary>
        /// 获取最大的bookmark NO ,没有返回 0
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static int GetMaxMarkNo(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nTemp = 0;
                foreach (Word.Bookmark item in WordApp.ActiveDocument.Bookmarks)
                {
                    if (item.Name.StartsWith("BIMT"))
                    {
                        string _strName = item.Name.Replace("BIMT", "");
                        int _nNo = int.Parse(_strName);
                        if (_nNo > _nTemp)
                        {
                            _nTemp = _nNo;
                        }
                    }
                }
                return _nTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加段落

        /// <summary>
        ///  在指定range后添加段落
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_range"></param>
        /// <returns></returns>
        public static Word.Paragraph AddParagraph(Microsoft.Office.Interop.Word.Application WordApp, Word.Range p_range)
        {
            Word.Paragraph paragraph = WordApp.ActiveDocument.Paragraphs.Add(p_range);
            return paragraph;
        }
        static Object oMissing = System.Reflection.Missing.Value;
        /// <summary>
        /// 在文末添加段落
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Paragraph AddEndParagraph(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                Word.Paragraph paragraph = WordApp.ActiveDocument.Content.Paragraphs.Add(ref oMissing);
                return WordApp.ActiveDocument.Paragraphs.Last;
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// 在文末添加段落
        /// 2016-08-04
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Paragraph AddEndParagraph()
        {
            try
            {
                return AddEndParagraph(WordApplication.GetInstance().WordApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 在当前光标位置添加段落
        /// 吴海龙
        /// 2017-07-11
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Paragraph AddParagraphAtSelection(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                //Globals.ThisAddIn.Application.Selection
                Word.Paragraph paragraph =WordApplication.GetInstance().WordApp.Application.Selection.Paragraphs.Add(ref oMissing);
                //Word.Range _range = WordApp.ActiveDocument.Range(WordApp.ActiveDocument.Paragraphs.Last.Range.End - 1, WordApp.ActiveDocument.Paragraphs.Last.Range.End);
                //Word.Paragraph paragraph = WordApp.ActiveDocument.Paragraphs.Add(_range);
                return paragraph;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 在当前光标位置添加段落
        /// 吴海龙
        /// 2016-08-04
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Paragraph AddParagraphAtSelection()
        {
            try
            {
                return AddParagraphAtSelection(WordApplication.GetInstance().WordApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 在range出添加段落
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_rangeTemp"></param>
        /// <returns></returns>
        public static Word.Paragraph AddParagraphAtRange(Microsoft.Office.Interop.Word.Application WordApp,Word.Range p_rangeTemp)
        {
            try
            {
                //Globals.ThisAddIn.Application.Selection
                Word.Paragraph paragraph = p_rangeTemp.Paragraphs.Add(ref oMissing);
                if (paragraph.Range.Text==string.Empty)
                {
                    paragraph.Range.Text = "/r";
                }
                //Word.Range _range = WordApp.ActiveDocument.Range(WordApp.ActiveDocument.Paragraphs.Last.Range.End - 1, WordApp.ActiveDocument.Paragraphs.Last.Range.End);
                //Word.Paragraph paragraph = WordApp.ActiveDocument.Paragraphs.Add(_range);
                return paragraph;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
                return null;
            }
        }

        /// <summary>
        /// 在range出添加段落
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static Word.Paragraph AddParagraphAtRangeEnd(Word.Range range)
        {
            try
            {
                Word.Paragraph p = range.Paragraphs.Add(ref oMissing);
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 管理论文末尾引文

        /// <summary>
        /// 填充论文末尾引文
        /// </summary>
        public static void FillQuotation() { }

        #endregion

        #region 插入文献引用整体流程
        /// <summary>
        /// 测试插入文献引用流程
        /// </summary>
        public static void InserLiteratureReference(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nNo = GetNextMarkNo(WordApp);
                string _strIndex = string.Format(@"[{0}]", _nNo);
                AddQuotationBookMarkIndex(WordApp, _strIndex);
                AddQuotationBookMarkTitle(WordApp);
                string _strQuotation = GetQuotationContext(_nNo.ToString());
                AddQuotationBookMarkItem(WordApp, _strQuotation);
                List<int> _listBookMarkNo = AdjustQuotationIndexByPosition(WordApp);
                AdjustQuotationItemByIndex(WordApp, _listBookMarkNo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// 获取所插入引文的详细信息
        /// 2016-03-29
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        private static string GetQuotationContext(string p_strQuotationNo)
        {
            return string.Format("[{0}] {0}", p_strQuotationNo);
        }
        #endregion

        #region 设置样式

        /// <summary>
        /// 设置文中引文样式
        /// 2016-03-31
        /// wuhailong
        /// </summary>
        public static void SetQuotationIndexStyle() { }

        /// <summary>
        /// 设置引文标题样式
        /// 2016-03-31
        /// wuhailong
        /// </summary>
        public static void SetQuotationTitleStyle() { }

      
        /// <summary>
        /// 设置文末引文样式
        /// 2016-03-31
        /// wuhailong
        /// </summary>
        public static void setQuotationItemStyle() { }

        /// <summary>
        /// 设置文末引文 索引样式
        /// 2016-03-31
        /// wuhailong
        /// </summary>
        public static void SetQuotationItemIndexStyle() { }
        #endregion


        #region 返回下一个FieldNO

        /// <summary>
        /// 返回下一个BIMT域应该的标志
        /// </summary>
        /// <returns></returns>
        public static int GetNextFieldNo(Microsoft.Office.Interop.Word.Application WordApp, Quotation q)
        {
            try
            {
                int _nNo = 1;
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    string _strCur = QuotationIndex.FLAG + "_" + q.GetCurrentAuthorYear();
                    string _strCode = item.Code.Text;
                    if (_strCode.Contains(QuotationIndex.FLAG))
                    {
                        if (_strCode.Contains(_strCur))
                        {
                            return _nNo;
                        }
                        _nNo++;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
                return -1;
            }
        }

        #endregion

        #region 获取最大Field NO

        /// <summary>
        /// 获取最大的bookmark NO ,没有返回 0
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static int GetMaxFieldNo(Microsoft.Office.Interop.Word.Application WordApp)
        {
            try
            {
                int _nTemp = 0;
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationIndex.FLAG))
                    {
                        _nTemp++;
                    }
                }
                return _nTemp;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
                return 0;
            }
        }

        #endregion


        #region 获取字符串中数字

        /// <summary>
        /// 输出字符串中的数字
        /// 2016-04-07
        /// wuhailong
        /// </summary>
        /// <param name="p_strR"></param>
        /// <returns></returns>
        public static int GetNum(string p_strR)
        {
            //string _strReg = @"(\d+)";//(\d+)
            string _strReg = @"[0-9]+(?=[^0-9]*$)";
            var match = Regex.Match(p_strR, _strReg);
            return int.Parse(match.Captures[0].ToString());
        }
        #endregion

        #region 添加域
        /// <summary>
        /// 将当range加为域
        /// 2016-04-18
        /// 吴海龙
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_range"></param>
        /// <param name="p_strCode"></param>
        /// <param name="p_strAuthor">作者存储到 field的data中</param>
        /// <param name="p_strPubYear">出版年存储到 field的data中</param>
        /// <returns></returns>
        public static Word.Field AddField(Microsoft.Office.Interop.Word.Application WordApp, Word.Range p_range, string p_strCode, string p_strAuthor, string p_strPubYear)
        {
            try
            {
                string _strText = p_range.Text;
                object fieldType = Word.WdFieldType.wdFieldKeyWord;
                object formula = p_strCode;
                object presrveFormatting = false;
                Word.Field _field = WordApp.ActiveDocument.Fields.Add(p_range, ref fieldType, ref formula, ref presrveFormatting);
                _field.Result.Text = _strText;
                return _field;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
                return null;
            }

        }

        /// <summary>
        /// 将汉字字体转换为可识别字符串
        /// 2016-04-07
        /// wuahilong
        /// </summary>
        /// <param name="p_strName"></param>
        /// <returns></returns>
        public static string FixFontSize(string p_strName)
        {
//9
//10
//12
//14
//18
            string _strResult = "12";
            p_strName = p_strName.Trim();
            switch (p_strName)
            {
                case "小五":
                    _strResult = "9";
                    break;
                case "五号":
                    _strResult = "10.5";
                    break;
                case "小四":
                    _strResult = "12";
                    break;
                case "四号":
                    _strResult = "14";
                    break;
                case "小三":
                    _strResult = "15";
                    break;
                case "三号":
                    _strResult = "16";
                    break;
                case "小二":
                    _strResult = "18";
                    break;
                case "9":
                    _strResult = "9";
                    break;
                case "10":
                    _strResult = "10";
                    break;
                case "12":
                    _strResult = "12";
                    break;
                case "14":
                    _strResult = "14";
                    break;
                case "18":
                    _strResult = "18";
                    break;
                default:
                    LogHelper.WriteLog(typeof(QuotationIndex), "未知字号" + _strResult);
                    break;
            }
            return _strResult;
        }

        /// <summary>
        /// 判断字符串是否为中文字符串，假如包含中文则true否者false；
        /// wuhailong
        /// 2016-07-09
        /// </summary>
        /// <param name="p_strItem"></param>
        /// <returns></returns>
        public static bool IsCnString(string p_strItem)
        {
            try
            {
                string _strReg = @"[\u4e00-\u9fa5]";
                var matches = Regex.Matches(p_strItem, _strReg);
                if (matches.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return false;
            }
        }

        /// <summary>
        /// 将模板内容写入指定range，并返回对象
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="range">range</param>
        /// <param name="templetName">模板名称</param>
        /// <param name="p_strFieldCode">usrName code</param>
        /// <returns></returns>
        public static Word.Field WriteQuotationFieldAtRange(Microsoft.Office.Interop.Word.Application WordApp, Word.Range range, string templetName, Quotation quotation)
        {
            //return WriteQuotationFieldAtRangeAtOnce(WordApp, range, templetName, quotation);
            //先加域，再组织内容
            try
            {
                string _strResult = string.Empty;
                string _strTemp = JsonHelper.GetValue(templetName);
                string _strTemplet = _strTemp.Split('#')[1];
                if (PublicVar.WriteIndex)
                {
                    string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                    string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                    _strTemplet = "<" + _strPrefix + "_0>" + _strTemplet + "<" + _strSuffix + "_0>";
                }
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);

                Word.Range _rangeDone = WordApp.ActiveDocument.Range(range.Start, range.Start + _strResult.Length);
                Word.Field _field = AddField(WordApp, _rangeDone, templetName + "_" + quotation.GetCurrentAuthorYear());

                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    Word.Range _range = WordApp.ActiveDocument.Range(_field.Result.Start + _strResult.Length, _field.Result.Start + _strResult.Length);
                    _strResult += CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, quotation);
                }
                return _field;
            }
            catch (Exception ex)
            {
                throw new Exception("WriteQuotationFieldAtRange", ex);
            }
        }

        /// <summary>
        /// 将文献list添加到range并生成域
        /// wuhailong
        /// 2016-09-22
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="range"></param>
        /// <param name="templetName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Word.Field WriteQuotationFieldAtRange(Microsoft.Office.Interop.Word.Application WordApp, Word.Field field, string templetName, List<Quotation> list)
        {
            try
            {
                field.Result.Text = string.Empty;
                //Word.Range range =WordApp.ActiveDocument.Range(usrName.Result.Start, usrName.Result.Start);
                //usrName.Delete();
                string result = string.Empty;
                string _strTemp = JsonHelper.GetValue(templetName);
                string _strTemplet = _strTemp.Split('#')[1];
                //range.Text = string.Empty;
                if (PublicVar.WriteIndex)
                {
                    string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                    field.Result = CommonFunction.AppendTextAtRange2(_strPrefix + "_0", field.Result);
                }

                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                string authorYears = string.Empty;
                string SPLIT = JsonHelper.GetValue("QUOTATION_INDEX_AUTHOR_YEAR_CHAR");
                int end = field.Result.End;
                foreach (Quotation quotation in list)
                {
                    result = string.Empty;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                        Word.Range _range = WordApp.ActiveDocument.Range(field.Result.End, field.Result.End);
                        result = CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, quotation);
                        field.Result.End = field.Result.End + result.Length;
                    }

                  //  authorYears += quotation.GetCurrentAuthorYear() + "#";
                  //  for (int i = 0; i < matches.Count; i++)
                  //  {
                  //      var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                  //      string value = quotation.GetFieldValue(WordApp, _strFieldAndStyleMix.Split('_')[0]);// +"_" + _strFieldAndStyleMix.Split('_')[1];
                  //      if (value.Contains('#'))
                  //      {
                  //          string[] authors = value.Split('#');

                  //          value = authors[0] + "_" + _strFieldAndStyleMix.Split('_')[1];
                  //          range = CommonFunction.AppendTextAtRange2(value, range);
                  //          string ILITIC = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                  //          if ("TRUE" == ILITIC.ToUpper())
                  //          {
                  //              value = authors[1] + "_3";
                  //          }
                  //          else
                  //          {
                  //              value = authors[1] + "_" + _strFieldAndStyleMix.Split('_')[1];
                  //          }
                           
                  //          range = CommonFunction.AppendTextAtRange2(value, range);
                  //      }
                  //      else
                  //      {
                  //          value = value + "_" + _strFieldAndStyleMix.Split('_')[1];
                  //          range = CommonFunction.AppendTextAtRange2(value, range);
                  //      }
                  //  }
                    //Word.Range rangeSplit = WordApp.ActiveDocument.Range(end, end);
                    int index = list.FindIndex(s => s.title == quotation.title);
                    if (!(index + 1 == list.Count))
                    {
                        field.Result = CommonFunction.AppendTextAtRange2(SPLIT + "_0", field.Result);
                        //end = rangeSplit.End;
                    }
                }
                authorYears = authorYears.Trim('#');
                if (PublicVar.WriteIndex)
                {
                    //Word.Range rangeSuff = WordApp.ActiveDocument.Range(end, end);
                    string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                    field.Result = CommonFunction.AppendTextAtRange2(_strSuffix + "_0", field.Result);
                    //end = rangeSuff.End;
                }
                //range.End = end;
                //Word.Range rangeEnd = WordApp.ActiveDocument.Range(range.Start, end);
                //Word.Field _field = AddField(WordApp, range, templetName + "_" + authorYears);
                return field;
            }
            catch (Exception ex)
            {
                throw new Exception("WriteQuotationFieldAtRange", ex);
            }
        }

        /// <summary>
        /// 将模板内容写入指定range，并返回对象
        /// 2016-04-19
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="range">range</param>
        /// <param name="templetName">模板名称</param>
        /// <param name="p_strFieldCode">usrName code</param>
        /// <returns></returns>
        public static Word.Field WriteQuotationFieldAtRange( Word.Range range, string templetName, Quotation quotation)
        {
            //return WriteQuotationFieldAtRangeAtOnce(WordApp, range, templetName, quotation);
            //先加域，再组织内容
            try
            {
              return WriteQuotationFieldAtRange(WordApplication.GetInstance().WordApp, range,  templetName,  quotation);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //先组织再加域
        //try
        //{
        //    string _strResult = string.Empty;
        //    string _strTemplet = JsonHelper.GetValue(p_strTempletName); ;
        //    string _strReg = @"<([^<>]*)>";
        //    var matches = Regex.Matches(_strTemplet, _strReg);

        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
        //        Word.Range _range = WordApp.ActiveDocument.Range(p_range.Start + _strResult.Length, p_range.Start + _strResult.Length);
        //        SetFieldStyle(_range, _strFieldAndStyleMix.Split('_')[1]);
        //        _strResult += CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, p_objQuotation);
        //    }
        //    //测试
        //    return null;
        //    Word.Range _rangeDone = WordApp.ActiveDocument.Range(p_range.Start, p_range.Start + _strResult.Length);
        //    return AddField(WordApp, _rangeDone, p_strTempletName + "_" + p_objQuotation.GetCurrentAuthorYear());
        //}
        //catch (Exception ex)
        //{
        //    LogHelper.WriteLog(typeof(QuotationIndex), ex);
        //    return null;
        //}

        /// <summary>
        /// 一次性写入引文内容，然后再进行效果渲染
        /// 2016-05-25
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="range">range</param>
        /// <param name="templetName">模板名称</param>
        /// <param name="p_strFieldCode">usrName code</param>
        /// <returns></returns>
        public static Word.Field WriteQuotationFieldAtRangeAtOnce(Microsoft.Office.Interop.Word.Application WordApp, Word.Range range, string templetName, Quotation quotation)
        {
            //先加域，再组织内容
            try
            {
                string _strResult = string.Empty;
                string _strTemp = JsonHelper.GetValue(templetName);
                string _strTemplet = _strTemp.Split('#')[1];
                if (PublicVar.WriteIndex)
                {
                    string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                    string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                    _strTemplet = "<" + _strPrefix + "_0>" + _strTemplet + "<" + _strSuffix + "_0>";
                }
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);

                Word.Range _rangeDone = WordApp.ActiveDocument.Range(range.Start, range.Start + _strResult.Length);
                Word.Field _field = AddField(WordApp, _rangeDone, templetName + "_" + quotation.GetCurrentAuthorYear());

                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    //Word.Range _range = WordApp.ActiveDocument.Range(_field.Result.Start + _strResult.Length, _field.Result.Start + _strResult.Length);
                    string[] _params = _strFieldAndStyleMix.Split('_');
                    _strResult += quotation.GetFieldValue(WordApp, _params[0]);// CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, quotation);
                }
                _field.Result.Text = _strResult;
                return _field;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
         
        }

        /// <summary>
        /// 将模板内容写入指定range，并返回对象
        /// 2016-05-17
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_range"></param>
        /// <param name="p_strTempletName"></param>
        /// <param name="p_objQuotation"></param>
        /// <param name="isQuotationIndex"></param>
        /// <returns></returns>
        public static Word.Field WriteQuotationFieldAtRange(Microsoft.Office.Interop.Word.Application WordApp, Word.Range p_range, string p_strTempletName, Quotation p_objQuotation,bool isQuotationIndex)
        {
            //先加域，再组织内容
            try
            {
                string _strResult = string.Empty;
                string _strTemp = JsonHelper.GetValue(p_strTempletName);
                string _strTemplet = _strTemp.Split('#')[1];
                if (isQuotationIndex)
                {
                    string _strPrefix = JsonHelper.GetValue("QUOTATION_INDEX_PREFIX");
                    string _strSuffix = JsonHelper.GetValue("QUOTATION_INDEX_SUFFIX");
                    _strTemplet = "<" + _strPrefix + "_0>" + _strTemplet + "<" + _strSuffix + "_0>";
                }
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);

                Word.Range _rangeDone = WordApp.ActiveDocument.Range(p_range.Start, p_range.Start + _strResult.Length);
                Word.Field _field = AddField(WordApp, _rangeDone, p_strTempletName + "_" + p_objQuotation.GetCurrentAuthorYear());

                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    Word.Range _range = WordApp.ActiveDocument.Range(_field.Result.Start + _strResult.Length, _field.Result.Start + _strResult.Length);
                    _strResult += CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, p_objQuotation);
                }
                return _field;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 向range写入引文内容
        /// 2016-05-17
        /// wuhailong
        /// </summary>
        /// <param name="WordApp">word 对象</param>
        /// <param name="range">区域</param>
        /// <param name="templetName">标志名称</param>
        /// <param name="templetString">模板</param>
        /// <param name="quotation">引文对象</param>
        /// <returns></returns>
        public static void WriteQuotationAtRange(Microsoft.Office.Interop.Word.Application WordApp, Word.Range range, string templetName, string templetString, Quotation quotation)
        {
            try
            {
                string _strResult = string.Empty;
                string _strTemplet = templetString;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                for (int i = 0; i < matches.Count; i++)
                {
                    var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
                    Word.Range _range = WordApp.ActiveDocument.Range(range.Start + _strResult.Length, range.Start + _strResult.Length);
                    _strResult += CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, quotation);
                }
                //return _field;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                //return null;
            }
            //try
            //{
            //    string _strResult = string.Empty;
            //    string _strTemplet = templetString;
            //    string _strReg = @"<([^<>]*)>";
            //    var matches = Regex.Matches(_strTemplet, _strReg);
            //    Word.Range _rangeDone = WordApp.ActiveDocument.Range(range.Start, range.Start + _strResult.Length);
            //    Word.Field _field = AddField(WordApp, _rangeDone, templetName + "_" + quotation.GetCurrentAuthorYear());
            //    for (int i = 0; i < matches.Count; i++)
            //    {
            //        var _strFieldAndStyleMix = matches[i].Captures[0].Value.Replace("<", "").Replace(">", "");
            //        Word.Range _range = WordApp.ActiveDocument.Range(_field.Result.Start + _strResult.Length, _field.Result.Start + _strResult.Length);
            //        _strResult += CommonFunction.AddTextAtRange(WordApp, _strFieldAndStyleMix, _range, quotation);
            //    }
            //    return _field;
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(QuotationIndex), ex);
            //    return null;
            //}
        }

        /// <summary>
        /// 设置range 粗体、斜体、下划线
        /// 2016-04-27
        /// wuhailong
        /// </summary>
        /// <param name="range"></param>
        /// <param name="p_strStyleFlag"></param>
        public static void SetFieldStyle(Word.Range range, string p_strStyleFlag)
        {
            if (p_strStyleFlag == "1")
            {
                range.Font.Bold = 1;
            }
            else if (p_strStyleFlag == "3")
            {
                range.Font.Italic = 1;
            }
            else if (p_strStyleFlag == "5")
            {
                range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
        }
        #region 通过光标返回所在引文
        /// <summary>
        /// 通过光标返回所在引文
        /// </summary>
        /// <param name="WordApp"></param>
        /// <returns></returns>
        public static Word.Field GetFieldBySection(Microsoft.Office.Interop.Word.Application WordApp)
        {
            int _nLocationStart = WordApp.Selection.Start;
            int _nLocationEnd = WordApp.Selection.End;
            foreach (Word.Field item in WordApp.ActiveDocument.Fields)
            {
                //相邻就合并
                int _nStart = item.Code.Start;// (item.Result.Start - item.Code.End);
                int _nEnd = item.Result.End; //(item.Result.End - item.Code.End);
                //if (_nLocationStart != 0)
                //{
                //    _nLocationStart = _nLocationStart - item.Result.End;
                //}

                if (_nStart <= _nLocationStart + 1 && _nLocationStart - 1 <= _nEnd)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// 获取当前域的作者年信息
        /// wuhailong
        /// 2016-04-20
        /// </summary>
        /// <param name="p_field"></param>
        /// <returns></returns>
        public static string GetFieldAuthorYear(Word.Field p_field)
        {
            try
            {
                return GetFieldAuthorYear(p_field, 1);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        /// <summary>
        /// 获取当前域的作者年信息
        /// QuotationFlag小于0 位获取文末引文作者年信息
        /// wuhailong
        /// 2016-04-20
        /// </summary>
        /// <param name="p_field"></param>
        /// <returns></returns>
        public static string GetFieldAuthorYear(Word.Field p_field, int QuotationFlag)
        {
            try
            {
                string _strFlag = string.Empty;
                if (QuotationFlag > 0)
                {
                    _strFlag = QuotationIndex.FLAG;
                }
                else
                {
                    _strFlag = QuotationItem.FLAG;
                }
                if (p_field.Code.Text.Contains(_strFlag))
                {
                    string _strNeedClear = "KEYWORDS " + _strFlag + "_";
                    string code = p_field.Code.Text.Replace(_strNeedClear, string.Empty);
                    string[] arrayCode = code.Split('_');
                    return code;// arrayCode[0].Trim() + "_" + arrayCode[1].Trim();//.Replace(_strNeedClear, string.Empty);
                }
                return string.Empty;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 向range内追加文本 格式按照fieldAndStyle设置
        /// wuhailong
        /// 2016-09-22
        /// </summary>
        /// <param name="fieldAndStyle">字段及样式</param>
        /// <param name="range">range</param>
        /// <returns></returns>
        public static Word.Range AppendTextAtRange2(string fieldAndStyle, Word.Range range)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application WordApp = WordApplication.GetInstance().WordApp;
                string[] arrayFieldStyle = fieldAndStyle.Split('_');

                string fixedValue = arrayFieldStyle[0];// quotation.GetFieldValue(WordApp, arrayFieldStyle[0]);
                int start = range.End;
                int end = range.End + fixedValue.Length;
                Word.Range rangeTemp = WordApp.ActiveDocument.Range(start, start);
                rangeTemp.Text = fixedValue;
               
                range.SetRange(range.Start, rangeTemp.End);
                SetRangeStyle(rangeTemp, arrayFieldStyle[1]);
                return range;
            }
            catch (Exception ex)
            {
                throw new Exception("AppendTextAtRange", ex);
            }
        }

        /// <summary>
        /// 在文末添加文字,参数为包含样式说明的字段
        /// 2016-04-06
        /// wuahilong
        /// </summary>
        public static Word.Range AppendTextAtRange2(string fieldAndStyle, Word.Range range, Quotation quotation)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application WordApp = WordApplication.GetInstance().WordApp;
                string[] arrayFieldStyle = fieldAndStyle.Split('_');
                string fixedValue = quotation.GetFieldValue(WordApp, arrayFieldStyle[0]);
                if (fixedValue.Contains("#"))//作者超过规定个数其他作者替代符
                {
                    string[] arrayAuthors = fixedValue.Split('#');
                    //作者信息
                    fixedValue = arrayAuthors[0];
                    int start = range.Start;//
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        SetRangeStyle(range, arrayFieldStyle[1]);
                    }
                    //其他作者信息
                    fixedValue = arrayAuthors[1];
                    start = end;

                    range.SetRange(start, end);
                    range.Text = fixedValue;
                    string otherStyle = string.Empty;//
                    if (PublicVar.WriteIndex)//文中其他作者斜体
                    {
                        otherStyle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                    }

                    else if (!PublicVar.WriteIndex)//文末其他作者斜体
                    {
                        otherStyle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
                    }
                    string _strStyle = "0";//斜体标志
                    if ("TRUE" == otherStyle.ToUpper())
                    {
                        _strStyle = "3";
                    }
                    if (fixedValue.Length > 0)
                    {
                        SetRangeStyle(range, _strStyle);
                    }
                    return range;
                }
                else if (fixedValue == "{0}")
                {//序号
                    QuotationIndex qIndex = QuotationIndex.GetInstance(null);
                    int index = qIndex.GetQuotationIndexOrder(quotation);
                    fixedValue = string.Format(fixedValue, index);
                    int start = range.Start;
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        Word.Range rangeTemp = WordApp.ActiveDocument.Range(start, end);
                        SetRangeStyle(rangeTemp, arrayFieldStyle[1]);
                    }
                    return range;
                }
                {//其他字段
                    int start = range.Start;
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        Word.Range rangeTemp = WordApp.ActiveDocument.Range(start, end);
                        SetRangeStyle(rangeTemp, arrayFieldStyle[1]);
                    }
                    return range;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AppendTextAtRange", ex);
            }
        }

        /// <summary>
        /// 在文末添加文字,参数为包含样式说明的字段
        /// 2016-04-06
        /// wuahilong
        /// </summary>
        public static string AppendTextAtRange( string fieldAndStyle, Word.Range range, Quotation quotation)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application WordApp = WordApplication.GetInstance().WordApp;
                string[] arrayFieldStyle = fieldAndStyle.Split('_');
                string fixedValue = quotation.GetFieldValue(WordApp, arrayFieldStyle[0]);
                if (fixedValue.Contains("#"))//作者超过规定个数其他作者替代符
                {
                    string[] arrayAuthors = fixedValue.Split('#');
                    //作者信息
                    fixedValue = arrayAuthors[0];
                    int start = range.Start;//
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        SetRangeStyle(range, arrayFieldStyle[1]);
                    }
                    //其他作者信息
                    fixedValue = arrayAuthors[1];
                    start = end;
                   
                    range.SetRange(start, end);
                    range.Text = fixedValue;
                    string otherStyle = string.Empty;//
                    if (PublicVar.WriteIndex)//文中其他作者斜体
                    {
                        otherStyle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                    }
                    
                    else if (!PublicVar.WriteIndex)//文末其他作者斜体
                    {
                        otherStyle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
                    }
                    string _strStyle = "0";//斜体标志
                    if ("TRUE" == otherStyle.ToUpper())
                    {
                        _strStyle = "3";
                    }
                    if (fixedValue.Length > 0)
                    {
                        SetRangeStyle(range, _strStyle);
                    }
                    return arrayAuthors[0] + arrayAuthors[1];
                }
                else if (fixedValue == "{0}")
                {//序号
                    QuotationIndex qIndex = QuotationIndex.GetInstance(null);
                    int index = qIndex.GetQuotationIndexOrder(quotation);
                    fixedValue = string.Format(fixedValue, index);
                    int start = range.Start;
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        Word.Range rangeTemp = WordApp.ActiveDocument.Range(start, end);
                        SetRangeStyle(rangeTemp, arrayFieldStyle[1]);
                    }
                    return fixedValue;
                }
                {//其他字段
                    int start = range.Start;
                    int end = start + fixedValue.Length;
                    range.Text = fixedValue;
                    if (fixedValue.Length > 0)
                    {
                        Word.Range rangeTemp = WordApp.ActiveDocument.Range(start, end);
                        SetRangeStyle(rangeTemp, arrayFieldStyle[1]);
                    }
                    return fixedValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AppendTextAtRange", ex);
            }
        }

        /// <summary>
        /// 在文末添加文字,参数为包含样式说明的字段
        /// 2016-04-06
        /// wuahilong
        /// </summary>
        public static string AddTextAtRange(Microsoft.Office.Interop.Word.Application WordApp,string p_strFieldAndStyleMix, Word.Range p_range,Quotation quotation)
        {
            try
            {
                string[] _params = p_strFieldAndStyleMix.Split('_');
                string _strFiexedValue = quotation.GetFieldValue(WordApp, _params[0]);
                if (_strFiexedValue.Contains("#"))//作者超过规定个数其他作者替代符
                {
                    string[] _arrAuthor = _strFiexedValue.Split('#');
                    //作者信息
                    _strFiexedValue = _arrAuthor[0];
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;
                    p_range.Text = _strFiexedValue;
                    if (_strFiexedValue.Length > 0)
                    {
                        SetRangeStyle(p_range, _params[1]);
                    }
                    //其他作者信息
                    _strFiexedValue = _arrAuthor[1];
                    _nStart = _nEnd;
                    p_range.SetRange(_nStart, _nEnd);
                    p_range.Text = _strFiexedValue;
                    string _strOtherAuthorSytle = string.Empty;//
                    if (PublicVar.WriteIndex)//英文、文中引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                    }
                    else if (!PublicVar.WriteIndex)//英文、文末引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
                    }
                    string _strStyle = "0";//斜体标志
                    if ("TRUE" == _strOtherAuthorSytle.ToUpper())
                    {
                        _strStyle = "3";
                    }
                    if (_strFiexedValue.Length > 0)
                    {
                        SetRangeStyle(p_range, _strStyle);
                    }
                    return _arrAuthor[0] + _arrAuthor[1];
                }
                else
                {
                    if (_strFiexedValue == "{0}")
                    {
                        //Word.Field _field = GetFieldByCodeText(WordApp, QuotationIndex.FLAG + "_" + quotation.GetCurrentAuthorYear());
                        int _nNo = QuotationItem.GetQuotationItemOrder(quotation);// GetMaxFieldNo(WordApp);// GetNum(_field.Result.Text);
                        _strFiexedValue = string.Format(_strFiexedValue, _nNo);
                    }
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;
                    p_range.Text = _strFiexedValue;
                    if (_strFiexedValue.Length > 0)
                    {
                        Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(_rangeMark, _params[1]);
                    }
                    return _strFiexedValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        ///在rangen内添加文本，并返回
        /// 2016-04-06
        /// wuahilong
        /// </summary>
        //public  Word.Range AddTextAtRange2(Microsoft.Office.Interop.Word.Application WordApp, string p_strFieldAndStyleMix, Word.Range p_range, Quotation quotation)
        //{
        //    try
        //    {
        //        string[] _params = p_strFieldAndStyleMix.Split('_');
        //        string _strFiexedValue = quotation.GetFieldValue2(WordApp, _params[0]);
        //        if (_strFiexedValue.Contains("#"))//作者超过规定个数其他作者替代符
        //        {
        //            string[] _arrAuthor = _strFiexedValue.Split('#');
        //            //作者信息
        //            _strFiexedValue = _arrAuthor[0];
        //            int _nStart = p_range.Start;//
        //            int _nEnd = _nStart + _strFiexedValue.Length;
        //            p_range.Text = _strFiexedValue;
        //            if (_strFiexedValue.Length > 0)
        //            {
        //                //Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
        //                SetRangeStyle(p_range, _params[1]);
        //            }
        //            //其他作者信息
        //            _strFiexedValue = _arrAuthor[1];
        //            _nStart = _nEnd;
        //            //Word.Range _rangeTemp = WordApp.ActiveDocument.Range(_nStart, _nStart);
        //            //_rangeTemp.Text = _strFiexedValue;
        //            //_nEnd = _nStart + _strFiexedValue.Length;
        //            p_range.SetRange(_nStart, _nEnd);
        //            p_range.Text = _strFiexedValue;
        //            string _strOtherAuthorSytle = string.Empty;//
        //            if (PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文中引文
        //            {
        //                _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
        //            }
        //            else if (PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文中引文
        //            {
        //                _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC");
        //            }
        //            else if (!PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文末引文
        //            {
        //                _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
        //            }
        //            else if (!PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文末引文
        //            {
        //                _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_CN");
        //            }
        //            string _strStyle = "0";//斜体标志
        //            if ("TRUE" == _strOtherAuthorSytle.ToUpper())
        //            {
        //                _strStyle = "3";
        //            }
        //            if (_strFiexedValue.Length > 0)
        //            {
        //                SetRangeStyle(p_range, _strStyle);
        //            }
        //            return p_range;// _arrAuthor[0] + _arrAuthor[1];
        //        }
        //        else
        //        {
        //            if (_strFiexedValue == "{0}")
        //            {
        //                //Word.Field _field = GetFieldByCodeText(WordApp, QuotationIndex.FLAG + "_" + quotation.GetCurrentAuthorYear());
        //                int _nNo = QuotationItem.GetQuotationItemOrder(quotation);// GetMaxFieldNo(WordApp);// GetNum(_field.Result.Text);
        //                _strFiexedValue = string.Format(_strFiexedValue, _nNo);
        //            }
        //            int _nStart = p_range.Start;//
        //            int _nEnd = _nStart + _strFiexedValue.Length;
        //            p_range.Text = _strFiexedValue;
        //            if (_strFiexedValue.Length > 0)
        //            {
        //                Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
        //                SetRangeStyle(_rangeMark, _params[1]);
        //            }
        //            return p_range;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(typeof(QuotationIndex), ex);
        //        return null;
        //    }
        //}

        /// <summary>
        /// 为文【中】引文刷新特制的函数
        /// 2016-05-19
        /// wuahilong
        /// </summary>
        public static string AddTextAtRangeForIndex(Microsoft.Office.Interop.Word.Application WordApp, string p_strFieldAndStyleMix, Word.Range p_range, Quotation quotation)
        {
            try
            {
                string[] _params = p_strFieldAndStyleMix.Split('_');
                string _strFiexedValue = quotation.GetFieldValue(WordApp, _params[0]);
                if (_strFiexedValue.Contains("#"))//作者超过规定个数其他作者替代符
                {
                    string[] _arrAuthor = _strFiexedValue.Split('#');
                    //作者信息
                    _strFiexedValue = _arrAuthor[0];
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;
                    p_range.Text = _strFiexedValue;

                    if (_strFiexedValue.Length > 0)
                    {
                        //Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(p_range, _params[1]);
                    }
                    //其他作者信息
                    _strFiexedValue = _arrAuthor[1];
                    _nStart = _nEnd;
                    //Word.Range _rangeTemp = WordApp.ActiveDocument.Range(_nStart, _nStart);
                    //_rangeTemp.Text = _strFiexedValue;
                    //_nEnd = _nStart + _strFiexedValue.Length;
                    p_range.SetRange(_nStart, _nEnd);
                    p_range.Text = _strFiexedValue;
                    string _strOtherAuthorSytle = string.Empty;//
                    if (PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文中引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                    }
                    else if (PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文中引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC");
                    }
                    else if (!PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文末引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
                    }
                    else if (!PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文末引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_CN");
                    }

                    string _strStyle = "0";//斜体标志
                    if ("TRUE" == _strOtherAuthorSytle.ToUpper())
                    {
                        _strStyle = "3";
                    }
                    if (_strFiexedValue.Length > 0)
                    {
                        //Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(p_range, _strStyle);
                    }
                    return _arrAuthor[0] + _arrAuthor[1];
                }
                else
                {


                    if (_strFiexedValue == "{0}")
                    {
                        //Word.Field _field = GetFieldByCodeText(WordApp, QuotationIndex.FLAG + "_" + quotation.GetCurrentAuthorYear());
                        QuotationIndex qIndex = QuotationIndex.GetInstance(null);
                        int _nNo = qIndex.GetQuotationIndexOrder(quotation);// GetMaxFieldNo(WordApp);// GetNum(_field.Result.Text);
                        _strFiexedValue = string.Format(_strFiexedValue, _nNo);
                    }
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;

                    p_range.Text = _strFiexedValue;

                    if (_strFiexedValue.Length > 0)
                    {
                        Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(_rangeMark, _params[1]);
                    }

                    return _strFiexedValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 位文中引【末】刷新特制的函数
        /// 2016-05-19
        /// wuahilong
        /// </summary>
        public static string AddTextAtRangeForItem(Microsoft.Office.Interop.Word.Application WordApp, string p_strFieldAndStyleMix, Word.Range p_range, Quotation quotation)
        {
            try
            {
                string[] _params = p_strFieldAndStyleMix.Split('_');
                string _strFiexedValue = quotation.GetFieldValue(WordApp, _params[0]);
                if (_strFiexedValue.Contains("#"))//作者超过规定个数其他作者替代符
                {
                    string[] _arrAuthor = _strFiexedValue.Split('#');
                    //作者信息
                    _strFiexedValue = _arrAuthor[0];
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;
                    p_range.Text = _strFiexedValue;

                    if (_strFiexedValue.Length > 0)
                    {
                        //Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(p_range, _params[1]);
                    }
                    //其他作者信息
                    _strFiexedValue = _arrAuthor[1];
                    _nStart = _nEnd;
                    //Word.Range _rangeTemp = WordApp.ActiveDocument.Range(_nStart, _nStart);
                    //_rangeTemp.Text = _strFiexedValue;
                    //_nEnd = _nStart + _strFiexedValue.Length;
                    p_range.SetRange(_nStart, _nEnd);
                    p_range.Text = _strFiexedValue;
                    string _strOtherAuthorSytle = string.Empty;//
                    if (PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文中引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC_EN");
                    }
                    else if (PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文中引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_INDEX_OTHER_AUTHOR_USE_ILITIC");
                    }
                    else if (!PublicVar.WriteIndex && quotation.IsEnQuotation())//英文、文末引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_EN");
                    }
                    else if (!PublicVar.WriteIndex && !quotation.IsEnQuotation())//中文、文末引文
                    {
                        _strOtherAuthorSytle = JsonHelper.GetValue("QUOTATION_ITEM_ELLIPSIS_CHAR_STYLE_CN");
                    }

                    string _strStyle = "0";//斜体标志
                    if ("TRUE" == _strOtherAuthorSytle.ToUpper())
                    {
                        _strStyle = "3";
                    }
                    if (_strFiexedValue.Length > 0)
                    {
                        //Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(p_range, _strStyle);
                    }
                    return _arrAuthor[0] + _arrAuthor[1];
                }
                else
                {


                    if (_strFiexedValue == "{0}")
                    {
                        //Word.Field _field = GetFieldByCodeText(WordApp, QuotationIndex.FLAG + "_" + quotation.GetCurrentAuthorYear());
                        int _nNo = QuotationItem.GetQuotationItemOrder2(quotation);// GetMaxFieldNo(WordApp);// GetNum(_field.Result.Text);
                        _strFiexedValue = string.Format(_strFiexedValue, _nNo);
                    }
                    int _nStart = p_range.Start;//
                    int _nEnd = _nStart + _strFiexedValue.Length;

                    p_range.Text = _strFiexedValue;

                    if (_strFiexedValue.Length > 0)
                    {
                        Word.Range _rangeMark = WordApp.ActiveDocument.Range(_nStart, _nEnd);
                        SetRangeStyle(_rangeMark, _params[1]);
                    }

                    return _strFiexedValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(QuotationIndex), ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        public static void SetRangeStyle(Word.Range p_strRange, string p_strStyle)
        {
            //Word.Bookmark _markTitle = GetBookMarkByName(WordApp, "QuotationTitle");
            //Word.Range _rangeTitle= _markTitle.Range;
            //_rangeTitle.Select();
            //p_strRange.Font.Name = "";
            //p_strRange.Font.Size = float.Parse("12");
            if (p_strStyle == "9")
            {
                p_strRange.Font.Bold = 1;
                p_strRange.Font.Italic = 1;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (p_strStyle == "8")
            {
                p_strRange.Font.Bold = 0;
                p_strRange.Font.Italic = 1;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (p_strStyle == "6")
            {
                p_strRange.Font.Bold = 1;
                p_strRange.Font.Italic = 0;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (p_strStyle == "5")
            {
                p_strRange.Font.Bold = 0;
                p_strRange.Font.Italic = 0;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;
            }
            else if (p_strStyle == "4")
            {
                p_strRange.Font.Bold = 1;
                p_strRange.Font.Italic = 1;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (p_strStyle == "3")
            {
                p_strRange.Font.Bold = 0;
                p_strRange.Font.Italic = 1;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else if (p_strStyle == "1")
            {
                p_strRange.Font.Bold = 1;
                p_strRange.Font.Italic = 0;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
            else
            {
                p_strRange.Font.Bold = 0;
                p_strRange.Font.Italic = 0;
                p_strRange.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
            }
        }

        /// <summary>
        /// 将当range加为域
        /// 2016-04-07
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_strRange"></param>
        /// <param name="p_strCode"></param>
        /// <returns></returns>
        public static Word.Field AddField(Microsoft.Office.Interop.Word.Application WordApp, Word.Range p_strRange, string p_strCode)
        {
            return AddField(WordApp, p_strRange, p_strCode, string.Empty, string.Empty);
        }

        /// <summary>
        /// 判断是否存在code text指定的域
        /// 2016-04-13
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="codeText"></param>
        /// <returns></returns>
        public static bool ExistField(Microsoft.Office.Interop.Word.Application WordApp, string codeText)
        {
            try
            {
                foreach (Word.Field item in WordApp.ActiveDocument.Fields)
                {
                    if (item.Code.Text.Contains(QuotationItem.FLAG) && item.Code.Text.Contains(codeText))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 判断是否存在code text指定的域
        /// 2016-04-13
        /// wuhailong
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_strCodeText"></param>
        /// <returns></returns>
        public static bool ExistField(string codeText)
        {
            try
            {
                return ExistField(WordApplication.GetInstance().WordApp, codeText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region 通过域code获取域


        /// <summary>
        /// 通过code text 寻找field
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_strCodeText"></param>
        /// <returns></returns>
        public static Word.Field GetFieldByCodeText(Microsoft.Office.Interop.Word.Application WordApp, string p_strCodeText)
        {
            foreach (Word.Field item in WordApp.ActiveDocument.Fields)
            {
                if (item.Code.Text.Contains(p_strCodeText))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过作者年返回文末参考文献的域
        /// wuhailong
        /// 2016-07-16
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="codeText"></param>
        /// <returns></returns>
        //public static Word.Field GetQuotationItemFieldByCodeText(Microsoft.Office.Interop.Word.Application WordApp, string codeText)
        //{
        //    try
        //    {
        //        Word.Field usrName = null;
        //        foreach (Word.Field item in WordApp.ActiveDocument.Fields)
        //        {
        //            string currentCodeText = item.Code.Text;
        //            if (currentCodeText.Contains(QuotationItem.FLAG) && currentCodeText.Contains(codeText))
        //            {
        //                usrName= item;
        //                break;
        //            }
        //        }
        //        return usrName;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
           
        //}


        /// <summary>
        /// 通过作者年返回文末参考文献的域
        /// wuhailong
        /// 2016-07-16
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_strCodeText"></param>
        /// <returns></returns>
        //public static Word.Field GetQuotationItemFieldByCodeText( string codeText)
        //{
        //    try
        //    {
        //        return GetQuotationItemFieldByCodeText(WordApplication.GetInstance().WordApp, codeText);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        #endregion

        #region 获取文件下所有文件的名称

        /// <summary>
        /// 获取文件下所有文件的名称
        /// </summary>
        /// <param name="p_strDir"></param>
        /// <param name="p_strExtension">*.txt;*.cs;*.json</param>
        /// <returns></returns>
        public static List<string> GetFileName(string p_strDir,string p_strExtension) {
            List<string> _listNames = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(p_strDir);
            foreach (FileInfo file in folder.GetFiles(p_strExtension))
            {
                _listNames.Add(file.Name.Replace(file.Extension,string.Empty));
                Console.WriteLine(file.FullName);
            }
            return _listNames;
        }
        #endregion

        internal static void WritField(System.Windows.Forms.RichTextBox QUOTATION_INDEX_FIELD, string p)
        {
            QUOTATION_INDEX_FIELD.AppendText(p);
        }

        #region 插入引文流程

      

        /// <summary>
        /// 插入引文流程传入引文对象
        /// 2016-05-06
        /// wuhailong
        /// </summary>
        /// <param name="q">引文对象</param>
        public static void WriteQuotation(Quotation quotation)
        {
            try
            {
                Word.Field field = CommonFunction.GetFieldBySection(WordApplication.GetInstance().WordApp);
                if (field != null && field.Code.Text.Contains(QuotationSet.FLAG))
                {//引文信息存储关键位置不允许插入
                    MessageBox.Show(null, "当前位置无法引用文献！", "引用文献");
                    return;
                }
                if (!quotation.IsAuthorInfoComplete())
                {//作者信息补全不允许插入
                    MessageBox.Show(null, "当前文献作者信息不完整请补全后引用！", "引用文献");
                    return;
                }
                //文中引文
                QuotationIndex.GetInstance(quotation).WriteContent();
                //引文信息
                QuotationSet set = new QuotationSet(quotation);
                set.WriteContent();
                //文末引文
                QuotationItem item =  QuotationItem.GetInstance(quotation);
                item.WriteContent();
                if (QuotationIndex.IsOrderStyle())
                {//文中引文当为序号制才需要刷新序号
                    PublicVar.WriteIndex = true;
                    QuotationIndex.GetInstance(quotation).RefreshIndex();
                }
                //文末一直需要刷新序号
                PublicVar.WriteIndex = false;
                item.RefreshQuotatationItemIndex();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), new Exception("引用文献", ex));
            }
        }

        public static string ConvertDictToJson(Dictionary<string, object> dic)
        {
            try
            {
                return (new JavaScriptSerializer()).Serialize(dic);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修正json
        /// wuhailong
        /// 2016-07-26
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FixStyleJson(string json)
        {
            try
            {
                Dictionary<string, object> _dictJson = CommonFunction.JsonToDictionary(json);
                string _strJson = CommonFunction.ConvertDictToJson(_dictJson);
                return _strJson;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 引文对象转换为json
        /// 2016-05-06
        /// wuhailong
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        public static string GetJsonString(List<Quotation> qs)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(qs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Dictionary<string, Quotation> JSONStringToDict( string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            Dictionary<string, Quotation> objs = Serializer.Deserialize<Dictionary<string, Quotation>>(JsonStr);
            return objs;
        }

        //public static QuotationSet Deserialize(string json)
        //{
        //    QuotationSet obj = Activator.CreateInstance<QuotationSet>();
        //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        //    {
        //        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        //        return (QuotationSet)serializer.ReadObject(ms);
        //    }
        //}


        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
        public static List<T> JSONStringToList<T>( string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }  

        /// <summary>
        /// 将当前引文行插入到 论文中
        /// 2016-05-06
        /// wuhailong
        /// </summary>
        /// <param name="_drCurrent"></param>
        public static void WriteQuotation(DataGridViewRow _drCurrent)
        {
            Quotation quotation = new Quotation(_drCurrent);
            WriteQuotation(quotation);
        }

        #endregion

        #region 序列化json
        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
                return null;
            }
        }

        /// <summary>
        /// 清洗标题十七符合文件名命名规则
        /// wuhailong
        /// 2016-06-30
        /// 201
        /// </summary>
        /// <param name="sb"></param>
        public static void CleanStringBuilder(StringBuilder sb)
        {
            sb.Replace("\\", string.Empty).Replace("/", string.Empty).Replace("<", string.Empty).Replace(">", string.Empty).Replace("|", string.Empty).Replace("\"", string.Empty).Replace("*", string.Empty).Replace("?", string.Empty).Replace(":", string.Empty);
        }


        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }
        #endregion

        #region config

        /// <summary>
        /// 2015-01-05
        /// 吴海龙
        /// 保存配置信息
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        public static void SaveConfig(string p_strKey, string p_strValue)
        {
            try
            {
                //获取Configuration对象
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //写入<add>元素的Value
                config.AppSettings.Settings[p_strKey].Value = p_strValue;
                config.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CommonFunction), ex);
            }
          
        }


        /// <summary>
        /// 获取节点设置
        /// </summary>
        /// <param name="m_strElementName"></param>
        /// <returns></returns>
        public static string GetConfig(string m_strElementName)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string _strValue = string.Empty;
            ////根据Key读取<add>元素的Value
            try
            {
                _strValue = config.AppSettings.Settings[m_strElementName].Value;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return _strValue;
        }
        #endregion 


        /// <summary>
        /// 刷新样式
        /// 2016-08-05
        /// wuhailong
        /// </summary>
        public static void RefreshStyle()
        {

            try
            {
                QuotationIndex quotationIndex = QuotationIndex.GetInstance(null);
                quotationIndex.RefreshStyle(MagazineStyle.GetInstance().Name);
                bool ok = QuotationIndex.IsOrderStyle();
                if (ok)
                {
                    quotationIndex.RefreshIndex();
                }
                QuotationItem quotationItem = QuotationItem.GetInstance();
                quotationItem.RefreshStyle(MagazineStyle.GetInstance().Name);
                quotationItem.RefreshQuotatationItemIndex();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 删除文中引文了，要联动删除文末引文
        /// 2016-05-16
        /// wuahilong
        /// </summary>
        public static void DeleteQuotation(Microsoft.Office.Interop.Word.Application WordApp)
        {
            Word.Field locatedField = CommonFunction.GetFieldBySection(WordApp);
            if (locatedField.Code.Text.Contains(QuotationIndex.FLAG))
            {
                //QuotationIndex.DeleteIndexQuotation(locatedField);
            }
            else if (locatedField.Code.Text.Contains(QuotationItem.FLAG))
            {
               QuotationItem.GetInstance().DeleteItemQuotation(locatedField);
            }

            //return;
            ////返回啦*************************************************************
            //if (WordApp.Selection.Fields.Count > 0)
            //{
            //    foreach (Word.Field item in WordApp.Selection.Fields)
            //    {
            //        if (item.Code.Text.Contains(QuotationIndex.FLAG))
            //        {
            //            MessageBox.Show(null, "请通过右键菜单删除引文", "删除引文");
            //            WordApp.ActiveDocument.Range(WordApp.Selection.Range.End, WordApp.Selection.Range.End).Select();
            //        }
            //    }
               
            //}
            //return;
            //foreach (Word.Field item in WordApp.ActiveDocument.Fields)
            //{
            //    bool _needDel = true;
            //    //文末引文
            //    if (item.Code.Text.Contains(QuotationItem.FLAG))
            //    {
            //        foreach (Word.Field index in WordApp.ActiveDocument.Fields)
            //        {
            //            //文中引文
            //            if (index.Code.Text.Contains(QuotationIndex.FLAG))
            //            {
            //                //判断文末引文的文中引文是否存在
            //                string _strAuthorYearItem = CommonFunction.GetFieldAuthorYear(item,-1).Trim();
            //                string _strAuthorYearIndex = CommonFunction.GetFieldAuthorYear(index).Trim();
            //                if (_strAuthorYearIndex.Contains(_strAuthorYearItem))
            //                {
            //                    _needDel = false;
            //                }
                            
            //            }
            //        }
            //        if (_needDel)//文中引文已经删除了，文末引文随之删除
            //        {
            //            item.Result.Delete();
            //            //QuotationIndex qindex = new QuotationIndex();
            //            //qindex.RefreshStyle(MagazineStyle.GetInstance().Name);
            //            //QuotationItem qitem = new QuotationItem();
            //            //qitem.RefreshStyle(MagazineStyle.GetInstance().Name);
                     
            //        }
            //    }
            //}

            
        }

        
        

  
        

        #region json
        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }
        #endregion

        #region 判断当前样式是否为中文样式，假如为中文文献返回true

        /// <summary>
        /// 判断当前样式是否为中文样式，假如为中文文献返回true
        /// wuhailong
        /// 2016-07-04
        /// </summary>
        /// <param name="styleName"></param>
        /// <returns></returns>
        public static bool IsCNStyle(string styleName)
        {
            try
            {
                string _strResult = string.Empty;
                string _strTemplet = styleName;// p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
                string _strReg = @"[\u4e00-\u9fa5]";
                var matches = Regex.Matches(_strTemplet, _strReg);
                if (matches.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), "IsCNStyle" + ex.Message);
                return false;
            }
        }

        #endregion

        #region BIMT DIR
        /// <summary>
        /// 获取注册的写作助手目录
        /// 2016-05-27
        /// wuhailong
        /// </summary>
        /// <param name="p_strKey"></param>
        /// <returns></returns>
        public static string GetBIMTDIR()
        {
            try
            {
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey software = hkml.OpenSubKey("Software\\BIMT", true);
                string registData = software.GetValue("BIMT_DIR").ToString();
                return registData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }



}
