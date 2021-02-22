using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1076714939)]
    public class TLUpdateShortChatMessage : TLAbsUpdates
    {
        public override int Constructor
        {
            get
            {
                return 1076714939;
            }
        }

        public int Flags { get; set; }
		public bool Out { get; set; }
		public bool Mentioned { get; set; }
		public bool MediaUnread { get; set; }
		public bool Silent { get; set; }
		public int Id { get; set; }
		public int FromId { get; set; }
		public int ChatId { get; set; }
		public string Message { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }
		public int Date { get; set; }
		public TLAbsMessageFwdHeader FwdFrom { get; set; }
		public int ViaBotId { get; set; }
		public TLAbsMessageReplyHeader ReplyTo { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Out = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Mentioned = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				MediaUnread = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 15) != 0)
				Silent = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			FromId = br.ReadInt32();
			ChatId = br.ReadInt32();
			Message = StringUtil.Deserialize(br);
			Pts = br.ReadInt32();
			PtsCount = br.ReadInt32();
			Date = br.ReadInt32();
			if ((Flags & 0) != 0)
				FwdFrom = (TLAbsMessageFwdHeader)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				ViaBotId = br.ReadInt32();
			if ((Flags & 1) != 0)
				ReplyTo = (TLAbsMessageReplyHeader)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Out, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Mentioned, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(MediaUnread, bw);
			if ((Flags & 15) != 0)
	ObjectUtils.SerializeObject(Silent, bw);
			bw.Write(Id);
			bw.Write(FromId);
			bw.Write(ChatId);
			StringUtil.Serialize(Message, bw);
			bw.Write(Pts);
			bw.Write(PtsCount);
			bw.Write(Date);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(FwdFrom, bw);
			if ((Flags & 9) != 0)
	bw.Write(ViaBotId);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ReplyTo, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			
        }
    }
}