using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(889353612)]
    public class TLReplyKeyboardMarkup : TLAbsReplyMarkup
    {
        public override int Constructor
        {
            get
            {
                return 889353612;
            }
        }

        public int Flags { get; set; }
		public bool Resize { get; set; }
		public bool SingleUse { get; set; }
		public bool Selective { get; set; }
		public TLVector<TLAbsKeyboardButtonRow> Rows { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Resize = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				SingleUse = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Selective = (bool)ObjectUtils.DeserializeObject(br);
			Rows = (TLVector<TLAbsKeyboardButtonRow>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Resize, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SingleUse, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Selective, bw);
			ObjectUtils.SerializeObject(Rows, bw);
			
        }
    }
}