using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-415938591)]
    public class TLUpdateBotCallbackQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -415938591;
            }
        }

        public int Flags { get; set; }
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public TLAbsPeer Peer { get; set; }
		public int MsgId { get; set; }
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
			Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			MsgId = br.ReadInt32();
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
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(MsgId);
			bw.Write(ChatInstance);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Data, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(GameShortName, bw);
			
        }
    }
}