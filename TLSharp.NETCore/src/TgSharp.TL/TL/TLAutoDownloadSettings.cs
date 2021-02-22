using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-532532493)]
    public class TLAutoDownloadSettings : TLAbsAutoDownloadSettings
    {
        public override int Constructor
        {
            get
            {
                return -532532493;
            }
        }

        public int Flags { get; set; }
		public bool Disabled { get; set; }
		public bool VideoPreloadLarge { get; set; }
		public bool AudioPreloadNext { get; set; }
		public bool PhonecallsLessData { get; set; }
		public int PhotoSizeMax { get; set; }
		public int VideoSizeMax { get; set; }
		public int FileSizeMax { get; set; }
		public int VideoUploadMaxbitrate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Disabled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				VideoPreloadLarge = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				AudioPreloadNext = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				PhonecallsLessData = (bool)ObjectUtils.DeserializeObject(br);
			PhotoSizeMax = br.ReadInt32();
			VideoSizeMax = br.ReadInt32();
			FileSizeMax = br.ReadInt32();
			VideoUploadMaxbitrate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Disabled, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(VideoPreloadLarge, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(AudioPreloadNext, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(PhonecallsLessData, bw);
			bw.Write(PhotoSizeMax);
			bw.Write(VideoSizeMax);
			bw.Write(FileSizeMax);
			bw.Write(VideoUploadMaxbitrate);
			
        }
    }
}