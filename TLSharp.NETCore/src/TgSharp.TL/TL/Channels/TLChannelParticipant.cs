using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(-791039645)]
    public class TLChannelParticipant : TgSharp.TL.Channels.TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return -791039645;
            }
        }

        
		public TLAbsChannelParticipant Participant { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Participant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Participant, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}