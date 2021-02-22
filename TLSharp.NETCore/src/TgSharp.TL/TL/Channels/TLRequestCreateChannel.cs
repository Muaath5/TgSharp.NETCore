using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(1029681423)]
    public class TLRequestCreateChannel : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1029681423;
            }
        }

        public int Flags { get; set; }
		public bool Broadcast { get; set; }
		public bool Megagroup { get; set; }
		public bool ForImport { get; set; }
		public string Title { get; set; }
		public string About { get; set; }
		public TLAbsInputGeoPoint GeoPoint { get; set; }
		public string Address { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Broadcast = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Megagroup = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				ForImport = (bool)ObjectUtils.DeserializeObject(br);
			Title = StringUtil.Deserialize(br);
			About = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Address = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Broadcast, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Megagroup, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ForImport, bw);
			StringUtil.Serialize(Title, bw);
			StringUtil.Serialize(About, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(GeoPoint, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Address, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}