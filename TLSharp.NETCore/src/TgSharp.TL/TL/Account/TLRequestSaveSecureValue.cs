using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1986010339)]
    public class TLRequestSaveSecureValue : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1986010339;
            }
        }

        
		public TLAbsInputSecureValue Value { get; set; }
		public long SecureSecretId { get; set; }
		public TLAbsSecureValue Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = (TLAbsInputSecureValue)ObjectUtils.DeserializeObject(br);
			SecureSecretId = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Value, bw);
			bw.Write(SecureSecretId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsSecureValue)ObjectUtils.DeserializeObject(br);
        }
    }
}