using System;
using System.Collections.Generic;
using System.Xml;

namespace NET02._4
{
    class MonitorSetting
    {
        public List<SiteData> siteData;
        public MonitorSetting()
        {
            siteData = new List<SiteData>();
        }
        public void SetSettingByXml(XmlDocument document)
        {
            int interval = 0;
            int serverResponseTime = 0;
            string siteUrl = String.Empty;
            string adminEmail = String.Empty;
            XmlElement rootNode = document.DocumentElement;
            try
            {
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
                    siteData.Add(new SiteData(interval, serverResponseTime, siteUrl, adminEmail));
                }
            }
            catch (Exception excaption)
            {
                throw new Exception(excaption.Message);
            }
        }
    }
}
