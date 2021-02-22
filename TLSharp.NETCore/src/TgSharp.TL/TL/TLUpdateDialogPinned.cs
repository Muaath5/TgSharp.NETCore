using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1852826908)]
    public class TLUpdateDialogPinned : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1852826908;
            }
        }

        public int Flags { get; set; }
		public bool Pinned { get; set; }
		public int FolderId { get; set; }
		public TLAbsDialogPeer Peer { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Pinned = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				FolderId = br.ReadInt32();
			Peer = (TLAbsDialogPeer)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Pinned, bw);
			if ((Flags & 3) != 0)
	bw.Write(FolderId);
			ObjectUtils.SerializeObject(Peer, bw);
			
        }
    }
}