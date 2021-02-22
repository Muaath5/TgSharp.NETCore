using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1594999949)]
    public class TLRequestGetDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1594999949;
            }
        }

        public int Flags { get; set; }
		public bool ExcludePinned { get; set; }
		public int FolderId { get; set; }
		public int OffsetDate { get; set; }
		public int OffsetId { get; set; }
		public TLAbsInputPeer OffsetPeer { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }
		public Messages.TLAbsDialogs Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				ExcludePinned = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				FolderId = br.ReadInt32();
			OffsetDate = br.ReadInt32();
			OffsetId = br.ReadInt32();
			OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Limit = br.ReadInt32();
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ExcludePinned, bw);
			if ((Flags & 3) != 0)
	bw.Write(FolderId);
			bw.Write(OffsetDate);
			bw.Write(OffsetId);
			ObjectUtils.SerializeObject(OffsetPeer, bw);
			bw.Write(Limit);
			bw.Write(Hash);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsDialogs)ObjectUtils.DeserializeObject(br);
        }
    }
}