using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(1654593920)]
    public class TLLoginToken : TgSharp.TL.Auth.TLAbsLoginToken
    {
        public override int Constructor
        {
            get
            {
                return 1654593920;
            }
        }

        
		public int Expires { get; set; }
		public byte[] Token { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();
			Token = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Expires);
			ObjectUtils.SerializeObject(Token, bw);
			
        }
    }
}