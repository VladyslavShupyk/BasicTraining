using System;

namespace NET01._1.Materials
{
    class TrainingMaterial
    {
        const int _MAX_LENGTH_DESCRIPTION = 256;
        string _description = null;
        public Guid guid { get; set; }
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
        public bool Equals(TrainingMaterial material)
        {
            return this.guid == material.guid;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is TrainingMaterial)
            {
                return Equals(obj as TrainingMaterial);
            }
            return false;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Description))
            {
                return "Material don't have description";
            }
            else
            {
                return Description;
            }
        }
    }
}
