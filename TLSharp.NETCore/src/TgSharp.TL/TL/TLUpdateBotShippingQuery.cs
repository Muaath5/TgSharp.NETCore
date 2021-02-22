using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-523384512)]
    public class TLUpdateBotShippingQuery : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -523384512;
            }
        }

        
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public byte[] Payload { get; set; }
		public TLAbsPostAddress ShippingAddress { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            QueryId = br.ReadInt64();
			UserId = br.ReadInt32();
			Payload = (byte[])ObjectUtils.DeserializeObject(br);
			ShippingAddress = (TLAbsPostAddress)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(QueryId);
			bw.Write(UserId);
			ObjectUtils.SerializeObject(Payload, bw);
			ObjectUtils.SerializeObject(ShippingAddress, bw);
			
        }
    }
}