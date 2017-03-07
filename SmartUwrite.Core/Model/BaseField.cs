using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 字段父类
    /// </summary>
    public class BaseField:Quotation
    {
        public Quotation quotation = null;
        public string result = string.Empty;
        public BaseField()
        {
        }
       
        //public BaseField(Quotation quotation)
        //{
        //    this.quotation = quotation;
        //}
    }
}
