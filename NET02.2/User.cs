using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(!String.IsNullOrEmpty(window.Top))
                {
                    outputString.Append(window.Top + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (!String.IsNullOrEmpty(window.Left))
                {
                    outputString.Append(window.Left + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (!String.IsNullOrEmpty(window.Width))
                {
                    outputString.Append(window.Width + ", ");
                }
                else
                {
                    outputString.Append("?, ");
                }
                if (!String.IsNullOrEmpty(window.Height))
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
