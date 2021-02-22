using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(648939889)]
    public class TLChannelAdminLogEventActionToggleSignatures : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 648939889;
            }
        }

        
		public TLAbsBool NewValue { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            NewValue = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(NewValue, bw);
			
        }
    }
}