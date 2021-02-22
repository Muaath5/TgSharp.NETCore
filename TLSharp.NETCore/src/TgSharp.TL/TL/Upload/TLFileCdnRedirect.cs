using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(-242427324)]
    public class TLFileCdnRedirect : TgSharp.TL.Upload.TLAbsFile
    {
        public override int Constructor
        {
            get
            {
                return -242427324;
            }
        }

        
		public int DcId { get; set; }
		public byte[] FileToken { get; set; }
		public byte[] EncryptionKey { get; set; }
		public byte[] EncryptionIv { get; set; }
		public TLVector<TLAbsFileHash> FileHashes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            DcId = br.ReadInt32();
			FileToken = (byte[])ObjectUtils.DeserializeObject(br);
			EncryptionKey = (byte[])ObjectUtils.DeserializeObject(br);
			EncryptionIv = (byte[])ObjectUtils.DeserializeObject(br);
			FileHashes = (TLVector<TLAbsFileHash>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(DcId);
			ObjectUtils.SerializeObject(FileToken, bw);
			ObjectUtils.SerializeObject(EncryptionKey, bw);
			ObjectUtils.SerializeObject(EncryptionIv, bw);
			ObjectUtils.SerializeObject(FileHashes, bw);
			
        }
    }
}