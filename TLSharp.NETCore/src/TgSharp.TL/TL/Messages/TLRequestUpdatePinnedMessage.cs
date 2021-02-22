using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-760547348)]
    public class TLRequestUpdatePinnedMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -760547348;
            }
        }

        public int Flags { get; set; }
		public bool Silent { get; set; }
		public bool Unpin { get; set; }
		public bool PmOneside { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int Id { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Silent = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Unpin = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				PmOneside = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Silent, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Unpin, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(PmOneside, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(Id);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}