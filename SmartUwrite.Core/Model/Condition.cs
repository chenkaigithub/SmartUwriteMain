using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    public class Condition
    {
        [DataMember(Name = "oper", IsRequired = false, Order = 0)]
        public string oper = string.Empty;
        [DataMember(Name = "key", IsRequired = false, Order = 1)]
        public string key = string.Empty;
        [DataMember(Name = "type", IsRequired = false, Order = 2)]
        public string type = string.Empty;

        public Condition() { }

        public Condition(string oper, string key, string type)
        {
            try
            {
                this.oper = oper;
                this.key = key;
                this.type = type;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
