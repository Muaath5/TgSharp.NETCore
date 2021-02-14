using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-484690728)]
    public class TLChannelAdminLogEventActionParticipantInvite : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return -484690728;
            }
        }

        public TLAbsChannelParticipant Participant { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Participant = (TLAbsChannelParticipant)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Participant, bw);
        }
    }
}
