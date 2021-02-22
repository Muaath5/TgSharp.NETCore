using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-990308245)]
    public class TLRequestGetConfig : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -990308245;
            }
        }

        
		public TLAbsConfig Response { get; set; }

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
            Response = (TLAbsConfig)ObjectUtils.DeserializeObject(br);
        }
    }
}