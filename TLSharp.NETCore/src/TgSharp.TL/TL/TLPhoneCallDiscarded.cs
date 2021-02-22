using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1355435489)]
    public class TLPhoneCallDiscarded : TLAbsPhoneCall
    {
        public override int Constructor
        {
            get
            {
                return 1355435489;
            }
        }

        public int Flags { get; set; }
		public bool NeedRating { get; set; }
		public bool NeedDebug { get; set; }
		public bool Video { get; set; }
		public long Id { get; set; }
		public TLAbsPhoneCallDiscardReason Reason { get; set; }
		public int Duration { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 0) != 0)
				NeedRating = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				NeedDebug = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Video = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt64();
			if ((Flags & 2) != 0)
				Reason = (TLAbsPhoneCallDiscardReason)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Duration = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(NeedRating, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(NeedDebug, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			bw.Write(Id);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Reason, bw);
			if ((Flags & 3) != 0)
	bw.Write(Duration);
			
        }
    }
}