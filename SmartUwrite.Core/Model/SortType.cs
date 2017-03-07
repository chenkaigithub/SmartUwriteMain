using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    public class SortType
    {
        [DataMember(Name = "property", IsRequired = false, Order = 0)]
        public string property = "Time";
        [DataMember(Name = "direction", IsRequired = false, Order = 1)]
        public string direction = "DESC";

        public SortType() { }

        public SortType(string property, string direction)
        {
            this.property = property;
            this.direction = direction;
        }
    }
}
