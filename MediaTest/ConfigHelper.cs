using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MediaTest
{
    class ConfigHelper
    {
        //配置文件名
        private const string CONFIG_FILE = "MediaTest.exe.config";

        public static string getValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings.GetValues(key)[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
            //string path = null;
            //if (_configuration == null)
            //{
            //    //path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("./"), CONFIG_FILE);
            //    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            //    map.ExeConfigFilename = CONFIG_FILE;
            //    ConfigurationManager.AppSettings[key].ToString();

            //    _configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            //}
            //return _configuration.AppSettings.Settings[key].Value;
        }
    }
}
