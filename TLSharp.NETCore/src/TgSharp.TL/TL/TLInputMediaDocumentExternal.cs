using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-78455655)]
    public class TLInputMediaDocumentExternal : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -78455655;
            }
        }

        public int Flags { get; set; }
		public string Url { get; set; }
		public int TtlSeconds { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Url = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				TtlSeconds = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Url, bw);
			if ((Flags & 2) != 0)
	bw.Write(TtlSeconds);
			
        }
    }
}