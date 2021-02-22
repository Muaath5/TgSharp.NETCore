using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1803769784)]
    public class TLBotResults : TgSharp.TL.Messages.TLAbsBotResults
    {
        public override int Constructor
        {
            get
            {
                return -1803769784;
            }
        }

        public int Flags { get; set; }
		public bool Gallery { get; set; }
		public long QueryId { get; set; }
		public string NextOffset { get; set; }
		public TLAbsInlineBotSwitchPM SwitchPm { get; set; }
		public TLVector<TLAbsBotInlineResult> Results { get; set; }
		public int CacheTime { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Gallery = (bool)ObjectUtils.DeserializeObject(br);
			QueryId = br.ReadInt64();
			if ((Flags & 3) != 0)
				NextOffset = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				SwitchPm = (TLAbsInlineBotSwitchPM)ObjectUtils.DeserializeObject(br);
			Results = (TLVector<TLAbsBotInlineResult>)ObjectUtils.DeserializeObject(br);
			CacheTime = br.ReadInt32();
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Gallery, bw);
			bw.Write(QueryId);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(NextOffset, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(SwitchPm, bw);
			ObjectUtils.SerializeObject(Results, bw);
			bw.Write(CacheTime);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}