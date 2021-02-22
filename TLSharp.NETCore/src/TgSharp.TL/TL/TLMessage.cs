using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1487813065)]
    public class TLMessage : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 1487813065;
            }
        }

        public int Flags { get; set; }
		public bool Out { get; set; }
		public bool Mentioned { get; set; }
		public bool MediaUnread { get; set; }
		public bool Silent { get; set; }
		public bool Post { get; set; }
		public bool FromScheduled { get; set; }
		public bool Legacy { get; set; }
		public bool EditHide { get; set; }
		public bool Pinned { get; set; }
		public int Id { get; set; }
		public TLAbsPeer FromId { get; set; }
		public TLAbsPeer PeerId { get; set; }
		public TLAbsMessageFwdHeader FwdFrom { get; set; }
		public int ViaBotId { get; set; }
		public TLAbsMessageReplyHeader ReplyTo { get; set; }
		public int Date { get; set; }
		public string Message { get; set; }
		public TLAbsMessageMedia Media { get; set; }
		public TLAbsReplyMarkup ReplyMarkup { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public int Views { get; set; }
		public int Forwards { get; set; }
		public TLAbsMessageReplies Replies { get; set; }
		public int EditDate { get; set; }
		public string PostAuthor { get; set; }
		public long GroupedId { get; set; }
		public TLVector<TLAbsRestrictionReason> RestrictionReason { get; set; }

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
			if ((Flags & 12) != 0)
				Post = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 16) != 0)
				FromScheduled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 17) != 0)
				Legacy = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 23) != 0)
				EditHide = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 26) != 0)
				Pinned = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			if ((Flags & 10) != 0)
				FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				FwdFrom = (TLAbsMessageFwdHeader)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				ViaBotId = br.ReadInt32();
			if ((Flags & 1) != 0)
				ReplyTo = (TLAbsMessageReplyHeader)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			Message = StringUtil.Deserialize(br);
			if ((Flags & 11) != 0)
				Media = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				Views = br.ReadInt32();
			if ((Flags & 8) != 0)
				Forwards = br.ReadInt32();
			if ((Flags & 21) != 0)
				Replies = (TLAbsMessageReplies)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				EditDate = br.ReadInt32();
			if ((Flags & 18) != 0)
				PostAuthor = StringUtil.Deserialize(br);
			if ((Flags & 19) != 0)
				GroupedId = br.ReadInt64();
			if ((Flags & 20) != 0)
				RestrictionReason = (TLVector<TLAbsRestrictionReason>)ObjectUtils.DeserializeObject(br);
			
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
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(Post, bw);
			if ((Flags & 16) != 0)
	ObjectUtils.SerializeObject(FromScheduled, bw);
			if ((Flags & 17) != 0)
	ObjectUtils.SerializeObject(Legacy, bw);
			if ((Flags & 23) != 0)
	ObjectUtils.SerializeObject(EditHide, bw);
			if ((Flags & 26) != 0)
	ObjectUtils.SerializeObject(Pinned, bw);
			bw.Write(Id);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(FromId, bw);
			ObjectUtils.SerializeObject(PeerId, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(FwdFrom, bw);
			if ((Flags & 9) != 0)
	bw.Write(ViaBotId);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ReplyTo, bw);
			bw.Write(Date);
			StringUtil.Serialize(Message, bw);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(Media, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(ReplyMarkup, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			if ((Flags & 8) != 0)
	bw.Write(Views);
			if ((Flags & 8) != 0)
	bw.Write(Forwards);
			if ((Flags & 21) != 0)
	ObjectUtils.SerializeObject(Replies, bw);
			if ((Flags & 13) != 0)
	bw.Write(EditDate);
			if ((Flags & 18) != 0)
	StringUtil.Serialize(PostAuthor, bw);
			if ((Flags & 19) != 0)
	bw.Write(GroupedId);
			if ((Flags & 20) != 0)
	ObjectUtils.SerializeObject(RestrictionReason, bw);
			
        }
    }
}