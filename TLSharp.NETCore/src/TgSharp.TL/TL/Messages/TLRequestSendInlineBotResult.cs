using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(570955184)]
    public class TLRequestSendInlineBotResult : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 570955184;
            }
        }

        public int Flags { get; set; }
		public bool Silent { get; set; }
		public bool Background { get; set; }
		public bool ClearDraft { get; set; }
		public bool HideVia { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int ReplyToMsgId { get; set; }
		public long RandomId { get; set; }
		public long QueryId { get; set; }
		public string Id { get; set; }
		public int ScheduleDate { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 7) != 0)
				Silent = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Background = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				ClearDraft = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				HideVia = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				ReplyToMsgId = br.ReadInt32();
			RandomId = br.ReadInt64();
			QueryId = br.ReadInt64();
			Id = StringUtil.Deserialize(br);
			if ((Flags & 8) != 0)
				ScheduleDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Silent, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Background, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(ClearDraft, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(HideVia, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			if ((Flags & 2) != 0)
	bw.Write(ReplyToMsgId);
			bw.Write(RandomId);
			bw.Write(QueryId);
			StringUtil.Serialize(Id, bw);
			if ((Flags & 8) != 0)
	bw.Write(ScheduleDate);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}