using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-2127811866)]
    public class TLRequestGetStatsURL : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2127811866;
            }
        }

        public int Flags { get; set; }
		public bool Dark { get; set; }
		public TLAbsInputPeer Peer { get; set; }
		public string Params { get; set; }
		public TLAbsStatsURL Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Dark = (bool)ObjectUtils.DeserializeObject(br);
			Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Params = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Dark, bw);
			ObjectUtils.SerializeObject(Peer, bw);
			StringUtil.Serialize(Params, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsStatsURL)ObjectUtils.DeserializeObject(br);
        }
    }
}