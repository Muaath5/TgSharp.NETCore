using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1272375192)]
    public class TLMessageMediaPoll : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return 1272375192;
            }
        }

        
		public TLAbsPoll Poll { get; set; }
		public TLAbsPollResults Results { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
			Results = (TLAbsPollResults)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Poll, bw);
			ObjectUtils.SerializeObject(Results, bw);
			
        }
    }
}