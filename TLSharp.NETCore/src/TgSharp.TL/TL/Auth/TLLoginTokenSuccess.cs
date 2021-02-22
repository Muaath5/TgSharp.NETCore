using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(957176926)]
    public class TLLoginTokenSuccess : TgSharp.TL.Auth.TLAbsLoginToken
    {
        public override int Constructor
        {
            get
            {
                return 957176926;
            }
        }

        
		public TLAbsAuthorization Authorization { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Authorization = (TLAbsAuthorization)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Authorization, bw);
			
        }
    }
}