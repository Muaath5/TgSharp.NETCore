using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-2000710887)]
    public class TLInputBotInlineResult : TLAbsInputBotInlineResult
    {
        public override int Constructor
        {
            get
            {
                return -2000710887;
            }
        }

        public int Flags { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public TLAbsInputWebDocument Thumb { get; set; }
		public TLAbsInputWebDocument Content { get; set; }
		public TLAbsInputBotInlineMessage SendMessage { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = StringUtil.Deserialize(br);
			Type = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Title = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Description = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Url = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				Thumb = (TLAbsInputWebDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Content = (TLAbsInputWebDocument)ObjectUtils.DeserializeObject(br);
			SendMessage = (TLAbsInputBotInlineMessage)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Id, bw);
			StringUtil.Serialize(Type, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Title, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Description, bw);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Url, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Thumb, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Content, bw);
			ObjectUtils.SerializeObject(SendMessage, bw);
			
        }
    }
}