using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1096616924)]
    public class TLGlobalPrivacySettings : TLAbsGlobalPrivacySettings
    {
        public override int Constructor
        {
            get
            {
                return -1096616924;
            }
        }

        public int Flags { get; set; }
		public TLAbsBool ArchiveAndMuteNewNoncontactPeers { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				ArchiveAndMuteNewNoncontactPeers = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ArchiveAndMuteNewNoncontactPeers, bw);
			
        }
    }
}