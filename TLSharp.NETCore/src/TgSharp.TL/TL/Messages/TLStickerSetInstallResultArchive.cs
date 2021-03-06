using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(904138920)]
    public class TLStickerSetInstallResultArchive : TgSharp.TL.Messages.TLAbsStickerSetInstallResult
    {
        public override int Constructor
        {
            get
            {
                return 904138920;
            }
        }

        
		public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Sets = (TLVector<TLAbsStickerSetCovered>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Sets, bw);
			
        }
    }
}