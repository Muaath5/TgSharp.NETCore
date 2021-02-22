using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1421174295)]
    public class TLWebPageAttributeTheme : TLAbsWebPageAttribute
    {
        public override int Constructor
        {
            get
            {
                return 1421174295;
            }
        }

        public int Flags { get; set; }
		public TLVector<TLAbsDocument> Documents { get; set; }
		public TLAbsThemeSettings Settings { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Settings = (TLAbsThemeSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Documents, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			
        }
    }
}