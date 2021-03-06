using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1823064809)]
    public class TLPollAnswer : TLAbsPollAnswer
    {
        public override int Constructor
        {
            get
            {
                return 1823064809;
            }
        }

        
		public string Text { get; set; }
		public byte[] Option { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);
			Option = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Text, bw);
			ObjectUtils.SerializeObject(Option, bw);
			
        }
    }
}