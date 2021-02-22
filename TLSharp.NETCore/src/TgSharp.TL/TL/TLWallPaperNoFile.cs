using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1963717851)]
    public class TLWallPaperNoFile : TLAbsWallPaper
    {
        public override int Constructor
        {
            get
            {
                return -1963717851;
            }
        }

        public int Flags { get; set; }
		public bool Default { get; set; }
		public bool Dark { get; set; }
		public TLAbsWallPaperSettings Settings { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Default = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Settings = (TLAbsWallPaperSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Default, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			
        }
    }
}