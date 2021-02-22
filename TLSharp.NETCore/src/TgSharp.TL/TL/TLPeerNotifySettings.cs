using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1353671392)]
    public class TLPeerNotifySettings : TLAbsPeerNotifySettings
    {
        public override int Constructor
        {
            get
            {
                return -1353671392;
            }
        }

        public int Flags { get; set; }
		public TLAbsBool ShowPreviews { get; set; }
		public TLAbsBool Silent { get; set; }
		public int MuteUntil { get; set; }
		public string Sound { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				ShowPreviews = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Silent = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				MuteUntil = br.ReadInt32();
			if ((Flags & 1) != 0)
				Sound = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ShowPreviews, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Silent, bw);
			if ((Flags & 0) != 0)
	bw.Write(MuteUntil);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Sound, bw);
			
        }
    }
}