using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-994444869)]
    public class TLError : TLAbsError
    {
        public override int Constructor
        {
            get
            {
                return -994444869;
            }
        }

        
		public int Code { get; set; }
		public string Text { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Code = br.ReadInt32();
			Text = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Code);
			StringUtil.Serialize(Text, bw);
			
        }
    }
}