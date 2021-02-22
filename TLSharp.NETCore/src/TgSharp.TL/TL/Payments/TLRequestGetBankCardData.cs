using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(779736953)]
    public class TLRequestGetBankCardData : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 779736953;
            }
        }

        
		public string Number { get; set; }
		public Payments.TLAbsBankCardData Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Number = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			StringUtil.Serialize(Number, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Payments.TLAbsBankCardData)ObjectUtils.DeserializeObject(br);
        }
    }
}