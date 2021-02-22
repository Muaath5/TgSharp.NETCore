using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-288727837)]
    public class TLLangPackLanguage : TLAbsLangPackLanguage
    {
        public override int Constructor
        {
            get
            {
                return -288727837;
            }
        }

        public int Flags { get; set; }
		public bool Official { get; set; }
		public bool Rtl { get; set; }
		public bool Beta { get; set; }
		public string Name { get; set; }
		public string NativeName { get; set; }
		public string LangCode { get; set; }
		public string BaseLangCode { get; set; }
		public string PluralCode { get; set; }
		public int StringsCount { get; set; }
		public int TranslatedCount { get; set; }
		public string TranslationsUrl { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Official = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Rtl = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Beta = (bool)ObjectUtils.DeserializeObject(br);
			Name = StringUtil.Deserialize(br);
			NativeName = StringUtil.Deserialize(br);
			LangCode = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				BaseLangCode = StringUtil.Deserialize(br);
			PluralCode = StringUtil.Deserialize(br);
			StringsCount = br.ReadInt32();
			TranslatedCount = br.ReadInt32();
			TranslationsUrl = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Official, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Rtl, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Beta, bw);
			StringUtil.Serialize(Name, bw);
			StringUtil.Serialize(NativeName, bw);
			StringUtil.Serialize(LangCode, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(BaseLangCode, bw);
			StringUtil.Serialize(PluralCode, bw);
			bw.Write(StringsCount);
			bw.Write(TranslatedCount);
			StringUtil.Serialize(TranslationsUrl, bw);
			
        }
    }
}