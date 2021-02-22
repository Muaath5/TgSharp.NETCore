using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-884757282)]
    public class TLStatsAbsValueAndPrev : TLAbsStatsAbsValueAndPrev
    {
        public override int Constructor
        {
            get
            {
                return -884757282;
            }
        }

        
		public double Current { get; set; }
		public double Previous { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Current = br.ReadDouble();
			Previous = br.ReadDouble();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Current);
			bw.Write(Previous);
			
        }
    }
}