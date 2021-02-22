using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1495959709)]
    public class TLMessageReplyHeader : TLAbsMessageReplyHeader
    {
        public override int Constructor
        {
            get
            {
                return -1495959709;
            }
        }

        public int Flags { get; set; }
		public int ReplyToMsgId { get; set; }
		public TLAbsPeer ReplyToPeerId { get; set; }
		public int ReplyToTopId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();ReplyToMsgId = br.ReadInt32();
			if ((Flags & 2) != 0)
				ReplyToPeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				ReplyToTopId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReplyToMsgId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ReplyToPeerId, bw);
			if ((Flags & 3) != 0)
	bw.Write(ReplyToTopId);
			
        }
    }
}