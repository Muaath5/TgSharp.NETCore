using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-229175188)]
    public class TLRequestSaveTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -229175188;
            }
        }

        
		public TLAbsInputTheme Theme { get; set; }
		public TLAbsBool Unsave { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Theme = (TLAbsInputTheme)ObjectUtils.DeserializeObject(br);
			Unsave = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Theme, bw);
			ObjectUtils.SerializeObject(Unsave, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}