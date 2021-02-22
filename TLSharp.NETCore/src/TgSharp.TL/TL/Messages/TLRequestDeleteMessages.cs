using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-443640366)]
    public class TLRequestDeleteMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -443640366;
            }
        }

        public int Flags { get; set; }
		public bool Revoke { get; set; }
		public TLVector<int> Id { get; set; }
		public Messages.TLAbsAffectedMessages Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Revoke = (bool)ObjectUtils.DeserializeObject(br);
			Id = (TLVector<int>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Revoke, bw);
			ObjectUtils.SerializeObject(Id, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsAffectedMessages)ObjectUtils.DeserializeObject(br);
        }
    }
}