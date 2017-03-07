using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.upgrade
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "updateVersion", IsRequired = false, Order = 1)]
        public string updateVersion;
        [DataMember(Name = "msg", IsRequired = false, Order = 1)]
        public List<string> updateInfo = new List<string>();
    }
}
