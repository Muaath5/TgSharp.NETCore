using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1754754159)]
    public class TLRequestRegisterDevice : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1754754159;
            }
        }

        public int Flags { get; set; }
		public bool NoMuted { get; set; }
		public int TokenType { get; set; }
		public string Token { get; set; }
		public TLAbsBool AppSandbox { get; set; }
		public byte[] Secret { get; set; }
		public TLVector<int> OtherUids { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				NoMuted = (bool)ObjectUtils.DeserializeObject(br);
			TokenType = br.ReadInt32();
			Token = StringUtil.Deserialize(br);
			AppSandbox = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			Secret = (byte[])ObjectUtils.DeserializeObject(br);
			OtherUids = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(NoMuted, bw);
			bw.Write(TokenType);
			StringUtil.Serialize(Token, bw);
			ObjectUtils.SerializeObject(AppSandbox, bw);
			ObjectUtils.SerializeObject(Secret, bw);
			ObjectUtils.SerializeObject(OtherUids, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}