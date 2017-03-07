using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteratureManager;
using System.IO;
using BIMTClassLibrary.DocDatabase.Doc;
using System.Threading;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.DocDatabase.Upload
{
    public class AsynUploadDocService:BaseDocManager
    {
        public struct synResult
        {
            public int successCount;
            public int falseCount;
        }

        public void SynUpolad()
        {
            try
            {
                Thread thread = new Thread(Upload);
                thread.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Upload()
        {
            try
            {
                synResult result;
                result.successCount = 0;
                result.falseCount = 0;
                FileStorageService helper = FileStorageService.GetInstance();
                List<string> list = helper.GetCategorylist();
                foreach (var categoryName in list)
                {//User.getInstance().Key.id
                    CategoryDao cd = new CategoryDao(User.GetInstance().Key.id, categoryName);
                    bool added = cd.Add();
                    if (added)
                    {
                        List<string> literatures = helper.GetLiteratures(categoryName);
                        foreach (var literatureName in literatures)
                        {
                            string path = string.Format("{0}\\{1}\\{2}.json", FileStorageService.GetInstance().GetBaseDir(), categoryName, literatureName);
                            string doc = File.ReadAllText(path);
                            LiteratureDao dao = new LiteratureDao(User.GetInstance().Key.id, categoryName, doc);
                            bool ok = dao.Add();
                            if (ok)
                            {
                                result.successCount++;
                            }
                            else
                            {
                                result.falseCount++;
                            }
                        }
                    }
                }
                Log4Net.LogHelper.WriteLog(typeof(AsynUploadDocService), string.Format("同步成功：{0} 同步失败：{1}", result.successCount, result.falseCount));
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(AsynUploadDocService), ex);
            }
        }
    }
}
