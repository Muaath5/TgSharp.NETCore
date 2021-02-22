using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(878078826)]
    public class TLPageTableCell : TLAbsPageTableCell
    {
        public override int Constructor
        {
            get
            {
                return 878078826;
            }
        }

        public int Flags { get; set; }
		public bool Header { get; set; }
		public bool AlignCenter { get; set; }
		public bool AlignRight { get; set; }
		public bool ValignMiddle { get; set; }
		public bool ValignBottom { get; set; }
		public TLAbsRichText Text { get; set; }
		public int Colspan { get; set; }
		public int Rowspan { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Header = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				AlignCenter = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				AlignRight = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				ValignMiddle = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				ValignBottom = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Text = (TLAbsRichText)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Colspan = br.ReadInt32();
			if ((Flags & 0) != 0)
				Rowspan = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Header, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(AlignCenter, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(AlignRight, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(ValignMiddle, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(ValignBottom, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Text, bw);
			if ((Flags & 3) != 0)
	bw.Write(Colspan);
			if ((Flags & 0) != 0)
	bw.Write(Rowspan);
			
        }
    }
}