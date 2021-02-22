using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(136574537)]
    public class TLVotesList : TgSharp.TL.Messages.TLAbsVotesList
    {
        public override int Constructor
        {
            get
            {
                return 136574537;
            }
        }

        public int Flags { get; set; }
		public int Count { get; set; }
		public TLVector<TLAbsMessageUserVote> Votes { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }
		public string NextOffset { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Count = br.ReadInt32();
			Votes = (TLVector<TLAbsMessageUserVote>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				NextOffset = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
			ObjectUtils.SerializeObject(Votes, bw);
			ObjectUtils.SerializeObject(Users, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(NextOffset, bw);
			
        }
    }
}