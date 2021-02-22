using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-540871282)]
    public class TLChatInvite : TLAbsChatInvite
    {
        public override int Constructor
        {
            get
            {
                return -540871282;
            }
        }

        public int Flags { get; set; }
		public bool Channel { get; set; }
		public bool Broadcast { get; set; }
		public bool Public { get; set; }
		public bool Megagroup { get; set; }
		public string Title { get; set; }
		public TLAbsPhoto Photo { get; set; }
		public int ParticipantsCount { get; set; }
		public TLVector<TLAbsUser> Participants { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Channel = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Broadcast = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Public = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Megagroup = (bool)ObjectUtils.DeserializeObject(br);
			Title = StringUtil.Deserialize(br);
			Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			ParticipantsCount = br.ReadInt32();
			if ((Flags & 6) != 0)
				Participants = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Channel, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Broadcast, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Public, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Megagroup, bw);
			StringUtil.Serialize(Title, bw);
			ObjectUtils.SerializeObject(Photo, bw);
			bw.Write(ParticipantsCount);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Participants, bw);
			
        }
    }
}