using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(90744648)]
    public class TLKeyboardButtonSwitchInline : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return 90744648;
            }
        }

        public int Flags { get; set; }
		public bool SamePeer { get; set; }
		public string Text { get; set; }
		public string Query { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				SamePeer = (bool)ObjectUtils.DeserializeObject(br);
			Text = StringUtil.Deserialize(br);
			Query = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(SamePeer, bw);
			StringUtil.Serialize(Text, bw);
			StringUtil.Serialize(Query, bw);
			
        }
    }
}