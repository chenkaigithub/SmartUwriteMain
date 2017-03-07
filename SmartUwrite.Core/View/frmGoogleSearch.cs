using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    public partial class frmGoogleSearch : Form
    {
        UrlEntity ue = new UrlEntity();
        string url = string.Empty;
        bool needAdd = true;
        BaseProxy proxy;
        public frmGoogleSearch()
        {
            try
            {
                InitializeComponent();
                proxy= new BimtProxyService();
                proxy.InitProxy();
            }
            catch (Exception)
            {
                BimtProxyService.ShutDown();
                MessageBox.Show(null,"代理初始化失败！","代理设置");
                
            }
           
        }

        private void browser_DocumentCompleted(object sender,
WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error
        += new HtmlElementErrorEventHandler(Window_Error);
        }


        private void Window_Error(object sender, HtmlElementErrorEventArgs
        e)
        {
            // Ignore the error and suppress the error dialog box. 
            wb_google.ScriptErrorsSuppressed = true;
            e.Handled = true;
        }


       
           

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //if (needAdd)
            //{
            url = wb_google.Url.ToString();
            txt_url.Text = url;
            //    ue.ToNewPage(url);
            //}
            //needAdd = true;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            wb_google.GoBack();//.inv.InvokeScript("eval", "history.Go(-1)");
            //url = ue.BackPage();
            //if (url != "-1")
            //{
            //    needAdd = false;
            //    Uri uri = new Uri(url);
            //    wb_google.Url = uri;
            //}
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            wb_google.GoForward();
            //url = ue.ForwardPage();
            //if (url != "-1")
            //{
            //    needAdd = false;
            //    Uri uri = new Uri(url);
            //    wb_google.Url = uri;
            //}
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://scholar.google.com.hk/schhp?hl=zh-CN");
            wb_google.Url = uri;
        }

        private void btn_proxy_Click(object sender, EventArgs e)
        {
            try
            {
                frmProxySetting frm = new frmProxySetting();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(url);
            wb_google.Url = uri;
        }

        private void wb_google_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            if (needAdd)
            {
                url = wb_google.Url.ToString();
                txt_url.Text = url;
                ue.ToNewPage(url);
            }
            needAdd = true;
        }

        private void frmGoogleSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            BimtProxyService.ShutDown();
        }
    }
}
