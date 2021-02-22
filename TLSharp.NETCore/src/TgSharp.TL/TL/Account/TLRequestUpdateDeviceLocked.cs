using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(954152242)]
    public class TLRequestUpdateDeviceLocked : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 954152242;
            }
        }

        
		public int Period { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Period = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			bw.Write(Period);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}