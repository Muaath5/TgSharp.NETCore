using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stickers
{
    [TLObject(-251435136)]
    public class TLRequestCreateStickerSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -251435136;
            }
        }

        public int Flags { get; set; }
		public bool Masks { get; set; }
		public bool Animated { get; set; }
		public TLAbsInputUser UserId { get; set; }
		public string Title { get; set; }
		public string ShortName { get; set; }
		public TLAbsInputDocument Thumb { get; set; }
		public TLVector<TLAbsInputStickerSetItem> Stickers { get; set; }
		public Messages.TLAbsStickerSet Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Masks = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Animated = (bool)ObjectUtils.DeserializeObject(br);
			UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
			Title = StringUtil.Deserialize(br);
			ShortName = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Thumb = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
			Stickers = (TLVector<TLAbsInputStickerSetItem>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Masks, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Animated, bw);
			ObjectUtils.SerializeObject(UserId, bw);
			StringUtil.Serialize(Title, bw);
			StringUtil.Serialize(ShortName, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Thumb, bw);
			ObjectUtils.SerializeObject(Stickers, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsStickerSet)ObjectUtils.DeserializeObject(br);
        }
    }
}