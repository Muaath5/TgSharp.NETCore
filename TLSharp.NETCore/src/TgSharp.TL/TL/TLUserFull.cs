using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-302941166)]
    public class TLUserFull : TLAbsUserFull
    {
        public override int Constructor
        {
            get
            {
                return -302941166;
            }
        }

        public int Flags { get; set; }
		public bool Blocked { get; set; }
		public bool PhoneCallsAvailable { get; set; }
		public bool PhoneCallsPrivate { get; set; }
		public bool CanPinMessage { get; set; }
		public bool HasScheduled { get; set; }
		public bool VideoCallsAvailable { get; set; }
		public TLAbsUser User { get; set; }
		public string About { get; set; }
		public TLAbsPeerSettings Settings { get; set; }
		public TLAbsPhoto ProfilePhoto { get; set; }
		public TLAbsPeerNotifySettings NotifySettings { get; set; }
		public TLAbsBotInfo BotInfo { get; set; }
		public int PinnedMsgId { get; set; }
		public int CommonChatsCount { get; set; }
		public int FolderId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Blocked = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				PhoneCallsAvailable = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				PhoneCallsPrivate = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				CanPinMessage = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				HasScheduled = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 15) != 0)
				VideoCallsAvailable = (bool)ObjectUtils.DeserializeObject(br);
			User = (TLAbsUser)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				About = StringUtil.Deserialize(br);
			Settings = (TLAbsPeerSettings)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ProfilePhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				BotInfo = (TLAbsBotInfo)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				PinnedMsgId = br.ReadInt32();
			CommonChatsCount = br.ReadInt32();
			if ((Flags & 9) != 0)
				FolderId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Blocked, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(PhoneCallsAvailable, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(PhoneCallsPrivate, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(CanPinMessage, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(HasScheduled, bw);
			if ((Flags & 15) != 0)
	ObjectUtils.SerializeObject(VideoCallsAvailable, bw);
			ObjectUtils.SerializeObject(User, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(About, bw);
			ObjectUtils.SerializeObject(Settings, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ProfilePhoto, bw);
			ObjectUtils.SerializeObject(NotifySettings, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(BotInfo, bw);
			if ((Flags & 4) != 0)
	bw.Write(PinnedMsgId);
			bw.Write(CommonChatsCount);
			if ((Flags & 9) != 0)
	bw.Write(FolderId);
			
        }
    }
}