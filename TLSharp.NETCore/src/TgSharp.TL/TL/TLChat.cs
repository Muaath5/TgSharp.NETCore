using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1004149726)]
    public class TLChat : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return 1004149726;
            }
        }

        public int Flags { get; set; }
		public bool Creator { get; set; }
		public bool Kicked { get; set; }
		public bool Left { get; set; }
		public bool Deactivated { get; set; }
		public bool CallActive { get; set; }
		public bool CallNotEmpty { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public TLAbsChatPhoto Photo { get; set; }
		public int ParticipantsCount { get; set; }
		public int Date { get; set; }
		public int Version { get; set; }
		public TLAbsInputChannel MigratedTo { get; set; }
		public TLAbsChatAdminRights AdminRights { get; set; }
		public TLAbsChatBannedRights DefaultBannedRights { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Creator = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Kicked = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Left = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Deactivated = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 21) != 0)
				CallActive = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 26) != 0)
				CallNotEmpty = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			Title = StringUtil.Deserialize(br);
			Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
			ParticipantsCount = br.ReadInt32();
			Date = br.ReadInt32();
			Version = br.ReadInt32();
			if ((Flags & 4) != 0)
				MigratedTo = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			if ((Flags & 12) != 0)
				AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 16) != 0)
				DefaultBannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Creator, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Kicked, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Left, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Deactivated, bw);
			if ((Flags & 21) != 0)
	ObjectUtils.SerializeObject(CallActive, bw);
			if ((Flags & 26) != 0)
	ObjectUtils.SerializeObject(CallNotEmpty, bw);
			bw.Write(Id);
			StringUtil.Serialize(Title, bw);
			ObjectUtils.SerializeObject(Photo, bw);
			bw.Write(ParticipantsCount);
			bw.Write(Date);
			bw.Write(Version);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(MigratedTo, bw);
			if ((Flags & 12) != 0)
	ObjectUtils.SerializeObject(AdminRights, bw);
			if ((Flags & 16) != 0)
	ObjectUtils.SerializeObject(DefaultBannedRights, bw);
			
        }
    }
}