using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(610945826)]
    public class TLUpdatePeerBlocked : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 610945826;
            }
        }

        
		public TLAbsPeer PeerId { get; set; }
		public TLAbsBool Blocked { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			Blocked = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PeerId, bw);
			ObjectUtils.SerializeObject(Blocked, bw);
			
        }
    }
}