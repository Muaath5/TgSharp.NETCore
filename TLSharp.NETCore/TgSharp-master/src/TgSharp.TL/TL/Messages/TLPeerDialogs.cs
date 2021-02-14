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
    public class TLPeerDialogs : TLObject
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
        public Updates.TLState State { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Dialogs = (TLVector<TLAbsDialog>)ObjectUtils.DeserializeVector<TLAbsDialog>(br);
            Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeVector<TLAbsMessage>(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
            State = (Updates.TLState)ObjectUtils.DeserializeObject(br);
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
