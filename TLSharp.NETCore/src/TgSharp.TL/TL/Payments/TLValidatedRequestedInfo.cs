using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(-784000893)]
    public class TLValidatedRequestedInfo : TgSharp.TL.Payments.TLAbsValidatedRequestedInfo
    {
        public override int Constructor
        {
            get
            {
                return -784000893;
            }
        }

        public int Flags { get; set; }
		public string Id { get; set; }
		public TLVector<TLAbsShippingOption> ShippingOptions { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Id = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				ShippingOptions = (TLVector<TLAbsShippingOption>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	StringUtil.Serialize(Id, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(ShippingOptions, bw);
			
        }
    }
}