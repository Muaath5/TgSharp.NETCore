using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(163765653)]
    public class TLRequestSetBotPrecheckoutResults : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 163765653;
            }
        }

        public int Flags { get; set; }
		public bool Success { get; set; }
		public long QueryId { get; set; }
		public string Error { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				Success = (bool)ObjectUtils.DeserializeObject(br);
			QueryId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Error = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Success, bw);
			bw.Write(QueryId);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Error, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}