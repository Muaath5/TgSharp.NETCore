using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(1062645411)]
    public class TLPaymentForm : TgSharp.TL.Payments.TLAbsPaymentForm
    {
        public override int Constructor
        {
            get
            {
                return 1062645411;
            }
        }

        public int Flags { get; set; }
		public bool CanSaveCredentials { get; set; }
		public bool PasswordMissing { get; set; }
		public int BotId { get; set; }
		public TLAbsInvoice Invoice { get; set; }
		public int ProviderId { get; set; }
		public string Url { get; set; }
		public string NativeProvider { get; set; }
		public TLAbsDataJSON NativeParams { get; set; }
		public TLAbsPaymentRequestedInfo SavedInfo { get; set; }
		public TLAbsPaymentSavedCredentials SavedCredentials { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 0) != 0)
				CanSaveCredentials = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				PasswordMissing = (bool)ObjectUtils.DeserializeObject(br);
			BotId = br.ReadInt32();
			Invoice = (TLAbsInvoice)ObjectUtils.DeserializeObject(br);
			ProviderId = br.ReadInt32();
			Url = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				NativeProvider = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				NativeParams = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				SavedInfo = (TLAbsPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SavedCredentials = (TLAbsPaymentSavedCredentials)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(CanSaveCredentials, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(PasswordMissing, bw);
			bw.Write(BotId);
			ObjectUtils.SerializeObject(Invoice, bw);
			bw.Write(ProviderId);
			StringUtil.Serialize(Url, bw);
			if ((Flags & 6) != 0)
	StringUtil.Serialize(NativeProvider, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(NativeParams, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(SavedInfo, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SavedCredentials, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}