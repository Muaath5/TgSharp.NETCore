using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(405695855)]
    public class TLRequestGetWebAuthorizations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 405695855;
            }
        }

        
		public Account.TLAbsWebAuthorizations Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Account.TLAbsWebAuthorizations)ObjectUtils.DeserializeObject(br);
        }
    }
}