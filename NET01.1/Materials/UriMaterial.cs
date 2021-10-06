using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Materials
{
    class UriMaterial : TrainingMaterial
    {
        public string Uri { get; set; }
        Types.UriFormat Format { get; set; }
        public UriMaterial(string uri, Types.UriFormat format)
        {
            if (uri == String.Empty)
                throw new Exception("Uri cannot be empty");
            else if(uri == null)
                throw new Exception("Uri cannot be empty");
            else
            {
                Uri = uri;
                Format = format;
            }
        }
        public UriMaterial(string uri, Types.UriFormat format, string description)
        {
            Uri = uri;
            Format = format;
            Description = description;
        }
        public Types.UriFormat GetUriFormat()
        {
            return Format;
        }
    }
}
