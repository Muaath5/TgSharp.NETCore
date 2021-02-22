using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(998448230)]
    public class TLRequestGetFullChat : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 998448230;
            }
        }

        
		public int ChatId { get; set; }
		public Messages.TLAbsChatFull Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			bw.Write(ChatId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsChatFull)ObjectUtils.DeserializeObject(br);
        }
    }
}