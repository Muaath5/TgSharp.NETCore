using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1186937242)]
    public class TLMessageMediaGeoLive : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -1186937242;
            }
        }

        public int Flags { get; set; }
		public TLAbsGeoPoint Geo { get; set; }
		public int Heading { get; set; }
		public int Period { get; set; }
		public int ProximityNotificationRadius { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Heading = br.ReadInt32();
			Period = br.ReadInt32();
			if ((Flags & 3) != 0)
				ProximityNotificationRadius = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Geo, bw);
			if ((Flags & 2) != 0)
	bw.Write(Heading);
			bw.Write(Period);
			if ((Flags & 3) != 0)
	bw.Write(ProximityNotificationRadius);
			
        }
    }
}