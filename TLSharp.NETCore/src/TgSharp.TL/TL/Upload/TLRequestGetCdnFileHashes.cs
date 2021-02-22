using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(1302676017)]
    public class TLRequestGetCdnFileHashes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1302676017;
            }
        }

        
		public byte[] FileToken { get; set; }
		public int Offset { get; set; }
		public TLVector<TLAbsFileHash> Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = (byte[])ObjectUtils.DeserializeObject(br);
			Offset = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(FileToken, bw);
			bw.Write(Offset);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLVector<TLAbsFileHash>)ObjectUtils.DeserializeObject(br);
        }
    }
}