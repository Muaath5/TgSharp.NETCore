using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2032041631)]
    public class TLPoll : TLAbsPoll
    {
        public override int Constructor
        {
            get
            {
                return -2032041631;
            }
        }

        
		public long Id { get; set; }
		public int Flags { get; set; }
		public bool Closed { get; set; }
		public bool PublicVoters { get; set; }
		public bool MultipleChoice { get; set; }
		public bool Quiz { get; set; }
		public string Question { get; set; }
		public TLVector<TLAbsPollAnswer> Answers { get; set; }
		public int ClosePeriod { get; set; }
		public int CloseDate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
			Flags = br.ReadInt32();
			if ((Flags & 2) != 0)
				Closed = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				PublicVoters = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				MultipleChoice = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Quiz = (bool)ObjectUtils.DeserializeObject(br);
			Question = StringUtil.Deserialize(br);
			Answers = (TLVector<TLAbsPollAnswer>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				ClosePeriod = br.ReadInt32();
			if ((Flags & 7) != 0)
				CloseDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			ObjectUtils.SerializeObject(Flags, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Closed, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(PublicVoters, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(MultipleChoice, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Quiz, bw);
			StringUtil.Serialize(Question, bw);
			ObjectUtils.SerializeObject(Answers, bw);
			if ((Flags & 6) != 0)
	bw.Write(ClosePeriod);
			if ((Flags & 7) != 0)
	bw.Write(CloseDate);
			
        }
    }
}