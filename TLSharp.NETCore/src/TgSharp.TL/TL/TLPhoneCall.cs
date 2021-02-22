using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2025673089)]
    public class TLPhoneCall : TLAbsPhoneCall
    {
        public override int Constructor
        {
            get
            {
                return -2025673089;
            }
        }

        public int Flags { get; set; }
		public bool P2pAllowed { get; set; }
		public bool Video { get; set; }
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GAOrB { get; set; }
		public long KeyFingerprint { get; set; }
		public TLAbsPhoneCallProtocol Protocol { get; set; }
		public TLVector<TLAbsPhoneConnection> Connections { get; set; }
		public int StartDate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 7) != 0)
				P2pAllowed = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Video = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			Date = br.ReadInt32();
			AdminId = br.ReadInt32();
			ParticipantId = br.ReadInt32();
			GAOrB = (byte[])ObjectUtils.DeserializeObject(br);
			KeyFingerprint = br.ReadInt64();
			Protocol = (TLAbsPhoneCallProtocol)ObjectUtils.DeserializeObject(br);
			Connections = (TLVector<TLAbsPhoneConnection>)ObjectUtils.DeserializeObject(br);
			StartDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(P2pAllowed, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			bw.Write(Id);
			bw.Write(AccessHash);
			bw.Write(Date);
			bw.Write(AdminId);
			bw.Write(ParticipantId);
			ObjectUtils.SerializeObject(GAOrB, bw);
			bw.Write(KeyFingerprint);
			ObjectUtils.SerializeObject(Protocol, bw);
			ObjectUtils.SerializeObject(Connections, bw);
			bw.Write(StartDate);
			
        }
    }
}