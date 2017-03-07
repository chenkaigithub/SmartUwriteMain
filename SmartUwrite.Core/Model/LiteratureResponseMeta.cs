using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase
{
    [Serializable]
    class LiteratureResponseMeta
    {
        [DataMember(Name = "count", IsRequired = false, Order = 0)]
        int count;
    }
}
