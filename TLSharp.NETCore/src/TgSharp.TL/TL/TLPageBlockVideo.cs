using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(2089805750)]
    public class TLPageBlockVideo : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 2089805750;
            }
        }

        public int Flags { get; set; }
		public bool Autoplay { get; set; }
		public bool Loop { get; set; }
		public long VideoId { get; set; }
		public TLAbsPageCaption Caption { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Autoplay = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Loop = (bool)ObjectUtils.DeserializeObject(br);
			VideoId = br.ReadInt64();
			Caption = (TLAbsPageCaption)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Autoplay, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Loop, bw);
			bw.Write(VideoId);
			ObjectUtils.SerializeObject(Caption, bw);
			
        }
    }
}