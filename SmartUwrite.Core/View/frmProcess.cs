using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Controller.Service;
using System.Threading;
using System.IO;
using BIMT.Util;

namespace BIMTClassLibrary.View
{
    public partial class frmProcess : Form, IViewCallback
    {
        IInvokeService service;
       
        public frmProcess()
        {
            
            InitializeComponent();
        }


        public void SetView(int count, string content)
        {
            if (content == null)
            {
                pb_output_word.Maximum = count;
            }
            else
            {
                if (count > pb_output_word.Maximum)
                {
                    pb_output_word.Value = pb_output_word.Maximum;
                    content = string.Format("{0} {1}",
                        DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second
                        , content);
                }
                else
                {
                    pb_output_word.Value = count;
                    content = string.Format("{0} 进度进行中[{1}/{2}]... {3}",
                        DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second
                        , count
                        , pb_output_word.Maximum
                        , content);
                }
                richTextBox1.Text = content + "\n" + richTextBox1.Text;
            }
        }

      

        public void MyInvoke(InitItemInvoke mi, object[] arrayObj)
        {
            BeginInvoke(mi, arrayObj);
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();
            if (Directory.Exists(ofd.SelectedPath))
            {
                service = new ExtractInfoService(this, ofd.SelectedPath);
                Thread thread = new Thread(new ThreadStart(service.DoWord));
                thread.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("WINWORD"))
            {
                p.Kill();
            }
        }

        private void btn_open_excel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xlsx|*.xlsx";
            ofd.ShowDialog();
            if (File.Exists(ofd.FileName))
            {
                service = new OutputTwoTempletService(this, ofd.FileName);
                Thread thread = new Thread(new ThreadStart(service.DoWord));
                thread.Start();
            }
        }

        private void btn_expot_comments_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                ofd.ShowDialog();
                if (Directory.Exists(ofd.SelectedPath))
                {
                    service = new ExportReviewCommentService(this, ofd.SelectedPath);
                    Thread thread = new Thread(new ThreadStart(service.DoWord));
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_upload_doc_Click(object sender, EventArgs e)
        {
            //SubmissionOnlineService service = new SubmissionOnlineService();
            //service.Test();
        }
    }
}
