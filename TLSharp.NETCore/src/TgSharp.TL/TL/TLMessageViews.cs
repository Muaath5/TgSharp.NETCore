using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1163625789)]
    public class TLMessageViews : TLAbsMessageViews
    {
        public override int Constructor
        {
            get
            {
                return 1163625789;
            }
        }

        public int Flags { get; set; }
		public int Views { get; set; }
		public int Forwards { get; set; }
		public TLAbsMessageReplies Replies { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Views = br.ReadInt32();
			if ((Flags & 3) != 0)
				Forwards = br.ReadInt32();
			if ((Flags & 0) != 0)
				Replies = (TLAbsMessageReplies)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	bw.Write(Views);
			if ((Flags & 3) != 0)
	bw.Write(Forwards);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Replies, bw);
			
        }
    }
}