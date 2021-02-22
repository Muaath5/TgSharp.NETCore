using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(2010127419)]
    public class TLImportedContacts : TgSharp.TL.Contacts.TLAbsImportedContacts
    {
        public override int Constructor
        {
            get
            {
                return 2010127419;
            }
        }

        
		public TLVector<TLAbsImportedContact> Imported { get; set; }
		public TLVector<TLAbsPopularContact> PopularInvites { get; set; }
		public TLVector<long> RetryContacts { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Imported = (TLVector<TLAbsImportedContact>)ObjectUtils.DeserializeObject(br);
			PopularInvites = (TLVector<TLAbsPopularContact>)ObjectUtils.DeserializeObject(br);
			RetryContacts = (TLVector<long>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Imported, bw);
			ObjectUtils.SerializeObject(PopularInvites, bw);
			ObjectUtils.SerializeObject(RetryContacts, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}