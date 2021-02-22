using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Updates
{
    [TLObject(1041346555)]
    public class TLChannelDifferenceEmpty : TgSharp.TL.Updates.TLAbsChannelDifference
    {
        public override int Constructor
        {
            get
            {
                return 1041346555;
            }
        }

        public int Flags { get; set; }
		public bool Final { get; set; }
		public int Pts { get; set; }
		public int Timeout { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Final = (bool)ObjectUtils.DeserializeObject(br);
			Pts = br.ReadInt32();
			if ((Flags & 3) != 0)
				Timeout = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Final, bw);
			bw.Write(Pts);
			if ((Flags & 3) != 0)
	bw.Write(Timeout);
			
        }
    }
}