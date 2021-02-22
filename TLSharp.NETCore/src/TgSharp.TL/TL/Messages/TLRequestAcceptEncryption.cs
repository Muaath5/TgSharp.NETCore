using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1035731989)]
    public class TLRequestAcceptEncryption : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1035731989;
            }
        }

        
		public TLAbsInputEncryptedChat Peer { get; set; }
		public byte[] GB { get; set; }
		public long KeyFingerprint { get; set; }
		public TLAbsEncryptedChat Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputEncryptedChat)ObjectUtils.DeserializeObject(br);
			GB = (byte[])ObjectUtils.DeserializeObject(br);
			KeyFingerprint = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(GB, bw);
			bw.Write(KeyFingerprint);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsEncryptedChat)ObjectUtils.DeserializeObject(br);
        }
    }
}