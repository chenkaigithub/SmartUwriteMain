using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMTClassLibrary.WordTemplate
{
    interface ITemplate
    {
        DataTable GetSource();
    }
}
