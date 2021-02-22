using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-1014526429)]
    public class TLCountry : TgSharp.TL.Help.TLAbsCountry
    {
        public override int Constructor
        {
            get
            {
                return -1014526429;
            }
        }

        public int Flags { get; set; }
		public bool Hidden { get; set; }
		public string Iso2 { get; set; }
		public string DefaultName { get; set; }
		public string Name { get; set; }
		public TLVector<TLAbsCountryCode> CountryCodes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Hidden = (bool)ObjectUtils.DeserializeObject(br);
			Iso2 = StringUtil.Deserialize(br);
			DefaultName = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Name = StringUtil.Deserialize(br);
			CountryCodes = (TLVector<TLAbsCountryCode>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Hidden, bw);
			StringUtil.Serialize(Iso2, bw);
			StringUtil.Serialize(DefaultName, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Name, bw);
			ObjectUtils.SerializeObject(CountryCodes, bw);
			
        }
    }
}