using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-539317279)]
    public class TLInputFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return -539317279;
            }
        }

        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }
        public byte[] FileReference { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            VolumeId = br.ReadInt64();
            LocalId = br.ReadInt32();
            Secret = br.ReadInt64();
            FileReference = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(VolumeId);
            bw.Write(LocalId);
            bw.Write(Secret);
            BytesUtil.Serialize(FileReference, bw);
        }
    }
}
