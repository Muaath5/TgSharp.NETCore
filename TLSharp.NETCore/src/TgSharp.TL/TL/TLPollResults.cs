using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1159937629)]
    public class TLPollResults : TLAbsPollResults
    {
        public override int Constructor
        {
            get
            {
                return -1159937629;
            }
        }

        public int Flags { get; set; }
		public bool Min { get; set; }
		public TLVector<TLAbsPollAnswerVoters> Results { get; set; }
		public int TotalVoters { get; set; }
		public TLVector<int> RecentVoters { get; set; }
		public string Solution { get; set; }
		public TLVector<TLAbsMessageEntity> SolutionEntities { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Min = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Results = (TLVector<TLAbsPollAnswerVoters>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				TotalVoters = br.ReadInt32();
			if ((Flags & 1) != 0)
				RecentVoters = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Solution = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				SolutionEntities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Min, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Results, bw);
			if ((Flags & 0) != 0)
	bw.Write(TotalVoters);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(RecentVoters, bw);
			if ((Flags & 6) != 0)
	StringUtil.Serialize(Solution, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(SolutionEntities, bw);
			
        }
    }
}