using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(1577067778)]
    public class TLSentCode : TgSharp.TL.Auth.TLAbsSentCode
    {
        public override int Constructor
        {
            get
            {
                return 1577067778;
            }
        }

        public int Flags { get; set; }
		public Auth.TLAbsSentCodeType Type { get; set; }
		public string PhoneCodeHash { get; set; }
		public Auth.TLAbsCodeType NextType { get; set; }
		public int Timeout { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Type = (TLAbsSentCodeType)ObjectUtils.DeserializeObject(br);
			PhoneCodeHash = StringUtil.Deserialize(br);
			NextType = (TLAbsCodeType)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Timeout = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type, bw);
			StringUtil.Serialize(PhoneCodeHash, bw);
			ObjectUtils.SerializeObject(NextType, bw);
			if ((Flags & 0) != 0)
	bw.Write(Timeout);
			
        }
    }
}