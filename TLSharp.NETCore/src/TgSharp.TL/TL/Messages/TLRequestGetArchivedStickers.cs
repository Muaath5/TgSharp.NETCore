using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1475442322)]
    public class TLRequestGetArchivedStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1475442322;
            }
        }

        public int Flags { get; set; }
		public bool Masks { get; set; }
		public long OffsetId { get; set; }
		public int Limit { get; set; }
		public Messages.TLAbsArchivedStickers Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Masks = (bool)ObjectUtils.DeserializeObject(br);
			OffsetId = br.ReadInt64();
			Limit = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Masks, bw);
			bw.Write(OffsetId);
			bw.Write(Limit);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsArchivedStickers)ObjectUtils.DeserializeObject(br);
        }
    }
}