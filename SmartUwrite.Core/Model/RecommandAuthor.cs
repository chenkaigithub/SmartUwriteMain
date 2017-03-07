using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BIMTClassLibrary
{
    [DataContract(Name = "Author", Namespace = "BIMTClassLibrary")]
    public class Author
    {
        [DataMember(Name = "organizations", IsRequired = false, Order = 0)]
        public string organizations = string.Empty;
        [DataMember(Name = "addresses", IsRequired = false, Order = 1)]
        public string addresses = string.Empty;
        [DataMember(Name = "name", IsRequired = false, Order = 2)]
        public Name name;

        public override string ToString()
        {
            if (name.fore.Trim() != string.Empty.Trim() && name.last.Trim() != string.Empty)
            {
                return name.last.Trim() + name.fore.Trim();
            }
            else
            {
                return name.full.Trim();
            }
        }

        /// <summary>
        /// 判断作者是否为中文姓名，包含中文字符即判定为中文
        /// wuhailong
        /// 2016-11-07
        /// </summary>
        /// <returns></returns>
        public bool IsCN()
        {
            string text = this.ToString();
            if (Regex.IsMatch(text, @"[\u4e00-\u9fa5]"))
                return true;
            return false;
        }

        public Author(Name myname, string organizations, string addresses)
        {
            this.name = myname;
            this.organizations = organizations;
            this.addresses = addresses;

        }

        public Author()
        {
        }

        public Author(Name name)
        {
            // TODO: Complete member initialization
            this.name = name;
        }
    }

    [DataContract(Name = "Name", Namespace = "BIMTClassLibrary")]
    public class Name
    {
        [DataMember(Name = "last", IsRequired = false, Order = 0)]
        public string last;
        [DataMember(Name = "fore", IsRequired = false, Order = 1)]
        public string fore;
        [DataMember(Name = "full", IsRequired = false, Order = 2)]
        public string full;
        [DataMember(Name = "cn", IsRequired = false, Order = 3)]
        public string cn;
        [DataMember(Name = "en", IsRequired = false, Order = 4)]
        public string en;
        public Name()
        { }
        public Name(string last, string fore, string full)
        {
            this.last = last;
            this.fore = fore;
            this.full = full;
        }
    }
}
