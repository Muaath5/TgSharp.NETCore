using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1824339449)]
    public class TLRequestGetBotCallbackAnswer : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1824339449;
            }
        }

        public int Flags { get; set; }
		public bool Game { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int MsgId { get; set; }
		public byte[] Data { get; set; }
		public TLAbsInputCheckPasswordSRP Password { get; set; }
		public Messages.TLAbsBotCallbackAnswer Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				Game = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			MsgId = br.ReadInt32();
			if ((Flags & 2) != 0)
				Data = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Password = (TLAbsInputCheckPasswordSRP)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Game, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(MsgId);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Data, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Password, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsBotCallbackAnswer)ObjectUtils.DeserializeObject(br);
        }
    }
}