using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1149094475)]
    public class TLChannelParticipantCreator : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 1149094475;
            }
        }

        public int Flags { get; set; }
		public int UserId { get; set; }
		public TLAbsChatAdminRights AdminRights { get; set; }
		public string Rank { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();UserId = br.ReadInt32();
			AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Rank = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			ObjectUtils.SerializeObject(AdminRights, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Rank, bw);
			
        }
    }
}