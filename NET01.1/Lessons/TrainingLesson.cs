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
        const int maxLengthDescription = 256;
        public TrainingMaterial material;
        byte[] version;
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
            if (Description == null || Description == String.Empty)
                return "Lesson don't have description";
            else
                return Description;
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
            {
                for (int i = 0; i < version.Length; i++)
                    this.version[i] = version[i];
            }
            else
                throw new Exception("Version not contain 8 byte array.");
        }
        public object Clone()
        {
            TrainingLesson newLesson = new TrainingLesson(this.material);
            newLesson.guid = this.guid;
            newLesson.version = this.version;
            newLesson.Description = this.Description;
            return newLesson;
        }
    }
}
