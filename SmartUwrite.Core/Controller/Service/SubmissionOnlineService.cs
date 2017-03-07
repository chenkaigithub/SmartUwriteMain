using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Security.Policy;
using BIMT.Util.Configuration;
using BIMTClassLibrary.Model;
using BIMT.Util.Upload;
using BIMT.Util;

namespace BIMTClassLibrary.Controller.Service
{
    public class SubmissionOnlineService :BaseService, IInvokeService
    {
        Magazine magazine = null;

        private static readonly string BASE_URL = ConfigurationHelper.GetConfig(@"UploadDocBaseUrl");//"http://ll.bimttest.com/member/";
        private static readonly string UPLOAD_URL = ConfigurationHelper.GetConfig(@"UploadUrl");
        public SubmissionOnlineService(IViewCallback view, Magazine magazine)
            : base(view)
        {
            this.magazine = magazine;
        }

        private void SendMagazine(Magazine magazine)
        {
            FileInfo fileInfo = new FileInfo(WordApplication.GetInstance().WordApp.ActiveDocument.FullName);
            view.MyInvoke(mi, new object[] { 0, "读取稿件文件..." });

            Dictionary<string, string> stringDict = new Dictionary<string, string>();
            stringDict.Add("fileName", fileInfo.Name);
            stringDict.Add("size", "300");
            stringDict.Add("suffix", fileInfo.Extension.Trim().Trim('.'));
            view.MyInvoke(mi, new object[] { 0, "验证用户信息..." });
            User user = User.GetInstance();
            user.RefreshDetail();
            string token = user.Detail.result.token;
            stringDict.Add("token", token);
            view.MyInvoke(mi, new object[] { 0, "开始上传稿件..." });
            string json = UploadFile.ProcessRequest(fileInfo, stringDict, UPLOAD_URL);
            dynamic content = JsonConvert.DeserializeObject(json);
            view.MyInvoke(mi, new object[] { 0, "跳转到网站“我的稿件”模块..." });
            Goto(content, magazine, token);
            view.MyInvoke(mi, new object[] { -1, "操作完毕..." });
        }

        public void SendMagazineTest(Magazine magazine)
        {
            FileInfo fileInfo = new FileInfo(WordApplication.GetInstance().WordApp.ActiveDocument.FullName);
            Dictionary<string, string> stringDict = new Dictionary<string, string>();
            stringDict.Add("fileName", fileInfo.Name);
            stringDict.Add("size", "300");
            stringDict.Add("suffix", fileInfo.Extension.Trim().Trim('.'));
            User user = User.GetInstance();
            user.RefreshDetail();
            string token = "14815091648672b51081824294983a7f3879da8cb78a7686";// user.Detail.result.token;
            stringDict.Add("token", token);
            string json = UploadFile.ProcessRequest(fileInfo, stringDict, UPLOAD_URL);
            dynamic content = JsonConvert.DeserializeObject(json);
            magazine.Id = "030F41F5DB4FBAAA990B19AE940FBB69";
            magazine.StrName = "安徽卫生职业技术学院学报";
            Goto(content, magazine, token);
        }

        public void Goto(dynamic content,Magazine magazine,string token)
        {
            string id = content.data.article.attachment.id;
            string name = content.data.article.attachment.name;
            string createdTime = content.data.article.attachment.createdTime;
            ExtractInfoService service = new ExtractInfoService(WordApplication.GetInstance().WordApp);
            //string title = service.ExtractTitle();// content.data.paper.title;
            //string keyword = service.ExtractCNKeywords() + service.ExtractENKeywords();// content.data.paper.keyword;
            //string summary = service.ExtractCNAbstracts() + service.ExtractENAbstracts();// content.data.paper.summary;
            string pdfid = content.data.article.pdfId;

            string url = string.Format(@"{0}/match"
                                        + "?latestArticle.attachment.id={1}"
                                        + "&latestArticle.attachment.name={2}"
                                        + "&time={3}"
                                        //+ "&paper.title={4}"
                                        //+ "&paper.keyword={5}"
                                        //+ "&paper.summary={6}"
                                        + "&word=word"
                                        + "&latestArticle.pdfId={4}"
                                        + "&token={5}"
                                        + "&periodical.name&={6}"
                                        + "&periodical.id={7}"
                                        + "&periodical.code={8}"
                                        + "&symbiosis={9}"
                                        + "&decode="
                , BASE_URL
                , id.Trim()
                , name.Trim()
                , createdTime.Trim()
                //, "nullValue"//title.Trim()
                //, "nullValue"//keyword.Trim()
                //, "nullValue"//summary.Trim()
                , pdfid.Trim()
                , token
                , magazine.StrName.Trim()
                , magazine.Id.Trim()
                , "nullValue"
                , magazine.IsCol == true ? "true" : "false");
            System.Diagnostics.Process.Start(url);
        }

        public void DoWord()
        {
            //SendMagazineTest(magazine);
            SendMagazine(magazine);
        }
    }
}
