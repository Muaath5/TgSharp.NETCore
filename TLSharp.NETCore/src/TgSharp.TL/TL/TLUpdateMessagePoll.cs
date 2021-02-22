using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1398708869)]
    public class TLUpdateMessagePoll : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1398708869;
            }
        }

        public int Flags { get; set; }
		public long PollId { get; set; }
		public TLAbsPoll Poll { get; set; }
		public TLAbsPollResults Results { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();PollId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
			Results = (TLAbsPollResults)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PollId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Poll, bw);
			ObjectUtils.SerializeObject(Results, bw);
			
        }
    }
}