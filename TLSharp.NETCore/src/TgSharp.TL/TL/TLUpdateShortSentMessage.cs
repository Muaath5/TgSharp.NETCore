using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(301019932)]
    public class TLUpdateShortSentMessage : TLAbsUpdates
    {
        public override int Constructor
        {
            get
            {
                return 301019932;
            }
        }

        public int Flags { get; set; }
		public bool Out { get; set; }
		public int Id { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }
		public int Date { get; set; }
		public TLAbsMessageMedia Media { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Out = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			Pts = br.ReadInt32();
			PtsCount = br.ReadInt32();
			Date = br.ReadInt32();
			if ((Flags & 11) != 0)
				Media = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Out, bw);
			bw.Write(Id);
			bw.Write(Pts);
			bw.Write(PtsCount);
			bw.Write(Date);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(Media, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			
        }
    }
}