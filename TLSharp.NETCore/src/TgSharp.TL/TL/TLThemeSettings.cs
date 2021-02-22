using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1676371894)]
    public class TLThemeSettings : TLAbsThemeSettings
    {
        public override int Constructor
        {
            get
            {
                return -1676371894;
            }
        }

        public int Flags { get; set; }
		public TLAbsBaseTheme BaseTheme { get; set; }
		public int AccentColor { get; set; }
		public int MessageTopColor { get; set; }
		public int MessageBottomColor { get; set; }
		public TLAbsWallPaper Wallpaper { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();BaseTheme = (TLAbsBaseTheme)ObjectUtils.DeserializeObject(br);
			AccentColor = br.ReadInt32();
			if ((Flags & 2) != 0)
				MessageTopColor = br.ReadInt32();
			if ((Flags & 2) != 0)
				MessageBottomColor = br.ReadInt32();
			if ((Flags & 3) != 0)
				Wallpaper = (TLAbsWallPaper)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(BaseTheme, bw);
			bw.Write(AccentColor);
			if ((Flags & 2) != 0)
	bw.Write(MessageTopColor);
			if ((Flags & 2) != 0)
	bw.Write(MessageBottomColor);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Wallpaper, bw);
			
        }
    }
}