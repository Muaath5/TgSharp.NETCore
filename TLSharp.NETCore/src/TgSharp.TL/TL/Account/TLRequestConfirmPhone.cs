using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1596029123)]
    public class TLRequestConfirmPhone : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1596029123;
            }
        }

        
		public string PhoneCodeHash { get; set; }
		public string PhoneCode { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneCodeHash = StringUtil.Deserialize(br);
			PhoneCode = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			StringUtil.Serialize(PhoneCodeHash, bw);
			StringUtil.Serialize(PhoneCode, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}