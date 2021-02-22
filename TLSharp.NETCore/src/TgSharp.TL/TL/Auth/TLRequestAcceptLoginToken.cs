using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(-392909491)]
    public class TLRequestAcceptLoginToken : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -392909491;
            }
        }

        
		public byte[] Token { get; set; }
		public TLAbsAuthorization Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Token = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Token, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsAuthorization)ObjectUtils.DeserializeObject(br);
        }
    }
}