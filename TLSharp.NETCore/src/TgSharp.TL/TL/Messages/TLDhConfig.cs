using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(740433629)]
    public class TLDhConfig : TgSharp.TL.Messages.TLAbsDhConfig
    {
        public override int Constructor
        {
            get
            {
                return 740433629;
            }
        }

        
		public int G { get; set; }
		public byte[] P { get; set; }
		public int Version { get; set; }
		public byte[] Random { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            G = br.ReadInt32();
			P = (byte[])ObjectUtils.DeserializeObject(br);
			Version = br.ReadInt32();
			Random = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(G);
			ObjectUtils.SerializeObject(P, bw);
			bw.Write(Version);
			ObjectUtils.SerializeObject(Random, bw);
			
        }
    }
}