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
        string text { get; set; }
        public TextMaterial(string text)
        {
            if (text.Length <= maxLengthText)
                this.text = text;
            else
                this.text = text.Substring(0, maxLengthText);
        }
        public override string ToString()
        {
            return text;
        }
    }
}
