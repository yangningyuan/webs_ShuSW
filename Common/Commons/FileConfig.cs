
using System.Configuration;
using System.Xml;

namespace Common.Commons
{
    /// <summary>
    /// 对config文件的读写操作
    /// </summary>
    public class FileConfig
    {
        private static string configPath = "";//Commons.Systems.GetAppPath() + "*.Config";

        public static string GetConfigValue(string key)
        {
            //要使用ConfigurationManager，需添加对 System.Configuration.dll 文件的引用
            //if (ConfigurationManager.ConnectionStrings[key] != null) 
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetConfigValue(string key, string value)
        {
            bool isModified = false;
            foreach (string keyExist in ConfigurationManager.AppSettings)
            {
                if (keyExist == key)
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove(key);
            }
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// 方法二：保存AppSettings,注释内容不会丢失
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetXMLValue(string key, string value)
        {
            //验证key value
            //To Do

            XmlDocument xml = new XmlDocument();
            xml.Load(configPath);

            XmlNodeList nodeList = xml.GetElementsByTagName("appSettings");

            if (nodeList != null)
            {
                if (nodeList.Count >= 1)
                {
                    XmlNode node = nodeList[0];
                    foreach (XmlNode item in node)
                    {
                        if (item.NodeType == XmlNodeType.Comment)
                        {
                            
                            continue;
                        }

                        XmlAttribute xaKey = item.Attributes["key"];
                        XmlAttribute xaValue = item.Attributes["value"];


                        if (xaKey != null && xaValue != null && xaKey.Value.Equals(key))
                        {
                            xaValue.Value = value;
                        }
                    }
                }
            }
            xml.Save(configPath);
        }
    }
}
