using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(978610270)]
    public class TLMessagesSlice : TgSharp.TL.Messages.TLAbsMessages
    {
        public override int Constructor
        {
            get
            {
                return 978610270;
            }
        }

        public int Flags { get; set; }
		public bool Inexact { get; set; }
		public int Count { get; set; }
		public int NextRate { get; set; }
		public int OffsetIdOffset { get; set; }
		public TLVector<TLAbsMessage> Messages { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Inexact = (bool)ObjectUtils.DeserializeObject(br);
			Count = br.ReadInt32();
			if ((Flags & 2) != 0)
				NextRate = br.ReadInt32();
			if ((Flags & 0) != 0)
				OffsetIdOffset = br.ReadInt32();
			Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Inexact, bw);
			bw.Write(Count);
			if ((Flags & 2) != 0)
	bw.Write(NextRate);
			if ((Flags & 0) != 0)
	bw.Write(OffsetIdOffset);
			ObjectUtils.SerializeObject(Messages, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}