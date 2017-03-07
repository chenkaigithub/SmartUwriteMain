using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    public class PageInfo
    {
        [DataMember(Name = "page", IsRequired = false, Order = 0)]
        public int page = 0;
        [DataMember(Name = "size", IsRequired = false, Order = 1)]
        public int size = 10;

        public PageInfo() { }

        public PageInfo(int page, int size)
        {
            this.page = page;
            this.size = size;
        }
    }
}
