using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(958863608)]
    public class TLRequestSaveRecentSticker : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 958863608;
            }
        }

        public int Flags { get; set; }
		public bool Attached { get; set; }
		public TLAbsInputDocument Id { get; set; }
		public TLAbsBool Unsave { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Attached = (bool)ObjectUtils.DeserializeObject(br);
			Id = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);
			Unsave = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Attached, bw);
			ObjectUtils.SerializeObject(Id, bw);
			ObjectUtils.SerializeObject(Unsave, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}