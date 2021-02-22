using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-1705233435)]
    public class TLPasswordSettings : TgSharp.TL.Account.TLAbsPasswordSettings
    {
        public override int Constructor
        {
            get
            {
                return -1705233435;
            }
        }

        public int Flags { get; set; }
		public string Email { get; set; }
		public TLAbsSecureSecretSettings SecureSettings { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Email = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				SecureSettings = (TLAbsSecureSecretSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	StringUtil.Serialize(Email, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SecureSettings, bw);
			
        }
    }
}