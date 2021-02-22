using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(871426631)]
    public class TLSecureCredentialsEncrypted : TLAbsSecureCredentialsEncrypted
    {
        public override int Constructor
        {
            get
            {
                return 871426631;
            }
        }

        
		public byte[] Data { get; set; }
		public byte[] Hash { get; set; }
		public byte[] Secret { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Data = (byte[])ObjectUtils.DeserializeObject(br);
			Hash = (byte[])ObjectUtils.DeserializeObject(br);
			Secret = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Data, bw);
			ObjectUtils.SerializeObject(Hash, bw);
			ObjectUtils.SerializeObject(Secret, bw);
			
        }
    }
}