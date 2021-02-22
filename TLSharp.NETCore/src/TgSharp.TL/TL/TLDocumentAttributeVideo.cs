using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(250621158)]
    public class TLDocumentAttributeVideo : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return 250621158;
            }
        }

        public int Flags { get; set; }
		public bool RoundMessage { get; set; }
		public bool SupportsStreaming { get; set; }
		public int Duration { get; set; }
		public int W { get; set; }
		public int H { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				RoundMessage = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SupportsStreaming = (bool)ObjectUtils.DeserializeObject(br);
			Duration = br.ReadInt32();
			W = br.ReadInt32();
			H = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(RoundMessage, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SupportsStreaming, bw);
			bw.Write(Duration);
			bw.Write(W);
			bw.Write(H);
			
        }
    }
}