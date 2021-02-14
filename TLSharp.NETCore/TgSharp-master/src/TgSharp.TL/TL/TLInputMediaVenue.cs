using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1052959727)]
    public class TLInputMediaVenue : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1052959727;
            }
        }

        public TLAbsInputGeoPoint GeoPoint { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Provider { get; set; }
        public string VenueId { get; set; }
        public string VenueType { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
            Title = StringUtil.Deserialize(br);
            Address = StringUtil.Deserialize(br);
            Provider = StringUtil.Deserialize(br);
            VenueId = StringUtil.Deserialize(br);
            VenueType = StringUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(GeoPoint, bw);
            StringUtil.Serialize(Title, bw);
            StringUtil.Serialize(Address, bw);
            StringUtil.Serialize(Provider, bw);
            StringUtil.Serialize(VenueId, bw);
            StringUtil.Serialize(VenueType, bw);
        }
    }
}
