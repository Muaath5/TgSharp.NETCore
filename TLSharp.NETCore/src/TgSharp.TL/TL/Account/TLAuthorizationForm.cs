using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1389486888)]
    public class TLAuthorizationForm : TgSharp.TL.Account.TLAbsAuthorizationForm
    {
        public override int Constructor
        {
            get
            {
                return -1389486888;
            }
        }

        public int Flags { get; set; }
		public TLVector<TLAbsSecureRequiredType> RequiredTypes { get; set; }
		public TLVector<TLAbsSecureValue> Values { get; set; }
		public TLVector<TLAbsSecureValueError> Errors { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }
		public string PrivacyPolicyUrl { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();RequiredTypes = (TLVector<TLAbsSecureRequiredType>)ObjectUtils.DeserializeObject(br);
			Values = (TLVector<TLAbsSecureValue>)ObjectUtils.DeserializeObject(br);
			Errors = (TLVector<TLAbsSecureValueError>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				PrivacyPolicyUrl = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(RequiredTypes, bw);
			ObjectUtils.SerializeObject(Values, bw);
			ObjectUtils.SerializeObject(Errors, bw);
			ObjectUtils.SerializeObject(Users, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(PrivacyPolicyUrl, bw);
			
        }
    }
}