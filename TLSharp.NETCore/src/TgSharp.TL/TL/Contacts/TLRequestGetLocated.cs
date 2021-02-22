using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(-750207932)]
    public class TLRequestGetLocated : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -750207932;
            }
        }

        public int Flags { get; set; }
		public bool Background { get; set; }
		public TLAbsInputGeoPoint GeoPoint { get; set; }
		public int SelfExpires { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				Background = (bool)ObjectUtils.DeserializeObject(br);
			GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				SelfExpires = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Background, bw);
			ObjectUtils.SerializeObject(GeoPoint, bw);
			if ((Flags & 2) != 0)
	bw.Write(SelfExpires);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}