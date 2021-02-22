using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-290164953)]
    public class TLStickerSet : TLAbsStickerSet
    {
        public override int Constructor
        {
            get
            {
                return -290164953;
            }
        }

        public int Flags { get; set; }
		public bool Archived { get; set; }
		public bool Official { get; set; }
		public bool Masks { get; set; }
		public bool Animated { get; set; }
		public int InstalledDate { get; set; }
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public string Title { get; set; }
		public string ShortName { get; set; }
		public TLAbsPhotoSize Thumb { get; set; }
		public int ThumbDcId { get; set; }
		public int Count { get; set; }
		public int Hash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Archived = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Official = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Masks = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Animated = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				InstalledDate = br.ReadInt32();
			Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			Title = StringUtil.Deserialize(br);
			ShortName = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				Thumb = (TLAbsPhotoSize)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				ThumbDcId = br.ReadInt32();
			Count = br.ReadInt32();
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Archived, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Official, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Masks, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Animated, bw);
			if ((Flags & 2) != 0)
	bw.Write(InstalledDate);
			bw.Write(Id);
			bw.Write(AccessHash);
			StringUtil.Serialize(Title, bw);
			StringUtil.Serialize(ShortName, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Thumb, bw);
			if ((Flags & 6) != 0)
	bw.Write(ThumbDcId);
			bw.Write(Count);
			bw.Write(Hash);
			
        }
    }
}