using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(678405636)]
    public class TLMessageService : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 678405636;
            }
        }

        public int Flags { get; set; }
		public bool Out { get; set; }
		public bool Mentioned { get; set; }
		public bool MediaUnread { get; set; }
		public bool Silent { get; set; }
		public bool Post { get; set; }
		public bool Legacy { get; set; }
		public int Id { get; set; }
		public TLAbsPeer FromId { get; set; }
		public TLAbsPeer PeerId { get; set; }
		public TLAbsMessageReplyHeader ReplyTo { get; set; }
		public int Date { get; set; }
		public TLAbsMessageAction Action { get; set; }

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
			if ((Flags & 17) != 0)
				Legacy = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			if ((Flags & 10) != 0)
				FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				ReplyTo = (TLAbsMessageReplyHeader)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			Action = (TLAbsMessageAction)ObjectUtils.DeserializeObject(br);
			
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
			if ((Flags & 17) != 0)
	ObjectUtils.SerializeObject(Legacy, bw);
			bw.Write(Id);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(FromId, bw);
			ObjectUtils.SerializeObject(PeerId, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ReplyTo, bw);
			bw.Write(Date);
			ObjectUtils.SerializeObject(Action, bw);
			
        }
    }
}