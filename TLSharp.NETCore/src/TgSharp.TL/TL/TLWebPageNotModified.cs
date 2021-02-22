using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1930545681)]
    public class TLWebPageNotModified : TLAbsWebPage
    {
        public override int Constructor
        {
            get
            {
                return 1930545681;
            }
        }

        public int Flags { get; set; }
		public int CachedPageViews { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				CachedPageViews = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	bw.Write(CachedPageViews);
			
        }
    }
}