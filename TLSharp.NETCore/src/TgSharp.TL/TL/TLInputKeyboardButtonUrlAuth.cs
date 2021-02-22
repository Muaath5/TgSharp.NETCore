using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-802258988)]
    public class TLInputKeyboardButtonUrlAuth : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return -802258988;
            }
        }

        public int Flags { get; set; }
		public bool RequestWriteAccess { get; set; }
		public string Text { get; set; }
		public string FwdText { get; set; }
		public string Url { get; set; }
		public TLAbsInputUser Bot { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				RequestWriteAccess = (bool)ObjectUtils.DeserializeObject(br);
			Text = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				FwdText = StringUtil.Deserialize(br);
			Url = StringUtil.Deserialize(br);
			Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(RequestWriteAccess, bw);
			StringUtil.Serialize(Text, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(FwdText, bw);
			StringUtil.Serialize(Url, bw);
			ObjectUtils.SerializeObject(Bot, bw);
			
        }
    }
}