using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Storage
{
    [TLObject(-1373745011)]
    public class TLFilePdf : TgSharp.TL.Storage.TLAbsFileType
    {
        public override int Constructor
        {
            get
            {
                return -1373745011;
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