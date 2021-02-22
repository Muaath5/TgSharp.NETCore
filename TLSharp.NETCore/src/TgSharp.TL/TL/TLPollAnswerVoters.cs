using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(997055186)]
    public class TLPollAnswerVoters : TLAbsPollAnswerVoters
    {
        public override int Constructor
        {
            get
            {
                return 997055186;
            }
        }

        public int Flags { get; set; }
		public bool Chosen { get; set; }
		public bool Correct { get; set; }
		public byte[] Option { get; set; }
		public int Voters { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Chosen = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Correct = (bool)ObjectUtils.DeserializeObject(br);
			Option = (byte[])ObjectUtils.DeserializeObject(br);
			Voters = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Chosen, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Correct, bw);
			ObjectUtils.SerializeObject(Option, bw);
			bw.Write(Voters);
			
        }
    }
}