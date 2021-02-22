using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(1342771681)]
    public class TLPaymentReceipt : TgSharp.TL.Payments.TLAbsPaymentReceipt
    {
        public override int Constructor
        {
            get
            {
                return 1342771681;
            }
        }

        public int Flags { get; set; }
		public int Date { get; set; }
		public int BotId { get; set; }
		public TLAbsInvoice Invoice { get; set; }
		public int ProviderId { get; set; }
		public TLAbsPaymentRequestedInfo Info { get; set; }
		public TLAbsShippingOption Shipping { get; set; }
		public string Currency { get; set; }
		public long TotalAmount { get; set; }
		public string CredentialsTitle { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Date = br.ReadInt32();
			BotId = br.ReadInt32();
			Invoice = (TLAbsInvoice)ObjectUtils.DeserializeObject(br);
			ProviderId = br.ReadInt32();
			if ((Flags & 2) != 0)
				Info = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Shipping = (TLAbsShippingOption)ObjectUtils.DeserializeObject(br);
			Currency = StringUtil.Deserialize(br);
			TotalAmount = br.ReadInt64();
			CredentialsTitle = StringUtil.Deserialize(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Date);
			bw.Write(BotId);
			ObjectUtils.SerializeObject(Invoice, bw);
			bw.Write(ProviderId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Info, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Shipping, bw);
			StringUtil.Serialize(Currency, bw);
			bw.Write(TotalAmount);
			StringUtil.Serialize(CredentialsTitle, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}