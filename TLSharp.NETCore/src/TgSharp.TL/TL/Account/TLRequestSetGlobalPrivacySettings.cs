using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(517647042)]
    public class TLRequestSetGlobalPrivacySettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 517647042;
            }
        }

        
		public TLAbsGlobalPrivacySettings Settings { get; set; }
		public TLAbsGlobalPrivacySettings Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Settings = (TLAbsGlobalPrivacySettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Settings, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsGlobalPrivacySettings)ObjectUtils.DeserializeObject(br);
        }
    }
}