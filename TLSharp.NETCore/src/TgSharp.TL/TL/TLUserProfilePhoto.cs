using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1775479590)]
    public class TLUserProfilePhoto : TLAbsUserProfilePhoto
    {
        public override int Constructor
        {
            get
            {
                return 1775479590;
            }
        }

        public int Flags { get; set; }
		public bool HasVideo { get; set; }
		public long PhotoId { get; set; }
		public TLAbsFileLocation PhotoSmall { get; set; }
		public TLAbsFileLocation PhotoBig { get; set; }
		public int DcId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				HasVideo = (bool)ObjectUtils.DeserializeObject(br);
			PhotoId = br.ReadInt64();
			PhotoSmall = (TLAbsFileLocation)ObjectUtils.DeserializeObject(br);
			PhotoBig = (TLAbsFileLocation)ObjectUtils.DeserializeObject(br);
			DcId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(HasVideo, bw);
			bw.Write(PhotoId);
			ObjectUtils.SerializeObject(PhotoSmall, bw);
			ObjectUtils.SerializeObject(PhotoBig, bw);
			bw.Write(DcId);
			
        }
    }
}