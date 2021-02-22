using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1387279939)]
    public class TLMessageInteractionCounters : TLAbsMessageInteractionCounters
    {
        public override int Constructor
        {
            get
            {
                return -1387279939;
            }
        }

        
		public int MsgId { get; set; }
		public int Views { get; set; }
		public int Forwards { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt32();
			Views = br.ReadInt32();
			Forwards = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MsgId);
			bw.Write(Views);
			bw.Write(Forwards);
			
        }
    }
}