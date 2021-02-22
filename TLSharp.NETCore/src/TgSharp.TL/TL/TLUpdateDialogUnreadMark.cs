using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-513517117)]
    public class TLUpdateDialogUnreadMark : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -513517117;
            }
        }

        public int Flags { get; set; }
		public bool Unread { get; set; }
		public TLAbsDialogPeer Peer { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Unread = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsDialogPeer)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Unread, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			
        }
    }
}