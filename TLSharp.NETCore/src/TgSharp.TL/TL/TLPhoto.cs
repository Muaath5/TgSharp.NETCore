using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-82216347)]
    public class TLPhoto : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return -82216347;
            }
        }

        public int Flags { get; set; }
		public bool HasStickers { get; set; }
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public int Date { get; set; }
		public TLVector<TLAbsPhotoSize> Sizes { get; set; }
		public TLVector<TLAbsVideoSize> VideoSizes { get; set; }
		public int DcId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				HasStickers = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			FileReference = (byte[])ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			Sizes = (TLVector<TLAbsPhotoSize>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				VideoSizes = (TLVector<TLAbsVideoSize>)ObjectUtils.DeserializeObject(br);
			DcId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(HasStickers, bw);
			bw.Write(Id);
			bw.Write(AccessHash);
			ObjectUtils.SerializeObject(FileReference, bw);
			bw.Write(Date);
			ObjectUtils.SerializeObject(Sizes, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(VideoSizes, bw);
			bw.Write(DcId);
			
        }
    }
}