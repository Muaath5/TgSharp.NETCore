using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(307276766)]
    public class TLAuthorizations : TgSharp.TL.Account.TLAbsAuthorizations
    {
        public override int Constructor
        {
            get
            {
                return 307276766;
            }
        }

        
		public TLVector<TLAbsAuthorization> Authorizations { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Authorizations = (TLVector<TLAbsAuthorization>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Authorizations, bw);
			
        }
    }
}