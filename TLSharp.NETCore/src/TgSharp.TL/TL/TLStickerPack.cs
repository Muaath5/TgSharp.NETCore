using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(313694676)]
    public class TLStickerPack : TLAbsStickerPack
    {
        public override int Constructor
        {
            get
            {
                return 313694676;
            }
        }

        
		public string Emoticon { get; set; }
		public TLVector<long> Documents { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);
			Documents = (TLVector<long>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Emoticon, bw);
			ObjectUtils.SerializeObject(Documents, bw);
			
        }
    }
}