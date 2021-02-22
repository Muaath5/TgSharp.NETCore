using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1910543603)]
    public class TLDialogsSlice : TgSharp.TL.Messages.TLAbsDialogs
    {
        public override int Constructor
        {
            get
            {
                return 1910543603;
            }
        }

        
		public int Count { get; set; }
		public TLVector<TLAbsDialog> Dialogs { get; set; }
		public TLVector<TLAbsMessage> Messages { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
			Dialogs = (TLVector<TLAbsDialog>)ObjectUtils.DeserializeObject(br);
			Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
			ObjectUtils.SerializeObject(Dialogs, bw);
			ObjectUtils.SerializeObject(Messages, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}