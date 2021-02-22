using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-99664734)]
    public class TLUpdatePinnedDialogs : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -99664734;
            }
        }

        public int Flags { get; set; }
		public int FolderId { get; set; }
		public TLVector<TLAbsDialogPeer> Order { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				FolderId = br.ReadInt32();
			if ((Flags & 2) != 0)
				Order = (TLVector<TLAbsDialogPeer>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	bw.Write(FolderId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Order, bw);
			
        }
    }
}