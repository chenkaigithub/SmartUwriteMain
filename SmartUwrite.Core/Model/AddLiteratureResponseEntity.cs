using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.DocDatabase
{
    [Serializable]
    class AddLiteratureResponseEntity
    {
        [DataMember(Name = "meta", IsRequired = false, Order = 0)]
        public LiteratureResponseMeta meta;
        [DataMember(Name = "result", IsRequired = false, Order = 1)]
        //public List<Quotation> result = new List<Quotation>();
        public string result;
    }
}
