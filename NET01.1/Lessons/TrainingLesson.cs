using NET01._1.Formats;
using NET01._1.Materials;
using NET01._1.Versions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Lessons
{
    class TrainingLesson : IVersionable , ICloneable
    {
        public TrainingMaterial material;
        public byte[] version;
        public Guid guid;
        public TrainingLesson(TrainingMaterial material)
        {
            guid = Guid.Empty;
            this.material = material;
            version = new byte[8]; 
        }
        public TypeOfLesson GetTypeOfLesson()
        {
            if (this.material.GetType() == typeof(VideoMaterial))
                return TypeOfLesson.VideoLesson;
            return TypeOfLesson.TextLesson;
        }
        public override string ToString()
        {
            return material.ToString();
        }
        public bool Equals(TrainingLesson lesson)
        {
            if (this.guid == lesson.guid)
                return true;
            return false;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj);
        }

        public byte [] GetVersion()
        {
            return this.version;
        }

        public void SetVersion(byte [] version)
        {
            if (version.Length == 8)
                this.version = version;
        }
        public object Clone()
        {
            TrainingLesson newLesson = new TrainingLesson(this.material);
            newLesson.guid = this.guid;
            newLesson.version = this.version;
            return newLesson;
        }
    }
}
