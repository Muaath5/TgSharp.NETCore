using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-847783593)]
    public class TLChannelMessagesFilter : TLAbsChannelMessagesFilter
    {
        public override int Constructor
        {
            get
            {
                return -847783593;
            }
        }

        public int Flags { get; set; }
		public bool ExcludeNewMessages { get; set; }
		public TLVector<TLAbsMessageRange> Ranges { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				ExcludeNewMessages = (bool)ObjectUtils.DeserializeObject(br);
			Ranges = (TLVector<TLAbsMessageRange>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(ExcludeNewMessages, bw);
			ObjectUtils.SerializeObject(Ranges, bw);
			
        }
    }
}