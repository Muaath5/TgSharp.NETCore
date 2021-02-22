using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(-1290580579)]
    public class TLFound : TgSharp.TL.Contacts.TLAbsFound
    {
        public override int Constructor
        {
            get
            {
                return -1290580579;
            }
        }

        
		public TLVector<TLAbsPeer> MyResults { get; set; }
		public TLVector<TLAbsPeer> Results { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MyResults = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeObject(br);
			Results = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(MyResults, bw);
			ObjectUtils.SerializeObject(Results, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}