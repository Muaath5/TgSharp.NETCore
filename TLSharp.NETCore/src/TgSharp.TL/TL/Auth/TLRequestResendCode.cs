using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(1056025023)]
    public class TLRequestResendCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1056025023;
            }
        }

        
		public string PhoneNumber { get; set; }
		public string PhoneCodeHash { get; set; }
		public Auth.TLAbsSentCode Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
			PhoneCodeHash = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			StringUtil.Serialize(PhoneNumber, bw);
			StringUtil.Serialize(PhoneCodeHash, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Auth.TLAbsSentCode)ObjectUtils.DeserializeObject(br);
        }
    }
}