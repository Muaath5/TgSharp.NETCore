using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(698914348)]
    public class TLRequestBlockFromReplies : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 698914348;
            }
        }

        public int Flags { get; set; }
		public bool DeleteMessage { get; set; }
		public bool DeleteHistory { get; set; }
		public bool ReportSpam { get; set; }
		public int MsgId { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				DeleteMessage = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				DeleteHistory = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReportSpam = (bool)ObjectUtils.DeserializeObject(br);
			MsgId = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(DeleteMessage, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(DeleteHistory, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReportSpam, bw);
			bw.Write(MsgId);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}