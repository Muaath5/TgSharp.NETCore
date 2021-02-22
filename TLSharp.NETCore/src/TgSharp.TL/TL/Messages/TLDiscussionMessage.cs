using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-170029155)]
    public class TLDiscussionMessage : TgSharp.TL.Messages.TLAbsDiscussionMessage
    {
        public override int Constructor
        {
            get
            {
                return -170029155;
            }
        }

        public int Flags { get; set; }
		public TLVector<TLAbsMessage> Messages { get; set; }
		public int MaxId { get; set; }
		public int ReadInboxMaxId { get; set; }
		public int ReadOutboxMaxId { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				MaxId = br.ReadInt32();
			if ((Flags & 3) != 0)
				ReadInboxMaxId = br.ReadInt32();
			if ((Flags & 0) != 0)
				ReadOutboxMaxId = br.ReadInt32();
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Messages, bw);
			if ((Flags & 2) != 0)
	bw.Write(MaxId);
			if ((Flags & 3) != 0)
	bw.Write(ReadInboxMaxId);
			if ((Flags & 0) != 0)
	bw.Write(ReadOutboxMaxId);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}