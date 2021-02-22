using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1486110434)]
    public class TLRequestSetTyping : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1486110434;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int TopMsgId { get; set; }
		public TLAbsSendMessageAction Action { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				TopMsgId = br.ReadInt32();
			Action = (TLAbsSendMessageAction)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			if ((Flags & 2) != 0)
	bw.Write(TopMsgId);
			ObjectUtils.SerializeObject(Action, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}