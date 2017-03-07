using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace BIMTClassLibrary.WordTemplate
{
    class Demo : BaseTemplate
    {
        public Demo() : base() { }
        public override DataTable GetSource()
        {
            try
            {
                source.Rows.Add("Acta Geophysica", "SCI", "0.945", "模板.docx");
                source.Rows.Add("Abacus", "其他", "-", "模板.docx");
                source.Rows.Add("FEBS", "SCI", "4.237", "模板.docx");
                source.Rows.Add("BMC Ecology", "SCI", "2.724", "模板.docx");
                source.Rows.Add("Addiction", "SCI", "4.972", "模板.docx");
                source.Rows.Add("Experimental Physiology", "SCI", "2.818", "模板.docx");
                source.Rows.Add("Acta Zoologica", "SCI", "0.31", "模板.docx");
                source.Rows.Add("The FASEB Journal", "SCI", "5.299", "模板.docx");
                source.Rows.Add("Journal of Computer Science & Technology", "SCI", "0.643", "模板.docx");
                source.Rows.Add("Aust J Dermatol", "SCI", "1.427", "模板.docx");
                source.Rows.Add("Clinical Transplantation", "SCI", "1.844", "模板.docx");
                source.Rows.Add("Communication Theory", "其他", "-", "模板.docx");
                source.Rows.Add("journal of the American Cerramic Society", "其他", "-", "模板.docx");
                source.Rows.Add("CNS Drugs", "SCI", "4.91", "模板.docx");
                source.Rows.Add("Coloration Thechnology", "其他", "-", "模板.docx");
                source.Rows.Add("Agricultural Economics", "SCI", "1.436", "模板.docx");
                return source;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        /// <summary>
        /// 打开模板文件
        /// 先将文件复制到桌面然后再打开
        /// wuahilong
        /// 2016-10-08
        /// </summary>
        /// <param name="name"></param>
        public override void OpenTemplate(string name, string url)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\BIMT\\template\\Acta Archaeologica.docx";
                if (File.Exists(path))
                {
                    string newPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Acta Archaeologica.docx";
                    File.Copy(path, newPath,true);
                    if (File.Exists(newPath))
                    {
                        Process.Start(newPath);
                    }
                    else
                    {
                        Log4Net.LogHelper.WriteLog(typeof(Demo), "复制文件失败！");
                    }
                    
                }
                else
                {
                    Log4Net.LogHelper.WriteLog(typeof(Demo), "文件不存在！");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void OpenLink(string name)
        {
            try
            {
                System.Diagnostics.Process.Start( "http://j.bimt.com/periodical/18665.html");    
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
