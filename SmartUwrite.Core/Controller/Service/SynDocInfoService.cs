using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.DocDatabase.Doc;
using LiteratureManager;
using System.Threading;
using System.Windows.Forms;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.DocDatabase.Service
{
    public class SynDocInfoService : BaseDocManager
    {
        public struct result {
            public int scount;
            public int fcount;
        }
        string userId, userName, userPhone, userEmail;
        private frmLiteratureStorage frm;
        public SynDocInfoService(string userId, string userName, string userPhone, string userEmail)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPhone = userPhone;
            this.userEmail = userEmail;
        }

        public SynDocInfoService(frmLiteratureStorage frmMyLiterature, string userId, string userName, string userPhone, string userEmail)
        {
            // TODO: Complete member initialization
            this.frm = frmMyLiterature;
            this.userId = userId;
            this.userName = userName;
            this.userPhone = userPhone;
            this.userEmail = userEmail;
        }

        public void SynDocInfo()
        {
            try
            {
                frm.ShowPb();
                result r;
                r.fcount = 0;
                r.scount = 0;
                FileStorageService jhelper = FileStorageService.GetInstance();
                CategoryDao cd = new CategoryDao(userId, userName, userPhone, userEmail);
                List<string> listCategory = cd.Query();
                foreach (var category in listCategory)
                {
                    bool ok = jhelper.AddCatagory(category);
                    if (ok)
                    {
                        LiteratureDao ld = new LiteratureDao(category, User.GetInstance().Key.id);
                        List<Quotation> listQuotation = ld.QueryQuotation();
                        frm.InitProcessBar(listQuotation.Count);
                        r.fcount = 0;
                        r.scount = 0;
                        //Thread.Sleep(1000);
                        foreach (var quotation in listQuotation)
                        {
                            bool success = jhelper.AddLiterature(category, quotation);
                            if (success)
                            {
                                r.scount++;
                                frm.SetProcessValue(r.scount);
                            }
                            else
                            {
                                r.fcount++;
                            }
                        }
                    }
                    Log4Net.LogHelper.WriteLog(typeof(SynDocInfoService), string.Format("同步成功{0};失败{1}", r.scount, r.fcount));
                }
                //MessageBox.Show("同步完成！", "消息");
                frm.HidenPb();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
