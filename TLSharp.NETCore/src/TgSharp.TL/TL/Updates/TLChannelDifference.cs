using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Updates
{
    [TLObject(543450958)]
    public class TLChannelDifference : TgSharp.TL.Updates.TLAbsChannelDifference
    {
        public override int Constructor
        {
            get
            {
                return 543450958;
            }
        }

        public int Flags { get; set; }
		public bool Final { get; set; }
		public int Pts { get; set; }
		public int Timeout { get; set; }
		public TLVector<TLAbsMessage> NewMessages { get; set; }
		public TLVector<TLAbsUpdate> OtherUpdates { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Final = (bool)ObjectUtils.DeserializeObject(br);
			Pts = br.ReadInt32();
			if ((Flags & 3) != 0)
				Timeout = br.ReadInt32();
			NewMessages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			OtherUpdates = (TLVector<TLAbsUpdate>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Final, bw);
			bw.Write(Pts);
			if ((Flags & 3) != 0)
	bw.Write(Timeout);
			ObjectUtils.SerializeObject(NewMessages, bw);
			ObjectUtils.SerializeObject(OtherUpdates, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}