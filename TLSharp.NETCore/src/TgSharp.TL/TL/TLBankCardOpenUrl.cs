using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-177732982)]
    public class TLBankCardOpenUrl : TLAbsBankCardOpenUrl
    {
        public override int Constructor
        {
            get
            {
                return -177732982;
            }
        }

        
		public string Url { get; set; }
		public string Name { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
			Name = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Url, bw);
			StringUtil.Serialize(Name, bw);
			
        }
    }
}