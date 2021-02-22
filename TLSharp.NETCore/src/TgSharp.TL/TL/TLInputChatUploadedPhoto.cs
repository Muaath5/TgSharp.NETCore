using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-968723890)]
    public class TLInputChatUploadedPhoto : TLAbsInputChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return -968723890;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputFile File { get; set; }
		public TLAbsInputFile Video { get; set; }
		public double VideoStartTs { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Video = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				VideoStartTs = br.ReadDouble();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(File, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			if ((Flags & 0) != 0)
	bw.Write(VideoStartTs);
			
        }
    }
}