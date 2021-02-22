using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(84438264)]
    public class TLWallPaperSettings : TLAbsWallPaperSettings
    {
        public override int Constructor
        {
            get
            {
                return 84438264;
            }
        }

        public int Flags { get; set; }
		public bool Blur { get; set; }
		public bool Motion { get; set; }
		public int BackgroundColor { get; set; }
		public int SecondBackgroundColor { get; set; }
		public int Intensity { get; set; }
		public int Rotation { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Blur = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Motion = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				BackgroundColor = br.ReadInt32();
			if ((Flags & 6) != 0)
				SecondBackgroundColor = br.ReadInt32();
			if ((Flags & 1) != 0)
				Intensity = br.ReadInt32();
			if ((Flags & 6) != 0)
				Rotation = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Blur, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Motion, bw);
			if ((Flags & 2) != 0)
	bw.Write(BackgroundColor);
			if ((Flags & 6) != 0)
	bw.Write(SecondBackgroundColor);
			if ((Flags & 1) != 0)
	bw.Write(Intensity);
			if ((Flags & 6) != 0)
	bw.Write(Rotation);
			
        }
    }
}