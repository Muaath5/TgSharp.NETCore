using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-209768682)]
    public class TLFavedStickers : TgSharp.TL.Messages.TLAbsFavedStickers
    {
        public override int Constructor
        {
            get
            {
                return -209768682;
            }
        }

        
		public int Hash { get; set; }
		public TLVector<TLAbsStickerPack> Packs { get; set; }
		public TLVector<TLAbsDocument> Stickers { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
			Packs = (TLVector<TLAbsStickerPack>)ObjectUtils.DeserializeObject(br);
			Stickers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
			ObjectUtils.SerializeObject(Packs, bw);
			ObjectUtils.SerializeObject(Stickers, bw);
			
        }
    }
}