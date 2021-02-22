using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(531836966)]
    public class TLRequestGetNearestDc : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 531836966;
            }
        }

        
		public TLAbsNearestDc Response { get; set; }

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
            Response = (TLAbsNearestDc)ObjectUtils.DeserializeObject(br);
        }
    }
}