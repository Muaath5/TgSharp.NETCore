using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(85477117)]
    public class TLBotInlineMessageMediaGeo : TLAbsBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return 85477117;
            }
        }

        public int Flags { get; set; }
		public TLAbsGeoPoint Geo { get; set; }
		public int Heading { get; set; }
		public int Period { get; set; }
		public int ProximityNotificationRadius { get; set; }
		public TLAbsReplyMarkup ReplyMarkup { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Heading = br.ReadInt32();
			if ((Flags & 3) != 0)
				Period = br.ReadInt32();
			if ((Flags & 1) != 0)
				ProximityNotificationRadius = br.ReadInt32();
			if ((Flags & 0) != 0)
				ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Geo, bw);
			if ((Flags & 2) != 0)
	bw.Write(Heading);
			if ((Flags & 3) != 0)
	bw.Write(Period);
			if ((Flags & 1) != 0)
	bw.Write(ProximityNotificationRadius);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReplyMarkup, bw);
			
        }
    }
}