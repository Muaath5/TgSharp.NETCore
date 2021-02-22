using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1662637586)]
    public class TLDocumentAttributeSticker : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return 1662637586;
            }
        }

        public int Flags { get; set; }
		public bool Mask { get; set; }
		public string Alt { get; set; }
		public TLAbsInputStickerSet Stickerset { get; set; }
		public TLAbsMaskCoords MaskCoords { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Mask = (bool)ObjectUtils.DeserializeObject(br);
			Alt = StringUtil.Deserialize(br);
			Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				MaskCoords = (TLAbsMaskCoords)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Mask, bw);
			StringUtil.Serialize(Alt, bw);
			ObjectUtils.SerializeObject(Stickerset, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(MaskCoords, bw);
			
        }
    }
}