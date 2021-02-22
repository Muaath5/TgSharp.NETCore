using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1028140917)]
    public class TLRequestSearchStickerSets : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1028140917;
            }
        }

        public int Flags { get; set; }
		public bool ExcludeFeatured { get; set; }
		public string Q { get; set; }
		public int Hash { get; set; }
		public Messages.TLAbsFoundStickerSets Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				ExcludeFeatured = (bool)ObjectUtils.DeserializeObject(br);
			Q = StringUtil.Deserialize(br);
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ExcludeFeatured, bw);
			StringUtil.Serialize(Q, bw);
			bw.Write(Hash);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsFoundStickerSets)ObjectUtils.DeserializeObject(br);
        }
    }
}