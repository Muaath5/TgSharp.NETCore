using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(2061776695)]
    public class TLRequestInstallTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2061776695;
            }
        }

        public int Flags { get; set; }
		public bool Dark { get; set; }
		public string Format { get; set; }
		public TLAbsInputTheme Theme { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Format = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Theme = (TLAbsInputTheme)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Format, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Theme, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}