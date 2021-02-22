using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1200736242)]
    public class TLRequestGetPollVotes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1200736242;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public int Id { get; set; }
		public byte[] Option { get; set; }
		public string Offset { get; set; }
		public int Limit { get; set; }
		public Messages.TLAbsVotesList Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			if ((Flags & 2) != 0)
				Option = (byte[])ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Offset = StringUtil.Deserialize(br);
			Limit = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			bw.Write(Id);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Option, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Offset, bw);
			bw.Write(Limit);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsVotesList)ObjectUtils.DeserializeObject(br);
        }
    }
}