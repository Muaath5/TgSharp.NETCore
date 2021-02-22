using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1398240377)]
    public class TLRequestGetNotifyExceptions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1398240377;
            }
        }

        public int Flags { get; set; }
		public bool CompareSound { get; set; }
		public TLAbsInputNotifyPeer Peer { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				CompareSound = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Peer = (TLAbsInputNotifyPeer)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(CompareSound, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Peer, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}