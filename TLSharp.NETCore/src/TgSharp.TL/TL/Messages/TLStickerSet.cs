using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1240849242)]
    public class TLStickerSet : TgSharp.TL.Messages.TLAbsStickerSet
    {
        public override int Constructor
        {
            get
            {
                return -1240849242;
            }
        }

        
		public TLAbsStickerSet Set { get; set; }
		public TLVector<TLAbsStickerPack> Packs { get; set; }
		public TLVector<TLAbsDocument> Documents { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Set = (TLAbsStickerSet)ObjectUtils.DeserializeObject(br);
			Packs = (TLVector<TLAbsStickerPack>)ObjectUtils.DeserializeObject(br);
			Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Set, bw);
			ObjectUtils.SerializeObject(Packs, bw);
			ObjectUtils.SerializeObject(Documents, bw);
			
        }
    }
}