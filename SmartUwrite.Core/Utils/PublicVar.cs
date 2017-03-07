using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;
using LiteratureManager;
using BIMTClassLibrary.userBeheiverTrick;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.EditStyle;
//using BIMTClassLibrary.db;

namespace BIMTClassLibrary
{
    public class PublicVar
    {
        /// <summary>
        /// 软件的版本值，当与服务器版本比较小于服务器版本时弹出提示
        /// wuhailong
        /// 2016-08-23
        /// </summary>
        public static double Verstion = 12.0;
        public static int MenuFlag = 0;
        public static readonly int WXJS = 1;
        public static readonly int YJPP = 2;
        
        public static int CurrentIndex = 1;
        //public static string userId = string.Empty;
        //public static Microsoft.Office.Interop.Word.Application wordApp;
        public static string selectedCatagory = string.Empty;
        //public static frmMyLiterature myLiterature = frmMyLiterature.GetInstance();

        //public static UserBeheiverTrickService userTrick = new UserBeheiverTrickService();
        /// <summary>
        /// 顺序编码制
        /// </summary>
        //public static  int OrderCoingRule = 1;
        /// <summary>
        /// 作者出版年制
        /// </summary>
        //public static  int AuthorPubYearRule = 2;

        public static bool WriteIndex = false;
        

        public static string CurrentStyleJsonString = string.Empty;

        public static JObject CurrentStyleJObject = null;

        public static void SetCurrentStyleJObject()
        {
            try
            {
                string filePath = PublicVar.StyleDir + "\\" + MagazineStyle.GetInstance().Name + ".json";
                string jsonText = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
                PublicVar.CurrentStyleJsonString = jsonText;
                PublicVar.CurrentStyleJObject = JObject.Parse(jsonText);
            }
            catch (Exception)
            {

                throw;
            }

        }


       
        public static string StyleDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\\BIMT\\styles\\";

        public static string DocDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BIMT\docs\";
        
        public static string DBFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\\BIMT\\literature.accdb";// CommonFunction.GetBIMTDIR() + @"\literature.accdb";

        public static string ConnectString =string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", DBFilePath);

        //public static string MyliteraturePath = @"D:\GitLab\wordplugin-frontend\LiteratureManager\bin\Debug\LiteratureManager.exe";
        //public static string MyliteraturePath = @"D:\Program Files\BIMT\Debug\LiteratureManager.exe";
        public static string MyliteraturePath =string.Empty;// CommonFunction.GetBIMTDIR() + @"\LiteratureManager.exe";
        //https://writeaid.api.bimt.com:8443/
        //http://192.168.1.57:8080/writeaid/
        //测试
        //public static string BaseUrl = @"http://192.168.1.57:8080/writeaid/";
        //正式
        public static string literatureBaseUrl = @"http://writeaid.api.bimt.com/";
        //public static string BaseUrl = @"http://192.168.1.84:8081/";

        //public static string DescriptionDocument = @"D:\Program Files\BIMT\BIMTWORD.docx";
        public static string DescriptionDocument =string.Empty;// CommonFunction.GetBIMTDIR() + @"\BIMTWORD.docx";

        //public static string BaseUrl = @"http://192.168.1.94:5723/writeaid/services";
        //public static string DBFPath = @"D:\GitLab\wordplugin-frontend\OfficeUtil\bin\Debug\db\literature.dbf";

        //public static LiteratureDataSet literature = new LiteratureDataSet();


        //public static string WAKey = string.Empty;

        //public static string LiteratureDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\\BIMT\\literatures\\";

        public static string BaseDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        //public static LiteratureManager.IMyLiterature Myliterature = new JsonFilsSysHelper();

        public static bool CNStyle { get; set; }

        /// <summary>
        /// 期刊推荐和专家推荐的baseURL
        /// wuhailong
        /// 2016-07-12
        /// </summary>
        public static string recommandBaseUrl = "http://bigdata.api.bimt.com/v1/";

        public static string m_strTitleSpecialChar { get; set; }

        public static bool m_needChange { get; set; }

        //public static string userName { get; set; }

        //public static string UserEmail { get; set; }

        //public static string UserPhone { get; set; }
    }
}
