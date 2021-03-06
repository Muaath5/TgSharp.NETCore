using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-436833542)]
    public class TLRequestSetBotShippingResults : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -436833542;
            }
        }

        public int Flags { get; set; }
		public long QueryId { get; set; }
		public string Error { get; set; }
		public TLVector<TLAbsShippingOption> ShippingOptions { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			QueryId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Error = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				ShippingOptions = (TLVector<TLAbsShippingOption>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			bw.Write(QueryId);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Error, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(ShippingOptions, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}