using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(-74456004)]
    public class TLSavedInfo : TgSharp.TL.Payments.TLAbsSavedInfo
    {
        public override int Constructor
        {
            get
            {
                return -74456004;
            }
        }

        public int Flags { get; set; }
		public bool HasSavedCredentials { get; set; }
		public TLAbsPaymentRequestedInfo SavedInfo { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				HasSavedCredentials = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				SavedInfo = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(HasSavedCredentials, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(SavedInfo, bw);
			
        }
    }
}