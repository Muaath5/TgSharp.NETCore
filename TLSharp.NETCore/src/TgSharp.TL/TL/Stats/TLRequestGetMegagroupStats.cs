using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stats
{
    [TLObject(-589330937)]
    public class TLRequestGetMegagroupStats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -589330937;
            }
        }

        public int Flags { get; set; }
		public bool Dark { get; set; }
		public TLAbsInputChannel Channel { get; set; }
		public Stats.TLAbsMegagroupStats Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			ObjectUtils.SerializeObject(Channel, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Stats.TLAbsMegagroupStats)ObjectUtils.DeserializeObject(br);
        }
    }
}