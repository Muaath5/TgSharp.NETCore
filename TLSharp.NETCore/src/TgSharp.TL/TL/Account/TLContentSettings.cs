using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1474462241)]
    public class TLContentSettings : TgSharp.TL.Account.TLAbsContentSettings
    {
        public override int Constructor
        {
            get
            {
                return 1474462241;
            }
        }

        public int Flags { get; set; }
		public bool SensitiveEnabled { get; set; }
		public bool SensitiveCanChange { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				SensitiveEnabled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SensitiveCanChange = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(SensitiveEnabled, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SensitiveCanChange, bw);
			
        }
    }
}