using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(527021574)]
    public class TLRequestToggleSignatures : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 527021574;
            }
        }

        
		public TLAbsInputChannel Channel { get; set; }
		public TLAbsBool Enabled { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			Enabled = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Channel, bw);
			ObjectUtils.SerializeObject(Enabled, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}