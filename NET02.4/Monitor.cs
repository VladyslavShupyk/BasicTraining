using NLog;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NET02._4
{
    class Monitor
    {
        private string _path = @"..\..\..\Configuration/site.xml";
        private List<Pingger> _pingers;
        private MonitorSetting _settings;
        private FileSystemWatcher _fsw;
        private Logger logger = LogManager.GetLogger("myRules");
        public Monitor()
        {
            _settings = new MonitorSetting();
            _pingers = new List<Pingger>();
        }
        public void SetSettingByXml(string path)
        {
            _settings.SetSettingByXml(path);
        }
        public void Start()
        {
            foreach(SiteInfo data in _settings.siteInfo)
            {
                Pingger pingger = new Pingger(data.PingInterval, data.ServerResponseTime, data.SiteUrl, data.AdminEmail);
                _pingers.Add(pingger);
                pingger.StartPing();
            }
        }
        public void Stop()
        {
            foreach (Pingger pingger in _pingers)
            {
                pingger.cancelTokenSource.Cancel();
            }
            _pingers.Clear();
            _settings.siteInfo.Clear();
        }
        public void StartFileSystemWatch(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);
            string filePath = Path.GetFileName(path);
            _fsw = new FileSystemWatcher(directoryPath, filePath);
            _fsw.Changed += Fsw_Changed;
            _fsw.EnableRaisingEvents = true;
        }
        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                _fsw.EnableRaisingEvents = false;
                logger.Info("Configuration changed");
                Stop();
                Task.WaitAll();
                _settings.SetSettingByXml(_path);
                Start();
            }
            finally
            {
                _fsw.EnableRaisingEvents = true;
            }
        }
    }
}
