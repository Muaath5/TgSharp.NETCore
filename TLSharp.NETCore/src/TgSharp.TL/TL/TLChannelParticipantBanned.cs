using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(470789295)]
    public class TLChannelParticipantBanned : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 470789295;
            }
        }

        public int Flags { get; set; }
		public bool Left { get; set; }
		public int UserId { get; set; }
		public int KickedBy { get; set; }
		public int Date { get; set; }
		public TLAbsChatBannedRights BannedRights { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Left = (bool)ObjectUtils.DeserializeObject(br);
			UserId = br.ReadInt32();
			KickedBy = br.ReadInt32();
			Date = br.ReadInt32();
			BannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Left, bw);
			bw.Write(UserId);
			bw.Write(KickedBy);
			bw.Write(Date);
			ObjectUtils.SerializeObject(BannedRights, bw);
			
        }
    }
}