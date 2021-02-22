using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(497489295)]
    public class TLAppUpdate : TgSharp.TL.Help.TLAbsAppUpdate
    {
        public override int Constructor
        {
            get
            {
                return 497489295;
            }
        }

        public int Flags { get; set; }
		public bool CanNotSkip { get; set; }
		public int Id { get; set; }
		public string Version { get; set; }
		public string Text { get; set; }
		public TLVector<TLAbsMessageEntity> Entities { get; set; }
		public TLAbsDocument Document { get; set; }
		public string Url { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				CanNotSkip = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			Version = StringUtil.Deserialize(br);
			Text = StringUtil.Deserialize(br);
			Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Url = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(CanNotSkip, bw);
			bw.Write(Id);
			StringUtil.Serialize(Version, bw);
			StringUtil.Serialize(Text, bw);
			ObjectUtils.SerializeObject(Entities, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Url, bw);
			
        }
    }
}