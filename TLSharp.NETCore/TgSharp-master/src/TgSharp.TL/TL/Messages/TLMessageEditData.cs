using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(649453030)]
    public class TLMessageEditData : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 649453030;
            }
        }

        public int Flags { get; set; }
        public bool Caption { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Caption = (Flags & 1) != 0;
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
        }
    }
}
