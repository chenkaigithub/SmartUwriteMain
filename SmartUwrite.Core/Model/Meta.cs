using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase
{
    [Serializable]
    class Meta
    {
        [DataMember(Name = "userId", IsRequired = false, Order = 0)]
        string userId = string.Empty;
        [DataMember(Name = "count", IsRequired = false, Order = 0)]
        string count = string.Empty;
    }
}
