using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1085412734)]
    public class TLPageBlockTable : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return -1085412734;
            }
        }

        public int Flags { get; set; }
		public bool Bordered { get; set; }
		public bool Striped { get; set; }
		public TLAbsRichText Title { get; set; }
		public TLVector<TLAbsPageTableRow> Rows { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Bordered = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Striped = (bool)ObjectUtils.DeserializeObject(br);
			Title = (TLAbsRichText)ObjectUtils.DeserializeObject(br);
			Rows = (TLVector<TLAbsPageTableRow>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Bordered, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Striped, bw);
			ObjectUtils.SerializeObject(Title, bw);
			ObjectUtils.SerializeObject(Rows, bw);
			
        }
    }
}