using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(1107543535)]
    public class TLCountryCode : TgSharp.TL.Help.TLAbsCountryCode
    {
        public override int Constructor
        {
            get
            {
                return 1107543535;
            }
        }

        public int Flags { get; set; }
		public string CountryCode { get; set; }
		public TLVector<string> Prefixes { get; set; }
		public TLVector<string> Patterns { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();CountryCode = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Prefixes = (TLVector<string>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Patterns = (TLVector<string>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(CountryCode, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Prefixes, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Patterns, bw);
			
        }
    }
}