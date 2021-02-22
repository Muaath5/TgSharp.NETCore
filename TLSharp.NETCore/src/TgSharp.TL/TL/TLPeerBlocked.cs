using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-386039788)]
    public class TLPeerBlocked : TLAbsPeerBlocked
    {
        public override int Constructor
        {
            get
            {
                return -386039788;
            }
        }

        
		public TLAbsPeer PeerId { get; set; }
		public int Date { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PeerId, bw);
			bw.Write(Date);
			
        }
    }
}