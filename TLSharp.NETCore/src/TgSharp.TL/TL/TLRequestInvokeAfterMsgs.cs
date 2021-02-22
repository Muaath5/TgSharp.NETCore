using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1036301552)]
    public class TLRequestInvokeAfterMsgs<X> : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1036301552;
            }
        }

        
		public TLVector<long> MsgIds { get; set; }
		public X Query { get; set; }
		public X Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MsgIds = (TLVector<long>)ObjectUtils.DeserializeObject(br);
			Query = (X)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(MsgIds, bw);
			ObjectUtils.SerializeObject(Query, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (X)ObjectUtils.DeserializeObject(br);
        }
    }
}