using NET01._1.Types;
using NET01._1.Versions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Materials
{
    class VideoMaterial : TrainingMaterial, IVersionable
    {
        byte[] version;
        public string VideoUri { get; set; }
        public string PictureUri { get; set; }
        VideoFormat Format { get; set; }
        public VideoMaterial(string videoUri, string pictureUri, VideoFormat format)
        {
            if (videoUri == String.Empty)
                throw new Exception("Video uri cannot be empty");
            else if (videoUri == null)
                throw new Exception("Video uri cannot be empty");
            else
            {
                VideoUri = videoUri;
                PictureUri = pictureUri;
                Format = format;
                version = new byte[8];
            }
        }
        public VideoMaterial(string videoUri, string pictureUri, VideoFormat format, string description)
        {
            VideoUri = videoUri;
            PictureUri = pictureUri;
            Format = format;
            version = new byte[8];
            Description = description;
        }
        public VideoFormat GetVideoFormat()
        {
            return Format;
        }
        public byte[] GetVersion()
        {
            return this.version;
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length == 8)
            {
                for (int i = 0; i < version.Length; i++)
                    this.version[i] = version[i];
            }
            else
                throw new Exception("Version not contain 8 byte array.");
        }
    }
}
