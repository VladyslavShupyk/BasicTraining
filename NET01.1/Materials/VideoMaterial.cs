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
        public string videoUri { get; set; }
        public string pictureUri { get; set; }
        VideoFormat format { get; set; }
        byte[] version;

        public VideoMaterial(string videoUri, string pictureUri, VideoFormat format)
        {
            this.videoUri = videoUri;
            this.pictureUri = pictureUri;
            this.format = format;
            this.version = new byte[8];
        }
        public VideoFormat GetVideoFormat()
        {
            return this.format;
        }
        public override string ToString()
        {
            return videoUri;
        }
        public byte[] GetVersion()
        {
            return this.version;
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length == 8)
                this.version = version;
        }
    }
}
