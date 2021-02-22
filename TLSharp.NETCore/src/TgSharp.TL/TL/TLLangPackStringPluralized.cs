using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1816636575)]
    public class TLLangPackStringPluralized : TLAbsLangPackString
    {
        public override int Constructor
        {
            get
            {
                return 1816636575;
            }
        }

        public int Flags { get; set; }
		public string Key { get; set; }
		public string ZeroValue { get; set; }
		public string OneValue { get; set; }
		public string TwoValue { get; set; }
		public string FewValue { get; set; }
		public string ManyValue { get; set; }
		public string OtherValue { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Key = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				ZeroValue = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				OneValue = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				TwoValue = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				FewValue = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				ManyValue = StringUtil.Deserialize(br);
			OtherValue = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Key, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(ZeroValue, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(OneValue, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(TwoValue, bw);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(FewValue, bw);
			if ((Flags & 6) != 0)
	StringUtil.Serialize(ManyValue, bw);
			StringUtil.Serialize(OtherValue, bw);
			
        }
    }
}