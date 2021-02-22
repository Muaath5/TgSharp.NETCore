using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(261416433)]
    public class TLInputMediaPoll : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 261416433;
            }
        }

        public int Flags { get; set; }
		public TLAbsPoll Poll { get; set; }
		public TLVector<byte[]> CorrectAnswers { get; set; }
		public string Solution { get; set; }
		public TLVector<TLAbsMessageEntity> SolutionEntities { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				CorrectAnswers = (TLVector<byte[]>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Solution = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				SolutionEntities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Poll, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(CorrectAnswers, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Solution, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(SolutionEntities, bw);
			
        }
    }
}