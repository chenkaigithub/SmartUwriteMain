using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.Json;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Json;
using LiteratureManager;
using BIMTClassLibrary.Service;
using BIMTClassLibrary.EditStyle;

namespace BIMTClassLibrary
{
    public partial class ucSearchItem : UserControl
    {
        private Quotation quotation;
        private object item;
        frmLiteratureStorage frm = new frmLiteratureStorage();
        public ucSearchItem()
        {
            InitializeComponent();
            title.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
            baseinfo.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
        }

        public ucSearchItem(Quotation q)
        {
            try
            {
                InitializeComponent();
                this.quotation = q;
                title.Text = quotation.title;
                string _strAuthorList = string.Empty;
                int _nCount = 0;
                bool moreThenTwo = false;
                foreach (var item in quotation.listAuthor)
                {
                    if (_nCount == 2)
                    {
                        moreThenTwo = true;
                        break;
                    }
                    if (item.name.last != string.Empty && item.name.fore != string.Empty)
                    {
                        _strAuthorList += item.name.last + " " + item.name.fore + ",";
                        _nCount++;
                    }
                    else
                    {
                        _strAuthorList += item.name.full + ",";
                        _nCount++;
                    }
                }
                if (moreThenTwo)
                {
                    if (quotation.listAuthor[quotation.listAuthor.Count - 1].name.last != string.Empty && quotation.listAuthor[quotation.listAuthor.Count - 1].name.fore != string.Empty)
                    {
                        _strAuthorList += quotation.listAuthor[quotation.listAuthor.Count - 1].name.last + " " + quotation.listAuthor[quotation.listAuthor.Count - 1].name.fore + ",";
                        _nCount++;
                    }
                    else
                    {
                        _strAuthorList += quotation.listAuthor[quotation.listAuthor.Count - 1].name.full + ",";
                        _nCount++;
                    }
                }
                _strAuthorList = _strAuthorList.Trim(',');
                if (quotation.listAuthor.Count > 0)
                {//作者信息+作者机构信息+出版年+出版社
                    baseinfo.Text = "作者："+_strAuthorList.Trim() + " 期刊：" + quotation.publishInfo.periodicalInfo.name + " 出版年：" + quotation.publishInfo.publishYear ;
                }
                else
                {
                    baseinfo.Text = "[作者未知]" + " 期刊：" + quotation.publishInfo.periodicalInfo.name + " 出版年：" + quotation.publishInfo.publishYear;
                }
                if (quotation.online.ToUpper() == "TRUE")//是否有原文信息
                {
                    linkLabel1.Enabled = true;
                }
                else
                {
                    linkLabel1.Enabled = false;
                }
                title.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
                baseinfo.BackColor = System.Drawing.Color.FromArgb(247, 249, 249);
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucSearchItem), ex);
            }
        }

        public ucSearchItem(Quotation quotation, object item)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
            this.item = item;
        }

        private void ucSearchItem_SizeChanged(object sender, EventArgs e)
        {
            title.Width = Width - 20;
            baseinfo.Width = Width - 20;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (MagazineStyle.GetInstance().Name == "请选择样式")
                {
                    MessageBox.Show("请选择具体的参考文献样式后再引用。");
                    return;
                }
                if (quotation.listAuthor.Count == 0)
                {
                    MessageBox.Show(null, "作者缺失，无法引用!", "插入文献");
                    return;
                }

                if (quotation.listAuthor.Count > 0)
                {
                    CommonFunction.WriteQuotation(quotation);
                    //ThreadQuotation tq = new ThreadQuotation(quotation);
                    //Thread t = new Thread(tq.SynWriteQuuotation);
                    //t.Start();
                
                    frm.Source.AddLiterature(quotation);
                    
                }
                else
                {
                    MessageBox.Show("关键信息缺失无法引用或收藏。");
                }
                using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
                {
                    if (PublicVar.MenuFlag == PublicVar.WXJS)
                    {
                        ubts.SynDoTrick("文献检索", "引用", quotation.did + "_" + quotation.title + "_" + quotation.GetCurrentAuthorYear());
                    }
                    else
                    {
                        ubts.SynDoTrick("语句匹配", "引用", quotation.did + "_" + quotation.title + "_" + quotation.GetCurrentAuthorYear());
                    }
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucSearchItem), ex);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (quotation.listAuthor.Count == 0)
                {
                    MessageBox.Show("作者缺失，无法收藏。");
                    return;
                }

                if (quotation.listAuthor.Count > 0)
                {
                    frm.Source.AddLiterature(quotation);
                    MessageBox.Show(null, "收藏文献成功!                              ", "收藏文献");
                }
                else
                {
                    MessageBox.Show("关键信息缺失无法引用或收藏。");
                }
                using (userBeheiverTrick.UserBeheiverTrickService ubts = new userBeheiverTrick.UserBeheiverTrickService())
                {
                    ubts.SynDoTrick("文献收藏", "收藏", quotation.did + "_" + quotation.title + "_" + quotation.GetCurrentAuthorYear());
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucSearchItem), ex);
            }
           
        }

        /// <summary>
        /// 将文献以json的形式存储到本地word目录下的literatures下
        /// 2016-05-30
        /// wuhailong
        /// </summary>
        /// <returns></returns>
        private int CollectionToDir()
        {
            try
            {
                //List<Quotation> list = new List<Quotation>();
                //list.Add(quotation);
                //string _strR = CommonFunction.GetJsonString(list);
                string _strR2 = CommonFunction.stringify(quotation);
                string _strName =FileStorageService.GetInstance().GetBaseDir()+"\\"+quotation.title+".json";
                File.WriteAllText(_strName, _strR2, Encoding.UTF8);
                //MessageBox.Show(_strR);
                //MessageBox.Show(_strR2);
                //Quotation qq = parse<Quotation>(_strR2);
                return 1;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucSearchItem), ex);
                return -1;
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            string result = BIMTService.CallGetService(PublicVar.literatureBaseUrl + "/documents/" + quotation.did, string.Empty, string.Empty, false);
            Dictionary<string, object> _dict =  (Dictionary<string, object>)CommonFunction.JsonToDictionary(result);
            Dictionary<string, object> _dictAbstracts = (Dictionary<string, object>)_dict["abstracts"];
            if (_dictAbstracts != null && _dictAbstracts["cn"] != null)
            {
                quotation.abstracts = _dictAbstracts["cn"].ToString();
            }
            else if (_dictAbstracts != null && _dictAbstracts["en"] != null)
            {
                quotation.abstracts = _dictAbstracts["en"].ToString();
            }

            frmUnderline frm = new frmUnderline(quotation.abstracts);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PublicVar.literatureBaseUrl + "/documents/" + quotation.did + "/online?source=writeaid"); 
   

        }
    }
}
