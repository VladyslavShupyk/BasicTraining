using System;

namespace NET01._1.Materials
{
    class TextMaterial : TrainingMaterial
    {
        const int _MAX_TEXT_LENGTH = 10000;
        string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new Exception($"The text can't be empty or null");
                }
                if (value.Length <= _MAX_TEXT_LENGTH)
                {
                    _text = value;
                }
                else
                {
                    throw new Exception($"The text can contain up to {_MAX_TEXT_LENGTH} characters");
                }
            }
        }
        #region Constructors
        public TextMaterial(string text)
        {
            Text = text;
        }
        public TextMaterial(string text, string description)
        {
            Description = description;
            Text = text;
        }
        #endregion
    }
}
