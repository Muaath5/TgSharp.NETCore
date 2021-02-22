using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(486505992)]
    public class TLRequestGetSplitRanges : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 486505992;
            }
        }

        
		public TLVector<TLAbsMessageRange> Response { get; set; }

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
            Response = (TLVector<TLAbsMessageRange>)ObjectUtils.DeserializeObject(br);
        }
    }
}