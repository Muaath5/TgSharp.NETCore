using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(859091184)]
    public class TLInputSecureFileUploaded : TLAbsInputSecureFile
    {
        public override int Constructor
        {
            get
            {
                return 859091184;
            }
        }

        
		public long Id { get; set; }
		public int Parts { get; set; }
		public string Md5Checksum { get; set; }
		public byte[] FileHash { get; set; }
		public byte[] Secret { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
			Parts = br.ReadInt32();
			Md5Checksum = StringUtil.Deserialize(br);
			FileHash = (byte[])ObjectUtils.DeserializeObject(br);
			Secret = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			bw.Write(Parts);
			StringUtil.Serialize(Md5Checksum, bw);
			ObjectUtils.SerializeObject(FileHash, bw);
			ObjectUtils.SerializeObject(Secret, bw);
			
        }
    }
}