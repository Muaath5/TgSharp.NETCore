using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(991616823)]
    public class TLRequestReorderPinnedDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 991616823;
            }
        }

        public int Flags { get; set; }
		public bool Force { get; set; }
		public int FolderId { get; set; }
		public TLVector<TLAbsInputDialogPeer> Order { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Force = (bool)ObjectUtils.DeserializeObject(br);
			FolderId = br.ReadInt32();
			Order = (TLVector<TLAbsInputDialogPeer>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Force, bw);
			bw.Write(FolderId);
			ObjectUtils.SerializeObject(Order, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}