using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-557924733)]
    public class TLCodeSettings : TLAbsCodeSettings
    {
        public override int Constructor
        {
            get
            {
                return -557924733;
            }
        }

        public int Flags { get; set; }
		public bool AllowFlashcall { get; set; }
		public bool CurrentNumber { get; set; }
		public bool AllowAppHash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				AllowFlashcall = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				CurrentNumber = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				AllowAppHash = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(AllowFlashcall, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(CurrentNumber, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(AllowAppHash, bw);
			
        }
    }
}