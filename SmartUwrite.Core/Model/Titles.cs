using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    [DataContract(Namespace = "http://coderzh.cnblogs.com")]
    public class Titles
    {
        [DataMember(Order = 0)]
        public string cn;
        [DataMember(Order = 1)]
        public string en;
    }
}
