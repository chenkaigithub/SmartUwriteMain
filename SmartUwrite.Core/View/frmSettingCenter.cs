using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.Controller.Service;
using System.Dynamic;
using System.Collections;
using Aliyun.OpenServices.OpenStorageService;
using BIMT.Util.Encrypt;
using BIMT.Util.Configuration;
using BIMT.Util;
using System.Threading;

namespace BIMTClassLibrary.View
{
    public partial class frmSettingCenter : Form, IViewCallback
    {

        IUpdateStorage service;// = new OSSService(this);
        public frmSettingCenter()
        {
            InitializeComponent();
            service = new OSSService(this);
        }

        private void RefreshInfo(string info)
        {
            lb_Info.Text = string.Format("{0} {1} \n{2}", DateTime.Now.ToString("HH:mm:ss"), info, lb_Info.Text);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            dynamic param = new System.Dynamic.ExpandoObject();
            param.containerName = cmb_bucket.Text;
            RefreshInfo(service.AddContainer(param));
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            dynamic param = new System.Dynamic.ExpandoObject();
            param.containerName = cmb_bucket.Text;
            RefreshInfo(service.DelContainer(param));
        }

        public string GetFolder()
        {
            if (rb_x64.Checked)
            {
                return rb_x64.Text + "/";
            }
            else if (rb_x86.Checked)
            {
                return rb_x86.Text + "/";
            }
            else if (rb_proxy.Checked)
            {
                 return rb_proxy.Text + "/";
            }
            else if (rb_styles.Checked)
            {
                return rb_styles.Text + "/";
            }
            return string.Empty;
        }

        private void btn_upload_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ShowDialog();
            service = new OSSService(this,  cmb_bucket.Text, GetFolder(),ofd.FileNames);
            dynamic param = new System.Dynamic.ExpandoObject();
            Thread t = new Thread(service.UploadFile);
            t.Start();
            //service.UploadFile();
            
            //foreach (var item in ofd.FileNames)
            //{
            //    dynamic param = new System.Dynamic.ExpandoObject();
            //    param.containerName = cmb_bucket.Text;
            //    param.path = item;
            //    param.folder = GetFolder();
            //    RefreshInfo(service.UploadFile(param));
            //}
            //RefreshFileList();
        }

        private void btn_del_file_Click(object sender, EventArgs e)
        {
            dynamic param = new System.Dynamic.ExpandoObject();
            param.containerName=this.cmb_bucket.Text;
            param.fileName=listFile.Text;
            RefreshInfo(service.DelFile(param));
            RefreshFileList();
        }

        private void frmSettingCenter_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
        }

        private void listBucket_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        public void RefreshFileList(string folder)
        {
            dynamic param = new System.Dynamic.ExpandoObject();
            param.containerName = cmb_bucket.Text;// listBucket.Text;// .SelectedItem.ToString();
            listFile.Items.Clear();
            IEnumerable list = service.GetFileList(param);
            foreach (var item in list)
            {
                if (item.ToString().StartsWith(folder))
                {
                    listFile.Items.Add(item);
                }
                
            }
        }

        public void RefreshFileList()
        {
            RefreshFileList(GetFolder());
        }

        //public void RefreshBucketList() {
        //    IEnumerable list = service.GetContainers(null);
        //    foreach (var item in list)
        //    {
        //        listBucket.Items.Add(item);
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //<add key="_accessId" value="pvKCnFrty5c0g48B" />
            //<add key="_accessKey" value="xANkSRfCk3FLu5MAlVVKFyY4hFJJkc" />
            //<add key="_http" value="http://oss-cn-hangzhou.aliyuncs.com" />
            EncryptHelper helper = new EncryptHelper("smartuwrite");
            RefreshInfo(helper.Do(helper.De(ConfigurationHelper.GetConfig("FreeTimes"))));
            //RefreshInfo(helper.Do("xANkSRfCk3FLu5MAlVVKFyY4hFJJkc"));
            //RefreshInfo(helper.Do("http://oss-cn-hangzhou.aliyuncs.com"));
        }

        private void btn_de_Click(object sender, EventArgs e)
        {
            EncryptHelper helper = new EncryptHelper("smartuwrite");
            RefreshInfo(helper.De(ConfigurationHelper.GetConfig("FreeTimes")));
            //RefreshInfo(helper.De(helper.Do("xANkSRfCk3FLu5MAlVVKFyY4hFJJkc")));
            //RefreshInfo(helper.De(helper.Do("http://oss-cn-hangzhou.aliyuncs.com")));
        }

        private void cmb_bucket_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void btn_up_big_Click(object sender, EventArgs e)
        {

        }

        public void SetView(int count, string content)
        {
            if (content == null)
            {
                pb_runing.Value = 0;
                pb_runing.Maximum = count;
            }
            else
            {
                if (count > pb_runing.Maximum)
                {
                    pb_runing.Value = pb_runing.Maximum;
                }
                else
                {
                    pb_runing.Value = count;
                }
                RefreshInfo(content);
            }
            RefreshFileList();
        }

        public void MyInvoke(InitItemInvoke mi, object[] arrayObj)
        {
            BeginInvoke(mi, arrayObj);
        }
    }
}
