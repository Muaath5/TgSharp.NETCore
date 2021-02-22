using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-103646630)]
    public class TLUpdateInlineBotCallbackQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -103646630;
            }
        }

        public int Flags { get; set; }
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public TLAbsInputBotInlineMessageID MsgId { get; set; }
		public long ChatInstance { get; set; }
		public byte[] Data { get; set; }
		public string GameShortName { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();QueryId = br.ReadInt64();
			UserId = br.ReadInt32();
			MsgId = (TLAbsInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
			ChatInstance = br.ReadInt64();
			if ((Flags & 2) != 0)
				Data = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				GameShortName = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(QueryId);
			bw.Write(UserId);
			ObjectUtils.SerializeObject(MsgId, bw);
			bw.Write(ChatInstance);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Data, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(GameShortName, bw);
			
        }
    }
}