using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Phone
{
    [TLObject(1003664544)]
    public class TLRequestAcceptCall : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1003664544;
            }
        }

        
		public TLAbsInputPhoneCall Peer { get; set; }
		public byte[] GB { get; set; }
		public TLAbsPhoneCallProtocol Protocol { get; set; }
		public Phone.TLAbsPhoneCall Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPhoneCall)ObjectUtils.DeserializeObject(br);
			GB = (byte[])ObjectUtils.DeserializeObject(br);
			Protocol = (TLAbsPhoneCallProtocol)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(GB, bw);
			ObjectUtils.SerializeObject(Protocol, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Phone.TLAbsPhoneCall)ObjectUtils.DeserializeObject(br);
        }
    }
}