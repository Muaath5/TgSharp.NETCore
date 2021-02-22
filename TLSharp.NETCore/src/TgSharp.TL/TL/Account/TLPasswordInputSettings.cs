using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1036572727)]
    public class TLPasswordInputSettings : TgSharp.TL.Account.TLAbsPasswordInputSettings
    {
        public override int Constructor
        {
            get
            {
                return -1036572727;
            }
        }

        public int Flags { get; set; }
		public TLAbsPasswordKdfAlgo NewAlgo { get; set; }
		public byte[] NewPasswordHash { get; set; }
		public string Hint { get; set; }
		public string Email { get; set; }
		public TLAbsSecureSecretSettings NewSecureSettings { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				NewAlgo = (TLAbsPasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				NewPasswordHash = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Hint = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Email = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				NewSecureSettings = (TLAbsSecureSecretSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(NewAlgo, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(NewPasswordHash, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Hint, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Email, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(NewSecureSettings, bw);
			
        }
    }
}