using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1648543603)]
    public class TLFileHash : TLAbsFileHash
    {
        public override int Constructor
        {
            get
            {
                return 1648543603;
            }
        }

        
		public int Offset { get; set; }
		public int Limit { get; set; }
		public byte[] Hash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
			Limit = br.ReadInt32();
			Hash = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Offset);
			bw.Write(Limit);
			ObjectUtils.SerializeObject(Hash, bw);
			
        }
    }
}