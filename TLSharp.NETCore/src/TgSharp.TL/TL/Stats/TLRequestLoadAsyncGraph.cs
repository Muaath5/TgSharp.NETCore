using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stats
{
    [TLObject(1646092192)]
    public class TLRequestLoadAsyncGraph : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1646092192;
            }
        }

        public int Flags { get; set; }
		public string Token { get; set; }
		public long X { get; set; }
		public TLAbsStatsGraph Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Token = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				X = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			StringUtil.Serialize(Token, bw);
			if ((Flags & 2) != 0)
	bw.Write(X);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
        }
    }
}