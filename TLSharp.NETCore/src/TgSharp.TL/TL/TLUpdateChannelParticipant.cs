using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1708307556)]
    public class TLUpdateChannelParticipant : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1708307556;
            }
        }

        public int Flags { get; set; }
		public int ChannelId { get; set; }
		public int Date { get; set; }
		public int UserId { get; set; }
		public TLAbsChannelParticipant PrevParticipant { get; set; }
		public TLAbsChannelParticipant NewParticipant { get; set; }
		public int Qts { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();ChannelId = br.ReadInt32();
			Date = br.ReadInt32();
			UserId = br.ReadInt32();
			if ((Flags & 2) != 0)
				PrevParticipant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				NewParticipant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
			Qts = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChannelId);
			bw.Write(Date);
			bw.Write(UserId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(PrevParticipant, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NewParticipant, bw);
			bw.Write(Qts);
			
        }
    }
}