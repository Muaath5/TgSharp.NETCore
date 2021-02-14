using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(1036054804)]
    public class TLRequestGetRecentMeUrls : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1036054804;
            }
        }

        public string Referer { get; set; }
        public Help.TLRecentMeUrls Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Referer = StringUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Referer, bw);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Help.TLRecentMeUrls)ObjectUtils.DeserializeObject(br);
        }
    }
}
