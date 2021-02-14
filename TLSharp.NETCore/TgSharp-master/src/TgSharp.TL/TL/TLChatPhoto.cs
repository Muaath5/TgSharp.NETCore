using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1197267925)]
    public class TLChatPhoto : TLAbsChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return 1197267925;
            }
        }

        // manual edit: FileLocation->TLFileLocationToBeDeprecated
        public TLFileLocationToBeDeprecated PhotoSmall { get; set; }
        // manual edit: FileLocation->TLFileLocationToBeDeprecated
        public TLFileLocationToBeDeprecated PhotoBig { get; set; }
        public int DcId { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            // manual edit: FileLocation->TLFileLocationToBeDeprecated
            PhotoSmall = (TLFileLocationToBeDeprecated)ObjectUtils.DeserializeObject(br);
            // manual edit: FileLocation->TLFileLocationToBeDeprecated
            PhotoBig = (TLFileLocationToBeDeprecated)ObjectUtils.DeserializeObject(br);
            DcId = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PhotoSmall, bw);
            ObjectUtils.SerializeObject(PhotoBig, bw);
            bw.Write(DcId);
        }
    }
}
