using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Materials
{
    class TextMaterial : TrainingMaterial
    {
        const int maxLengthText = 10000;
        string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (value.Length <= maxLengthText)
                    text = value;
                else
                    throw new Exception("The text can contain up to 10,000 characters.");
            }
        }
        public TextMaterial(string text)
        {
            Text = text;
        }
        public TextMaterial(string text, string description)
        {
            Description = description;
            Text = text;
        }
    }
}
