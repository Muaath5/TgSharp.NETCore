using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-712043766)]
    public class TLRequestSetBotCallbackAnswer : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -712043766;
            }
        }

        public int Flags { get; set; }
		public bool Alert { get; set; }
		public long QueryId { get; set; }
		public string Message { get; set; }
		public string Url { get; set; }
		public int CacheTime { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 3) != 0)
				Alert = (bool)ObjectUtils.DeserializeObject(br);
			QueryId = br.ReadInt64();
			if ((Flags & 2) != 0)
				Message = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				Url = StringUtil.Deserialize(br);
			CacheTime = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Alert, bw);
			bw.Write(QueryId);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Message, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Url, bw);
			bw.Write(CacheTime);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}