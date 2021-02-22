using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Phone
{
    [TLObject(-1295269440)]
    public class TLRequestDiscardCall : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1295269440;
            }
        }

        public int Flags { get; set; }
		public bool Video { get; set; }
		public TLAbsInputPhoneCall Peer { get; set; }
		public int Duration { get; set; }
		public TLAbsPhoneCallDiscardReason Reason { get; set; }
		public long ConnectionId { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Video = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPhoneCall)ObjectUtils.DeserializeObject(br);
			Duration = br.ReadInt32();
			Reason = (TLAbsPhoneCallDiscardReason)ObjectUtils.DeserializeObject(br);
			ConnectionId = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(Duration);
			ObjectUtils.SerializeObject(Reason, bw);
			bw.Write(ConnectionId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}