using System;

namespace NET02._3
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerSetting logSetting = new LoggerSetting();
            logSetting.GetSettingFromJson();
            Logger logger = new Logger(logSetting);
            logger.Debug("Hello from app:D");
            logger.Error("ErrorMessage");
            Student student = new Student { Name = "Vladyslav", Surname = "Shupyk", Age = 23 };
            logger.Track(student);
        }
    }
}
