using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BIMTClassLibrary.dynamicClass
{
    public class DynamicStyle
    {
        public static object GetInstance(string json)
        {
            try
            {
                Dictionary<string, object> _dictPropertys = CommonFunction.JsonToDictionary(json);
                List<BIMTClassLibrary.dynamicClass.ClassHelper.CustPropertyInfo> _listPropertys = new List<ClassHelper.CustPropertyInfo>();
                foreach (var item in _dictPropertys.Keys)
                {
                    BIMTClassLibrary.dynamicClass.ClassHelper.CustPropertyInfo cpinfo = new ClassHelper.CustPropertyInfo("System.String", item.ToString());
                    _listPropertys.Add(cpinfo);
                }
                object _objStyle = ClassHelper.CreateInstance("StyleEntity", _listPropertys);
                return _objStyle;
            }
            catch (Exception)
            {
                throw;
            }
          
        }
    }
}
