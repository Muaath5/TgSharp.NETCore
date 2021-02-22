using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-753232354)]
    public class TLChannel : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return -753232354;
            }
        }

        public int Flags { get; set; }
		public bool Creator { get; set; }
		public bool Left { get; set; }
		public bool Broadcast { get; set; }
		public bool Verified { get; set; }
		public bool Megagroup { get; set; }
		public bool Restricted { get; set; }
		public bool Signatures { get; set; }
		public bool Min { get; set; }
		public bool Scam { get; set; }
		public bool HasLink { get; set; }
		public bool HasGeo { get; set; }
		public bool SlowmodeEnabled { get; set; }
		public bool CallActive { get; set; }
		public bool CallNotEmpty { get; set; }
		public int Id { get; set; }
		public long AccessHash { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
		public TLAbsChatPhoto Photo { get; set; }
		public int Date { get; set; }
		public int Version { get; set; }
		public TLVector<TLAbsRestrictionReason> RestrictionReason { get; set; }
		public TLAbsChatAdminRights AdminRights { get; set; }
		public TLAbsChatBannedRights BannedRights { get; set; }
		public TLAbsChatBannedRights DefaultBannedRights { get; set; }
		public int ParticipantsCount { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Creator = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Left = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Broadcast = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Verified = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				Megagroup = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 11) != 0)
				Restricted = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				Signatures = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				Min = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 17) != 0)
				Scam = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 22) != 0)
				HasLink = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 23) != 0)
				HasGeo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 20) != 0)
				SlowmodeEnabled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 21) != 0)
				CallActive = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 26) != 0)
				CallNotEmpty = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			if ((Flags & 15) != 0)
				AccessHash = br.ReadInt64();
			Title = StringUtil.Deserialize(br);
			if ((Flags & 4) != 0)
				Username = StringUtil.Deserialize(br);
			Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
			Date = br.ReadInt32();
			Version = br.ReadInt32();
			if ((Flags & 11) != 0)
				RestrictionReason = (TLVector<TLAbsRestrictionReason>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 12) != 0)
				AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				BannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 16) != 0)
				DefaultBannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 19) != 0)
				ParticipantsCount = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Creator, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Left, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Broadcast, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Verified, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(Megagroup, bw);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(Restricted, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(Signatures, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(Min, bw);
			if ((Flags & 17) != 0)
	ObjectUtils.SerializeObject(Scam, bw);
			if ((Flags & 22) != 0)
	ObjectUtils.SerializeObject(HasLink, bw);
			if ((Flags & 23) != 0)
	ObjectUtils.SerializeObject(HasGeo, bw);
			if ((Flags & 20) != 0)
	ObjectUtils.SerializeObject(SlowmodeEnabled, bw);
			if ((Flags & 21) != 0)
	ObjectUtils.SerializeObject(CallActive, bw);
			if ((Flags & 26) != 0)
	ObjectUtils.SerializeObject(CallNotEmpty, bw);
			bw.Write(Id);
			if ((Flags & 15) != 0)
	bw.Write(AccessHash);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 4) != 0)
	StringUtil.Serialize(Username, bw);
			ObjectUtils.SerializeObject(Photo, bw);
			bw.Write(Date);
			bw.Write(Version);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(RestrictionReason, bw);
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(AdminRights, bw);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(BannedRights, bw);
			if ((Flags & 16) != 0)
	ObjectUtils.SerializeObject(DefaultBannedRights, bw);
			if ((Flags & 19) != 0)
	bw.Write(ParticipantsCount);
			
        }
    }
}