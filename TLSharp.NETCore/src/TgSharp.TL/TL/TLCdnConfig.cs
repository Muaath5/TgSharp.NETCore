using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1462101002)]
    public class TLCdnConfig : TLAbsCdnConfig
    {
        public override int Constructor
        {
            get
            {
                return 1462101002;
            }
        }

        
		public TLVector<TLAbsCdnPublicKey> PublicKeys { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PublicKeys = (TLVector<TLAbsCdnPublicKey>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PublicKeys, bw);
			
        }
    }
}