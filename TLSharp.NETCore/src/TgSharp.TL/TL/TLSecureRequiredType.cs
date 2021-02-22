using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2103600678)]
    public class TLSecureRequiredType : TLAbsSecureRequiredType
    {
        public override int Constructor
        {
            get
            {
                return -2103600678;
            }
        }

        public int Flags { get; set; }
		public bool NativeNames { get; set; }
		public bool SelfieRequired { get; set; }
		public bool TranslationRequired { get; set; }
		public TLAbsSecureValueType Type { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				NativeNames = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SelfieRequired = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				TranslationRequired = (bool)ObjectUtils.DeserializeObject(br);
			Type = (TLAbsSecureValueType)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(NativeNames, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SelfieRequired, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(TranslationRequired, bw);
			ObjectUtils.SerializeObject(Type, bw);
			
        }
    }
}