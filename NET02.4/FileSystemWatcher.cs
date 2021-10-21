using System.Threading;
using System.Xml;

namespace NET02._4
{
    class FileSystemWatcher
    {
        public delegate void Change(Monitor monitor, XmlDocument document);
        public event Change ChangeConfigutarion;
        const int DEFAULT_INTERVAL = 1;
        readonly int _interval;
        XmlDocument _document;
        Monitor _monitor;
        string _path;
        public FileSystemWatcher(Monitor monitor, XmlDocument document, string path, int intervalSeconds = DEFAULT_INTERVAL)
        {
            _monitor = monitor;
            _document = document;
            _path = path;
            _interval = intervalSeconds;
        }
        public void Start()
        {
            XmlDocument document = new XmlDocument();
            for (;;)
            {
                document.Load(_path);
                if(document.InnerText != _document.InnerText)
                {
                    _document.Load(_path);
                    ChangeConfigutarion.Invoke(_monitor, _document);
                }
                Thread.Sleep(_interval*1000);
            }
        }
    }
}
