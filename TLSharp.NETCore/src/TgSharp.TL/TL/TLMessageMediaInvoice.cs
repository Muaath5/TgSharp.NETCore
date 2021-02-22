using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2074799289)]
    public class TLMessageMediaInvoice : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -2074799289;
            }
        }

        public int Flags { get; set; }
		public bool ShippingAddressRequested { get; set; }
		public bool Test { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TLAbsWebDocument Photo { get; set; }
		public int ReceiptMsgId { get; set; }
		public string Currency { get; set; }
		public long TotalAmount { get; set; }
		public string StartParam { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				ShippingAddressRequested = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Test = (bool)ObjectUtils.DeserializeObject(br);
			Title = StringUtil.Deserialize(br);
			Description = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Photo = (TLAbsWebDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReceiptMsgId = br.ReadInt32();
			Currency = StringUtil.Deserialize(br);
			TotalAmount = br.ReadInt64();
			StartParam = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(ShippingAddressRequested, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Test, bw);
			StringUtil.Serialize(Title, bw);
			StringUtil.Serialize(Description, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			if ((Flags & 0) != 0)
	bw.Write(ReceiptMsgId);
			StringUtil.Serialize(Currency, bw);
			bw.Write(TotalAmount);
			StringUtil.Serialize(StartParam, bw);
			
        }
    }
}