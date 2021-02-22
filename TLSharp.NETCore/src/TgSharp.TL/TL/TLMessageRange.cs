using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(182649427)]
    public class TLMessageRange : TLAbsMessageRange
    {
        public override int Constructor
        {
            get
            {
                return 182649427;
            }
        }

        
		public int MinId { get; set; }
		public int MaxId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MinId = br.ReadInt32();
			MaxId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MinId);
			bw.Write(MaxId);
			
        }
    }
}