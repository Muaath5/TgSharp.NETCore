using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-368018716)]
    public class TLChannelAdminLogEventsFilter : TLAbsChannelAdminLogEventsFilter
    {
        public override int Constructor
        {
            get
            {
                return -368018716;
            }
        }

        public int Flags { get; set; }
		public bool Join { get; set; }
		public bool Leave { get; set; }
		public bool Invite { get; set; }
		public bool Ban { get; set; }
		public bool Unban { get; set; }
		public bool Kick { get; set; }
		public bool Unkick { get; set; }
		public bool Promote { get; set; }
		public bool Demote { get; set; }
		public bool Info { get; set; }
		public bool Settings { get; set; }
		public bool Pinned { get; set; }
		public bool Edit { get; set; }
		public bool Delete { get; set; }
		public bool GroupCall { get; set; }
		public bool Invites { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Join = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Leave = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Invite = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Ban = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Unban = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Kick = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Unkick = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Promote = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				Demote = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 11) != 0)
				Info = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				Settings = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				Pinned = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				Edit = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 15) != 0)
				Delete = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 12) != 0)
				GroupCall = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				Invites = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Join, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Leave, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Invite, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Ban, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Unban, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Kick, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Unkick, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Promote, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(Demote, bw);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(Info, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(Pinned, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(Edit, bw);
			if ((Flags & 15) != 0)
	ObjectUtils.SerializeObject(Delete, bw);
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(GroupCall, bw);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(Invites, bw);
			
        }
    }
}