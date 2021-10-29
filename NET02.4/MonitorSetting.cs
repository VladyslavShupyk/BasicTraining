using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using NLog;

namespace NET02._4
{
    class MonitorSetting
    {
        private static Logger _logger = LogManager.GetLogger("myRules");
        public List<SiteInfo> siteInfo;
        public MonitorSetting()
        {
            siteInfo = new List<SiteInfo>();
        }
        public void SetSettingByXml(string path)
        {
            XmlDocument document = new XmlDocument();
            while (!IsFileReady(path)) { Thread.Sleep(1000); }
            document.Load(path);
            int interval = 0;
            int serverResponseTime = 0;
            string siteUrl = String.Empty;
            string adminEmail = String.Empty;
            XmlElement rootNode = document.DocumentElement;
            foreach (XmlNode node in rootNode)
            {
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "interval")
                        interval = Convert.ToInt32(childNode.InnerText);
                    if (childNode.Name == "maxResponseTime")
                        serverResponseTime = Convert.ToInt32(childNode.InnerText);
                    if (childNode.Name == "url")
                        siteUrl = childNode.InnerText;
                    if (childNode.Name == "adminEmail")
                        adminEmail = childNode.InnerText;
                }
                siteInfo.Add(new SiteInfo(interval, serverResponseTime, siteUrl, adminEmail));
            }
        }
        public static bool IsFileReady(string filename)
        {
            try
            {
                FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                inputStream.Close();
                    return true;
            }
            catch
            {
                _logger.Warn("Can't open file configurating");
                return false;
            }
        }
    }
}
