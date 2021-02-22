using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1634294960)]
    public class TLChatInvitePeek : TLAbsChatInvite
    {
        public override int Constructor
        {
            get
            {
                return 1634294960;
            }
        }

        
		public TLAbsChat Chat { get; set; }
		public int Expires { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Chat = (TLAbsChat)ObjectUtils.DeserializeObject(br);
			Expires = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Chat, bw);
			bw.Write(Expires);
			
        }
    }
}