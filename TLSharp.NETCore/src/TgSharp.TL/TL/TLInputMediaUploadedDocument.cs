using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1530447553)]
    public class TLInputMediaUploadedDocument : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 1530447553;
            }
        }

        public int Flags { get; set; }
		public bool NosoundVideo { get; set; }
		public bool ForceFile { get; set; }
		public TLAbsInputFile File { get; set; }
		public TLAbsInputFile Thumb { get; set; }
		public string MimeType { get; set; }
		public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }
		public TLVector<TLAbsInputDocument> Stickers { get; set; }
		public int TtlSeconds { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 1) != 0)
				NosoundVideo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				ForceFile = (bool)ObjectUtils.DeserializeObject(br);
			File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Thumb = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
			MimeType = StringUtil.Deserialize(br);
			Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Stickers = (TLVector<TLAbsInputDocument>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				TtlSeconds = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(NosoundVideo, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(ForceFile, bw);
			ObjectUtils.SerializeObject(File, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Thumb, bw);
			StringUtil.Serialize(MimeType, bw);
			ObjectUtils.SerializeObject(Attributes, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Stickers, bw);
			if ((Flags & 3) != 0)
	bw.Write(TtlSeconds);
			
        }
    }
}