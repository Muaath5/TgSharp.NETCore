using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-786326563)]
    public class TLInputPrivacyKeyAddedByPhone : TLAbsInputPrivacyKey
    {
        public override int Constructor
        {
            get
            {
                return -786326563;
            }
        }

        

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
        }
    }
}