using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-40996577)]
    public class TLDraftMessage : TLAbsDraftMessage
    {
        public override int Constructor
        {
            get
            {
                return -40996577;
            }
        }

        public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public int ReplyToMsgId { get; set; }
		public string Message { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public int Date { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				NoWebpage = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				ReplyToMsgId = br.ReadInt32();
			Message = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NoWebpage, bw);
			if ((Flags & 2) != 0)
	bw.Write(ReplyToMsgId);
			StringUtil.Serialize(Message, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			bw.Write(Date);
			
        }
    }
}