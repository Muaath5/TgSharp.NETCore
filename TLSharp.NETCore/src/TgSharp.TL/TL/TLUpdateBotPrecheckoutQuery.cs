using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1563376297)]
    public class TLUpdateBotPrecheckoutQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1563376297;
            }
        }

        public int Flags { get; set; }
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public byte[] Payload { get; set; }
		public TLAbsPaymentRequestedInfo Info { get; set; }
		public string ShippingOptionId { get; set; }
		public string Currency { get; set; }
		public long TotalAmount { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();QueryId = br.ReadInt64();
			UserId = br.ReadInt32();
			Payload = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Info = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				ShippingOptionId = StringUtil.Deserialize(br);
			Currency = StringUtil.Deserialize(br);
			TotalAmount = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(QueryId);
			bw.Write(UserId);
			ObjectUtils.SerializeObject(Payload, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Info, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(ShippingOptionId, bw);
			StringUtil.Serialize(Currency, bw);
			bw.Write(TotalAmount);
			
        }
    }
}