using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1230257343)]
    public class TLFeaturedStickers : TgSharp.TL.Messages.TLAbsFeaturedStickers
    {
        public override int Constructor
        {
            get
            {
                return -1230257343;
            }
        }

        
		public int Hash { get; set; }
		public int Count { get; set; }
		public TLVector<TLAbsStickerSetCovered> Sets { get; set; }
		public TLVector<long> Unread { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
			Count = br.ReadInt32();
			Sets = (TLVector<TLAbsStickerSetCovered>)ObjectUtils.DeserializeObject(br);
			Unread = (TLVector<long>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
			bw.Write(Count);
			ObjectUtils.SerializeObject(Sets, bw);
			ObjectUtils.SerializeObject(Unread, bw);
			
        }
    }
}