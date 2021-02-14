using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1098628881)]
    public class TLInputBotInlineMessageMediaVenue : TLAbsInputBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return 1098628881;
            }
        }

        public int Flags { get; set; }
        public TLAbsInputGeoPoint GeoPoint { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Provider { get; set; }
        public string VenueId { get; set; }
        public string VenueType { get; set; }
        public TLAbsReplyMarkup ReplyMarkup { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
            Title = StringUtil.Deserialize(br);
            Address = StringUtil.Deserialize(br);
            Provider = StringUtil.Deserialize(br);
            VenueId = StringUtil.Deserialize(br);
            VenueType = StringUtil.Deserialize(br);
            if ((Flags & 4) != 0)
                ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
            else
                ReplyMarkup = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            ObjectUtils.SerializeObject(GeoPoint, bw);
            StringUtil.Serialize(Title, bw);
            StringUtil.Serialize(Address, bw);
            StringUtil.Serialize(Provider, bw);
            StringUtil.Serialize(VenueId, bw);
            StringUtil.Serialize(VenueType, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ReplyMarkup, bw);
        }
    }
}
