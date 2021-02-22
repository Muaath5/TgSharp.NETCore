using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(482797855)]
    public class TLInputSingleMedia : TLAbsInputSingleMedia
    {
        public override int Constructor
        {
            get
            {
                return 482797855;
            }
        }

        public int Flags { get; set; }
		public TLAbsInputMedia Media { get; set; }
		public long RandomId { get; set; }
		public string Message { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Media = (TLAbsInputMedia)ObjectUtils.DeserializeObject(br);
			RandomId = br.ReadInt64();
			Message = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Media, bw);
			bw.Write(RandomId);
			StringUtil.Serialize(Message, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Entities, bw);
			
        }
    }
}