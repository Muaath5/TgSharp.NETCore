using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2132731265)]
    public class TLMessageActionPhoneCall : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -2132731265;
            }
        }

        public int Flags { get; set; }
		public bool Video { get; set; }
		public long CallId { get; set; }
		public TLAbsPhoneCallDiscardReason Reason { get; set; }
		public int Duration { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 0) != 0)
				Video = (bool)ObjectUtils.DeserializeObject(br);
			CallId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Reason = (TLAbsPhoneCallDiscardReason)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Duration = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			bw.Write(CallId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Reason, bw);
			if ((Flags & 3) != 0)
	bw.Write(Duration);
			
        }
    }
}