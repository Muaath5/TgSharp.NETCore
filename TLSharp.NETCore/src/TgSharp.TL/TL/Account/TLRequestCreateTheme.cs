using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-2077048289)]
    public class TLRequestCreateTheme : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2077048289;
            }
        }

        public int Flags { get; set; }
		public string Slug { get; set; }
		public string Title { get; set; }
		public TLAbsInputDocument Document { get; set; }
		public TLAbsInputThemeSettings Settings { get; set; }
		public TLAbsTheme Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			Slug = StringUtil.Deserialize(br);
			Title = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Document = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Settings = (TLAbsInputThemeSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			StringUtil.Serialize(Slug, bw);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Document, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Settings, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsTheme)ObjectUtils.DeserializeObject(br);
        }
    }
}