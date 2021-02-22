using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(2135648522)]
    public class TLRequestReadEncryptedHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2135648522;
            }
        }

        
		public TLAbsInputEncryptedChat Peer { get; set; }
		public int MaxDate { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputEncryptedChat)ObjectUtils.DeserializeObject(br);
			MaxDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(MaxDate);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}