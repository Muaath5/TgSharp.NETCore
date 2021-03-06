using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(209668535)]
    public class TLPrivacyValueDisallowUsers : TLAbsPrivacyRule
    {
        public override int Constructor
        {
            get
            {
                return 209668535;
            }
        }

        
		public TLVector<int> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Users = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}