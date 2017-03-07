using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary
{
    public class ReviewerInfo
    {
        [DataMember(Name = "author", IsRequired = false, Order = 0)]
        public string author = string.Empty;
        [DataMember(Name = "email", IsRequired = false, Order = 1)]
        public string email = string.Empty;
        [DataMember(Name = "organization", IsRequired = false, Order = 2)]
        public string organization = string.Empty;
        [DataMember(Name = "status", IsRequired = false, Order = 3)]
        public string status = string.Empty;

        public ReviewerInfo() { }

        public ReviewerInfo(string author, string email, string organization, string status)
        {
            try
            {
                this.author = author;
                this.email = email;
                this.organization = organization;
                this.status = status;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
