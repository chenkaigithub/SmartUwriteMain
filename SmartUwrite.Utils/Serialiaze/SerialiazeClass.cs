using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BIMT.Util.Serialiaze
{
    public class SerialiazeClass
    {
        public static string Serialiaze(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
