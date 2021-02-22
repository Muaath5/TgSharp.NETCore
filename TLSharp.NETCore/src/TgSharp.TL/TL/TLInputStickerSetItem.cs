using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-6249322)]
    public class TLInputStickerSetItem : TLAbsInputStickerSetItem
    {
        public override int Constructor
        {
            get
            {
                return -6249322;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputDocument Document { get; set; }
		public string Emoji { get; set; }
		public TLAbsMaskCoords MaskCoords { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Document = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
			Emoji = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				MaskCoords = (TLAbsMaskCoords)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Document, bw);
			StringUtil.Serialize(Emoji, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(MaskCoords, bw);
			
        }
    }
}