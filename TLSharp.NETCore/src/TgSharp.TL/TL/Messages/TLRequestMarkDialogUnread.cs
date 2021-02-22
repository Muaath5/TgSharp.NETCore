using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1031349873)]
    public class TLRequestMarkDialogUnread : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1031349873;
            }
        }

        public int Flags { get; set; }
		public bool Unread { get; set; }
		public TLAbsInputDialogPeer Peer { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Unread = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputDialogPeer)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Unread, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}