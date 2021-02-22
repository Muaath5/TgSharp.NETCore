using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(873977640)]
    public class TLInputPaymentCredentials : TLAbsInputPaymentCredentials
    {
        public override int Constructor
        {
            get
            {
                return 873977640;
            }
        }

        public int Flags { get; set; }
		public bool Save { get; set; }
		public TLAbsDataJSON Data { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Save = (bool)ObjectUtils.DeserializeObject(br);
			Data = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Save, bw);
			ObjectUtils.SerializeObject(Data, bw);
			
        }
    }
}