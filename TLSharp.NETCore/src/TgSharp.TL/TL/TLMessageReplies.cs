using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1093204652)]
    public class TLMessageReplies : TLAbsMessageReplies
    {
        public override int Constructor
        {
            get
            {
                return 1093204652;
            }
        }

        public int Flags { get; set; }
		public bool Comments { get; set; }
		public int Replies { get; set; }
		public int RepliesPts { get; set; }
		public TLVector<TLAbsPeer> RecentRepliers { get; set; }
		public int ChannelId { get; set; }
		public int MaxId { get; set; }
		public int ReadMaxId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Comments = (bool)ObjectUtils.DeserializeObject(br);
			Replies = br.ReadInt32();
			RepliesPts = br.ReadInt32();
			if ((Flags & 3) != 0)
				RecentRepliers = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				ChannelId = br.ReadInt32();
			if ((Flags & 0) != 0)
				MaxId = br.ReadInt32();
			if ((Flags & 1) != 0)
				ReadMaxId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Comments, bw);
			bw.Write(Replies);
			bw.Write(RepliesPts);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(RecentRepliers, bw);
			if ((Flags & 2) != 0)
	bw.Write(ChannelId);
			if ((Flags & 0) != 0)
	bw.Write(MaxId);
			if ((Flags & 1) != 0)
	bw.Write(ReadMaxId);
			
        }
    }
}