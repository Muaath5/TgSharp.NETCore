using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(863093588)]
    public class TLPeerDialogs : TgSharp.TL.Messages.TLAbsPeerDialogs
    {
        public override int Constructor
        {
            get
            {
                return 863093588;
            }
        }

        
		public TLVector<TLAbsDialog> Dialogs { get; set; }
		public TLVector<TLAbsMessage> Messages { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }
		public TLAbsUpdates State { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Dialogs = (TLVector<TLAbsDialog>)ObjectUtils.DeserializeObject(br);
			Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			State = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Dialogs, bw);
			ObjectUtils.SerializeObject(Messages, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			ObjectUtils.SerializeObject(State, bw);
			
        }
    }
}