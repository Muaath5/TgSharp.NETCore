using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Phone
{
    [TLObject(662363518)]
    public class TLRequestSaveCallDebug : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 662363518;
            }
        }

        
		public TLAbsInputPhoneCall Peer { get; set; }
		public TLAbsDataJSON Debug { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPhoneCall)ObjectUtils.DeserializeObject(br);
			Debug = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(Debug, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}