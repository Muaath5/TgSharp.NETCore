using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-229005301)]
    public class TLPageBlockEmbedPost : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return -229005301;
            }
        }

        public string Url { get; set; }
        public long WebpageId { get; set; }
        public long AuthorPhotoId { get; set; }
        public string Author { get; set; }
        public int Date { get; set; }
        public TLVector<TLAbsPageBlock> Blocks { get; set; }
        public TLPageCaption Caption { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
            WebpageId = br.ReadInt64();
            AuthorPhotoId = br.ReadInt64();
            Author = StringUtil.Deserialize(br);
            Date = br.ReadInt32();
            Blocks = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
            Caption = (TLPageCaption)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Url, bw);
            bw.Write(WebpageId);
            bw.Write(AuthorPhotoId);
            StringUtil.Serialize(Author, bw);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Blocks, bw);
            ObjectUtils.SerializeObject(Caption, bw);
        }
    }
}
