using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(1997180532)]
    public class TLRequestValidateRequestedInfo : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1997180532;
            }
        }

        public int Flags { get; set; }
		public bool Save { get; set; }
		public int MsgId { get; set; }
		public TLAbsPaymentRequestedInfo Info { get; set; }
		public Payments.TLAbsValidatedRequestedInfo Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Save = (bool)ObjectUtils.DeserializeObject(br);
			MsgId = br.ReadInt32();
			Info = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Save, bw);
			bw.Write(MsgId);
			ObjectUtils.SerializeObject(Info, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Payments.TLAbsValidatedRequestedInfo)ObjectUtils.DeserializeObject(br);
        }
    }
}