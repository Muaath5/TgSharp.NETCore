using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(363700068)]
    public class TLRequestSetInlineGameScore : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 363700068;
            }
        }

        public int Flags { get; set; }
		public bool EditMessage { get; set; }
		public bool Force { get; set; }
		public TLAbsInputBotInlineMessageID Id { get; set; }
		public TLAbsInputUser UserId { get; set; }
		public int Score { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				EditMessage = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Force = (bool)ObjectUtils.DeserializeObject(br);
			Id = (TLAbsInputBotInlineMessageID)ObjectUtils.DeserializeObject(br);
			UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
			Score = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(EditMessage, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Force, bw);
			ObjectUtils.SerializeObject(Id, bw);
			ObjectUtils.SerializeObject(UserId, bw);
			bw.Write(Score);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}