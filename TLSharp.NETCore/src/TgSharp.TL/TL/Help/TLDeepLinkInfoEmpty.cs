using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(1722786150)]
    public class TLDeepLinkInfoEmpty : TgSharp.TL.Help.TLAbsDeepLinkInfo
    {
        public override int Constructor
        {
            get
            {
                return 1722786150;
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