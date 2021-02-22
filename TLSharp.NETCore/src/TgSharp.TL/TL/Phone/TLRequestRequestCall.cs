using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Phone
{
    [TLObject(1124046573)]
    public class TLRequestRequestCall : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1124046573;
            }
        }

        public int Flags { get; set; }
		public bool Video { get; set; }
		public TLAbsInputUser UserId { get; set; }
		public int RandomId { get; set; }
		public byte[] GAHash { get; set; }
		public TLAbsPhoneCallProtocol Protocol { get; set; }
		public Phone.TLAbsPhoneCall Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Video = (bool)ObjectUtils.DeserializeObject(br);
			UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
			RandomId = br.ReadInt32();
			GAHash = (byte[])ObjectUtils.DeserializeObject(br);
			Protocol = (TLAbsPhoneCallProtocol)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Video, bw);
			ObjectUtils.SerializeObject(UserId, bw);
			bw.Write(RandomId);
			ObjectUtils.SerializeObject(GAHash, bw);
			ObjectUtils.SerializeObject(Protocol, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Phone.TLAbsPhoneCall)ObjectUtils.DeserializeObject(br);
        }
    }
}