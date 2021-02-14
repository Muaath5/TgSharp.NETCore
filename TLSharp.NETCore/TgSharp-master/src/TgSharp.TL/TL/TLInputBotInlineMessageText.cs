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
            Flags = br.ReadInt32();
            NoWebpage = (Flags & 1) != 0;
            Message = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;

            if ((Flags & 4) != 0)
                ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
            else
                ReplyMarkup = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            StringUtil.Serialize(Message, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Entities, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ReplyMarkup, bw);
        }
    }
}
