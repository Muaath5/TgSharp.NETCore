using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Updates
{
    [TLObject(-1531132162)]
    public class TLChannelDifferenceTooLong : TgSharp.TL.Updates.TLAbsChannelDifference
    {
        public override int Constructor
        {
            get
            {
                return -1531132162;
            }
        }

        public int Flags { get; set; }
		public bool Final { get; set; }
		public int Timeout { get; set; }
		public TLAbsDialog Dialog { get; set; }
		public TLVector<TLAbsMessage> Messages { get; set; }
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
			if ((Flags & 3) != 0)
				Timeout = br.ReadInt32();
			Dialog = (TLAbsDialog)ObjectUtils.DeserializeObject(br);
			Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Final, bw);
			if ((Flags & 3) != 0)
	bw.Write(Timeout);
			ObjectUtils.SerializeObject(Dialog, bw);
			ObjectUtils.SerializeObject(Messages, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}