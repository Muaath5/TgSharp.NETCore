using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(400266251)]
    public class TLBotInlineMediaResult : TLAbsBotInlineResult
    {
        public override int Constructor
        {
            get
            {
                return 400266251;
            }
        }

        public int Flags { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public TLAbsPhoto Photo { get; set; }
		public TLAbsDocument Document { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TLAbsBotInlineMessage SendMessage { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = StringUtil.Deserialize(br);
			Type = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Title = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Description = StringUtil.Deserialize(br);
			SendMessage = (TLAbsBotInlineMessage)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Id, bw);
			StringUtil.Serialize(Type, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Title, bw);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Description, bw);
			ObjectUtils.SerializeObject(SendMessage, bw);
			
        }
    }
}