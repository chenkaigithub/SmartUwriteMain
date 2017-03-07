using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BIMTClassLibrary.style
{
    [DataContract]
    class AddStyleEntity : BaseResponseEntity
    {
        [DataMember]
        private string name;
        [DataMember]
        private string refJournalId;
        [DataMember]
        private string descptn;
        [DataMember]
        private object formats;
    }
}
