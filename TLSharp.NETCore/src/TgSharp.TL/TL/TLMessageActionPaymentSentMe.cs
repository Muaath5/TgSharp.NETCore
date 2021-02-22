using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1892568281)]
    public class TLMessageActionPaymentSentMe : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1892568281;
            }
        }

        public int Flags { get; set; }
		public string Currency { get; set; }
		public long TotalAmount { get; set; }
		public byte[] Payload { get; set; }
		public TLAbsPaymentRequestedInfo Info { get; set; }
		public string ShippingOptionId { get; set; }
		public TLAbsPaymentCharge Charge { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Currency = StringUtil.Deserialize(br);
			TotalAmount = br.ReadInt64();
			Payload = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Info = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				ShippingOptionId = StringUtil.Deserialize(br);
			Charge = (TLAbsPaymentCharge)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Currency, bw);
			bw.Write(TotalAmount);
			ObjectUtils.SerializeObject(Payload, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Info, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(ShippingOptionId, bw);
			ObjectUtils.SerializeObject(Charge, bw);
			
        }
    }
}