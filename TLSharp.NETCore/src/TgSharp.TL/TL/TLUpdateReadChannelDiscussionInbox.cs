using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(482860628)]
    public class TLUpdateReadChannelDiscussionInbox : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 482860628;
            }
        }

        public int Flags { get; set; }
		public int ChannelId { get; set; }
		public int TopMsgId { get; set; }
		public int ReadMaxId { get; set; }
		public int BroadcastId { get; set; }
		public int BroadcastPost { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();ChannelId = br.ReadInt32();
			TopMsgId = br.ReadInt32();
			ReadMaxId = br.ReadInt32();
			if ((Flags & 2) != 0)
				BroadcastId = br.ReadInt32();
			if ((Flags & 2) != 0)
				BroadcastPost = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChannelId);
			bw.Write(TopMsgId);
			bw.Write(ReadMaxId);
			if ((Flags & 2) != 0)
	bw.Write(BroadcastId);
			if ((Flags & 2) != 0)
	bw.Write(BroadcastPost);
			
        }
    }
}