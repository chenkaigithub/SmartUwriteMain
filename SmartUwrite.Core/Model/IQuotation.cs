using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace BIMTClassLibrary
{
    /// <summary>
    /// 插入引文接口
    /// 2016-04-06
    /// wuhailong
    /// </summary>
    interface IQuotation
    {
        /// <summary>
        /// 初始化状态参数
        /// </summary>
        void InitStatus();

        /// <summary>
        /// 写入引文
        /// </summary>
        void WriteContent();

        /// <summary>
        /// 刷新样式
        /// </summary>
        /// <param name="styleName"></param>
        void RefreshStyle(string styleName);

        /// <summary>
        /// 设置样式
        /// </summary>
        void SetStyle();

        /// <summary>
        /// 判断所指定的作者年文献是否存在
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        bool ExistField(string authorYear);

        /// <summary>
        /// 获取域的列表
        /// </summary>
        /// <returns></returns>
        List<Word.Field> GetDocFieldList();

        /// <summary>
        /// 通过作者年获取文档的域信息
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        Word.Field GetFieldByAuthorYear(string authorYear);

        /// <summary>
        /// 获取当前域的作者年信息
        /// </summary>
        /// <param name="usrName"></param>
        /// <returns></returns>
        string GetFieldAuthorYearInfo(Word.Field field);

        /// <summary>
        /// 通过作者年获取引文在doc中的位置
        /// </summary>
        /// <param name="authorYear"></param>
        /// <returns></returns>
        int GetQuotationIndex(string authorYear);
        
    }
}
