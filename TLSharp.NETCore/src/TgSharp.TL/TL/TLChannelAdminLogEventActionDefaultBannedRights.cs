using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(771095562)]
    public class TLChannelAdminLogEventActionDefaultBannedRights : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 771095562;
            }
        }

        
		public TLAbsChatBannedRights PrevBannedRights { get; set; }
		public TLAbsChatBannedRights NewBannedRights { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PrevBannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			NewBannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PrevBannedRights, bw);
			ObjectUtils.SerializeObject(NewBannedRights, bw);
			
        }
    }
}