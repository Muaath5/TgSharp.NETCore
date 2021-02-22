using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(2013922064)]
    public class TLTermsOfService : TgSharp.TL.Help.TLAbsTermsOfService
    {
        public override int Constructor
        {
            get
            {
                return 2013922064;
            }
        }

        public int Flags { get; set; }
		public bool Popup { get; set; }
		public TLAbsDataJSON Id { get; set; }
		public string Text { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public int MinAgeConfirm { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Popup = (bool)ObjectUtils.DeserializeObject(br);
			Id = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			Text = StringUtil.Deserialize(br);
			Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				MinAgeConfirm = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Popup, bw);
			ObjectUtils.SerializeObject(Id, bw);
			StringUtil.Serialize(Text, bw);
			ObjectUtils.SerializeObject(Entities, bw);
			if ((Flags & 3) != 0)
	bw.Write(MinAgeConfirm);
			
        }
    }
}