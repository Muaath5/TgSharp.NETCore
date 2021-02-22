using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1605510357)]
    public class TLChatAdminRights : TLAbsChatAdminRights
    {
        public override int Constructor
        {
            get
            {
                return 1605510357;
            }
        }

        public int Flags { get; set; }
		public bool ChangeInfo { get; set; }
		public bool PostMessages { get; set; }
		public bool EditMessages { get; set; }
		public bool DeleteMessages { get; set; }
		public bool BanUsers { get; set; }
		public bool InviteUsers { get; set; }
		public bool PinMessages { get; set; }
		public bool AddAdmins { get; set; }
		public bool Anonymous { get; set; }
		public bool ManageCall { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				ChangeInfo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				PostMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				EditMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				DeleteMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				BanUsers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				InviteUsers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				PinMessages = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 11) != 0)
				AddAdmins = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				Anonymous = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				ManageCall = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ChangeInfo, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(PostMessages, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(EditMessages, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(DeleteMessages, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(BanUsers, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(InviteUsers, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(PinMessages, bw);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(AddAdmins, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Anonymous, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(ManageCall, bw);
			
        }
    }
}