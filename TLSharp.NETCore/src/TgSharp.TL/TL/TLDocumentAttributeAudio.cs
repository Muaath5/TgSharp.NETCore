using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1739392570)]
    public class TLDocumentAttributeAudio : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return -1739392570;
            }
        }

        public int Flags { get; set; }
		public bool Voice { get; set; }
		public int Duration { get; set; }
		public string Title { get; set; }
		public string Performer { get; set; }
		public byte[] Waveform { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 8) != 0)
				Voice = (bool)ObjectUtils.DeserializeObject(br);
			Duration = br.ReadInt32();
			if ((Flags & 2) != 0)
				Title = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Performer = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Waveform = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Voice, bw);
			bw.Write(Duration);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Title, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Performer, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Waveform, bw);
			
        }
    }
}