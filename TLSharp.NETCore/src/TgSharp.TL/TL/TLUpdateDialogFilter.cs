using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(654302845)]
    public class TLUpdateDialogFilter : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 654302845;
            }
        }

        public int Flags { get; set; }
		public int Id { get; set; }
		public TLAbsDialogFilter Filter { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = br.ReadInt32();
			if ((Flags & 2) != 0)
				Filter = (TLAbsDialogFilter)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Filter, bw);
			
        }
    }
}