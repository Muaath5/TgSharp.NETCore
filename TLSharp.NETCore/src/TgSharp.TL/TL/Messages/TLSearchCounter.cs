using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-398136321)]
    public class TLSearchCounter : TgSharp.TL.Messages.TLAbsSearchCounter
    {
        public override int Constructor
        {
            get
            {
                return -398136321;
            }
        }

        public int Flags { get; set; }
		public bool Inexact { get; set; }
		public TLAbsMessagesFilter Filter { get; set; }
		public int Count { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Inexact = (bool)ObjectUtils.DeserializeObject(br);
			Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
			Count = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Inexact, bw);
			ObjectUtils.SerializeObject(Filter, bw);
			bw.Write(Count);
			
        }
    }
}