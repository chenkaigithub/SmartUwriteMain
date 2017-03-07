using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BIMT.Util.Configuration
{
    public class ConfigurationHelper
    {
        /// <summary>
        /// 获取节点设置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                string value = config.AppSettings.Settings[key].Value;
                return value;
            }
            throw new Exception(string.Format("key:{0} not exist", key));
        }

        public static void SetConfig(string key, string value)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            string _value = string.Empty;
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
