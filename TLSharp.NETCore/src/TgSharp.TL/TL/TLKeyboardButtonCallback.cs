using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(901503851)]
    public class TLKeyboardButtonCallback : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return 901503851;
            }
        }

        public int Flags { get; set; }
		public bool RequiresPassword { get; set; }
		public string Text { get; set; }
		public byte[] Data { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				RequiresPassword = (bool)ObjectUtils.DeserializeObject(br);
			Text = StringUtil.Deserialize(br);
			Data = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(RequiresPassword, bw);
			StringUtil.Serialize(Text, bw);
			ObjectUtils.SerializeObject(Data, bw);
			
        }
    }
}