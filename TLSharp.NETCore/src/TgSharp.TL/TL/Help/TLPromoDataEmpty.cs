using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-1728664459)]
    public class TLPromoDataEmpty : TgSharp.TL.Help.TLAbsPromoData
    {
        public override int Constructor
        {
            get
            {
                return -1728664459;
            }
        }

        
		public int Expires { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Expires);
			
        }
    }
}