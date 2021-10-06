using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Materials
{
    class TrainingMaterial
    {
        const int maxLengthDescription = 256;
        public Guid guid { get; set; }
        string description = null;
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= maxLengthDescription)
                    description = value;
                else
                    throw new Exception("The description can contain up to 256 characters");
            }
        }
        public bool Equals(TrainingMaterial material)
        {
            if (this.guid == material.guid)
                return true;
            return false;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj);
        }
        public override string ToString()
        {
            if (Description == null || Description == String.Empty)
                return "Material don't have description";
            else
                return Description;
        }
    }

}
