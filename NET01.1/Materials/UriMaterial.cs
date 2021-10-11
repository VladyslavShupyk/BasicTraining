using System;

namespace NET01._1.Materials
{
    class UriMaterial : TrainingMaterial
    {
        string _uri;
        public string Uri
        {
            get { return _uri; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Uri can't be empty or null");
                }
                else
                {
                    _uri = value;
                }
            }
        }
        public Types.UriFormat Format { get; set; }
        #region Constructors
        public UriMaterial(string uri, Types.UriFormat format)
        {
            Uri = uri;
            Format = format;
        }
        public UriMaterial(string uri, Types.UriFormat format, string description)
        {
            Uri = uri;
            Format = format;
            Description = description;
        }
        #endregion
    }
}
