using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1468953147)]
    public class TLPageBlockEmbed : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return -1468953147;
            }
        }

        public int Flags { get; set; }
		public bool FullWidth { get; set; }
		public bool AllowScrolling { get; set; }
		public string Url { get; set; }
		public string Html { get; set; }
		public long PosterPhotoId { get; set; }
		public int W { get; set; }
		public int H { get; set; }
		public TLAbsPageCaption Caption { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				FullWidth = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				AllowScrolling = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Url = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Html = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				PosterPhotoId = br.ReadInt64();
			if ((Flags & 7) != 0)
				W = br.ReadInt32();
			if ((Flags & 7) != 0)
				H = br.ReadInt32();
			Caption = (TLAbsPageCaption)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(FullWidth, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(AllowScrolling, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Url, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Html, bw);
			if ((Flags & 6) != 0)
	bw.Write(PosterPhotoId);
			if ((Flags & 7) != 0)
	bw.Write(W);
			if ((Flags & 7) != 0)
	bw.Write(H);
			ObjectUtils.SerializeObject(Caption, bw);
			
        }
    }
}