using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(239663460)]
    public class TLUpdateBotInlineSend : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 239663460;
            }
        }

        public int Flags { get; set; }
		public int UserId { get; set; }
		public string Query { get; set; }
		public TLAbsGeoPoint Geo { get; set; }
		public string Id { get; set; }
		public TLAbsInputBotInlineMessageID MsgId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();UserId = br.ReadInt32();
			Query = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
			Id = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				MsgId = (TLAbsInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			StringUtil.Serialize(Query, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Geo, bw);
			StringUtil.Serialize(Id, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(MsgId, bw);
			
        }
    }
}