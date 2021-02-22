using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1820043071)]
    public class TLUser : TLAbsUser
    {
        public override int Constructor
        {
            get
            {
                return -1820043071;
            }
        }

        public int Flags { get; set; }
		public bool Self { get; set; }
		public bool Contact { get; set; }
		public bool MutualContact { get; set; }
		public bool Deleted { get; set; }
		public bool Bot { get; set; }
		public bool BotChatHistory { get; set; }
		public bool BotNochats { get; set; }
		public bool Verified { get; set; }
		public bool Restricted { get; set; }
		public bool Min { get; set; }
		public bool BotInlineGeo { get; set; }
		public bool Support { get; set; }
		public bool Scam { get; set; }
		public bool ApplyMinPhoto { get; set; }
		public int Id { get; set; }
		public long AccessHash { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Phone { get; set; }
		public TLAbsUserProfilePhoto Photo { get; set; }
		public TLAbsUserStatus Status { get; set; }
		public int BotInfoVersion { get; set; }
		public TLVector<TLAbsRestrictionReason> RestrictionReason { get; set; }
		public string BotInlinePlaceholder { get; set; }
		public string LangCode { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 8) != 0)
				Self = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				Contact = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				MutualContact = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 15) != 0)
				Deleted = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 12) != 0)
				Bot = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				BotChatHistory = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 18) != 0)
				BotNochats = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 19) != 0)
				Verified = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 16) != 0)
				Restricted = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 22) != 0)
				Min = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 23) != 0)
				BotInlineGeo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 21) != 0)
				Support = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 26) != 0)
				Scam = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 27) != 0)
				ApplyMinPhoto = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			if ((Flags & 2) != 0)
				AccessHash = br.ReadInt64();
			if ((Flags & 3) != 0)
				FirstName = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				LastName = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Username = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				Phone = StringUtil.Deserialize(br);
			if ((Flags & 7) != 0)
				Photo = (TLAbsUserProfilePhoto)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Status = (TLAbsUserStatus)ObjectUtils.DeserializeObject(br);
			if ((Flags & 12) != 0)
				BotInfoVersion = br.ReadInt32();
			if ((Flags & 16) != 0)
				RestrictionReason = (TLVector<TLAbsRestrictionReason>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 17) != 0)
				BotInlinePlaceholder = StringUtil.Deserialize(br);
			if ((Flags & 20) != 0)
				LangCode = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Self, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(Contact, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(MutualContact, bw);
			if ((Flags & 15) != 0)
	ObjectUtils.SerializeObject(Deleted, bw);
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(Bot, bw);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(BotChatHistory, bw);
			if ((Flags & 18) != 0)
	ObjectUtils.SerializeObject(BotNochats, bw);
			if ((Flags & 19) != 0)
	ObjectUtils.SerializeObject(Verified, bw);
			if ((Flags & 16) != 0)
	ObjectUtils.SerializeObject(Restricted, bw);
			if ((Flags & 22) != 0)
	ObjectUtils.SerializeObject(Min, bw);
			if ((Flags & 23) != 0)
	ObjectUtils.SerializeObject(BotInlineGeo, bw);
			if ((Flags & 21) != 0)
	ObjectUtils.SerializeObject(Support, bw);
			if ((Flags & 26) != 0)
	ObjectUtils.SerializeObject(Scam, bw);
			if ((Flags & 27) != 0)
	ObjectUtils.SerializeObject(ApplyMinPhoto, bw);
			bw.Write(Id);
			if ((Flags & 2) != 0)
	bw.Write(AccessHash);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(FirstName, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(LastName, bw);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Username, bw);
			if ((Flags & 6) != 0)
	StringUtil.Serialize(Phone, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Status, bw);
			if ((Flags & 12) != 0)
	bw.Write(BotInfoVersion);
			if ((Flags & 16) != 0)
	ObjectUtils.SerializeObject(RestrictionReason, bw);
			if ((Flags & 17) != 0)
	StringUtil.Serialize(BotInlinePlaceholder, bw);
			if ((Flags & 20) != 0)
	StringUtil.Serialize(LangCode, bw);
			
        }
    }
}