using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(418631927)]
    public class TLStatsGroupTopPoster : TLAbsStatsGroupTopPoster
    {
        public override int Constructor
        {
            get
            {
                return 418631927;
            }
        }

        
		public int UserId { get; set; }
		public int Messages { get; set; }
		public int AvgChars { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			Messages = br.ReadInt32();
			AvgChars = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			bw.Write(Messages);
			bw.Write(AvgChars);
			
        }
    }
}