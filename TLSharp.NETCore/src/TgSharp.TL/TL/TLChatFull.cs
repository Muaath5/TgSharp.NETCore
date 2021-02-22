using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(461151667)]
    public class TLChatFull : TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return 461151667;
            }
        }

        public int Flags { get; set; }
		public bool CanSetUsername { get; set; }
		public bool HasScheduled { get; set; }
		public int Id { get; set; }
		public string About { get; set; }
		public TLAbsChatParticipants Participants { get; set; }
		public TLAbsPhoto ChatPhoto { get; set; }
		public TLAbsPeerNotifySettings NotifySettings { get; set; }
		public TLAbsExportedChatInvite ExportedInvite { get; set; }
		public TLVector<TLAbsBotInfo> BotInfo { get; set; }
		public int PinnedMsgId { get; set; }
		public int FolderId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 5) != 0)
				CanSetUsername = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				HasScheduled = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			About = StringUtil.Deserialize(br);
			Participants = (TLAbsChatParticipants)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ChatPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
			ExportedInvite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				BotInfo = (TLVector<TLAbsBotInfo>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				PinnedMsgId = br.ReadInt32();
			if ((Flags & 9) != 0)
				FolderId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(CanSetUsername, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(HasScheduled, bw);
			bw.Write(Id);
			StringUtil.Serialize(About, bw);
			ObjectUtils.SerializeObject(Participants, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ChatPhoto, bw);
			ObjectUtils.SerializeObject(NotifySettings, bw);
			ObjectUtils.SerializeObject(ExportedInvite, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(BotInfo, bw);
			if ((Flags & 4) != 0)
	bw.Write(PinnedMsgId);
			if ((Flags & 9) != 0)
	bw.Write(FolderId);
			
        }
    }
}