using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(982592842)]
    public class TLPasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : TLAbsPasswordKdfAlgo
    {
        public override int Constructor
        {
            get
            {
                return 982592842;
            }
        }

        
		public byte[] Salt1 { get; set; }
		public byte[] Salt2 { get; set; }
		public int G { get; set; }
		public byte[] P { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Salt1 = (byte[])ObjectUtils.DeserializeObject(br);
			Salt2 = (byte[])ObjectUtils.DeserializeObject(br);
			G = br.ReadInt32();
			P = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Salt1, bw);
			ObjectUtils.SerializeObject(Salt2, bw);
			bw.Write(G);
			ObjectUtils.SerializeObject(P, bw);
			
        }
    }
}