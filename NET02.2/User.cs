using System;
using System.Collections.Generic;
using System.Text;

namespace NET02._2
{
    class User
    {
        public string Name { get; set; }
        public List<Window> windows;
        public User(string name)
        {
            Name = name;
            windows = new List<Window>();
        }
        public void AddWindow(Window window)
        {
            windows.Add(window);
        }
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("login : " + Name +"\n");
            foreach(Window window in windows)
            {
                outputString.Append("  " + window.Title + "(");
                if(window.Top.HasValue)
                {
                    outputString.Append(window.Top + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (window.Left.HasValue)
                {
                    outputString.Append(window.Left + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (window.Width.HasValue)
                {
                    outputString.Append(window.Width + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (window.Height.HasValue)
                {
                    outputString.Append(window.Height + ")\n");
                }
                else
                {
                    outputString.Append("?)\n");
                }
            }
            return outputString.ToString();
        }
    }
}
