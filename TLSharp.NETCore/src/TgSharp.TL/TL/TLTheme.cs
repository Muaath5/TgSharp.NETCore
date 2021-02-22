using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(42930452)]
    public class TLTheme : TLAbsTheme
    {
        public override int Constructor
        {
            get
            {
                return 42930452;
            }
        }

        public int Flags { get; set; }
		public bool Creator { get; set; }
		public bool Default { get; set; }
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public string Slug { get; set; }
		public string Title { get; set; }
		public TLAbsDocument Document { get; set; }
		public TLAbsThemeSettings Settings { get; set; }
		public int InstallsCount { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Creator = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Default = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			Slug = StringUtil.Deserialize(br);
			Title = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Settings = (TLAbsThemeSettings)ObjectUtils.DeserializeObject(br);
			InstallsCount = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Creator, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Default, bw);
			bw.Write(Id);
			bw.Write(AccessHash);
			StringUtil.Serialize(Slug, bw);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			bw.Write(InstallsCount);
			
        }
    }
}