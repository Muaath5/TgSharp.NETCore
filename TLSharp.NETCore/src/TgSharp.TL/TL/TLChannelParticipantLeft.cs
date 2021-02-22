using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1010402965)]
    public class TLChannelParticipantLeft : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return -1010402965;
            }
        }

        
		public int UserId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			
        }
    }
}