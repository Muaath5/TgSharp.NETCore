using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-2091549254)]
    public class TLRequestEditInlineBotMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2091549254;
            }
        }

        public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public TLAbsInputBotInlineMessageID Id { get; set; }
		public string Message { get; set; }
		public TLAbsInputMedia Media { get; set; }
		public TLAbsReplyMarkup ReplyMarkup { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				NoWebpage = (bool)ObjectUtils.DeserializeObject(br);
			Id = (TLAbsInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				Message = StringUtil.Deserialize(br);
			if ((Flags & 12) != 0)
				Media = (TLAbsInputMedia)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NoWebpage, bw);
			ObjectUtils.SerializeObject(Id, bw);
			if ((Flags & 9) != 0)
	StringUtil.Serialize(Message, bw);
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(Media, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReplyMarkup, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}