using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1431914525)]
    public class TLRequestSendEncryptedFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1431914525;
            }
        }

        public int Flags { get; set; }
		public bool Silent { get; set; }
		public TLAbsInputEncryptedChat Peer { get; set; }
		public long RandomId { get; set; }
		public byte[] Data { get; set; }
		public TLAbsInputEncryptedFile File { get; set; }
		public Messages.TLAbsSentEncryptedMessage Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Silent = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputEncryptedChat)ObjectUtils.DeserializeObject(br);
			RandomId = br.ReadInt64();
			Data = (byte[])ObjectUtils.DeserializeObject(br);
			File = (TLAbsInputEncryptedFile)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Silent, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(RandomId);
			ObjectUtils.SerializeObject(Data, bw);
			ObjectUtils.SerializeObject(File, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsSentEncryptedMessage)ObjectUtils.DeserializeObject(br);
        }
    }
}