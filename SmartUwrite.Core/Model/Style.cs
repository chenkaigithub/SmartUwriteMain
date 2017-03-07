using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIMT.Util.Configuration;

namespace BIMTClassLibrary.EditStyle
{
    /// <summary>
    /// 单例
    /// </summary>
    public class MagazineStyle
    {
        private static readonly string DIR = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\\BIMT\\styles\\";
        private const string key = "CurrentStyle";
        private static MagazineStyle style ;
        private string id;
        private string name = ConfigurationHelper.GetConfig(key);
        private bool standard;
       

        private MagazineStyle() { }

        private MagazineStyle(string pname) {
            style = GetInstance();
            style.name = pname;
        }

        public static MagazineStyle GetInstance()
        {
            if (style == null)
            {
                style = new MagazineStyle();
            }
            return style;
        }

        public bool Standard
        {
            get { return standard; }
            set { standard = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (name!="参考文献样式")
                {
                    ConfigurationHelper.SetConfig(key, name);
                }
            }
        }
        

        public bool Exist()
        {
            if (Name == string.Empty)
            {
                return false;
            }
            DirectoryInfo theFolder = new DirectoryInfo(DIR);
            FileInfo[] fileInfo = theFolder.GetFiles();
            foreach (var item in fileInfo)
            {
                if (item.Name == name+".json")
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string GetPath()
        {
            return string.Format(DIR + "{0}.json", Name);
        }

        /// <summary>
        /// 获取样式设置的值
        /// wuhailong
        /// 2016-09-22
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return string.Empty;
        }
    }
}
