using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Materials
{
    class TrainingMaterial
    {
        public Guid guid { get; set; }
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
    }

}
