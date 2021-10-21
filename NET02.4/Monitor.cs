using System.Collections.Generic;
using System.Xml;

namespace NET02._4
{
    class Monitor
    {
        List<Pingger> _pingers;
        MonitorSetting _settings;
        public Monitor()
        {
            _settings = new MonitorSetting();
            _pingers = new List<Pingger>();
        }
        public void SetSettingByXml(XmlDocument document)
        {
            _settings.SetSettingByXml(document);
        }
        public void Start()
        {
            foreach(SiteData data in _settings.siteData)
            {
                Pingger pingger = new Pingger(data.PingInterval, data.ServerResponseTime, data.SiteUrl, data.AdminEmail);
                _pingers.Add(pingger);
                pingger.StartPing();
            }
        }
        public void Stop()
        {
            foreach(Pingger pingger in _pingers)
            {
                    pingger.cancelTokenSource.Cancel();
            }
            _pingers.Clear();
            _settings.siteData.Clear();
        }
    }
}
