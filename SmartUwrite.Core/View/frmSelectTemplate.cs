using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIMTClassLibrary.WordTemplate;
using BIMTClassLibrary.Email;
using BIMTWordAddIn;
using BIMT.Util;
using BIMTClassLibrary.RefreshView;

namespace BIMTClassLibrary.WordTemplete
{
    public partial class frmSelectTemplate : Form
    {
        DataTable source;
        BaseTemplate manager;
        public frmSelectTemplate()
        {
            InitializeComponent();
            manager = new TemplateService();
        }
        IRefreshViewable ss;
        public frmSelectTemplate(IRefreshViewable s)
        {
            InitializeComponent();
            manager = new TemplateService();

            ss = s;
        }

        private void dgv_template_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgv_template.Columns[e.ColumnIndex].Name == "name")
                {//打开链接
                    string id = dgv_template.CurrentRow.Cells["id"].Value.ToString();
                    manager.OpenLink("1"+id);
                }
                else if (dgv_template.Columns[e.ColumnIndex].Name == "text")
                {//打开文档

                   
                    string url = dgv_template.CurrentRow.Cells["templateUrl"].Value.ToString();
                    string name = dgv_template.CurrentRow.Cells["name"].Value.ToString() + "写作模板."+url.Split('.')[1];
                    styleName = dgv_template.CurrentRow.Cells["quotationName"].Value.ToString();
                    ss.SetStyle(styleName);
                    if (url.StartsWith("/"))
                    {
                        url = url.Substring(1);
                    }
                    manager.OpenTemplate(name,url);
                    
                    this.FindForm().Close();
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }

        }

        private void frmSelectTemplate_Load(object sender, EventArgs e)
        {
            try
            {
                source = manager.GetSource();
                dgv_template.DataSource = source;


                lb_count.Text = string.Format("目前收录{0}本期刊", source.Rows.Count.ToString());

            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }
            

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = string.Format("name like '%{0}%'", txt_name.Text);
                DataTable temp= source.Copy();
                if (txt_name.Text == "")
                {
                    dgv_template.DataSource = source.DefaultView;
                }
                else
                {
                    DataRow[] _array = source.Select(filter);
                    DataTable _dt = ((DataView)dgv_template.DataSource).ToTable().Clone();
                    if (_array.Length >= 1)
                    {
                        foreach (DataRow item in _array)
                        {
                            _dt.Rows.Add(item.ItemArray);
                        }
                    }
                    dgv_template.DataSource = _dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }
        }

        private void lL_create_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //frmAddTemplate frm = new frmAddTemplate();
                //frm.ShowDialog();
                this.Height = 640;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }
        }

        private void btn_od_Click(object sender, EventArgs e)
        {
            try
            {
                EmailService.TestEmail3("反馈所需出版物", string.Format("出版物名称：{0};\n 出版物官网{1};", textBox1.Text, txt_path.Text));
                this.Height = 640;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmSelectTemplate), ex);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txt_path.Text = string.Empty;
                ofd_template.ShowDialog();
                txt_path.Text = ofd_template.FileName;
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmAddTemplate), ex);
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Height = 570;
        }

        public string styleName { get;private set; }

        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "excel|*.xlsx";
            sfd.ShowDialog();
            ExcelHelper.DataTabletoExcel(source, sfd.FileName);
        }
    }
}
