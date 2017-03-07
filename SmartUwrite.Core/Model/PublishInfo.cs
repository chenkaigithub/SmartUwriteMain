using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    [DataContract(Name = "Author", Namespace = "BIMTClassLibrary")]
    public struct PublishInfo
    {
        // 期刊信息
        [DataMember(Name = "periodicalInfo", IsRequired = false, Order = 0)]
        public PeriodicalInfo periodicalInfo;
        [DataMember(Name = "publishYear", IsRequired = false, Order = 1)]
        public string publishYear;
        [DataMember(Name = "volumeCount", IsRequired = false, Order = 2)]
        public string volumeCount;// - 出版卷数
        [DataMember(Name = "volumeInfo", IsRequired = false, Order = 3)]
        public string volumeInfo;// - 出版卷
        [DataMember(Name = "issueInfo", IsRequired = false, Order = 4)]
        public string issueInfo;// - 出版期
        [DataMember(Name = "column", IsRequired = false, Order = 5)]
        public string column;// - 栏目
        [DataMember(Name = "pageRange", IsRequired = false, Order = 6)]
        public string pageRange;// - 页码
        [DataMember(Name = "wordsCount", IsRequired = false, Order = 7)]
        public string wordsCount;// - 字数
        [DataMember(Name = "price", IsRequired = false, Order = 8)]
        public string price;//- 价格

    }

    [DataContract(Name = "Author", Namespace = "BIMTClassLibrary")]
    public struct PeriodicalInfo
    {
        [DataMember(Name = "name", IsRequired = false, Order = 0)]
        public string name;//- 期刊名称，当前包含中文 / 英文名称
        [DataMember(Name = "nameAbbr", IsRequired = false, Order = 6)]
        public string nameAbbr;//期刊简称
        [DataMember(Name = "place", IsRequired = false, Order = 1)]
        public string place;//出版地
        [DataMember(Name = "press", IsRequired = false, Order = 2)]
        public string press;//- 出版社
        [DataMember(Name = "originalPress", IsRequired = false, Order = 3)]
        public string originalPress; //  - 原出版社
        [DataMember(Name = "reprintEdition", IsRequired = false, Order = 4)]
        public string reprintEdition; //  - 重印版次
        [DataMember(Name = "ISBNISSN", IsRequired = false, Order = 5)]
        public string ISBNISSN; // - ISBN/ISSN号
    }

    [DataContract(Name = "Author", Namespace = "BIMTClassLibrary")]
    public struct ExtraInfo
    {
        [DataMember(Name = "bibliographyType", IsRequired = false, Order = 0)]
        public string bibliographyType; // - 题录类型
        [DataMember(Name = "fundProject", IsRequired = false, Order = 0)]
        public string fundProject; // - 基金项目
        [DataMember(Name = "type", IsRequired = false, Order = 0)]
        public string type; //- 类型
        [DataMember(Name = "subjectClassification", IsRequired = false, Order = 0)]
        public string subjectClassification; // - 学科分类
        [DataMember(Name = "catagory", IsRequired = false, Order = 0)]
        public string catagory; //- 分类
        [DataMember(Name = "topic", IsRequired = false, Order = 0)]
        public string topic; // - 主题
        [DataMember(Name = "titleEntry", IsRequired = false, Order = 0)]
        public string titleEntry; //- 标题项
        [DataMember(Name = "tags", IsRequired = false, Order = 0)]
        public string tags; //- 标签
        [DataMember(Name = "bibTex", IsRequired = false, Order = 0)]
        public string bibTex; // BibTex关键字
        [DataMember(Name = "auxiliaryAuthors", IsRequired = false, Order = 0)]
        public string auxiliaryAuthors; // 辅助作者
        [DataMember(Name = "commentItems", IsRequired = false, Order = 0)]
        public string commentItems; // 评述项
        [DataMember(Name = "factor", IsRequired = false, Order = 0)]
        public string factor; // 影响因子
        [DataMember(Name = "includedRange", IsRequired = false, Order = 0)]
        public string includedRange; // 收录范围
        [DataMember(Name = "comments", IsRequired = false, Order = 0)]
        public string comments; // 注释
        [DataMember(Name = "pics", IsRequired = false, Order = 0)]
        public string pics; // 图片
        [DataMember(Name = "dataProvider", IsRequired = false, Order = 0)]
        public string dataProvider; // 数据库提供者
        [DataMember(Name = "lang", IsRequired = false, Order = 0)]
        public string lang; // 语言
        [DataMember(Name = "nation", IsRequired = false, Order = 0)]
        public string nation; // 国别
        [DataMember(Name = "citationCount", IsRequired = false, Order = 0)]
        public string citationCount; // 引用次数
        [DataMember(Name = "referenceDocumentsCount", IsRequired = false, Order = 0)]
        public string referenceDocumentsCount; // 引用参考文献数
        [DataMember(Name = "referenceDocumentsList", IsRequired = false, Order = 0)]
        public string referenceDocumentsList; // 引用参考文献
        [DataMember(Name = "version", IsRequired = false, Order = 0)]
        public string version; // 版本
        [DataMember(Name = "doi", IsRequired = false, Order = 0)]
        public string doi; // DOI
        [DataMember(Name = "acquisitionNumber", IsRequired = false, Order = 0)]
        public string acquisitionNumber; // 获取号
        [DataMember(Name = "acquisitionBookNumber", IsRequired = false, Order = 0)]
        public string acquisitionBookNumber; // 索书号
        [DataMember(Name = "displayDate", IsRequired = false, Order = 0)]
        public string displayDate; // 显示日期
        [DataMember(Name = "date", IsRequired = false, Order = 0)]
        public string date; // 日期
        [DataMember(Name = "inspectionDate", IsRequired = false, Order = 0)]
        public string inspectionDate; // 查阅日期
        [DataMember(Name = "modifyDate", IsRequired = false, Order = 0)]
        public string modifyDate; // 编辑日期
        [DataMember(Name = "createDate", IsRequired = false, Order = 0)]
        public string createDate; // 创建日期
        [DataMember(Name = "localPath", IsRequired = false, Order = 0)]
        public string localPath; // 文献路径
        [DataMember(Name = "email", IsRequired = false, Order = 0)]
        public string email; // Email
        [DataMember(Name = "PMID", IsRequired = false, Order = 0)]
        public string PMID; // PMID
        [DataMember(Name = "referenceList", IsRequired = false, Order = 0)]
        public string referenceList; // 引用列表
        [DataMember(Name = "clazzId", IsRequired = false, Order = 0)]
        public string clazzId; // ClassID
    }
}
