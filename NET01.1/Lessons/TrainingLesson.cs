using NET01._1.Formats;
using NET01._1.Materials;
using NET01._1.Versions;
using System;

namespace NET01._1.Lessons
{
    class TrainingLesson : IVersionable , ICloneable
    {
        const int _MAX_LENGTH_DESCRIPTION = 256;
        const int _VERSION_BYTES = 8;
        string _description;
        public Guid guid { get; set; }
        byte [] _version;
        public TrainingMaterial [] materials;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length <= _MAX_LENGTH_DESCRIPTION || String.IsNullOrEmpty(value))
                {
                    _description = value;
                }
                else
                {
                    throw new Exception($"The description can contain up to {_MAX_LENGTH_DESCRIPTION} characters");
                }  
            }
        }
        #region Constructors
        public TrainingLesson(params TrainingMaterial[] materials)
        {
            Description = String.Empty;
            this.materials = new TrainingMaterial[materials.Length];
            Array.Copy(materials, this.materials, materials.Length);
            guid = Guid.Empty;
            _version = new byte[_VERSION_BYTES];
        }
        public TrainingLesson(string description, params TrainingMaterial[] materials)
        {
            Description = description;
            this.materials = new TrainingMaterial[materials.Length];
            Array.Copy(materials, this.materials, materials.Length);
            guid = Guid.Empty;
            _version = new byte[_VERSION_BYTES];
        }
        #endregion
        public TypeLesson GetLessonType()
        {
            for (int i = 0; i < materials.Length; i++)
            {
                if(materials[i].GetType() == typeof(VideoMaterial))
                {
                    return TypeLesson.VideoLesson;
                }
            }
            return TypeLesson.TextLesson;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Description))
            {
                return "Lesson don't have description";
            }
            else
            {
                return Description;
            }  
        }
        public bool Equals(TrainingLesson lesson)
        {
            return this.guid == lesson.guid;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is TrainingLesson)
            {
                return Equals(obj as TrainingLesson);
            }
            return false;
        }

        public byte [] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte [] version)
        {
            if (version.Length == _VERSION_BYTES)
            {
                Array.Copy(version, this._version, _VERSION_BYTES);
            }
            else
            {
                throw new Exception($"Version not contain {_VERSION_BYTES} byte array.");
            }
        }
        public object Clone()
        {
            TrainingMaterial [] newMaterials = new TrainingMaterial[materials.Length];
            for (int i = 0; i < newMaterials.Length; i++)
            {
                if (materials[i].GetType() == typeof(TextMaterial))
                {
                    TextMaterial material = (TextMaterial)materials[i];
                    newMaterials[i] = new TextMaterial(material.Text,material.Description);
                    newMaterials[i].guid = material.guid;
                }
                else if (materials[i].GetType() == typeof(VideoMaterial))
                {
                    VideoMaterial material = (VideoMaterial)materials[i];
                    newMaterials[i] = new VideoMaterial(material.VideoUri,material.PictureUri,material.Format,material.Description);
                    newMaterials[i].guid = material.guid;
                }
                else
                {
                    UriMaterial material = (UriMaterial)materials[i];
                    newMaterials[i] = new UriMaterial(material.Uri, material.Format, material.Description);
                    newMaterials[i].guid = material.guid;
                }
            }
            byte[] newVersion = new byte[_VERSION_BYTES];
            Array.Copy(_version, newVersion, _VERSION_BYTES);
            return new TrainingLesson
            {
                Description = this.Description,
                guid = this.guid,
                _version = newVersion,
                materials = newMaterials
            };
        }
    }
}
