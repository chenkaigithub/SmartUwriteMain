using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BIMTClassLibrary
{
    public class DocumentSearchEntity : BasePostEntity
    {
        [DataMember(Name = "sorting", IsRequired = false, Order = 0)]
        public List<SortType> sorting = null;
        [DataMember(Name = "paging", IsRequired = false, Order = 0)]
        public PageInfo paging = null;
        [DataMember(Name = "conditions", IsRequired = false, Order = 0)]
        public List<Condition> conditions = null;

        public DocumentSearchEntity() { }

        public DocumentSearchEntity(List<SortType> sorting, PageInfo paging, List<Condition> conditions)
        {
            try
            {
                this.sorting = sorting;
                this.paging = paging;
                this.conditions = conditions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }
}
