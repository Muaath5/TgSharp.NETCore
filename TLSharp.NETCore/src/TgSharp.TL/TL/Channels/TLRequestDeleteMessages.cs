using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(-2067661490)]
    public class TLRequestDeleteMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2067661490;
            }
        }

        
		public TLAbsInputChannel Channel { get; set; }
		public TLVector<int> Id { get; set; }
		public Messages.TLAbsAffectedMessages Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			Id = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Channel, bw);
			ObjectUtils.SerializeObject(Id, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsAffectedMessages)ObjectUtils.DeserializeObject(br);
        }
    }
}