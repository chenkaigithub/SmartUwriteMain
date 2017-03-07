using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 无数据表面类型字段
    /// 例如 DOI: Doi:
    /// </summary>
    class EmptyField : BaseField, IField
    {
        string fieldName = string.Empty;
        public EmptyField() { }

        public EmptyField(string fieldName) {
            this.fieldName = fieldName;
        }
        public string GetValue()
        {
            return fieldName;
        }
    }
}
