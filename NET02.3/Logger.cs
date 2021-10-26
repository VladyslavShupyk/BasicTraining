using NET02._3.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NET02._3
{
    class Logger
    {
        List<IListener> _listeners;
        public string Name { get; set; }
        public Level LoggerLevel { get; set; }
        private LoggerSetting _setting;
        public Logger()
        {
            _setting = new LoggerSetting();
            _setting.GetSettingFromJson();
            Name = _setting.Name;
            LoggerLevel = _setting.LoggerLevel;
            _listeners = _setting.listeners;
            Directory.CreateDirectory("Logs");
        }
        public Logger(LoggerSetting loggerSetting)
        {
            _setting = loggerSetting;
            Name = _setting.Name;
            LoggerLevel = _setting.LoggerLevel;
            _listeners = _setting.listeners;
            Directory.CreateDirectory("Logs");
        }
        public void Debug(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.DEBUG);
            }
        }
        public void Trace(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.TRACE);
            }
        }
        public void Info(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.INFO);
            }
        }
        public void Warn(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.WARN);
            }
        }
        public void Error(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.ERROR);
            }
        }
        public void Fatal(string message)
        {
            foreach (var item in _listeners)
            {
                item.Write(message, Level.FATAL);
            }
        }
        public void Track(object obj)
        {
            Type type = obj.GetType();
            var entity = Attribute.GetCustomAttribute(type, typeof(TrakingEntity));
            if(entity != null)
            {
                var properties = type.GetProperties();
                foreach(var item in properties)
                {
                    if(Attribute.IsDefined(item,typeof(TrackingProperty)))
                    {
                        Trace(item.Name + " = " + item.GetValue(obj).ToString());
                    }
                }
            }
        }
    }
}
