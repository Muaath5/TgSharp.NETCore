using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1297942941)]
    public class TLGeoPoint : TLAbsGeoPoint
    {
        public override int Constructor
        {
            get
            {
                return -1297942941;
            }
        }

        public int Flags { get; set; }
		public double Long { get; set; }
		public double Lat { get; set; }
		public long AccessHash { get; set; }
		public int AccuracyRadius { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Long = br.ReadDouble();
			Lat = br.ReadDouble();
			AccessHash = br.ReadInt64();
			if ((Flags & 2) != 0)
				AccuracyRadius = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Long);
			bw.Write(Lat);
			bw.Write(AccessHash);
			if ((Flags & 2) != 0)
	bw.Write(AccuracyRadius);
			
        }
    }
}