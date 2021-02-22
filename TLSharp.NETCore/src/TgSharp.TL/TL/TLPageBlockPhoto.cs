using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(391759200)]
    public class TLPageBlockPhoto : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 391759200;
            }
        }

        public int Flags { get; set; }
		public long PhotoId { get; set; }
		public TLAbsPageCaption Caption { get; set; }
		public string Url { get; set; }
		public long WebpageId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();PhotoId = br.ReadInt64();
			Caption = (TLAbsPageCaption)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Url = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				WebpageId = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PhotoId);
			ObjectUtils.SerializeObject(Caption, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Url, bw);
			if ((Flags & 2) != 0)
	bw.Write(WebpageId);
			
        }
    }
}