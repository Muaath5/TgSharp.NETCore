using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1137057461)]
    public class TLRequestSaveDraft : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1137057461;
            }
        }

        public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public int ReplyToMsgId { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public string Message { get; set; }
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
			if ((Flags & 2) != 0)
				ReplyToMsgId = br.ReadInt32();
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Message = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NoWebpage, bw);
			if ((Flags & 2) != 0)
	bw.Write(ReplyToMsgId);
			ObjectUtils.SerializeObject(Peer, bw);
			StringUtil.Serialize(Message, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}