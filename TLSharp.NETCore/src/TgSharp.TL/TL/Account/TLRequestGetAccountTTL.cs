using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(150761757)]
    public class TLRequestGetAccountTTL : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 150761757;
            }
        }

        
		public TLAbsAccountDaysTTL Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsAccountDaysTTL)ObjectUtils.DeserializeObject(br);
        }
    }
}