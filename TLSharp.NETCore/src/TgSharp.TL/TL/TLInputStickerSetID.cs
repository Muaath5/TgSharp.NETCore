using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1645763991)]
    public class TLInputStickerSetID : TLAbsInputStickerSet
    {
        public override int Constructor
        {
            get
            {
                return -1645763991;
            }
        }

        
		public long Id { get; set; }
		public long AccessHash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			bw.Write(AccessHash);
			
        }
    }
}