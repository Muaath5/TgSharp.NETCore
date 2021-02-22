using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1123585836)]
    public class TLUpdateMessagePollVote : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1123585836;
            }
        }

        
		public long PollId { get; set; }
		public int UserId { get; set; }
		public TLVector<byte[]> Options { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PollId = br.ReadInt64();
			UserId = br.ReadInt32();
			Options = (TLVector<byte[]>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PollId);
			bw.Write(UserId);
			ObjectUtils.SerializeObject(Options, bw);
			
        }
    }
}