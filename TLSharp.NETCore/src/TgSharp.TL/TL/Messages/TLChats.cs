using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(1694474197)]
    public class TLChats : TgSharp.TL.Messages.TLAbsChats
    {
        public override int Constructor
        {
            get
            {
                return 1694474197;
            }
        }

        
		public TLVector<TLAbsChat> Chats { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Chats, bw);
			
        }
    }
}