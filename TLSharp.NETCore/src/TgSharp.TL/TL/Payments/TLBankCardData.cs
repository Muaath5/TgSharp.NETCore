using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(1042605427)]
    public class TLBankCardData : TgSharp.TL.Payments.TLAbsBankCardData
    {
        public override int Constructor
        {
            get
            {
                return 1042605427;
            }
        }

        
		public string Title { get; set; }
		public TLVector<TLAbsBankCardOpenUrl> OpenUrls { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);
			OpenUrls = (TLVector<TLAbsBankCardOpenUrl>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Title, bw);
			ObjectUtils.SerializeObject(OpenUrls, bw);
			
        }
    }
}