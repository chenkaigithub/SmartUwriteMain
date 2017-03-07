using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase.Dao
{
    [Serializable]
    class AddCategoryResponseEntity
    {
        [DataMember(Name = "meta", IsRequired = false, Order = 0)]
        AddCategoryMeta meta;
        [DataMember(Name = "result", IsRequired = false, Order = 0)]
        public bool result;
    }
}
