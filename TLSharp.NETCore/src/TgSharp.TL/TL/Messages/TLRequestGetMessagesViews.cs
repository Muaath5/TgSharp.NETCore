using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1468322785)]
    public class TLRequestGetMessagesViews : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1468322785;
            }
        }

        
		public TLAbsInputPeer Peer { get; set; }
		public TLVector<int> Id { get; set; }
		public TLAbsBool Increment { get; set; }
		public Messages.TLAbsMessageViews Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
			Id = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			Increment = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(Id, bw);
			ObjectUtils.SerializeObject(Increment, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsMessageViews)ObjectUtils.DeserializeObject(br);
        }
    }
}