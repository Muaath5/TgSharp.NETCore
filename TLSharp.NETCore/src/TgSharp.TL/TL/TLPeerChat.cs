using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1160714821)]
    public class TLPeerChat : TLAbsPeer
    {
        public override int Constructor
        {
            get
            {
                return -1160714821;
            }
        }

        
		public int ChatId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
			
        }
    }
}