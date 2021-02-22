using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(512177195)]
    public class TLDocument : TLAbsDocument
    {
        public override int Constructor
        {
            get
            {
                return 512177195;
            }
        }

        public int Flags { get; set; }
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public int Date { get; set; }
		public string MimeType { get; set; }
		public int Size { get; set; }
		public TLVector<TLAbsPhotoSize> Thumbs { get; set; }
		public TLVector<TLAbsVideoSize> VideoThumbs { get; set; }
		public int DcId { get; set; }
		public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			FileReference = (byte[])ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			MimeType = StringUtil.Deserialize(br);
			Size = br.ReadInt32();
			if ((Flags & 2) != 0)
				Thumbs = (TLVector<TLAbsPhotoSize>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				VideoThumbs = (TLVector<TLAbsVideoSize>)ObjectUtils.DeserializeObject(br);
			DcId = br.ReadInt32();
			Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			bw.Write(AccessHash);
			ObjectUtils.SerializeObject(FileReference, bw);
			bw.Write(Date);
			StringUtil.Serialize(MimeType, bw);
			bw.Write(Size);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Thumbs, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(VideoThumbs, bw);
			bw.Write(DcId);
			ObjectUtils.SerializeObject(Attributes, bw);
			
        }
    }
}