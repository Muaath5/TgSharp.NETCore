using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1908216652)]
    public class TLDialogFolder : TLAbsDialog
    {
        public override int Constructor
        {
            get
            {
                return 1908216652;
            }
        }

        public int Flags { get; set; }
		public bool Pinned { get; set; }
		public TLAbsFolder Folder { get; set; }
		public TLAbsPeer Peer { get; set; }
		public int TopMessage { get; set; }
		public int UnreadMutedPeersCount { get; set; }
		public int UnreadUnmutedPeersCount { get; set; }
		public int UnreadMutedMessagesCount { get; set; }
		public int UnreadUnmutedMessagesCount { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 0) != 0)
				Pinned = (bool)ObjectUtils.DeserializeObject(br);
			Folder = (TLAbsFolder)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			TopMessage = br.ReadInt32();
			UnreadMutedPeersCount = br.ReadInt32();
			UnreadUnmutedPeersCount = br.ReadInt32();
			UnreadMutedMessagesCount = br.ReadInt32();
			UnreadUnmutedMessagesCount = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Pinned, bw);
			ObjectUtils.SerializeObject(Folder, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(TopMessage);
			bw.Write(UnreadMutedPeersCount);
			bw.Write(UnreadUnmutedPeersCount);
			bw.Write(UnreadMutedMessagesCount);
			bw.Write(UnreadUnmutedMessagesCount);
			
        }
    }
}