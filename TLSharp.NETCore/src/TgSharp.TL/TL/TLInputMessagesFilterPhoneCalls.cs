using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2134272152)]
    public class TLInputMessagesFilterPhoneCalls : TLAbsMessagesFilter
    {
        public override int Constructor
        {
            get
            {
                return -2134272152;
            }
        }

        public int Flags { get; set; }
		public bool Missed { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Missed = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Missed, bw);
			
        }
    }
}