using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1567730343)]
    public class TLMessageUserVote : TLAbsMessageUserVote
    {
        public override int Constructor
        {
            get
            {
                return -1567730343;
            }
        }

        
		public int UserId { get; set; }
		public byte[] Option { get; set; }
		public int Date { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			Option = (byte[])ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			ObjectUtils.SerializeObject(Option, bw);
			bw.Write(Date);
			
        }
    }
}