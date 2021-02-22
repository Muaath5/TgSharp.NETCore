using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-241247891)]
    public class TLRequestGetDialogFilters : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -241247891;
            }
        }

        
		public TLVector<TLAbsDialogFilter> Response { get; set; }

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
            Response = (TLVector<TLAbsDialogFilter>)ObjectUtils.DeserializeObject(br);
        }
    }
}