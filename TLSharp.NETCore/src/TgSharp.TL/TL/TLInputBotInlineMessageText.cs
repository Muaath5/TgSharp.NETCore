using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1036876423)]
    public class TLInputBotInlineMessageText : TLAbsInputBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return 1036876423;
            }
        }

        public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public string Message { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public TLAbsReplyMarkup ReplyMarkup { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				NoWebpage = (bool)ObjectUtils.DeserializeObject(br);
			Message = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(NoWebpage, bw);
			StringUtil.Serialize(Message, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReplyMarkup, bw);
			
        }
    }
}