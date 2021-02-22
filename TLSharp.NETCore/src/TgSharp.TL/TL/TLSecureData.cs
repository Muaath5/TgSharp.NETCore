using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1964327229)]
    public class TLSecureData : TLAbsSecureData
    {
        public override int Constructor
        {
            get
            {
                return -1964327229;
            }
        }

        
		public byte[] Data { get; set; }
		public byte[] DataHash { get; set; }
		public byte[] Secret { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Data = (byte[])ObjectUtils.DeserializeObject(br);
			DataHash = (byte[])ObjectUtils.DeserializeObject(br);
			Secret = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Data, bw);
			ObjectUtils.SerializeObject(DataHash, bw);
			ObjectUtils.SerializeObject(Secret, bw);
			
        }
    }
}