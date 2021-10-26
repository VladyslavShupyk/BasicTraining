using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NET02._3
{
    class LoggerSetting
    {
        const string PATH_APPSETTINGS = @"..\..\..\Configuration/appsettings.json";
        public string Name { get; set; } = "Default Name";
        public Level LoggerLevel { get; set; } = Level.DEBUG;

        public List<IListener> listeners;
        public LoggerSetting() { listeners = new List<IListener>(); }
        public void GetSettingFromJson(string path = PATH_APPSETTINGS)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                var logerData = JsonConvert.DeserializeObject<LogerDataJson>(jsonString);
                Name = logerData.Name;
                switch (logerData.Level)
                {
                    case "Debug": { LoggerLevel = Level.DEBUG; } break;
                    case "Trace": { LoggerLevel = Level.TRACE; } break;
                    case "Info": { LoggerLevel = Level.INFO; } break;
                    case "Warn": { LoggerLevel = Level.WARN; } break;
                    case "Error": { LoggerLevel = Level.ERROR; } break;
                    case "Fatal": { LoggerLevel = Level.FATAL; } break;
                }
                string Path = String.Empty;
                Level level = Level.DEBUG;
                foreach (var item in logerData.Listeners)
                {
                    Path = item.Path;
                    switch (item.Level)
                    {
                        case "Debug": { level = Level.DEBUG; } break;
                        case "Trace": { level = Level.TRACE; } break;
                        case "Info": { level = Level.INFO; } break;
                        case "Warn": { level = Level.WARN; } break;
                        case "Error": { level = Level.ERROR; } break;
                        case "Fatal": { level = Level.FATAL; } break;
                    }
                    if (item.Type == ListenerType.TextListener.ToString())
                    {
                        Assembly assembly = Assembly.LoadFrom("TextListener.dll");
                        Type type = assembly.GetType("TextListener.TextListener", true, true);
                        var typeInstance = Activator.CreateInstance(type);
                        IListener listener = (IListener)typeInstance;
                        listener.Path = Path;
                        listener.Level = level;
                        listeners.Add(listener);
                    }
                    else if (item.Type == ListenerType.WordListener.ToString())
                    {
                        Assembly assembly = Assembly.LoadFrom("WordListener.dll");
                        Type type = assembly.GetType("WordListener.WordListener", true, true);
                        var typeInstance = Activator.CreateInstance(type);
                        IListener listener = (IListener)typeInstance;
                        listener.Path = Path;
                        listener.Level = level;
                        listeners.Add(listener);
                    }
                    else if (item.Type == ListenerType.EventLogListener.ToString())
                    {
                        Assembly assembly = Assembly.LoadFrom("EventLogListener.dll");
                        Type type = assembly.GetType("EventLogListener.EventLogListener", true, true);
                        var typeInstance = Activator.CreateInstance(type);
                        IListener listener = (IListener)typeInstance;
                        listener.Path = Path;
                        listener.Level = level;
                        listeners.Add(listener);
                    }
                }
            }
            catch (Exception excaption)
            {
                throw new Exception(excaption.Message);
            }
        }
    }
}
