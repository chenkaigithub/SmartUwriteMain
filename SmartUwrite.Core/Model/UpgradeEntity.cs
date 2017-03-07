using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.upgrade
{
    [Serializable]
    public class UpgradeEntity 
    {
        [DataMember(Name = "code", IsRequired = false, Order = 0)]
        public string code = string.Empty;
        [DataMember(Name = "msg", IsRequired = false, Order = 1)]
        public string msg = string.Empty;
        [DataMember(Name = "response", IsRequired = false, Order = 2)]
        public Response response;
    }
}
