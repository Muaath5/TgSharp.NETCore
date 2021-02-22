using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1868808300)]
    public class TLPaymentRequestedInfo : TLAbsPaymentRequestedInfo
    {
        public override int Constructor
        {
            get
            {
                return -1868808300;
            }
        }

        public int Flags { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public TLAbsPostAddress ShippingAddress { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Name = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Phone = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Email = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				ShippingAddress = (TLAbsPostAddress)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	StringUtil.Serialize(Name, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Phone, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Email, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ShippingAddress, bw);
			
        }
    }
}