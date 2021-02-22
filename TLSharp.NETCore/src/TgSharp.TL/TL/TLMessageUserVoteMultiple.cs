using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(244310238)]
    public class TLMessageUserVoteMultiple : TLAbsMessageUserVote
    {
        public override int Constructor
        {
            get
            {
                return 244310238;
            }
        }

        
		public int UserId { get; set; }
		public TLVector<byte[]> Options { get; set; }
		public int Date { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			Options = (TLVector<byte[]>)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			ObjectUtils.SerializeObject(Options, bw);
			bw.Write(Date);
			
        }
    }
}