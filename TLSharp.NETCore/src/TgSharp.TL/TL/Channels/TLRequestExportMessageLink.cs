using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(-432034325)]
    public class TLRequestExportMessageLink : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -432034325;
            }
        }

        public int Flags { get; set; }
		public bool Grouped { get; set; }
		public bool Thread { get; set; }
		public TLAbsInputChannel Channel { get; set; }
		public int Id { get; set; }
		public TLAbsExportedMessageLink Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Grouped = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Thread = (bool)ObjectUtils.DeserializeObject(br);
			Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Grouped, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Thread, bw);
			ObjectUtils.SerializeObject(Channel, bw);
			bw.Write(Id);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsExportedMessageLink)ObjectUtils.DeserializeObject(br);
        }
    }
}