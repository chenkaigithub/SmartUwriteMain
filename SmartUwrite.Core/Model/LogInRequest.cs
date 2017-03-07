using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.LogIn
{
    [DataContract]
    class LogInRequest : BaseResponseEntity
    {
        [DataMember]
        private string username;
        [DataMember]
        private string password;
        [DataMember]
        private string timestamp;
    }
}
