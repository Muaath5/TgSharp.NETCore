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
    public class TLPaymentForm : TLObject
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
        public TLInvoice Invoice { get; set; }
        public int ProviderId { get; set; }
        public string Url { get; set; }
        public string NativeProvider { get; set; }
        public TLDataJSON NativeParams { get; set; }
        public TLPaymentRequestedInfo SavedInfo { get; set; }
        // manual edit: PaymentSavedCredentials -> TLPaymentSavedCredentialsCard
        public TLPaymentSavedCredentialsCard SavedCredentials { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            CanSaveCredentials = (Flags & 4) != 0;
            PasswordMissing = (Flags & 8) != 0;
            BotId = br.ReadInt32();
            Invoice = (TLInvoice)ObjectUtils.DeserializeObject(br);
            ProviderId = br.ReadInt32();
            Url = StringUtil.Deserialize(br);
            if ((Flags & 16) != 0)
                NativeProvider = StringUtil.Deserialize(br);
            else
                NativeProvider = null;

            if ((Flags & 16) != 0)
                NativeParams = (TLDataJSON)ObjectUtils.DeserializeObject(br);
            else
                NativeParams = null;

            if ((Flags & 1) != 0)
                SavedInfo = (TLPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
            else
                SavedInfo = null;

            if ((Flags & 2) != 0)
                // manual edit: PaymentSavedCredentials -> TLPaymentSavedCredentialsCard
                SavedCredentials = (TLPaymentSavedCredentialsCard)ObjectUtils.DeserializeObject(br);
            else
                SavedCredentials = null;

            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            bw.Write(BotId);
            ObjectUtils.SerializeObject(Invoice, bw);
            bw.Write(ProviderId);
            StringUtil.Serialize(Url, bw);
            if ((Flags & 16) != 0)
                StringUtil.Serialize(NativeProvider, bw);
            if ((Flags & 16) != 0)
                ObjectUtils.SerializeObject(NativeParams, bw);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(SavedInfo, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(SavedCredentials, bw);
            ObjectUtils.SerializeObject(Users, bw);
        }
    }
}
