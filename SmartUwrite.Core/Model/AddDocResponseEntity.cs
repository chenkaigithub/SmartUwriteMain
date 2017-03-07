using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase.Doc
{
    [Serializable]
    class AddDocResponseEntity
    {
        [DataMember(Name = "meta", IsRequired = false, Order = 0)]
        AddDocMeta meta;
        [DataMember(Name = "result", IsRequired = false, Order = 1)]
        public bool result;
    }
}
