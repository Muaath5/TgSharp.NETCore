using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(450142282)]
    public class TLRequestUpdateDialogFilter : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 450142282;
            }
        }

        public int Flags { get; set; }
		public int Id { get; set; }
		public TLAbsDialogFilter Filter { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Id = br.ReadInt32();
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

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}