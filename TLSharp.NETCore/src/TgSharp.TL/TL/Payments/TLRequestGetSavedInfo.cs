using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(578650699)]
    public class TLRequestGetSavedInfo : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 578650699;
            }
        }

        
		public Payments.TLAbsSavedInfo Response { get; set; }

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
            Response = (Payments.TLAbsSavedInfo)ObjectUtils.DeserializeObject(br);
        }
    }
}