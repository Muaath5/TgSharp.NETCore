using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Updates
{
    [TLObject(-1459938943)]
    public class TLDifferenceSlice : TgSharp.TL.Updates.TLAbsDifference
    {
        public override int Constructor
        {
            get
            {
                return -1459938943;
            }
        }

        
		public TLVector<TLAbsMessage> NewMessages { get; set; }
		public TLVector<TLAbsEncryptedMessage> NewEncryptedMessages { get; set; }
		public TLVector<TLAbsUpdate> OtherUpdates { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }
		public TLAbsUpdates IntermediateState { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            NewMessages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeObject(br);
			NewEncryptedMessages = (TLVector<TLAbsEncryptedMessage>)ObjectUtils.DeserializeObject(br);
			OtherUpdates = (TLVector<TLAbsUpdate>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			IntermediateState = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(NewMessages, bw);
			ObjectUtils.SerializeObject(NewEncryptedMessages, bw);
			ObjectUtils.SerializeObject(OtherUpdates, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			ObjectUtils.SerializeObject(IntermediateState, bw);
			
        }
    }
}