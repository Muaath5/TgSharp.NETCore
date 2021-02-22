using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(1148485274)]
    public class TLAuthorizationSignUpRequired : TgSharp.TL.Auth.TLAbsAuthorization
    {
        public override int Constructor
        {
            get
            {
                return 1148485274;
            }
        }

        public int Flags { get; set; }
		public Help.TLAbsTermsOfService TermsOfService { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();TermsOfService = (Help.TLAbsTermsOfService)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(TermsOfService, bw);
			
        }
    }
}