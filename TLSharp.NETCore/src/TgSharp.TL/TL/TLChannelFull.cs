using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-253335766)]
    public class TLChannelFull : TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return -253335766;
            }
        }

        public int Flags { get; set; }
		public bool CanViewParticipants { get; set; }
		public bool CanSetUsername { get; set; }
		public bool CanSetStickers { get; set; }
		public bool HiddenPrehistory { get; set; }
		public bool CanSetLocation { get; set; }
		public bool HasScheduled { get; set; }
		public bool CanViewStats { get; set; }
		public bool Blocked { get; set; }
		public int Id { get; set; }
		public string About { get; set; }
		public int ParticipantsCount { get; set; }
		public int AdminsCount { get; set; }
		public int KickedCount { get; set; }
		public int BannedCount { get; set; }
		public int OnlineCount { get; set; }
		public int ReadInboxMaxId { get; set; }
		public int ReadOutboxMaxId { get; set; }
		public int UnreadCount { get; set; }
		public TLAbsPhoto ChatPhoto { get; set; }
		public TLAbsPeerNotifySettings NotifySettings { get; set; }
		public TLAbsExportedChatInvite ExportedInvite { get; set; }
		public TLVector<TLAbsBotInfo> BotInfo { get; set; }
		public int MigratedFromChatId { get; set; }
		public int MigratedFromMaxId { get; set; }
		public int PinnedMsgId { get; set; }
		public TLAbsStickerSet Stickerset { get; set; }
		public int AvailableMinId { get; set; }
		public int FolderId { get; set; }
		public int LinkedChatId { get; set; }
		public TLAbsChannelLocation Location { get; set; }
		public int SlowmodeSeconds { get; set; }
		public int SlowmodeNextSendDate { get; set; }
		public int StatsDc { get; set; }
		public int Pts { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 1) != 0)
				CanViewParticipants = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				CanSetUsername = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				CanSetStickers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				HiddenPrehistory = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 18) != 0)
				CanSetLocation = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 17) != 0)
				HasScheduled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 22) != 0)
				CanViewStats = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 20) != 0)
				Blocked = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			About = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				ParticipantsCount = br.ReadInt32();
			if ((Flags & 3) != 0)
				AdminsCount = br.ReadInt32();
			if ((Flags & 0) != 0)
				KickedCount = br.ReadInt32();
			if ((Flags & 0) != 0)
				BannedCount = br.ReadInt32();
			if ((Flags & 15) != 0)
				OnlineCount = br.ReadInt32();
			ReadInboxMaxId = br.ReadInt32();
			ReadOutboxMaxId = br.ReadInt32();
			UnreadCount = br.ReadInt32();
			ChatPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
			ExportedInvite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
			BotInfo = (TLVector<TLAbsBotInfo>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				MigratedFromChatId = br.ReadInt32();
			if ((Flags & 6) != 0)
				MigratedFromMaxId = br.ReadInt32();
			if ((Flags & 7) != 0)
				PinnedMsgId = br.ReadInt32();
			if ((Flags & 10) != 0)
				Stickerset = (TLAbsStickerSet)ObjectUtils.DeserializeObject(br);
			if ((Flags & 11) != 0)
				AvailableMinId = br.ReadInt32();
			if ((Flags & 9) != 0)
				FolderId = br.ReadInt32();
			if ((Flags & 12) != 0)
				LinkedChatId = br.ReadInt32();
			if ((Flags & 13) != 0)
				Location = (TLAbsChannelLocation)ObjectUtils.DeserializeObject(br);
			if ((Flags & 19) != 0)
				SlowmodeSeconds = br.ReadInt32();
			if ((Flags & 16) != 0)
				SlowmodeNextSendDate = br.ReadInt32();
			if ((Flags & 14) != 0)
				StatsDc = br.ReadInt32();
			Pts = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(CanViewParticipants, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(CanSetUsername, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(CanSetStickers, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(HiddenPrehistory, bw);
			if ((Flags & 18) != 0)
	ObjectUtils.SerializeObject(CanSetLocation, bw);
			if ((Flags & 17) != 0)
	ObjectUtils.SerializeObject(HasScheduled, bw);
			if ((Flags & 22) != 0)
	ObjectUtils.SerializeObject(CanViewStats, bw);
			if ((Flags & 20) != 0)
	ObjectUtils.SerializeObject(Blocked, bw);
			bw.Write(Id);
			StringUtil.Serialize(About, bw);
			if ((Flags & 2) != 0)
	bw.Write(ParticipantsCount);
			if ((Flags & 3) != 0)
	bw.Write(AdminsCount);
			if ((Flags & 0) != 0)
	bw.Write(KickedCount);
			if ((Flags & 0) != 0)
	bw.Write(BannedCount);
			if ((Flags & 15) != 0)
	bw.Write(OnlineCount);
			bw.Write(ReadInboxMaxId);
			bw.Write(ReadOutboxMaxId);
			bw.Write(UnreadCount);
			ObjectUtils.SerializeObject(ChatPhoto, bw);
			ObjectUtils.SerializeObject(NotifySettings, bw);
			ObjectUtils.SerializeObject(ExportedInvite, bw);
			ObjectUtils.SerializeObject(BotInfo, bw);
			if ((Flags & 6) != 0)
	bw.Write(MigratedFromChatId);
			if ((Flags & 6) != 0)
	bw.Write(MigratedFromMaxId);
			if ((Flags & 7) != 0)
	bw.Write(PinnedMsgId);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(Stickerset, bw);
			if ((Flags & 11) != 0)
	bw.Write(AvailableMinId);
			if ((Flags & 9) != 0)
	bw.Write(FolderId);
			if ((Flags & 12) != 0)
	bw.Write(LinkedChatId);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(Location, bw);
			if ((Flags & 19) != 0)
	bw.Write(SlowmodeSeconds);
			if ((Flags & 16) != 0)
	bw.Write(SlowmodeNextSendDate);
			if ((Flags & 14) != 0)
	bw.Write(StatsDc);
			bw.Write(Pts);
			
        }
    }
}