using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(-1691921240)]
    public class TLRequestReuploadCdnFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1691921240;
            }
        }

        
		public byte[] FileToken { get; set; }
		public byte[] RequestToken { get; set; }
		public TLVector<TLAbsFileHash> Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = (byte[])ObjectUtils.DeserializeObject(br);
			RequestToken = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(FileToken, bw);
			ObjectUtils.SerializeObject(RequestToken, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLVector<TLAbsFileHash>)ObjectUtils.DeserializeObject(br);
        }
    }
}