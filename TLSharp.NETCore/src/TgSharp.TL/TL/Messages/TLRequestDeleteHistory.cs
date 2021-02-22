using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(469850889)]
    public class TLRequestDeleteHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 469850889;
            }
        }

        public int Flags { get; set; }
		public bool JustClear { get; set; }
		public bool Revoke { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int MaxId { get; set; }
		public Messages.TLAbsAffectedHistory Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				JustClear = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Revoke = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			MaxId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(JustClear, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Revoke, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(MaxId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsAffectedHistory)ObjectUtils.DeserializeObject(br);
        }
    }
}