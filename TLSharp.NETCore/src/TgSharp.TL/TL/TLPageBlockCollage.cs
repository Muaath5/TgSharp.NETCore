using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1705048653)]
    public class TLPageBlockCollage : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 1705048653;
            }
        }

        
		public TLVector<TLAbsPageBlock> Items { get; set; }
		public TLAbsPageCaption Caption { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Items = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeObject(br);
			Caption = (TLAbsPageCaption)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Items, bw);
			ObjectUtils.SerializeObject(Caption, bw);
			
        }
    }
}