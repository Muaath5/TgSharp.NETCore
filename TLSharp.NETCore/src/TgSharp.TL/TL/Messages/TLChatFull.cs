using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-438840932)]
    public class TLChatFull : TgSharp.TL.Messages.TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return -438840932;
            }
        }

        
		public TLAbsChatFull FullChat { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FullChat = (TLAbsChatFull)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(FullChat, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}