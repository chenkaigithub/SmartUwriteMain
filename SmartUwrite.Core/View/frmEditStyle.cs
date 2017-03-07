using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public partial class frmEditStyle : Form
    {
        public frmEditStyle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmFeldList frm = new frmFeldList();
            //frm.ShowDialog();
            dataGridView1.Rows.Add(string.Empty,false,false,false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //richTextBox1.Text = GetFieldTemplet();
        }

        private string GetFieldTemplet()
        {
            string _strR = string.Empty;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                _strR += "<" + item.Cells["usrName"].Value.ToString() + "_" + FixValue(item) + ">";
            }
            return _strR;
        }

        /// <summary>
        /// 粗体值为1；斜体3；下划线5
        /// 在末尾加上数字以标识此字段是否带有样式
        /// 2016-04-06
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private string FixValue(DataGridViewRow item)
        {
            int _nflag = 0;
            if (item.Cells["blod"].Value != null && item.Cells["blod"].Value.ToString().ToUpper() == "TRUE")
            {
                _nflag += 1;
            }
            if (item.Cells["blod"].Value != null && item.Cells["ilitic"].Value.ToString().ToUpper() == "TRUE")
            {
                _nflag += 3;
            }
            if (item.Cells["blod"].Value != null && item.Cells["underline"].Value.ToString().ToUpper() == "TRUE")
            {
                _nflag += 5;
            }
            return _nflag.ToString();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            richTextBox1.Text = GetFieldTemplet();
        }
    }
}
