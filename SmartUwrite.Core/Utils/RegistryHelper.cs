using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace BIMTUtil
{
    /// <summary>
    /// 注册表帮助类
    /// 2016-05-20
    /// wuhailong
    /// </summary>
    public class RegistryHelper
    {
        /// <summary>
        /// 清除bimt软件的注册表项
        /// 2016-05-20
        /// wuhailong
        /// </summary>
        public static void ClearBIMTRegistry()
        {
            try
            {
                string[] subkeyNames;
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software = key.OpenSubKey(@"Software\Microsoft\Office\Word\Addins");
                subkeyNames = software.GetSubKeyNames();
                //取得该项下所有子项的名称的序列，并传递给预定的数组中  
                foreach (string keyName in subkeyNames)
                //遍历整个数组  
                {
                    if (keyName.Contains("BIMT"))
                    //判断子项的名称  
                    {
                        string _strKey = @"Software\Microsoft\Office\Word\Addins" +"\\"+ keyName;
                        key.DeleteSubKey(_strKey, true); //该方法无返回值，直接调用即可
                        key.Close();
                    }
                }
               
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(RegistryHelper), ex);
            }
        }
    }
}
