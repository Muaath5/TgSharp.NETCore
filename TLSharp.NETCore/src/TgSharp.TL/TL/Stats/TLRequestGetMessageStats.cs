using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stats
{
    [TLObject(-1226791947)]
    public class TLRequestGetMessageStats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1226791947;
            }
        }

        public int Flags { get; set; }
		public bool Dark { get; set; }
		public TLAbsInputChannel Channel { get; set; }
		public int MsgId { get; set; }
		public Stats.TLAbsMessageStats Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			MsgId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			ObjectUtils.SerializeObject(Channel, bw);
			bw.Write(MsgId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Stats.TLAbsMessageStats)ObjectUtils.DeserializeObject(br);
        }
    }
}