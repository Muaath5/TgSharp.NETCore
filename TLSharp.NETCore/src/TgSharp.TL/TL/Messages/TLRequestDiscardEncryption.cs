using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-304536635)]
    public class TLRequestDiscardEncryption : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -304536635;
            }
        }

        
		public int ChatId { get; set; }
		public TLAbsBool Response { get; set; }

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
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}