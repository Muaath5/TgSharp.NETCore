using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1987480557)]
    public class TLPageBlockDetails : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 1987480557;
            }
        }

        public int Flags { get; set; }
		public bool Open { get; set; }
		public TLVector<TLAbsPageBlock> Blocks { get; set; }
		public TLAbsRichText Title { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Open = (bool)ObjectUtils.DeserializeObject(br);
			Blocks = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeObject(br);
			Title = (TLAbsRichText)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Open, bw);
			ObjectUtils.SerializeObject(Blocks, bw);
			ObjectUtils.SerializeObject(Title, bw);
			
        }
    }
}