using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-206688531)]
    public class TLUserInfoEmpty : TgSharp.TL.Help.TLAbsUserInfo
    {
        public override int Constructor
        {
            get
            {
                return -206688531;
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