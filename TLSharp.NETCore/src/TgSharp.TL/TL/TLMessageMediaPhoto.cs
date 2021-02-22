using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1766936791)]
    public class TLMessageMediaPhoto : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return 1766936791;
            }
        }

        public int Flags { get; set; }
		public TLAbsPhoto Photo { get; set; }
		public int TtlSeconds { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				TtlSeconds = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			if ((Flags & 0) != 0)
	bw.Write(TtlSeconds);
			
        }
    }
}