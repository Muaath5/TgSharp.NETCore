using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(594758406)]
    public class TLEncryptedMessageService : TLAbsEncryptedMessage
    {
        public override int Constructor
        {
            get
            {
                return 594758406;
            }
        }

        
		public long RandomId { get; set; }
		public int ChatId { get; set; }
		public int Date { get; set; }
		public byte[] Bytes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            RandomId = br.ReadInt64();
			ChatId = br.ReadInt32();
			Date = br.ReadInt32();
			Bytes = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(RandomId);
			bw.Write(ChatId);
			bw.Write(Date);
			ObjectUtils.SerializeObject(Bytes, bw);
			
        }
    }
}