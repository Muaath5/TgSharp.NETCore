using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1494368259)]
    public class TLInputBotInlineMessageMediaContact : TLAbsInputBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return -1494368259;
            }
        }

        public int Flags { get; set; }
		public string PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Vcard { get; set; }
		public TLAbsReplyMarkup ReplyMarkup { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();PhoneNumber = StringUtil.Deserialize(br);
			FirstName = StringUtil.Deserialize(br);
			LastName = StringUtil.Deserialize(br);
			Vcard = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber, bw);
			StringUtil.Serialize(FirstName, bw);
			StringUtil.Serialize(LastName, bw);
			StringUtil.Serialize(Vcard, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReplyMarkup, bw);
			
        }
    }
}