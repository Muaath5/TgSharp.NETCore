using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(911761060)]
    public class TLBotCallbackAnswer : TgSharp.TL.Messages.TLAbsBotCallbackAnswer
    {
        public override int Constructor
        {
            get
            {
                return 911761060;
            }
        }

        public int Flags { get; set; }
		public bool Alert { get; set; }
		public bool HasUrl { get; set; }
		public bool NativeUi { get; set; }
		public string Message { get; set; }
		public string Url { get; set; }
		public int CacheTime { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 3) != 0)
				Alert = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				HasUrl = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				NativeUi = (bool)ObjectUtils.DeserializeObject(br);
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
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(HasUrl, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(NativeUi, bw);
			if ((Flags & 2) != 0)
	StringUtil.Serialize(Message, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(Url, bw);
			bw.Write(CacheTime);
			
        }
    }
}