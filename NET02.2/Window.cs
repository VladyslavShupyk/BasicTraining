using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET02._2
{
    class Window
    {
        public string Title { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public Window(string title, string top, string left, string width, string height)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
}
