using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-392411726)]
    public class TLWebPage : TLAbsWebPage
    {
        public override int Constructor
        {
            get
            {
                return -392411726;
            }
        }

        public int Flags { get; set; }
		public long Id { get; set; }
		public string Url { get; set; }
		public string DisplayUrl { get; set; }
		public int Hash { get; set; }
		public string Type { get; set; }
		public string SiteName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TLAbsPhoto Photo { get; set; }
		public string EmbedUrl { get; set; }
		public string EmbedType { get; set; }
		public int EmbedWidth { get; set; }
		public int EmbedHeight { get; set; }
		public int Duration { get; set; }
		public string Author { get; set; }
		public TLAbsDocument Document { get; set; }
		public TLAbsPage CachedPage { get; set; }
		public TLVector<TLAbsWebPageAttribute> Attributes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Id = br.ReadInt64();
			Url = StringUtil.Deserialize(br);
			DisplayUrl = StringUtil.Deserialize(br);
			Hash = br.ReadInt32();
			if ((Flags & 2) != 0)
				Type = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				SiteName = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Title = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Description = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				EmbedUrl = StringUtil.Deserialize(br);
			if ((Flags & 7) != 0)
				EmbedType = StringUtil.Deserialize(br);
			if ((Flags & 4) != 0)
				EmbedWidth = br.ReadInt32();
			if ((Flags & 4) != 0)
				EmbedHeight = br.ReadInt32();
			if ((Flags & 5) != 0)
				Duration = br.ReadInt32();
			if ((Flags & 10) != 0)
				Author = StringUtil.Deserialize(br);
			if ((Flags & 11) != 0)
				Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				CachedPage = (TLAbsPage)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				Attributes = (TLVector<TLAbsWebPageAttribute>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			StringUtil.Serialize(Url, bw);
			StringUtil.Serialize(DisplayUrl, bw);
			bw.Write(Hash);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Type, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(SiteName, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Title, bw);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(Description, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			if ((Flags & 7) != 0)
	StringUtil.Serialize(EmbedUrl, bw);
			if ((Flags & 7) != 0)
	StringUtil.Serialize(EmbedType, bw);
			if ((Flags & 4) != 0)
	bw.Write(EmbedWidth);
			if ((Flags & 4) != 0)
	bw.Write(EmbedHeight);
			if ((Flags & 5) != 0)
	bw.Write(Duration);
			if ((Flags & 10) != 0)
	StringUtil.Serialize(Author, bw);
			if ((Flags & 11) != 0)
	ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(CachedPage, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(Attributes, bw);
			
        }
    }
}