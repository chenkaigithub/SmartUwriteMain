using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMTClassLibrary.WordTemplate
{
    class BaseTemplate:ITemplate, IOpenTemplatable, ILinkable
    {
        public DataTable source = new DataTable();
        public BaseTemplate()
        {

            source.Columns.Add("name");
            source.Columns.Add("level");
            source.Columns.Add("yxyz");
            source.Columns.Add("templateUrl");
        }

        public virtual DataTable GetSource()
        {
            throw new NotImplementedException();
        }

        public virtual void OpenTemplate(string name, string url)
        {
            throw new NotImplementedException();
        }

        public virtual void OpenLink(string name)
        {
            throw new NotImplementedException();
        }
    }
}
