using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1444503762)]
    public class TLRequestEditChatAdmin : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1444503762;
            }
        }

        
		public int ChatId { get; set; }
		public TLAbsInputUser UserId { get; set; }
		public TLAbsBool IsAdmin { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
			UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
			IsAdmin = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			bw.Write(ChatId);
			ObjectUtils.SerializeObject(UserId, bw);
			ObjectUtils.SerializeObject(IsAdmin, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}