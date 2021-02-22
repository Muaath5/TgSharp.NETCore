using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(-855308010)]
    public class TLAuthorization : TgSharp.TL.Auth.TLAbsAuthorization
    {
        public override int Constructor
        {
            get
            {
                return -855308010;
            }
        }

        public int Flags { get; set; }
		public int TmpSessions { get; set; }
		public TLAbsUser User { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				TmpSessions = br.ReadInt32();
			User = (TLAbsUser)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	bw.Write(TmpSessions);
			ObjectUtils.SerializeObject(User, bw);
			
        }
    }
}