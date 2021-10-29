using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using NLog;

namespace NET02._4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!CheckMonitorExist())
            {
                try
                {
                    Monitor monitor = new Monitor();
                    string path = @"..\..\..\Configuration/site.xml";
                    monitor.SetSettingByXml(path);
                    monitor.Start();
                    monitor.StartFileSystemWatch(path);
                    Console.ReadKey();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadKey();
                }
            }
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
