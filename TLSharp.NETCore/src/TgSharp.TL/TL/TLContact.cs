using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-116274796)]
    public class TLContact : TLAbsContact
    {
        public override int Constructor
        {
            get
            {
                return -116274796;
            }
        }

        
		public int UserId { get; set; }
		public TLAbsBool Mutual { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			Mutual = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			ObjectUtils.SerializeObject(Mutual, bw);
			
        }
    }
}