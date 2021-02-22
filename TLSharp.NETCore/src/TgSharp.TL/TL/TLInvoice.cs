using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1022713000)]
    public class TLInvoice : TLAbsInvoice
    {
        public override int Constructor
        {
            get
            {
                return -1022713000;
            }
        }

        public int Flags { get; set; }
		public bool Test { get; set; }
		public bool NameRequested { get; set; }
		public bool PhoneRequested { get; set; }
		public bool EmailRequested { get; set; }
		public bool ShippingAddressRequested { get; set; }
		public bool Flexible { get; set; }
		public bool PhoneToProvider { get; set; }
		public bool EmailToProvider { get; set; }
		public string Currency { get; set; }
		public TLVector<TLAbsLabeledPrice> Prices { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Test = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				NameRequested = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				PhoneRequested = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				EmailRequested = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				ShippingAddressRequested = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Flexible = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				PhoneToProvider = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				EmailToProvider = (bool)ObjectUtils.DeserializeObject(br);
			Currency = StringUtil.Deserialize(br);
			Prices = (TLVector<TLAbsLabeledPrice>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Test, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NameRequested, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(PhoneRequested, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(EmailRequested, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(ShippingAddressRequested, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Flexible, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(PhoneToProvider, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(EmailToProvider, bw);
			StringUtil.Serialize(Currency, bw);
			ObjectUtils.SerializeObject(Prices, bw);
			
        }
    }
}