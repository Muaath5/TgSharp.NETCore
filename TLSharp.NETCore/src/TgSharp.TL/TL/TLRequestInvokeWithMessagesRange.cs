using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(911373810)]
    public class TLRequestInvokeWithMessagesRange<X> : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 911373810;
            }
        }

        
		public TLAbsMessageRange Range { get; set; }
		public X Query { get; set; }
		public X Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Range = (TLAbsMessageRange)ObjectUtils.DeserializeObject(br);
			Query = (X)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Range, bw);
			ObjectUtils.SerializeObject(Query, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (X)ObjectUtils.DeserializeObject(br);
        }
    }
}