using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(598418386)]
    public class TLInputMediaDocument : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 598418386;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputDocument Id { get; set; }
		public int TtlSeconds { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
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