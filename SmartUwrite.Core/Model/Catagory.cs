using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase
{
    [Serializable]
    class Category
    {
        [DataMember(Name = "categoryId", IsRequired = false, Order = 1)]
        public string categoryId = string.Empty;
        [DataMember(Name = "category", IsRequired = false, Order = 0)]
        public string category = string.Empty;
    }
}
