using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1738178803)]
    public class TLPage : TLAbsPage
    {
        public override int Constructor
        {
            get
            {
                return -1738178803;
            }
        }

        public int Flags { get; set; }
		public bool Part { get; set; }
		public bool Rtl { get; set; }
		public bool V2 { get; set; }
		public string Url { get; set; }
		public TLVector<TLAbsPageBlock> Blocks { get; set; }
		public TLVector<TLAbsPhoto> Photos { get; set; }
		public TLVector<TLAbsDocument> Documents { get; set; }
		public int Views { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Part = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Rtl = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				V2 = (bool)ObjectUtils.DeserializeObject(br);
			Url = StringUtil.Deserialize(br);
			Blocks = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeObject(br);
			Photos = (TLVector<TLAbsPhoto>)ObjectUtils.DeserializeObject(br);
			Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Views = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Part, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Rtl, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(V2, bw);
			StringUtil.Serialize(Url, bw);
			ObjectUtils.SerializeObject(Blocks, bw);
			ObjectUtils.SerializeObject(Photos, bw);
			ObjectUtils.SerializeObject(Documents, bw);
			if ((Flags & 1) != 0)
	bw.Write(Views);
			
        }
    }
}