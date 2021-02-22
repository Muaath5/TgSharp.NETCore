using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1144565411)]
    public class TLKeyboardButtonRequestPoll : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return -1144565411;
            }
        }

        public int Flags { get; set; }
		public TLAbsBool Quiz { get; set; }
		public string Text { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Quiz = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			Text = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Quiz, bw);
			StringUtil.Serialize(Text, bw);
			
        }
    }
}