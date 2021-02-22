using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1817860919)]
    public class TLRequestSaveWallPaper : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1817860919;
            }
        }

        
		public TLAbsInputWallPaper Wallpaper { get; set; }
		public TLAbsBool Unsave { get; set; }
		public TLAbsWallPaperSettings Settings { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Wallpaper = (TLAbsInputWallPaper)ObjectUtils.DeserializeObject(br);
			Unsave = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			Settings = (TLAbsWallPaperSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Wallpaper, bw);
			ObjectUtils.SerializeObject(Unsave, bw);
			ObjectUtils.SerializeObject(Settings, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}