using BIMTClassLibrary.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Net;
using System.Text.RegularExpressions;
using BIMTClassLibrary.DBF;
using BIMTClassLibrary.Service;
using BIMTClassLibrary.styles;
using System.IO;
using BIMTClassLibrary.rest;
using Newtonsoft.Json.Linq;
using BIMTClassLibrary.EditStyle;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary
{
    public partial class frmTempletManager : Form
    {
        int m_nStart = 0;
        int m_nLength = 0;
        private string p;
        public frmTempletManager()
        {
            InitializeComponent();
            treeView1.ExpandAll();
            InitData();
            QUOTATION_INDEX_PREFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            QUOTATION_INDEX_SUFFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            //QUOTATION_ITEM_FIELD_DISPLAY.SelectedText = "ASDF";

            foreach (var item in 插入字段ToolStripMenuItem.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(标题ToolStripMenuItem_Click);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }

            foreach (var item in toolStripMenuItem45.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(toolStripMenuItem55_Click);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }
            NOTES.Text = string.Empty;
        }

        public frmTempletManager(string p_strStyleName)
        {
            //m_strStyleName = p_strStyleName;
            currentStyleContent = System.IO.File.ReadAllText(PublicVar.StyleDir +"\\"+ p_strStyleName + ".json", Encoding.UTF8);
            currentStyleId = JsonHelper.GetValue("TID");
            currentStyleName = JsonHelper.GetValue("STYLE_NAME");
            InitializeComponent();
            treeView1.ExpandAll();
            InitData();
            QUOTATION_INDEX_PREFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            QUOTATION_INDEX_SUFFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            //QUOTATION_ITEM_FIELD_DISPLAY.SelectedText = "ASDF";

            //文中引文
            foreach (var item in 插入字段ToolStripMenuItem.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(标题ToolStripMenuItem_Click);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }
            //文中引文预览
            string _strTemplet = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Tag.ToString() + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
            ShowPreView(QUOTATION_INDEX_PREVIEW, _strTemplet, QUOTATION_INDEX_FONT_FAMILY.Text, float.Parse(QUOTATION_INDEX_FONT_SIZE.Text));

            //引文标题
            foreach (var item in toolStripMenuItem121.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(toolStripMenuItem194_Click);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }


            //文末引文
            foreach (var item in toolStripMenuItem45.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(toolStripMenuItem55_Click);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }
            //文末引文预览
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
           
            //题录类型
            foreach (var item in toolStripMenuItem120.DropDownItems)
            {
                string S = item.GetType().ToString();
                try
                {
                    if ("System.Windows.Forms.ToolStripMenuItem" == S)
                    {
                        ((System.Windows.Forms.ToolStripMenuItem)item).CheckedChanged += new EventHandler(通用ToolStripMenuItem_CheckedChanged);
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    continue;
                }
            }
            QUOTATION_INDEX_LIST_AUTHOR_COUNT_ONLY.Maximum = QUOTATION_INDEX_LIST_AUTHOR_COUNT_OVER.Value;

            //InitializeComponent();
            //treeView1.ExpandAll();

            //if (p_strStyleId == string.Empty)
            //{
            //    this.m_strStyleId = Guid.NewGuid().ToString();
            //}
            //this.m_strStyleId = p_strStyleId;
            //DataSet _ds = LocalDBHelper.ExcuteQuery(string.Format("select style_json from styles where style_name = '{0}'", m_strStyleId));
            //m_strStyleJson = _ds.Tables[0].Rows[0]["style_json"].ToString();


            //InitData();

            //QUOTATION_INDEX_PREFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            //QUOTATION_INDEX_SUFFIX.SelectedIndexChanged += new EventHandler(QUOTATION_INDEX_PREFIX_SelectedIndexChanged);
            ////QUOTATION_ITEM_FIELD_DISPLAY.SelectedText = "ASDF";

            //foreach (var item in 插入字段ToolStripMenuItem.DropDownItems)
            //{
            //    string S = item.GetType().ToString();
            //    try
            //    {
            //        if ("System.Windows.Forms.ToolStripMenuItem" == S)
            //        {
            //            ((System.Windows.Forms.ToolStripMenuItem)item).Click += new EventHandler(标题ToolStripMenuItem_Click);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //        continue;
            //    }
            //}


        }

        void QUOTATION_INDEXSUFFIX_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string _strKey = treeView1.SelectedNode.Name;
            tabControl1.SelectedTab = tabControl1.TabPages[_strKey];//.Select();
        }

        #region 数据初始化

        /// <summary>
        /// 初始化参数
        /// 2016-03-31
        /// wuhailog
        /// </summary>
        public void InitData()
        {
            currentStyleContent = CommonFunction.FixStyleJson(currentStyleContent);
            currentStyleId = JsonHelper.GetValue("TID");
            currentStyleName = JsonHelper.GetValue("STYLE_NAME");

            SetAllControlValue(this.Controls);
            if (CREATE_DATE.Text == string.Empty)
            {
                CREATE_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DisPlayStyle(QUOTATION_INDEX, 1);
            DisPlayStyle(QUOTATION_TITLE, 0);
            ShowPreview();
            NOTES.Text = string.Empty;
            bool ok = IsCnStyle();
            if (ok)
            {
                label50.Visible = true;
                label51.Visible = true;
                AUTHOR_LIST_OTHER_EN_CN.Visible = true;
                AUTHOR_LIST_OTHER_EN_CN_INDEX.Visible = true;
            }
           
        }

        public static bool IsCnStyle()
        {
            string _strTemplet = MagazineStyle.GetInstance().Name;
            string _strReg = @"[^\x00-\xff]";
            var matches = Regex.Matches(_strTemplet, _strReg);
            if (matches.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// g关于此样式的预览效果
        /// </summary>
        private void ShowPreview()
        {
            try
            {
                STYLE_PREVIEW.Text = string.Empty;
                string _strTemplet = JsonHelper.GetValue("QUOTATION_ITEM");
                string _strResult = string.Empty;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                foreach (Match item in matches)
                {
                    int _nStart = STYLE_PREVIEW.Text.Length;
                    var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
                    string[] _array = _strFieldAndStyleMix.Split('_');
                    string _strValue = GetPreviewValue(_array[0]);
                    STYLE_PREVIEW.AppendText(_strValue);
                    STYLE_PREVIEW.Select(_nStart, _strValue.Length);
                    STYLE_PREVIEW.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), GetStyle(_array[1]));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        /// <summary>
        /// 显示预览效果
        /// 2016-05-16
        /// wuhailong
        /// </summary>
        /// <param name="rtb">显示预览效果的富文本框</param>
        /// <param name="templetName">模板名称</param>
        public void ShowPreView(RichTextBox rtb, string templet,string fontFalimy,float fontSize)
        {
            try
            {
                rtb.Text = string.Empty;
                string _strTemplet = templet;
                string _strResult = string.Empty;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                foreach (Match item in matches)
                {
                    int _nStart = rtb.Text.Length;
                    var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
                    string[] _array = _strFieldAndStyleMix.Split('_');
                    string _strValue = GetPreviewValue(_array[0]);
                    rtb.AppendText(_strValue);
                    rtb.Select(_nStart, _strValue.Length);
                    rtb.SelectionFont = new Font(fontFalimy, fontSize, GetStyle(_array[1]));
                }
                //修复最后一个字段不展示bug wuhailong 2016-07-04
                rtb.Select(rtb.Text.Length,0);//.SelectedText = string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        /// <summary>
        /// 获取英文示例字段
        /// wuhailong
        /// 2016-07-04
        /// </summary>
        /// <param name="WordApp"></param>
        /// <param name="p_strFieldName"></param>
        /// <returns></returns>
        private string GetENPreviewValue(string _strField)
        {
            string _strR = string.Empty;
            if ("作者" == _strField)
            {
                string _strCharBAuthor = AUTHOR_BETWEEN_CHAR.Text;// JsonHelper.GetValue("AUTHOR_BETWEEN_CHAR");
                _strR += "Ichai C" + _strCharBAuthor + "Vinsonneau C" + _strCharBAuthor + "Souweine B" + _strCharBAuthor + "Armando F" + _strCharBAuthor + "Canet E" + _strCharBAuthor + "Clec'h C" + _strCharBAuthor + "et al";
            }
            else if ("序号" == _strField)
            {
                _strR += "1";
            }
            else if ("出版社" == _strField)
            {
                _strR += "新华出版社";
            }
            else if ("期刊" == _strField)
            {
                //string _strUseSX = JsonHelper.GetValue("USE_PERIODICAL_SHORTHAND_NAME");
                if (USE_PERIODICAL_SHORTHAND_NAME.Checked)
                {//Ann Intensive Care
                    _strR += "Ann Intensive Care";
                }
                else
                {
                    _strR += "Annals of intensive care";
                }
            }
            else if ("标题" == _strField)
            {
                _strR += "Acute kidney injury in the perioperative period and in intensive care units (excluding renal replacement therapies)";
            }
            else if ("年份" == _strField)
            {
                _strR += "2016";
            }
            else if ("出版日期" == _strField)
            {
                _strR += "2015-05-04";
            }
            else if ("出版者" == _strField)
            {
                _strR += "山东中医药大学学报";
            }
            else if ("卷" == _strField)
            {
                _strR += "6";
            }
            else if ("期" == _strField)
            {
                _strR += "1";
            }
            else if ("题录类型" == _strField)
            {
                _strR += "";
            }
            else if ("出版地点" == _strField)
            {
                _strR += "山东";
            }
            else if ("空格" == _strField)
            {
                _strR += " ";
            }
            else if ("制表符" == _strField)
            {
                _strR += "\t";
            }
            else if ("PMID号" == _strField)
            {
                _strR += "27177453";
            }
            else if ("DOI号" == _strField)
            {
                _strR += "10.1007/s10735-016-9679-y";
            }
            else if ("页码" == _strField)
            {
                _strR += "132-134";
            }
            else if ("出版时间" == _strField)
            {
                _strR += "2015-02-04";
            }
            else
            {
                _strR += _strField;
            }
            return _strR;
        }

        /// <summary>
        /// 获取预览效果的字段值
        /// 2016-05-17
        /// wuhailong
        /// </summary>
        /// <param name="_strField"></param>
        /// <returns></returns>
        private string GetPreviewValue(string _strField)
        {
            if (!PublicVar.CNStyle)
            {
                return GetENPreviewValue(_strField);
            }
            string _strR = string.Empty;
            if ("作者" == _strField)
            {
                _strR += "于福兵, 何夕昆, 郝玲, 等";
            }else if ("序号" == _strField)
            {
                _strR += "1";
            }
            else if ("出版社" == _strField)
            {
                _strR += "新华出版社";
            }
            else if ("期刊" == _strField)
            {
                _strR += "中国内镜杂志";
            }
            else if ("标题" == _strField)
            {
                _strR += "内镜黏膜下剥离切除胃间质瘤的治疗价值探讨";
            }
            else if ("年份" == _strField)
            {
                _strR += "2011";
            }
            else if ("出版日期" == _strField)
            {
                _strR += "2015-05-04";
            }
            else if ("出版者" == _strField)
            {
                _strR += "山东中医药大学学报";
            }
            else if ("卷" == _strField)
            {
                _strR += "17";
            }
            else if ("期" == _strField)
            {
                _strR += "05";
            }
            else if ("题录类型" == _strField)
            {
                _strR += "";
            }
            else if ("出版地点" == _strField)
            {
                _strR += "山东";
            }
            else if ("空格" == _strField)
            {
                _strR += " ";
            }
            else if ("制表符" == _strField)
            {
                _strR += "\t";
            }
            else if ("PMID号" == _strField)
            {
                _strR += "27177453";
            }
            else if ("DOI号" == _strField)
            {
                _strR += "10.1007/s10735-016-9679-y";
            }
            else if ("页码" == _strField)
            {
                _strR += "449-456";
            }
            else if ("出版时间" == _strField)
            {
                _strR += "2015-02-04";
            }
            else
            {
                _strR += _strField;
            }
            return _strR;
        }



        #region 依据空间状态给控件赋值

        /// <summary>
        /// 依据控件 的类型给控件赋值
        /// 2016-04-05
        /// wuahilong
        /// </summary>
        /// <param name="p_ctl"></param>
        /// <param name="p_strValue"></param>
        public void SetControlValueByType(Control p_ctl, string p_strValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == string.Empty)
                {
                    return;
                }
                Type t = p_ctl.GetType();
                if (t.Name == "RadioButton")
                {
                    if (p_strValue.ToUpper() != "TRUE")
                    {
                        p_strValue = "False";
                    }
                    bool _boolValue = bool.Parse(p_strValue);
                    ((RadioButton)p_ctl).Checked = _boolValue;

                }
                else if (t.Name == "NumericUpDown")
                {
                    ((NumericUpDown)p_ctl).Value = decimal.Parse(p_strValue);
                }
                else if (t.Name == "CheckBox")
                {
                    if (p_strValue.ToUpper() != "TRUE")
                    {
                        p_strValue = "False";
                    }
                    bool _boolValue = bool.Parse(p_strValue);
                    ((CheckBox)p_ctl).Checked = _boolValue;
                }
                else if (t.Name == "RichTextBox")
                {
                    string[] _array = p_strValue.Split('#');
                    ((RichTextBox)p_ctl).Text = _array[0];
                    ((RichTextBox)p_ctl).Tag = _array[1];
                    //SetFieldStyle();
                }
                else if (t.Name == "GroupBox" || t.Name == "TabPage")
                {
                    //string[] _array = p_strValue.Split('#');
                    //((RichTextBox)p_ctl).Text = _array[0];
                    //((RichTextBox)p_ctl).Tag = _array[1];
                }
                else if (p_ctl.Name == "menuStrip3")
                {
                    string[] _array = p_strValue.Split('#');
                    Dictionary<string, string> _dict = new Dictionary<string, string>();
                    foreach (string item in _array)
                    {
                        if (!item.Contains("|"))
                        {
                            continue;
                        }
                        string[] _itemArray = item.Split('|');
                        _dict.Add(_itemArray[0], _itemArray[1]);
                    }
                    foreach (var item in toolStripMenuItem120.DropDownItems)
                    {
                        string S = item.GetType().ToString();
                        try
                        {
                            if ("System.Windows.Forms.ToolStripMenuItem" == S)
                            {
                                string _strName = ((System.Windows.Forms.ToolStripMenuItem)item).Name;
                                string _strState = _dict[_strName].ToString().ToUpper();
                                if (_strState == "TRUE")
                                {
                                    ((System.Windows.Forms.ToolStripMenuItem)item).Checked = true;
                                    SetTempletVisibleState((System.Windows.Forms.ToolStripMenuItem)item);
                                    //**
                                }
                                //((System.Windows.Forms.ToolStripMenuItem)item).CheckedChanged += new EventHandler(通用ToolStripMenuItem_CheckedChanged);
                            }

                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteLog(typeof(frmTempletManager), ex);
                            continue;
                        }
                    }
                }
                else
                {
                    p_ctl.Text = p_strValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        #endregion

        /// <summary>
        /// 遍历所有空间，并给控件赋值
        /// 2013-03-31
        /// wuhailong
        /// </summary>
        /// <param name="ctls"></param>
        public void SetAllControlValue(Control.ControlCollection ctls)
        {
           
            foreach (Control con in ctls)
            {
                string _strTypeName = con.GetType().Name.ToString();
                if (_strTypeName == "Label" | _strTypeName == "Button" |
                    _strTypeName == "TreeView" || _strTypeName == "UpDownEdit")
                {
                    continue;
                }
                string _strResult = JsonHelper.GetValue(con.Name, currentStyleContent);
                SetControlValueByType(con, _strResult);
                if (con.Controls.Count > 0) SetAllControlValue(con.Controls);
            }
        }

        private string GetFieldValue(string p_fieldName)
        {
            try
            {
                DataSet _ds = LocalDBHelper.ExcuteQuery(string.Format("select field_value from style_detail where style_id='{0}' and field_name = '{1}'", currentStyleName, p_fieldName));
                return _ds.Tables[0].Rows[0]["field_value"].ToString();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(typeof(frmTempletManager), ex);
                return string.Empty;
            }

        }

        #endregion

        #region 保存信息

        #region 依据控件类型返回值

        /// <summary>
        /// 依据控件类型返回值
        /// RadioButton / CheckBox 返回选中状态  .Checked.ToString();
        /// 其他控件返回文本 .Text;
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <param name="p_ctl"></param>
        /// <returns></returns>
        public string GetFixValue(Control p_ctl)
        {
            Type t = p_ctl.GetType();
            if (t.Name == "RadioButton")
            {
                return ((RadioButton)p_ctl).Checked.ToString();
            }

            else if (t.Name == "CheckBox")
            {
                return ((CheckBox)p_ctl).Checked.ToString();
            }
            else if (t.Name == "RichTextBox")
            {
                string _strStyle = string.Empty;
                if (p_ctl.Tag == null)
                {
                    _strStyle = string.Empty;
                }
                else
                {
                    _strStyle = p_ctl.Tag.ToString();
                }
                return p_ctl.Text + "#" + _strStyle;
            }
            else if (t.Name == "MenuStrip")
            {
                string _strCheckState = string.Empty;
                if ("menuStrip3" == p_ctl.Name)
                {
                    Dictionary<string, bool> _dict = new Dictionary<string, bool>();

                    foreach (var item in toolStripMenuItem120.DropDownItems)
                    {
                        string S = item.GetType().ToString();
                        try
                        {
                            if ("System.Windows.Forms.ToolStripMenuItem" == S)
                            {

                                _dict.Add(((System.Windows.Forms.ToolStripMenuItem)item).Name, ((System.Windows.Forms.ToolStripMenuItem)item).Checked);
                                _strCheckState += ((System.Windows.Forms.ToolStripMenuItem)item).Name + "|" + ((System.Windows.Forms.ToolStripMenuItem)item).Checked.ToString() + "#";
                                //((System.Windows.Forms.ToolStripMenuItem)item).CheckedChanged += new EventHandler(通用ToolStripMenuItem_CheckedChanged);
                            }

                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteLog(typeof(frmTempletManager), ex);
                            continue;
                        }
                    }

                }
                //foreach (var item in ((MenuStrip)t).Items[0].)
                //{

                //}
                return _strCheckState;
            }
            else if (t.Name == "ComboBox")
            {
                return p_ctl.Text;
            }
            else if (t.Name == "NumericUpDown")
            {
                return ((UpDownBase)p_ctl).Text.ToString();
            }
            else if (t.Name == "UpDownEdit")
            {
                return p_ctl.Text;
            }
            return p_ctl.Text;

        }

        #endregion

        public void SaveData()
        {
            try
            {
                SaveAllControlValue(this.Controls);
                currentStyleContent = CommonFunction.FixStyleJson(currentStyleContent);
                System.IO.File.WriteAllText(PublicVar.StyleDir +"\\"+ MagazineStyle.GetInstance().Name + ".json", currentStyleContent, Encoding.UTF8);
                MessageBox.Show(null,"样式保存成功！","样式保存");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
                MessageBox.Show(null,"样式保存失败！","样式保存");
            }
        }

        public void SaveData(string _strFileName)
        {
            try
            {
                SaveAllControlValue(this.Controls);
                System.IO.File.WriteAllText(PublicVar.StyleDir + _strFileName + ".json", currentStyleContent, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        public void SaveAllControlValue(Control.ControlCollection ctls)
        {
            foreach (Control con in ctls)
            {
                string _strTypeName = con.GetType().Name.ToString();
                if (_strTypeName == "Label")
                {
                    continue;
                }
                string _strValue = GetFixValue(con);
                currentStyleContent = JsonHelper.UpdateValuesByStyleJson(con.Name, _strValue, currentStyleContent);
                if (con.Controls.Count > 0) SaveAllControlValue(con.Controls);
            }
        }

        /// <summary>
        /// 将样式更新到指定名称的样式文件中
        /// </summary>
        /// <param name="ctls"></param>
        public void SaveAllControlValueToStyle(Control.ControlCollection ctls, string _strStyleName)
        {
            foreach (Control con in ctls)
            {
                string _strTypeName = con.GetType().Name.ToString();
                if (_strTypeName == "Label")
                {
                    continue;
                }
                string _strValue = GetFixValue(con);
                currentStyleContent = JsonHelper.UpdateValuesBySyleName(con.Name, _strValue, _strStyleName);
                if (con.Controls.Count > 0) SaveAllControlValueToStyle(con.Controls, _strStyleName);
            }
        }


        private void SaveControlValue(string p, string _strValue)
        {
            int _n = LocalDBHelper.ExcuteNonQuery(string.Format("update style_detail set '{0}' where id='{1}' and _field_name='{2}'", currentStyleName, p, _strValue));
        }

        #endregion

        //public bool IsStandard()
        //{
        //    try
        //    {
        //        string content = BIMTService.CallGetService(PublicVar.BaseUrl + @"/templates/" + TID.Text, string.Empty, User.GetInstance().WaKey);
        //        Dictionary<string, object> _dictDid = (Dictionary<string, object>)CommonFunction.JsonToDictionary(content);
        //        Dictionary<string, object> response = (Dictionary<string, object>)_dictDid["response"];
        //        string _strType = response["type"].ToString();
        //        if (_dictDid == null)
        //        {
        //            return false;
        //        }
        //        if (_strType == "Standard")
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
          
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LAST_UPDATE_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                NOTES.Text = NOTES.Text.Replace("\"", string.Empty);
                //bool standard = false; //StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).IsStandardStyle();//.AddStyle(); IsStandard();
                //if (standard && !User.GetInstance().IsAdmin())
                //{
                //    MessageBox.Show(null, "默认样式无法修改！", "保存");
                //    return;
                //}
                //else 
                
                if (User.GetInstance().IsAdmin())
                {
                    if (StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).UpdateStyle())
                    {
                        LogHelper.WriteLog(typeof(frmTempletManager), currentStyleName + "更新成功");
                    }
                    else
                    {
                        LogHelper.WriteLog(typeof(frmTempletManager), currentStyleName + "更新样式");
                    }
                }
                SaveData();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmFeldList frm = new frmFeldList(this, 1);
            frm.ShowDialog();
            ////DisPlayStyle();
            //TextBox t1 = new TextBox();
            //t1.Text = "haha";
            ////t1.Controls.Add(l1);

            //t1.Location = new Point(0, 0);

            //Label l1 = new Label();
            //l1.Text ="haha";
            ////l1.Location = new Point(0,0);
            //l1.AutoSize = true;
            //t1.Width = l1.Width;
            //QUOTATION_ITEM.Controls.Add(t1);
        }

        /// <summary>
        /// 字段赋值,字段以<>包裹
        /// 0为设置文中引文模板
        /// 1文末引文模板
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <param name="p_strField"></param>
        public void SetTempletField(string p_strField)
        {
            //if (0 == p_nflag)
            //{
            //    QUOTATION_INDEX_FIELD.AppendText("<" + p_strField + ">");
            //}
            //else
            //{
            //    QUOTATION_ITEM_FIELD.AppendText(ClearField(p_strField));
            //    //QUOTATION_ITEM.AppendText("<" + p_strField + ">");
            //    QUOTATION_ITEM_FIELD.Tag += "<" + p_strField + ">";
            //}
            if (CurrentRichTextBox != null)
            {
                SetTempletField(CurrentRichTextBox, p_strField);
            }

        }

        /// <summary>
        /// 字段赋值,字段以<>包裹
        /// 0为设置文中引文模板
        /// 1文末引文模板
        /// 2016-04-05
        /// wuhailong
        /// </summary>
        /// <param name="p_strField"></param>
        public void SetTempletField(RichTextBox p_rtb, string p_strField)
        {
            //rtb.AppendText(ClearField(p_strField));
            //rtb.Tag += "<" + p_strField + ">";

            //p_rtb.SelectedText = ClearField(p_strField);

            int _nSelectedPosition = p_rtb.SelectionStart;
            string _strResult = string.Empty;
            string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
            string _strReg = @"<([^<>]*)>";
            var matches = Regex.Matches(_strTemplet, _strReg);
            List<string> _listCleared = new List<string>();
            List<string> _listField = new List<string>();

            foreach (Match item in matches)
            {
                string _strValue = item.Captures[0].Value.ToString();
                _listField.Add(_strValue);
                string _strClearedValue = _strValue.Replace("<", string.Empty).Replace(">", string.Empty).Split('_')[0];
                _listCleared.Add(_strClearedValue);
            }
            int _nClearedStart = 0;
            int _nIndex = 0;
            foreach (string item in _listCleared)
            {
                int _nClearedLength = item.Length;
                if (item == "空格")
                {
                    _nClearedLength = 1;
                }
                if (item == "换行符")
                {
                    _nClearedLength = 1;
                }
                int _nLength = matches[_nIndex].Captures[0].Value.ToString().Length;
                if (_nClearedStart == _nSelectedPosition)
                {
                    //p_rtb.Text = p_rtb.Text.Remove(_nClearedStart, _nClearedLength);
                    //p_rtb.SelectionStart = _nClearedStart;

                    p_rtb.SelectedText = ClearField(p_strField);
                    p_rtb.Select(p_rtb.SelectionStart - ClearField(p_strField).Length, ClearField(p_strField).Length);

                    //p_rtb.SelectionFont = new Font(p_rtb.SelectionFont.FontFamily, p_rtb.SelectionFont.Size, FontStyle.Regular);
                    break;
                }
                _nClearedStart += _nClearedLength;
                _nIndex++;
            }
            _listField.Insert(_nIndex, "<" + p_strField + ">");// SetFieldStyle(_listField[_nIndex], ((Button)sender).Text);
            string _newStyle = string.Empty;
            foreach (var item in _listField)
            {
                _newStyle += item;
            }
            p_rtb.Tag = _newStyle;
           
        }

        ///// <summary>
        ///// 字段赋值,字段以<>包裹
        ///// 0为设置文中引文模板
        ///// 2016-04-05
        ///// wuhailong
        ///// </summary>
        ///// <param name="p_strField"></param>
        //public void SetTempletField(string p_strField)
        //{
        //    SetTempletField(p_strField);
        //}

        /// <summary>
        /// 清洗字段，把格式去掉
        /// </summary>
        /// <param name="p_strField"></param>
        /// <returns></returns>
        public string ClearField(string p_strField)
        {
            try
            {
                if (p_strField.Contains("_"))
                {
                    string[] _arrayStr = p_strField.Split('_');
                    string _strResult = _arrayStr[0].Trim();
                    if (_strResult == "空格")
                    {
                        _strResult = " ";
                    }
                    if (_strResult == "换行符")
                    {
                        _strResult = "\n";
                    }
                    return _strResult;
                }
                return p_strField;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QUOTATION_ITEM.Enabled = true;
            //QUOTATION_ITEM.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {//另存为
            try
            {

                frmSaveAs frm = new frmSaveAs();

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    string styleName = frm.GetStyleName();
                   
                    
                    string styleId = StyleManager.GetInstance(string.Empty, styleName, currentStyleContent).AddStyle();//.UpdateStyle(Guid.NewGuid().ToString(), STYLE_NAME.Text, "79D52D5CC6460C73588693591E54ADBF", NOTES.Text, currentStyleContent);
                    CREATE_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    TID.Text = styleId;
                    STYLE_NAME.Text = styleName;
                    newStyle = styleName;
                    SaveData(styleName);
                    bool ok = StyleManager.GetInstance(styleId, styleName, currentStyleContent).UpdateStyle();
                    if (!ok)
                    {
                        MessageBox.Show(null, "另存为失败！", "另存为");
                    }
                    else
                    {
                        MessageBox.Show(null, "另存为成功！", "另存为");
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
            
        }

        /// <summary>
        /// 将当前改动过的样式存为新样式以供使用
        /// </summary>
        private bool SaveAs()
        {
            try
            {
                frmSaveAs frm = new frmSaveAs(MagazineStyle.GetInstance().Name, this);
                frm.ShowDialog();
                newStyle = STYLE_NAME.Text;
                if (frm.DialogResult == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        internal void SetStyleName(string p)
        {
            STYLE_NAME.Text = p;
            STYLE_TYPE.Text = "SelfDefined";
        }

        private void END_QUOTATION_ORDER_CODING_RULE_CheckedChanged(object sender, EventArgs e)
        {
            //if (END_QUOTATION_ORDER_CODING_RULE.Checked)
            //{
            //    USING_FIRST_NAME_CHAR_ORDER_RULE.Checked = false;
            //    USING_FIRST_NAME_CHAR_ORDER_RULE.Enabled = false;
            //}
            //else
            //{
            //    USING_FIRST_NAME_CHAR_ORDER_RULE.Enabled = true;
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //menuStrip1.
            frmIndexFeldList frm = new frmIndexFeldList(this, 0);
            frm.ShowDialog();
            //QUOTATION_INDEX_FIELD.Text = "<"+QUOTATION_INDEX_PREFIX.Text+"_0>" + QUOTATION_INDEX.Text + "<"+QUOTATION_INDEX_SUFFIX.Text+"_0>";
        }

        private void QUOTATION_INDEX_PREFIX_SelectedIndexChanged(object sender, EventArgs e)
        {
            //QUOTATION_INDEX_FIELD.Text = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Text + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmEditStyle frm = new frmEditStyle();
            frm.ShowDialog();
        }

        private void QUOTATION_ITEM_MouseClick(object sender, MouseEventArgs e)
        {
            //标签计算法
            //int _nSelected = QUOTATION_ITEM.SelectionStart;
            //int _nStartLeft = QUOTATION_ITEM.Text.Substring(0, _nSelected).LastIndexOf('<');
            //int _nEndRight = _nSelected + QUOTATION_ITEM.Text.Substring(_nSelected).IndexOf('>');
            //QUOTATION_ITEM.SelectionStart = _nStartLeft;
            //QUOTATION_ITEM.SelectionLength = _nEndRight - _nStartLeft + 1;

            //关键字查询法
            //int _nKeyStart = 0;
            //if (QUOTATION_ITEM.Text.Length == QUOTATION_ITEM.SelectionStart)
            //{
            //    _nKeyStart=QUOTATION_ITEM.SelectionStart - 1;
            //}
            //string _strKeyPart = QUOTATION_ITEM.Text.Substring(_nKeyStart, 1);
            //string _strKeyWord = FindKey(_strKeyPart);
        }

        /// <summary>
        /// 通过单个字，寻找关键词
        /// </summary>
        /// <param name="_strKeyPart"></param>
        /// <returns></returns>
        private string FindKey(string _strKeyPart)
        {
            throw new NotImplementedException();
        }

        private void QUOTATION_ITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar ==(char)Keys.Back)
            //{
            //    QUOTATION_ITEM.Text = QUOTATION_ITEM.Text.Remove(QUOTATION_ITEM.SelectionStart, QUOTATION_ITEM.SelectionLength);
            //    //QUOTATION_ITEM.SelectedText = "";
            //}
        }

        private void QUOTATION_ITEM_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode != Keys.Back)
            //{
            //    return;
            //}
        }



        private void button8_Click(object sender, EventArgs e)
        {
            ManageFieldStyle(((Button)sender).Text);
            DisPlayStyle();

            string _strTemplet = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Tag.ToString() + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
            ShowPreView(QUOTATION_INDEX_PREVIEW, _strTemplet, QUOTATION_INDEX_FONT_FAMILY.Text, float.Parse(QUOTATION_INDEX_FONT_SIZE.Text));

            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
            //try
            //{
            //    //设置文本粗体、斜体、下划线
            //    //if (QUOTATION_ITEM.SelectedText != string.Empty)
            //    //{
            //        if (((Button)sender).Text == "B")
            //        {
            //            //if (QUOTATION_ITEM.SelectionFont.Bold)
            //            if (QUOTATION_ITEM_FIELD.Tag.ToString().Contains("1"))
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Regular);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "0>";
            //            }
            //            else
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Bold);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "1>";
            //            }
            //        }
            //        else if (((Button)sender).Text == "I")
            //        {
            //            if (QUOTATION_ITEM.SelectedText.Contains("3"))
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Regular);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "0>";
            //            }
            //            else
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Italic);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "3>";
            //            }
            //        }
            //        else if (((Button)sender).Text == "U")
            //        {
            //            if (QUOTATION_ITEM.SelectedText.Contains("5"))
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Regular);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "0>";
            //            }
            //            else
            //            {
            //                //QUOTATION_ITEM.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), FontStyle.Underline);
            //                QUOTATION_ITEM.SelectedText = QUOTATION_ITEM.SelectedText.Split('_')[0] + "_" + "5>";
            //            }
            //        }
            //    //}

            //    DisPlayStyle();
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //}
        }

        /// <summary>
        /// 设置当前选中富文本框样式,加入当前富文本框为null则不执行
        /// 2016-05-03
        /// wuhailong
        /// </summary>
        /// <param name="p_strStyleFlag"></param>
        private void ManageFieldStyle(string p_strStyleFlag)
        {
            if (CurrentRichTextBox != null)
            {
                ManageFieldStyle(CurrentRichTextBox, p_strStyleFlag);
            }
        }

        /// <summary>
        /// 设置富文本框内字段样式
        /// 2016-05-03
        /// wuhailong
        /// </summary>
        /// <param name="p_trb">富文本框</param>
        /// <param name="p_strStyleFlag">样式标志</param>
        private void ManageFieldStyle(RichTextBox p_trb, string p_strStyleFlag)
        {
            try
            {
                int _nSelectStart = p_trb.SelectionStart;
                string _strResult = string.Empty;
                string _strTemplet = p_trb.Tag.ToString();// QUOTATION_ITEM.Text;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                List<string> _listCleared = new List<string>();
                List<string> _listField = new List<string>();
                foreach (Match item in matches)
                {
                    string _strValue = item.Captures[0].Value.ToString();
                    _listField.Add(_strValue);
                    string _strClearedValue = _strValue.Replace("<", string.Empty).Replace(">", string.Empty).Split('_')[0];
                    _listCleared.Add(_strClearedValue);
                }
                int _nClearedStart = 0;
                int _nIndex = 0;
                foreach (string item in _listCleared)
                {
                    int _nClearedLength = item.Length;
                    if (item == "空格")
                    {
                        _nClearedLength = 1;
                    }
                    if (item == "换行符")
                    {
                        _nClearedLength = 1;
                    }
                    int _nLength = matches[_nIndex].Captures[0].Value.ToString().Length;
                    if (_nClearedStart <= p_trb.SelectionStart && p_trb.SelectionStart < _nClearedStart + _nClearedLength)
                    {
                        break;
                    }
                    _nClearedStart += _nClearedLength;
                    _nIndex++;
                }
                _listField[_nIndex] = SetFieldStyle(_listField[_nIndex], p_strStyleFlag);//((Button)sender).Text);
                string _newStyle = string.Empty;
                foreach (var item in _listField)
                {
                    _newStyle += item;
                }
                p_trb.Tag = _newStyle;
                p_trb.SelectionStart = _nSelectStart;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        /// <summary>
        /// 设置字段样式
        /// </summary>
        /// <param name="p">字段标志</param>
        /// <param name="s">B;I;U</param>
        /// <returns></returns>
        private string SetFieldStyle(string p, string s)
        {
            try
            {
                string _str = p.Replace("<", "").Replace(">", "");
                string[] _array = _str.Split('_');
                if (((s.ToUpper() == "B") && (_array[1] == "1")) || ((s.ToUpper() == "I") && (_array[1] == "3")) || ((s.ToUpper() == "U") && (_array[1] == "5")))
                {
                    _array[1] = "0";
                }
                else if (s.ToUpper() == "B")
                {
                    _array[1] = "1";
                }
                else if (s.ToUpper() == "I")
                {
                    _array[1] = "3";
                }
                else if (s.ToUpper() == "U")
                {
                    _array[1] = "5";
                }
                return string.Format("<{0}_{1}>", _array[0], _array[1]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), "SetFieldStyle\n" + ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// 将样式展示到显示窗口 richtextbox
        /// 2016-04-25
        /// wuhailong
        /// </summary>
        private void DisPlayStyle()
        {
            return;//2016-05-30 去除字段预览 wuhailong
            if (CurrentRichTextBox != null)
            {
                DisPlayStyle(CurrentRichTextBox);
            }


            //try
            //{
            //    //QUOTATION_ITEM_FIELD_DISPLAY.Focus();
            //    string _strResult = string.Empty;
            //    string _strTemplet = QUOTATION_ITEM_FIELD.Tag.ToString();// QUOTATION_ITEM.Text;
            //    string _strReg = @"<([^<>]*)>";
            //    var matches = Regex.Matches(_strTemplet, _strReg);
            //    QUOTATION_ITEM_FIELD.Text = string.Empty;
            //    foreach (Match item in matches)
            //    {
            //        string _s = QUOTATION_ITEM_FIELD.SelectedRtf;
            //        int _nStart = QUOTATION_ITEM_FIELD.Text.Length;

            //        var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
            //        string[] _array = _strFieldAndStyleMix.Split('_');
            //        QUOTATION_ITEM_FIELD.AppendText(ClearField(_strFieldAndStyleMix));

            //        QUOTATION_ITEM_FIELD.Select(_nStart, ClearField(_strFieldAndStyleMix).Length);
            //        QUOTATION_ITEM_FIELD.SelectionFont = new Font(QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(CommonFunction.FixFontSize(QUOTATION_ITEM_FONT_SIZE.Text)), GetStyle(_array[1]));
            //    }
            //    QUOTATION_ITEM_FIELD.Select(QUOTATION_ITEM_FIELD.SelectionStart, 0);
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //}
        }

        /// <summary>
        /// 将样式展示到显示窗口 richtextbox
        /// p_nStyleFlag>0文末样式，==0 标题样式，小于0文中样式
        /// 2016-04-25
        /// wuhailong
        /// </summary>
        /// <param name="p_rtb"></param>
        /// <param name="p_nStyleFlag"></param>
        private void DisPlayStyle(RichTextBox p_rtb, int p_nStyleFlag)
        {
            //try
            //{
            DisPlayStyle(p_rtb, p_nStyleFlag, false);
            //    string _strResult = string.Empty;
            //    string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
            //    string _strReg = @"<([^<>]*)>";
            //    var matches = Regex.Matches(_strTemplet, _strReg);
            //    p_rtb.Text = string.Empty;
            //    foreach (Match item in matches)
            //    {
            //        string _s = p_rtb.SelectedRtf;
            //        int _nStart = p_rtb.Text.Length;

            //        var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
            //        string[] _array = _strFieldAndStyleMix.Split('_');
            //        //插入字段
            //        p_rtb.SelectedText = ClearField(_strFieldAndStyleMix);
            //        //末尾追加字段
            //        p_rtb.AppendText(ClearField(_strFieldAndStyleMix));

            //        p_rtb.Select(_nStart, ClearField(_strFieldAndStyleMix).Length);
            //        string _strFont = string.Empty; //JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
            //        float _fFontSize = 0; //float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE")));
            //        if (p_nStyleFlag<0)
            //        {
            //              _strFont =  JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
            //         _fFontSize =  float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE")));
            //        }
            //        else if (p_nStyleFlag==0)
            //        {
            //            _strFont = JsonHelper.GetValue("QUOTATION_TITLE_FONT_FAMILY");
            //            _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_TITLE_FONT_SIZE")));
            //        }
            //        else if (p_nStyleFlag > 0)
            //        {
            //            _strFont = JsonHelper.GetValue("QUOTATION_INDEX_FONT_FAMILY");
            //            _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_INDEX_FONT_SIZE")));
            //        }
            //        p_rtb.SelectionFont = new Font(_strFont, _fFontSize, GetStyle(_array[1]));
            //    }
            //    p_rtb.Select(p_rtb.SelectionStart, 0);
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //}
        }

        /// <summary>
        /// 当前操作的文本框
        /// 2016-05-13
        /// wuhailong
        /// </summary>
        /// <param name="p_rtb"></param>
        /// <param name="p_nStyleFlag">位置标志</param>
        /// <param name="p_append">是否追加</param>
        private void DisPlayStyle(RichTextBox p_rtb, int p_nStyleFlag, bool p_append)
        {
            try
            {
                //QUOTATION_ITEM_FIELD_DISPLAY.Focus();
                string _strResult = string.Empty;
                string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                p_rtb.Text = string.Empty;
                foreach (Match item in matches)
                {
                    string _s = p_rtb.SelectedRtf;
                    int _nStart = p_rtb.Text.Length;

                    var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
                    string[] _array = _strFieldAndStyleMix.Split('_');
                    //插入字段
                    if (p_append)
                    {
                        p_rtb.SelectedText = ClearField(_strFieldAndStyleMix);
                    }
                    else
                    {
                        //末尾追加字段
                        p_rtb.AppendText(ClearField(_strFieldAndStyleMix));
                    }
                    //int locate = _nStart + ClearField(_strFieldAndStyleMix).Length;
                    //p_rtb.Select(locate, locate);
                    //string _strFont = string.Empty; //JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
                    //float _fFontSize = 0; //float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE")));
                    //if (p_nStyleFlag < 0)
                    //{
                    //    _strFont = JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
                    //    _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE")));
                    //}
                    //else if (p_nStyleFlag == 0)
                    //{
                    //    _strFont = JsonHelper.GetValue("QUOTATION_TITLE_FONT_FAMILY");
                    //    _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_TITLE_FONT_SIZE")));
                    //}
                    //else if (p_nStyleFlag > 0)
                    //{
                    //    _strFont = JsonHelper.GetValue("QUOTATION_INDEX_FONT_FAMILY");
                    //    _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_INDEX_FONT_SIZE")));
                    //}
                    //p_rtb.SelectionFont = new Font(_strFont, _fFontSize, GetStyle(_array[1]));
                }
                //p_rtb.Select(p_rtb.SelectionStart, 0);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }


        /// <summary>
        /// 将样式展示到显示窗口 richtextbox
        /// 2016-04-25
        /// wuhailong
        /// </summary>
        private void DisPlayStyle(RichTextBox p_rtb)
        {
            if (p_rtb.Name == "QUOTATION_INDEX_FIELD")
            {
                DisPlayStyle(p_rtb, 1);
            }
            else if (p_rtb.Name == "QUOTATION_TITLE")
            {
                DisPlayStyle(p_rtb, 0);
            }
            else
            {
                DisPlayStyle(p_rtb, -1);
            }

            //try
            //{
            //    //QUOTATION_ITEM_FIELD_DISPLAY.Focus();
            //    string _strResult = string.Empty;
            //    string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
            //    string _strReg = @"<([^<>]*)>";
            //    var matches = Regex.Matches(_strTemplet, _strReg);
            //    p_rtb.Text = string.Empty;
            //    foreach (Match item in matches)
            //    {
            //        string _s = p_rtb.SelectedRtf;
            //        int _nStart = p_rtb.Text.Length;

            //        var _strFieldAndStyleMix = item.Captures[0].Value.Replace("<", "").Replace(">", "");
            //        string[] _array = _strFieldAndStyleMix.Split('_');
            //        p_rtb.AppendText(ClearField(_strFieldAndStyleMix));

            //        p_rtb.Select(_nStart, ClearField(_strFieldAndStyleMix).Length);
            //        string _strFont = JsonHelper.GetValue("QUOTATION_ITEM_CHINESE_FONT_FALIMY");
            //        float _fFontSize = float.Parse(CommonFunction.FixFontSize(JsonHelper.GetValue("QUOTATION_ITEM_FONT_SIZE")));
            //        p_rtb.SelectionFont = new Font(_strFont, _fFontSize, GetStyle(_array[1]));
            //    }
            //    p_rtb.Select(p_rtb.SelectionStart, 0);
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //}
        }

        private FontStyle GetStyle(string p)
        {
            try
            {
                if (p == "1")
                {
                    return FontStyle.Bold;
                }
                else if (p == "3")
                {
                    return FontStyle.Italic;
                }
                else if (p == "5")
                {
                    return FontStyle.Underline;
                }
                return FontStyle.Regular;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
                throw;
            }
        }

        /// <summary>
        /// 通过指定当前richitextbox的选区位置定位keyword
        /// 2016-04-25
        /// wuhailong
        /// </summary>
        /// <param name="p"></param>
        private void SelectKeyWord()
        {
            if (CurrentRichTextBox != null)
            {
                SelectKeyWord(CurrentRichTextBox, CurrentRichTextBox.SelectionStart);
            }
        }

        /// <summary>
        /// 通过指定当前richbox的指定选区位置定位keyword
        /// 2016-05-03
        /// wuhailong
        /// </summary>
        /// <param name="p"></param>
        private void SelectKeyWord(int p_nSelectionStart)
        {
            if (CurrentRichTextBox != null)
            {
                SelectKeyWord(CurrentRichTextBox, p_nSelectionStart);
            }
            //try
            //{
            //    string _strResult = string.Empty;
            //    string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
            //    string _strReg = @"<([^<>]*)>";
            //    var matches = Regex.Matches(_strTemplet, _strReg);
            //    List<string> _listCleared = new List<string>();
            //    string _strClearedTemplet = string.Empty;
            //    foreach (Match item in matches)
            //    {
            //        string _strValue = item.Captures[0].Value.ToString();
            //        string _strClearedValue = _strValue.Replace("<", string.Empty).Replace(">", string.Empty).Split('_')[0];
            //        _listCleared.Add(_strClearedValue);
            //        _strClearedTemplet += _strClearedValue;
            //    }
            //    int _nClearedStart = 0;
            //    int _nStart = 0;
            //    int _nIndex = 0;
            //    foreach (string item in _listCleared)
            //    {
            //        int _nClearedLength = item.Length;
            //        if (item == "空格")
            //        {
            //            _nClearedLength = 1;
            //        }
            //        if (item == "换行符")
            //        {
            //            _nClearedLength = 1;
            //        }
            //        int _nLength = matches[_nIndex].Captures[0].Value.ToString().Length;
            //        if (_nClearedStart <= p_rtb.SelectionStart && p_rtb.SelectionStart < _nClearedStart + _nClearedLength)
            //        {
            //            p_rtb.Select(_nClearedStart, _nClearedLength);//.SelectedText = _strValue;
            //            return;
            //        }
            //        _nClearedStart += _nClearedLength;
            //        _nStart += _nLength;
            //        _nIndex++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(frmTempletManager), ex);
            //}
        }

        /// <summary>
        /// 通过指定richitextbox的指定选区位置定位keyword
        /// 2016-05-03
        /// wuhailong
        /// </summary>
        /// <param name="p"></param>
        private void SelectKeyWord(RichTextBox p_rtb, int p_nSelectionStart)
        {
            try
            {
                string _strResult = string.Empty;
                string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                List<string> _listCleared = new List<string>();
                string _strClearedTemplet = string.Empty;
                foreach (Match item in matches)
                {
                    string _strValue = item.Captures[0].Value.ToString();
                    string _strClearedValue = _strValue.Replace("<", string.Empty).Replace(">", string.Empty).Split('_')[0];
                    _listCleared.Add(_strClearedValue);
                    _strClearedTemplet += _strClearedValue;
                }
                int _nClearedStart = 0;
                int _nStart = 0;
                int _nIndex = 0;
                foreach (string item in _listCleared)
                {
                    int _nClearedLength = item.Length;
                    if (item == "空格")
                    {
                        _nClearedLength = 1;
                    }
                    if (item == "换行符")
                    {
                        _nClearedLength = 1;
                    }
                    int _nLength = matches[_nIndex].Captures[0].Value.ToString().Length;
                    if (_nClearedStart <= p_nSelectionStart && p_nSelectionStart < _nClearedStart + _nClearedLength)
                    {
                        p_rtb.Select(_nClearedStart, _nClearedLength);//.SelectedText = _strValue;
                        return;
                    }
                    _nClearedStart += _nClearedLength;
                    _nStart += _nLength;
                    _nIndex++;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        private void QUOTATION_ITEM_FIELD_DISPLAY_MouseClick(object sender, MouseEventArgs e)
        {
            //SelectKeyWord();
        }



        private void QUOTATION_ITEM_FIELD_DISPLAY_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                DeleteSelectedField();
            }
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
            //if (e.KeyChar == (char)Keys.Up 
            //    || e.KeyChar == (char)Keys.Down
            //    || e.KeyChar == (char)Keys.Left
            //    || e.KeyChar == (char)Keys.Right)
            //{
            //    SelectKeyWord(QUOTATION_ITEM_FIELD_DISPLAY.SelectionStart);
            //}
        }

        /// <summary>
        /// 删除当前richtextbox字段
        /// 2016-05-03
        /// wuhailong
        /// </summary>
        private void DeleteSelectedField()
        {
            if (this.CurrentRichTextBox != null)
            {
                DeleteSelectedField(CurrentRichTextBox);
            }

        }

        struct KeyWord
        {
            int _nStart;
            string _strContent;
        }

        //private KeyWord GetKeyWordBySection(RichTextBox p_rtb,int p_strSection) {
        //    string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
        //    string _strReg = @"<([^<>]*)>";
        //    var matches = Regex.Matches(_strTemplet, _strReg);
        //    foreach (Match item in matches)
        //    {

        //    }
        //}

        /// <summary>
        /// 删除指定richtextbox选中字段
        /// wuhailong
        /// 2016-05-03
        /// </summary>
        /// <param name="p_rtb"></param>
        private void DeleteSelectedField(RichTextBox p_rtb)
        {
            try
            {
                int _nSelectedPosition = p_rtb.SelectionStart;
                //p_rtb.Text = p_rtb.Text.Remove(p_rtb.SelectionStart, p_rtb.SelectionLength);
                string _strResult = string.Empty;
                string _strTemplet = p_rtb.Tag.ToString();// QUOTATION_ITEM.Text;
                string _strReg = @"<([^<>]*)>";
                var matches = Regex.Matches(_strTemplet, _strReg);
                List<string> _listCleared = new List<string>();
                List<string> _listField = new List<string>();

                foreach (Match item in matches)
                {
                    string _strValue = item.Captures[0].Value.ToString();
                    _listField.Add(_strValue);
                    string _strClearedValue = _strValue.Replace("<", string.Empty).Replace(">", string.Empty).Split('_')[0];
                    _listCleared.Add(_strClearedValue);
                }
                int _nClearedStart = 0;
                int _nIndex = 0;
                foreach (string item in _listCleared)
                {
                    int _nClearedLength = item.Length;
                    if (item == "空格")
                    {
                        _nClearedLength = 1;
                    }
                    if (item == "换行符")
                    {
                        _nClearedLength = 1;
                    }
                    int _nLength = matches[_nIndex].Captures[0].Value.ToString().Length;
                    if (_nClearedStart < _nSelectedPosition && _nSelectedPosition <= _nClearedStart + _nClearedLength)
                    {
                        p_rtb.Text = p_rtb.Text.Remove(_nClearedStart, _nClearedLength);
                        p_rtb.SelectionStart = _nClearedStart;
                        break;
                    }
                    _nClearedStart += _nClearedLength;
                    _nIndex++;
                }
                _listField[_nIndex] = string.Empty;// SetFieldStyle(_listField[_nIndex], ((Button)sender).Text);
                string _newStyle = string.Empty;
                foreach (var item in _listField)
                {
                    _newStyle += item;
                }
                p_rtb.Tag = _newStyle;

                //DisPlayStyle();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        private void QUOTATION_ITEM_FIELD_DISPLAY_KeyDown(object sender, KeyEventArgs e)
        {

            //m_nStart = QUOTATION_ITEM_FIELD.SelectionStart;
            //m_nLength = QUOTATION_ITEM_FIELD.SelectedText.Length;
            if (this.CurrentRichTextBox != null)
            {
                m_nStart = this.CurrentRichTextBox.SelectionStart;
                m_nLength = this.CurrentRichTextBox.SelectedText.Length;
            }


        }

        private void QUOTATION_ITEM_FIELD_DISPLAY_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down
            //                || e.KeyCode == Keys.Right)
            //{
            //    KeyWordDown();
            //}
            //else if (e.KeyCode == Keys.Up
            //                || e.KeyCode == Keys.Left
            //                )
            //{
            //    KeyWordUp();

            //}
        }

        /// <summary>
        /// 向上寻找关键词
        ///  2016-04-25
        /// 吴海龙
        /// </summary>
        private void KeyWordUp()
        {
            //if (QUOTATION_ITEM_FIELD_DISPLAY.SelectedText!=string.Empty)
            //{
            SelectKeyWord(m_nStart - 1);
            //}
        }
        /// <summary>
        /// 乡下寻找关键词
        /// 2016-04-25
        /// 吴海龙
        /// </summary>
        private void KeyWordDown()
        {
            //if (QUOTATION_ITEM_FIELD_DISPLAY.SelectedText!=string.Empty)
            //{
            SelectKeyWord(m_nStart + m_nLength);
            //}
        }

        private void USING_SUPERSCRIPT_CheckedChanged(object sender, EventArgs e)
        {
            if (USING_SUPERSCRIPT.Checked)
            {
                USING_SUBSCRIPT.Checked = false;
            }
            //else
            //{
            //    USING_SUBSCRIPT.Checked = true;
            //}
        }

        private void USING_SUBSCRIPT_CheckedChanged(object sender, EventArgs e)
        {
            if (USING_SUBSCRIPT.Checked)
            {
                USING_SUPERSCRIPT.Checked = false;
            }
            //else
            //{
            //    USING_SUPERSCRIPT.Checked = true;
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show("Hello");
        }

        /// <summary>
        /// 文中引文插入字段
        /// wuhailong
        /// 2016-05-28
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello e");
            //CommonFunction.WritField(QUOTATION_INDEX_FIELD, "<"+((ToolStripMenuItem)sender).Text+"_0"+">");
            string _strField = ((ToolStripMenuItem)sender).Text;
            SetTempletField(_strField + "_0");
            int _nStart = CurrentRichTextBox.SelectionStart;
            if (CurrentRichTextBox != null)
            {
                DisPlayStyle(CurrentRichTextBox, 1);
            }
            _nStart = _nStart + _strField.Length;
            CurrentRichTextBox.Select(_nStart,0);
            string _strTemplet = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Tag.ToString() + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
            ShowPreView(QUOTATION_INDEX_PREVIEW, _strTemplet, QUOTATION_INDEX_FONT_FAMILY.Text, float.Parse(QUOTATION_INDEX_FONT_SIZE.Text));
        }

    

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
        public string currentStyleId { get; set; }

        public string currentStyleName { get; set; }

        public string currentStyleContent { get; set; }

        //文末引文插入字段
        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            //SetTempletField(((ToolStripMenuItem)sender).Text + "_0");
            string _strField = ((ToolStripMenuItem)sender).Text;
            SetTempletField(_strField + "_0");
            int _nStart = CurrentRichTextBox.SelectionStart;
            //修复空格和换行符字段插入后贯标位置显示错误bug; wuhailong 2016-07-11
            if (CurrentRichTextBox != null)
            {
                DisPlayStyle(CurrentRichTextBox, -1);
            }
            if (_strField == "空格" || _strField == "换行符")
            {
                _nStart = _nStart + 1;
            }
            else
            {
                _nStart = _nStart + _strField.Length;
            }
          
            CurrentRichTextBox.Select(_nStart, 0);
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
        }

        private void QUOTATION_ITEM_FIELD_Enter(object sender, EventArgs e)
        {
            ((RichTextBox)sender).BackColor = Color.AliceBlue;
            this.CurrentRichTextBox = ((RichTextBox)sender);
        }

        private void QUOTATION_ITEM_FIELD_Leave(object sender, EventArgs e)
        {
            ((RichTextBox)sender).BackColor = Color.White;
        }



        public RichTextBox CurrentRichTextBox { get; set; }



        private void IGNORE_REPEAT_AUTHORS_CheckedChanged(object sender, EventArgs e)
        {
            //if (IGNORE_REPEAT_AUTHORS.Checked)
            //{
            //    IGNORE_REPEAT_AUTHORS_USE_SPLIT_CHAR.Enabled = true;
            //    IGNORE_REPEAT_AUTHORS_IF_LOOK_SAME.Enabled = true;
            //    DONT_IGNORE_REPEAT_AUTHORS_WITH_SUFFIX.Enabled = true;
            //}
            //else
            //{
            //    IGNORE_REPEAT_AUTHORS_USE_SPLIT_CHAR.Enabled = false;
            //    IGNORE_REPEAT_AUTHORS_IF_LOOK_SAME.Enabled = false;
            //    DONT_IGNORE_REPEAT_AUTHORS_WITH_SUFFIX.Enabled = false;
            //}

        }

        private void 通用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //((ToolStripMenuItem)sender).Checked
            //    this.inv
        }

        private void 通用ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SetTempletVisibleState(((ToolStripMenuItem)sender));
        }

        private void SetTempletVisibleState(ToolStripMenuItem menuitem)
        {
            try
            {
                if (menuitem.Checked)
                {
                    foreach (Control item in panel5.Controls)
                    {
                        if (item.Name == menuitem.Text)
                        {
                            item.Visible = true;
                            DisPlayStyle((RichTextBox)item.Controls[0]);
                        }
                    }
                }
                else
                {
                    foreach (Control item in panel5.Controls)
                    {
                        if (item.Name == menuitem.Text)
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }



        private void QUOTATION_ITEM_FONT_SIZE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DisPlayStyle();
        }

        /// <summary>
        /// 设置title样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            //QUOTATION_TITLE
        }

        private void toolStripMenuItem194_Click(object sender, EventArgs e)
        {
            SetTempletField(((ToolStripMenuItem)sender).Text + "_0");
            //if (CurrentRichTextBox != null)
            //{
            DisPlayStyle(CurrentRichTextBox, 0);
            //}
        }

        private void toolStripMenuItem121_Click(object sender, EventArgs e)
        {
            QUOTATION_TITLE.Focus();
        }

        public string newStyle { get; set; }

        private void QUOTATION_INDEX_FONT_FAMILY_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _strTemplet = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Tag.ToString() + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
            ShowPreView(QUOTATION_INDEX_PREVIEW, _strTemplet, QUOTATION_INDEX_FONT_FAMILY.Text, float.Parse(QUOTATION_INDEX_FONT_SIZE.Text));
        }

        private void QUOTATION_ITEM_CHINESE_FONT_FALIMY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
        }

        private void QUOTATION_INDEX_PREFIX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string _strTemplet = "<" + QUOTATION_INDEX_PREFIX.Text + "_0>" + QUOTATION_INDEX.Tag.ToString() + "<" + QUOTATION_INDEX_SUFFIX.Text + "_0>";
            ShowPreView(QUOTATION_INDEX_PREVIEW, _strTemplet, QUOTATION_INDEX_FONT_FAMILY.Text, float.Parse(QUOTATION_INDEX_FONT_SIZE.Text));
            ComboBox combox =  sender as ComboBox ;
            if (combox.Name=="QUOTATION_INDEX_PREFIX")
            {
                if (combox.Text=="(")
                {
                    QUOTATION_INDEX_SUFFIX.Text = ")";
                }
                else if (combox.Text=="[")
                {
                    QUOTATION_INDEX_SUFFIX.Text = "]";
                }
                else
                {
                    QUOTATION_INDEX_SUFFIX.Text = "";
                }
            }
            else if (combox.Name == "QUOTATION_INDEX_SUFFIX")
            {
                if (combox.Text == ")")
                {
                    QUOTATION_INDEX_PREFIX.Text = "(";
                }
                else if (combox.Text == "]")
                {
                    QUOTATION_INDEX_PREFIX.Text = "[";
                }
                else
                {
                    QUOTATION_INDEX_PREFIX.Text = "";
                }
            }
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                StyleManager sm = StyleManager.GetInstance(currentStyleId, string.Empty, string.Empty);
                bool ok = sm.ConvertToPublic();
                if (ok)
                {
                    this.Text = "3：转换公有成功！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool exist = StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).ExistStyle();
                if (!exist)//新增
                {
                    if (DialogResult.Yes == MessageBox.Show(null, "服务器未找到当前样式，是否新增到服务器？", "更新样式", MessageBoxButtons.YesNo))
                    {
                        string styleId = StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).AddStyle();
                        if (styleId!=string.Empty)
                        {
                            MessageBox.Show(null, "样式新增成功", "新增样式");
                        }
                        else
                        {
                            MessageBox.Show(null, "样式新增失败", "新增样式");
                        }
                    }
                }
                else
                {
                    bool updateSuccess = StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).UpdateStyle();
                    if (updateSuccess)
                    {
                        this.Text = "2：样式更新成功";
                    }
                    else
                    {
                        MessageBox.Show(null, "样式更新失败", "更新样式");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }

           
         
            //StyleManager.AddStyle(

            //string _strPostData = "{"
            //                    +"\"name\": \"实验室\","
            //                    + "\"refJournalId\": \"DD539243E22540EB24E18194CD8B1577\","
            //                    +"\"descptn\": \"在学校实验室时投稿所用格式\","
            //                    +"\"formats\": "
            //                    +m_strStyleJson
                                
            //                    +"}";
            //BIMTService.CallPostService(PublicVar.BaseUrl + @"/templates", _strPostData,User.GetInstance().WaKey);
        }

        private void FAUTHOR_ALLAUTHOR_PUBYEAR_Click(object sender, EventArgs e)
        {
            GM++;
            if (GM==3)
            {
                button514.Visible = true;
                btn_convert_pub.Visible = true;
                btn_convert_my.Visible = true;
                STYLE_TYPE.Text = "GM";
            }
        }

        public int GM { get; set; }

        private void button3_Click_2(object sender, EventArgs e)
        {
            try
            {
                bool ok = StyleManager.GetInstance(currentStyleId, string.Empty, string.Empty).ConvertToMy();
                if (ok)
                {
                    this.Text = "1：转换私有成功！";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
            

        }

        private void 文末模板_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb_sjyes.Checked)
            {
                XGSJ_VALUE.Value = 2;
            }
            else if (rb_sjno.Checked)
            {
                XGSJ_VALUE.Value = 0;
            }
        }

        private void USE_FOUR_NUM_YEAR_CheckedChanged(object sender, EventArgs e)
        {
            if (USE_FOUR_NUM_YEAR.Checked)
            {
                QUOTATION_INDEX_PREVIEW.Text = QUOTATION_INDEX_PREVIEW.Text.Replace("20",string.Empty).Replace("15","2015");
            }
            else if (USE_TWO_NUM_YEAR.Checked)
            {
                QUOTATION_INDEX_PREVIEW.Text = QUOTATION_INDEX_PREVIEW.Text.Replace("2015", "15");
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            GM++;
            if (GM == 3)
            {
                TID.Visible = true;
                button514.Visible = true;
                //btn_convert_pub.Visible = true;
                //btn_convert_my.Visible = true;
                button3965.Visible = true;
                button39527.Visible = true;
                btn_delete_style.Visible = true;
                STYLE_TYPE.Text = "GM";
                isAdmin = true;
            }
        }

        private void button3965_Click(object sender, EventArgs e)
        {
            try
            {
                string styleId =  StyleManager.GetInstance(currentStyleId,currentStyleName, currentStyleContent).AddStyle();
                if (styleId!=string.Empty)
                {
                    MessageBox.Show(null, "样式成功添加到服务器", "添加样式");
                }
                else
                {
                    MessageBox.Show(null, "添加样式失败", "添加样式");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
           
            //bool r = StyleManager.ConvertToMy(TID.Text);
            //bool _boolR = StyleManager.UpdateStyle(TID.Text, STYLE_NAME.Text, "79D52D5CC6460C73588693591E54ADBF", NOTES.Text, m_strStyleJson);
            //bool _boolR2 = StyleManager.ConvertToPublic(TID.Text);
            //if (r && _boolR && _boolR2)
            //{
            //    MessageBox.Show(null, "上传成功！", "上传样式");
            //}
            //else
            //{
            //    MessageBox.Show(null, "上传失败！", "上传样式");
            //}
        }

        private void QUOTATION_INDEX_LIST_AUTHOR_COUNT_OVER_ValueChanged(object sender, EventArgs e)
        {
            QUOTATION_INDEX_LIST_AUTHOR_COUNT_ONLY.Maximum = QUOTATION_INDEX_LIST_AUTHOR_COUNT_OVER.Value;
        }


        private void button39527_Click(object sender, EventArgs e)
        {   //全部新增
            try
            {
                DirectoryInfo diHsz = new DirectoryInfo(PublicVar.StyleDir);
                int addCount = 0;
                int addFCount = 0;
                int updateCount = 0;
                int updateFCount = 0;
                StringBuilder sbid = new StringBuilder();
                foreach (FileInfo item in diHsz.GetFiles())
                {
                    try
                    {
                        string styleContent = File.ReadAllText(item.FullName);
                        styleContent = CommonFunction.FixStyleJson(styleContent);
                        Dictionary<string, object> _dict = CommonFunction.JsonToDictionary(styleContent);
                        string styleId = _dict["TID"].ToString();
                        string styleName = _dict["STYLE_NAME"].ToString().Replace("--OK", string.Empty).Trim();
                        StyleManager sm = StyleManager.GetInstance(styleId, styleName, styleContent);
                        bool exist = sm.ExistStyle();
                        bool update = false;
                        bool add = false;
                        if (exist)
                        {//修改样式
                            update = sm.UpdateStyle();
                            if (update)
                            {
                                ++updateCount;
                            }
                            else
                            {
                                ++updateFCount;
                               
                            }
                        }
                        else
                        {//新增样式
                            string rStyleId = sm.AddStyle();
                            if (rStyleId!=string.Empty)
                            {
                                ++addCount;
                                sbid.Append(rStyleId + ":");
                            }
                            else
                            {
                                ++addFCount;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(frmTempletManager), ex);
                    }
                }
                LogHelper.WriteLog(typeof(frmTempletManager),"FALSE ID LIST"+ sbid.ToString());
                MessageBox.Show(null, "成功上传" + addCount + "条 失败" + addFCount + "条" + " \n成功更新" + updateCount + "条 失败" + updateFCount + "条", "全部上传");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        private void USE_PERIODICAL_SHORTHAND_NAME_Click(object sender, EventArgs e)
        {
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
        }

        private void USE_PERIODICAL_FULL_NAME_Click(object sender, EventArgs e)
        {
            ShowPreView(QUOTATION_ITEM_PREVIEW, QUOTATION_ITEM.Tag.ToString(), QUOTATION_ITEM_CHINESE_FONT_FALIMY.Text, float.Parse(QUOTATION_ITEM_FONT_SIZE.Text));
        }

        private void groupBox40_Enter(object sender, EventArgs e)
        {

        }

        private void btn_delete_style_Click(object sender, EventArgs e)
        {
            try
            {
                bool exist = StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).ExistStyle();
                if (exist)
                {
                    bool ok = StyleManager.GetInstance(currentStyleId, currentStyleName, currentStyleContent).DeleteStyle();
                    if (ok)
                    {
                        MessageBox.Show(null, "样式删除成功！", "删除样式");
                    }
                    else
                    {
                        MessageBox.Show(null, "样式删除失败！", "删除样式");
                    }
                }
                else
                {
                    MessageBox.Show(null, "服务器不存在当前样式！", "删除样式");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), "删除样式" + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool isAdmin = false;

        private void frmTempletManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string filePath = PublicVar.StyleDir + "\\" + MagazineStyle.GetInstance().Name + ".json";
                string jsonText = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
                PublicVar.CurrentStyleJsonString = jsonText;
                PublicVar.CurrentStyleJObject = JObject.Parse(jsonText);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(frmTempletManager), ex);
            }
        }

        private void frmTempletManager_ForeColorChanged(object sender, EventArgs e)
        {

        }
    }
}
