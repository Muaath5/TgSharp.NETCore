using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Auth
{
    [TLObject(-661144474)]
    public class TLRequestRequestPasswordRecovery : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -661144474;
            }
        }

        
		public Auth.TLAbsPasswordRecovery Response { get; set; }

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
            Response = (Auth.TLAbsPasswordRecovery)ObjectUtils.DeserializeObject(br);
        }
    }
}