using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-859915345)]
    public class TLChannelParticipantAdmin : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return -859915345;
            }
        }

        public int Flags { get; set; }
		public bool CanEdit { get; set; }
		public bool Self { get; set; }
		public int UserId { get; set; }
		public int InviterId { get; set; }
		public int PromotedBy { get; set; }
		public int Date { get; set; }
		public TLAbsChatAdminRights AdminRights { get; set; }
		public string Rank { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				CanEdit = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Self = (bool)ObjectUtils.DeserializeObject(br);
			UserId = br.ReadInt32();
			if ((Flags & 3) != 0)
				InviterId = br.ReadInt32();
			PromotedBy = br.ReadInt32();
			Date = br.ReadInt32();
			AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Rank = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(CanEdit, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Self, bw);
			bw.Write(UserId);
			if ((Flags & 3) != 0)
	bw.Write(InviterId);
			bw.Write(PromotedBy);
			bw.Write(Date);
			ObjectUtils.SerializeObject(AdminRights, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Rank, bw);
			
        }
    }
}