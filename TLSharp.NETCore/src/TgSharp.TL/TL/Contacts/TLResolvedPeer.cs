using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(2131196633)]
    public class TLResolvedPeer : TgSharp.TL.Contacts.TLAbsResolvedPeer
    {
        public override int Constructor
        {
            get
            {
                return 2131196633;
            }
        }

        
		public TLAbsPeer Peer { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}