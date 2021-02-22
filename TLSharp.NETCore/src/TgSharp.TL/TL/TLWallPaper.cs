using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1539849235)]
    public class TLWallPaper : TLAbsWallPaper
    {
        public override int Constructor
        {
            get
            {
                return -1539849235;
            }
        }

        
		public long Id { get; set; }
		public int Flags { get; set; }
		public bool Creator { get; set; }
		public bool Default { get; set; }
		public bool Pattern { get; set; }
		public bool Dark { get; set; }
		public long AccessHash { get; set; }
		public string Slug { get; set; }
		public TLAbsDocument Document { get; set; }
		public TLAbsWallPaperSettings Settings { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
			Flags = br.ReadInt32();
			if ((Flags & 2) != 0)
				Creator = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Default = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Pattern = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			AccessHash = br.ReadInt64();
			Slug = StringUtil.Deserialize(br);
			Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Settings = (TLAbsWallPaperSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			ObjectUtils.SerializeObject(Flags, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Creator, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Default, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Pattern, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			bw.Write(AccessHash);
			StringUtil.Serialize(Slug, bw);
			ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			
        }
    }
}