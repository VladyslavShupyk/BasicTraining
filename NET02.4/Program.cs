using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using NLog;

namespace NET02._4
{
    class Program
    {
        static Logger logger = NLog.LogManager.GetLogger("myRules");
        static void Main(string[] args)
        {
            if(!CheckMonitorExist())
            {
                try
                {
                    Monitor monitor = new Monitor();
                    XmlDocument document = new XmlDocument();
                    string path = @"..\..\..\Configuration/site.xml";
                    document.Load(path);
                    monitor.SetSettingByXml(document);
                    monitor.Start();
                    FileSystemWatcher fileWatcher = new FileSystemWatcher(monitor,document, path);
                    fileWatcher.ChangeConfigutarion += FileWatcher_ChangeConfigutarion;
                    fileWatcher.Start();
                }
                catch (Exception exception) 
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadKey();
                }
            }
        }
        private static void FileWatcher_ChangeConfigutarion(Monitor monitor, XmlDocument document)
        {
            logger.Info("Configuration changed");
            monitor.Stop();
            Task.WaitAll();
            monitor.SetSettingByXml(document);
            monitor.Start();
        }
        private static bool CheckMonitorExist()
        {
            Process[] processCollection = Process.GetProcesses();
            int countProcesses = 0;
            foreach (Process p in processCollection)
            {
                if(p.ProcessName == Assembly.GetEntryAssembly().GetName().Name)
                {
                    countProcesses++;
                }
            }
            if (countProcesses == 1)
                return false;
            return true;
        }
    }
}
