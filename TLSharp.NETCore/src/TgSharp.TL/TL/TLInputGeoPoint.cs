using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1210199983)]
    public class TLInputGeoPoint : TLAbsInputGeoPoint
    {
        public override int Constructor
        {
            get
            {
                return 1210199983;
            }
        }

        public int Flags { get; set; }
		public double Lat { get; set; }
		public double Long { get; set; }
		public int AccuracyRadius { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Lat = br.ReadDouble();
			Long = br.ReadDouble();
			if ((Flags & 2) != 0)
				AccuracyRadius = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Lat);
			bw.Write(Long);
			if ((Flags & 2) != 0)
	bw.Write(AccuracyRadius);
			
        }
    }
}