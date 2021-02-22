using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1626209256)]
    public class TLChatBannedRights : TLAbsChatBannedRights
    {
        public override int Constructor
        {
            get
            {
                return -1626209256;
            }
        }

        public int Flags { get; set; }
		public bool ViewMessages { get; set; }
		public bool SendMessages { get; set; }
		public bool SendMedia { get; set; }
		public bool SendStickers { get; set; }
		public bool SendGifs { get; set; }
		public bool SendGames { get; set; }
		public bool SendInline { get; set; }
		public bool EmbedLinks { get; set; }
		public bool SendPolls { get; set; }
		public bool ChangeInfo { get; set; }
		public bool InviteUsers { get; set; }
		public bool PinMessages { get; set; }
		public int UntilDate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				ViewMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SendMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				SendMedia = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				SendStickers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				SendGifs = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				SendGames = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				SendInline = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				EmbedLinks = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				SendPolls = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				ChangeInfo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				InviteUsers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 19) != 0)
				PinMessages = (bool)ObjectUtils.DeserializeObject(br);
			UntilDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ViewMessages, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SendMessages, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(SendMedia, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(SendStickers, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(SendGifs, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(SendGames, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(SendInline, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(EmbedLinks, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(SendPolls, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(ChangeInfo, bw);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(InviteUsers, bw);
			if ((Flags & 19) != 0)
	ObjectUtils.SerializeObject(PinMessages, bw);
			bw.Write(UntilDate);
			
        }
    }
}