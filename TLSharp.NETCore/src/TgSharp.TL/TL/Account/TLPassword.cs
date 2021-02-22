using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1390001672)]
    public class TLPassword : TgSharp.TL.Account.TLAbsPassword
    {
        public override int Constructor
        {
            get
            {
                return -1390001672;
            }
        }

        public int Flags { get; set; }
		public bool HasRecovery { get; set; }
		public bool HasSecureValues { get; set; }
		public bool HasPassword { get; set; }
		public TLAbsPasswordKdfAlgo CurrentAlgo { get; set; }
		public byte[] SrpB { get; set; }
		public long SrpId { get; set; }
		public string Hint { get; set; }
		public string EmailUnconfirmedPattern { get; set; }
		public TLAbsPasswordKdfAlgo NewAlgo { get; set; }
		public TLAbsSecurePasswordKdfAlgo NewSecureAlgo { get; set; }
		public byte[] SecureRandom { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				HasRecovery = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				HasSecureValues = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				HasPassword = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				CurrentAlgo = (TLAbsPasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				SrpB = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				SrpId = br.ReadInt64();
			if ((Flags & 1) != 0)
				Hint = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				EmailUnconfirmedPattern = StringUtil.Deserialize(br);
			NewAlgo = (TLAbsPasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
			NewSecureAlgo = (TLAbsSecurePasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
			SecureRandom = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(HasRecovery, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(HasSecureValues, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(HasPassword, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(CurrentAlgo, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(SrpB, bw);
			if ((Flags & 0) != 0)
	bw.Write(SrpId);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Hint, bw);
			if ((Flags & 6) != 0)
	StringUtil.Serialize(EmailUnconfirmedPattern, bw);
			ObjectUtils.SerializeObject(NewAlgo, bw);
			ObjectUtils.SerializeObject(NewSecureAlgo, bw);
			ObjectUtils.SerializeObject(SecureRandom, bw);
			
        }
    }
}