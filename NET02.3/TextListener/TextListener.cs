using System;
using System.IO;
using NET02._3;

namespace TextListener
{
    public class TextListener : IListener
    {
        const string DEFAULT_PATH = "TextListenerLog.txt";
        public Level Level { get; set; } = Level.DEBUG;
        public string Path { get; set; } = DEFAULT_PATH;
        public TextListener() { }
        public void Write(string message, Level level)
        {
            if(level <= Level)
            {
                using (StreamWriter writer = new StreamWriter(Path,true))
                {
                    writer.WriteLine(DateTime.Now + "|" + level.ToString() + "|" + message);
                }
            }
        }
    }
}
