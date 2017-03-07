using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase
{
    [Serializable]
    class CatagoryResponseEntity
    {
        [DataMember(Name = "meta", IsRequired = false, Order = 0)]
        public Meta meta = null;
        [DataMember(Name = "categoryList", IsRequired = false, Order = 0)]
        public List<Category> result = new List<Category>();
    }
}
