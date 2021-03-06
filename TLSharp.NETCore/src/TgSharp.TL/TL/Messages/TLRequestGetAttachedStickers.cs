using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-866424884)]
    public class TLRequestGetAttachedStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -866424884;
            }
        }

        
		public TLAbsInputStickeredMedia Media { get; set; }
		public TLVector<TLAbsStickerSetCovered> Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Media = (TLAbsInputStickeredMedia)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Media, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLVector<TLAbsStickerSetCovered>)ObjectUtils.DeserializeObject(br);
        }
    }
}