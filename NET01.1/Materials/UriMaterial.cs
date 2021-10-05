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
        UriFormat Format { get; set; }
        public UriMaterial(string Uri, UriFormat Format)
        {
            this.Uri = Uri;
            this.Format = Format;
        }
        public UriFormat GetUriFormat()
        {
            return this.Format;
        }
        public override string ToString()
        {
            return Uri;
        }
    }
}
