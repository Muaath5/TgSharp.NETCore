using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2054649973)]
    public class TLUpdatePinnedChannelMessages : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -2054649973;
            }
        }

        public int Flags { get; set; }
		public bool Pinned { get; set; }
		public int ChannelId { get; set; }
		public TLVector<int> Messages { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Pinned = (bool)ObjectUtils.DeserializeObject(br);
			ChannelId = br.ReadInt32();
			Messages = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			Pts = br.ReadInt32();
			PtsCount = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Pinned, bw);
			bw.Write(ChannelId);
			ObjectUtils.SerializeObject(Messages, bw);
			bw.Write(Pts);
			bw.Write(PtsCount);
			
        }
    }
}