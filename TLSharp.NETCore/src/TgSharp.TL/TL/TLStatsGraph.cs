using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1901828938)]
    public class TLStatsGraph : TLAbsStatsGraph
    {
        public override int Constructor
        {
            get
            {
                return -1901828938;
            }
        }

        public int Flags { get; set; }
		public TLAbsDataJSON Json { get; set; }
		public string ZoomToken { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Json = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				ZoomToken = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Json, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(ZoomToken, bw);
			
        }
    }
}