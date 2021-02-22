using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-531931925)]
    public class TLChannelParticipantsMentions : TLAbsChannelParticipantsFilter
    {
        public override int Constructor
        {
            get
            {
                return -531931925;
            }
        }

        public int Flags { get; set; }
		public string Q { get; set; }
		public int TopMsgId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Q = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				TopMsgId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	StringUtil.Serialize(Q, bw);
			if ((Flags & 3) != 0)
	bw.Write(TopMsgId);
			
        }
    }
}