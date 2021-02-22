using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(204812012)]
    public class TLRequestSearch : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 204812012;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public string Q { get; set; }
		public TLAbsInputPeer FromId { get; set; }
		public int TopMsgId { get; set; }
		public TLAbsMessagesFilter Filter { get; set; }
		public int MinDate { get; set; }
		public int MaxDate { get; set; }
		public int OffsetId { get; set; }
		public int AddOffset { get; set; }
		public int Limit { get; set; }
		public int MaxId { get; set; }
		public int MinId { get; set; }
		public int Hash { get; set; }
		public Messages.TLAbsMessages Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Q = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				FromId = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				TopMsgId = br.ReadInt32();
			Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
			MinDate = br.ReadInt32();
			MaxDate = br.ReadInt32();
			OffsetId = br.ReadInt32();
			AddOffset = br.ReadInt32();
			Limit = br.ReadInt32();
			MaxId = br.ReadInt32();
			MinId = br.ReadInt32();
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			StringUtil.Serialize(Q, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(FromId, bw);
			if ((Flags & 3) != 0)
	bw.Write(TopMsgId);
			ObjectUtils.SerializeObject(Filter, bw);
			bw.Write(MinDate);
			bw.Write(MaxDate);
			bw.Write(OffsetId);
			bw.Write(AddOffset);
			bw.Write(Limit);
			bw.Write(MaxId);
			bw.Write(MinId);
			bw.Write(Hash);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);
        }
    }
}