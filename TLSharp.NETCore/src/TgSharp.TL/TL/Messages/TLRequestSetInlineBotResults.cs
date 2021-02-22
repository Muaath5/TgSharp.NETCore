using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-346119674)]
    public class TLRequestSetInlineBotResults : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -346119674;
            }
        }

        public int Flags { get; set; }
		public bool Gallery { get; set; }
		public bool Private { get; set; }
		public long QueryId { get; set; }
		public TLVector<TLAbsInputBotInlineResult> Results { get; set; }
		public int CacheTime { get; set; }
		public string NextOffset { get; set; }
		public TLAbsInlineBotSwitchPM SwitchPm { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Gallery = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Private = (bool)ObjectUtils.DeserializeObject(br);
			QueryId = br.ReadInt64();
			Results = (TLVector<TLAbsInputBotInlineResult>)ObjectUtils.DeserializeObject(br);
			CacheTime = br.ReadInt32();
			if ((Flags & 0) != 0)
				NextOffset = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				SwitchPm = (TLAbsInlineBotSwitchPM)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Gallery, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Private, bw);
			bw.Write(QueryId);
			ObjectUtils.SerializeObject(Results, bw);
			bw.Write(CacheTime);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(NextOffset, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(SwitchPm, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}