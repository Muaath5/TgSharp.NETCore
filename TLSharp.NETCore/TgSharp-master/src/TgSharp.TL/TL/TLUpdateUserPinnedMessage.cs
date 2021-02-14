using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1279515160)]
    public class TLUpdateUserPinnedMessage : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1279515160;
            }
        }

        public int UserId { get; set; }
        public int Id { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
            Id = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            bw.Write(Id);
        }
    }
}
