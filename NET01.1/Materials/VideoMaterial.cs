using NET01._1.Types;
using NET01._1.Versions;
using System;

namespace NET01._1.Materials
{
    class VideoMaterial : TrainingMaterial, IVersionable
    {
        const int _VERSION_BYTES = 8;
        byte [] _version;
        string _videoUri;
        public VideoFormat Format { get; set; }
        public string VideoUri
        {
            get { return _videoUri; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new Exception("Video uri can't be empty or null");
                }
                else
                {
                    _videoUri = value;
                }
            }
        }
        public string PictureUri { get; set; }
        #region Constructors
        public VideoMaterial(string videoUri, string pictureUri, VideoFormat format)
        {
            VideoUri = videoUri;
            PictureUri = pictureUri;
            Format = format;
        }
        public VideoMaterial(string videoUri, string pictureUri, VideoFormat format, string description)
        {
            VideoUri = videoUri;
            PictureUri = pictureUri;
            Format = format;
            Description = description;
        }
        #endregion
        public byte[] GetVersion()
        {
            return _version;
        }
        public void SetVersion(byte[] version)
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
    }
}
