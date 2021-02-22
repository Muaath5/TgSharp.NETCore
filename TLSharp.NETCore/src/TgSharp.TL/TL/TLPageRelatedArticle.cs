using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1282352120)]
    public class TLPageRelatedArticle : TLAbsPageRelatedArticle
    {
        public override int Constructor
        {
            get
            {
                return -1282352120;
            }
        }

        public int Flags { get; set; }
		public string Url { get; set; }
		public long WebpageId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long PhotoId { get; set; }
		public string Author { get; set; }
		public int PublishedDate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Url = StringUtil.Deserialize(br);
			WebpageId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Title = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				Description = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				PhotoId = br.ReadInt64();
			if ((Flags & 1) != 0)
				Author = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				PublishedDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Url, bw);
			bw.Write(WebpageId);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Title, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(Description, bw);
			if ((Flags & 0) != 0)
	bw.Write(PhotoId);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Author, bw);
			if ((Flags & 6) != 0)
	bw.Write(PublishedDate);
			
        }
    }
}