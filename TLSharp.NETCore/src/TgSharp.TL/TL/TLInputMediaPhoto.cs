using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1279654347)]
    public class TLInputMediaPhoto : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1279654347;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputPhoto Id { get; set; }
		public int TtlSeconds { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = (TLAbsInputPhoto)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				TtlSeconds = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id, bw);
			if ((Flags & 2) != 0)
	bw.Write(TtlSeconds);
			
        }
    }
}